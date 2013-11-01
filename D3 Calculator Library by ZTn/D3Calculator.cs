using System.Collections.Generic;
using System.Linq;
using ZTn.BNet.D3.Calculator.Helpers;
using ZTn.BNet.D3.Calculator.Skills;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.HeroFollowers;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    public class D3Calculator
    {
        #region >> Fields

        public HeroClass heroClass;
        public int heroLevel;

        public StatsItem heroStatsItem;

        ItemAttributes levelAttributes;
        ItemAttributes paragonLevelAttributes;

        #endregion

        #region >> Constants

        public static readonly Item nakedHandWeapon = new Item(new ItemAttributes() { attacksPerSecondItem = ItemValueRange.One });

        public static readonly Item blankWeapon = new Item(new ItemAttributes() { });

        readonly string[] damagePrefixes = new string[] { 
            "damageMin_", "damageBonusMin_",
            "damageDelta_", 
            "damageWeaponMin_", "damageWeaponBonusMin_",
            "damageWeaponDelta_", "damageWeaponBonusDelta_"
        };

        readonly string[] damageResists = new string[] {
            "Arcane", "Cold", "Fire", "Holy", "Lightning", "Physical", "Poison"
        };

        #endregion

        #region >> Constructors

        public D3Calculator(Hero hero, Item mainHand, Item offHand, IEnumerable<Item> items)
        {
            this.heroClass = hero.heroClass;
            this.heroLevel = hero.level;

            // Build unique item equivalent to items worn
            heroStatsItem = new StatsItem(mainHand, offHand, items);

            levelAttributes = new Heroes.ItemAttributesFromLevel(hero);
            paragonLevelAttributes = new Heroes.ItemAttributesFromParagonLevel(hero);

            update();
        }

        public D3Calculator(Follower follower, HeroClass heroClass, Item mainHand, Item offHand, IEnumerable<Item> items)
        {
            this.heroClass = heroClass;
            this.heroLevel = follower.level;

            foreach (Item item in items.Union(new List<Item>() { mainHand, offHand }))
            {
                applyFollowersBonusMalusOnItem(item, heroClass);
                if (item.gems != null)
                {
                    for (int i = 0; i < item.gems.Count(); i++)
                    {
                        Item gemItem = new Item()
                       {
                           id = item.gems[i].item.id,
                           attributes = item.gems[i].attributes,
                           attributesRaw = new ItemAttributes(item.gems[i].attributesRaw),
                           name = item.gems[i].item.name,
                           icon = item.gems[i].item.icon
                       };
                        item.gems[i] = new SocketedGem(applyFollowersBonusMalusOnItem(gemItem, heroClass));
                    }
                }
            }

            // Build unique item equivalent to items worn
            heroStatsItem = new StatsItem(mainHand, offHand, items);

            levelAttributes = new Followers.ItemAttributesFromLevel(follower, heroClass);

            update();
        }

        #endregion

        private Item applyFollowersBonusMalusOnItem(Item item, HeroClass heroClass)
        {
            double damagePercent = 1;
            switch (heroClass)
            {
                case HeroClass.EnchantressFollower:
                    damagePercent = 0.20;
                    break;
                case HeroClass.ScoundrelFollower:
                    damagePercent = 0.25;
                    break;
                case HeroClass.TemplarFollower:
                    damagePercent = 0.15;
                    break;
                default:
                    break;
            }

            ItemAttributes attr = item.attributesRaw;
            attr.dexterityItem *= 2.5;
            attr.intelligenceItem *= 2.5;
            attr.strengthItem *= 2.5;
            attr.vitalityItem *= 2.5;

            foreach (string resist in damageResists)
            {
                foreach (string damage in damagePrefixes)
                {
                    ItemValueRange value = attr.getAttributeByName(damage + resist);
                    attr.setAttributeByName(damage + resist, damagePercent * value);
                }
            }

            return item;
        }

        /// <summary>
        /// Return damage multiplier when the non critical hit (normal)
        /// </summary>
        /// <returns></returns>
        public double getDamageMultiplierNormal()
        {
            double multiplier = 1;

            // Update dps with main statistic
            multiplier *= 1 + getMainCharacteristic().min / 100;

            return multiplier;
        }

        /// <summary>
        /// Return damage multiplier for critical hit
        /// </summary>
        /// <returns></returns>
        public double getDamageMultiplierCritic()
        {
            double multiplier = 1;

            // Update dps with Critic
            double critDamagePercent = 0;
            if (heroStatsItem.attributesRaw.critDamagePercent != null)
                critDamagePercent += heroStatsItem.attributesRaw.critDamagePercent.min;
            multiplier *= 1 + critDamagePercent;

            // Update dps with main statistic
            multiplier *= 1 + getMainCharacteristic().min / 100;

            return multiplier;
        }

        /// <summary>
        /// Return average damage multiplier (taking care of critical and normal hits)
        /// </summary>
        /// <returns></returns>
        public ItemValueRange getDamageMultiplier()
        {
            ItemValueRange multiplier = ItemValueRange.One;

            // Update dps with Critic
            ItemValueRange critPercentBonusCapped = ItemValueRange.Zero;
            if (heroStatsItem.attributesRaw.critPercentBonusCapped != null)
                critPercentBonusCapped += heroStatsItem.attributesRaw.critPercentBonusCapped;
            ItemValueRange critDamagePercent = ItemValueRange.Zero;
            if (heroStatsItem.attributesRaw.critDamagePercent != null)
                critDamagePercent += heroStatsItem.attributesRaw.critDamagePercent;
            multiplier *= ItemValueRange.One + critPercentBonusCapped * critDamagePercent;

            // Update dps with main statistic
            ItemValueRange characteristic = getMainCharacteristic();
            multiplier *= ItemValueRange.One + characteristic / 100.0;

            return multiplier;
        }

        public ItemValueRange getActualAttackSpeed()
        {
            ItemValueRange multiplier = ItemValueRange.One;

            // Update malusMultiplier with Weapon Attack Speed
            multiplier *= heroStatsItem.getWeaponAttackPerSecond();

            return multiplier;
        }

        public ItemValueRange getHeroArmor()
        {
            ItemValueRange armor = ItemValueRange.Zero;

            // Update with base items armor
            armor += heroStatsItem.attributesRaw.armorItem;

            // Update with items bonus armor
            armor += heroStatsItem.attributesRaw.armorBonusItem;

            // Update with strength bonus
            armor += getHeroStrength();

            return armor;
        }

        public double getHeroDamageReduction_Armor(int mobLevel)
        {
            double armor = getHeroArmor().min;

            return armor / (armor + 50 * mobLevel);
        }

        public double getHeroDamageReduction(int mobLevel, string resist)
        {
            double resistance = getHeroResistance(resist).min;

            return resistance / (resistance + 5 * mobLevel);
        }

        public double getHeroDodge()
        {
            double dogde = 0;
            double dexterity = getHeroDexterity().min;

            double dex0_100 = (dexterity > 100 ? 100 : dexterity);
            double dex101_500 = (dexterity > 500 ? 500 - 100 : (dexterity > 100 ? dexterity - 100 : 0));
            double dex501_1000 = (dexterity > 1000 ? 1000 - 500 : (dexterity > 500 ? dexterity - 500 : 0));
            double dex1001_8000 = (dexterity > 8000 ? 8000 - 1000 : (dexterity > 1000 ? dexterity - 1000 : 0));

            dogde = 0.100 * dex0_100 + 0.025 * dex101_500 + 0.020 * dex501_1000 + 0.010 * dex1001_8000;

            return dogde;
        }

        private ItemValueRange getHeroDPSAsIs()
        {
            ItemValueRange dps = heroStatsItem.getWeaponDamage();

            // Update Damage Multiplier
            dps *= getDamageMultiplier();

            // Update Attack Speed Multiplier
            dps *= getActualAttackSpeed();

            return dps;
        }

        public ItemValueRange getHeroDPS()
        {
            return getHeroDPS(new List<ID3SkillModifier>(), new List<ID3SkillModifier>());
        }

        public ItemValueRange getHeroDPS(IEnumerable<ID3SkillModifier> passives, IEnumerable<ID3SkillModifier> actives)
        {
            ItemAttributes itemAttributes = new ItemAttributes();

            heroStatsItem.setLevelBonus(levelAttributes);
            heroStatsItem.setParagonLevelBonus(paragonLevelAttributes);

            update();

            // Build passive bonuses
            foreach (ID3SkillModifier modifier in passives)
            {
                itemAttributes += modifier.getBonus(this);
            }

            // Compute the new unique item state with passives
            update();

            // Build active bonuses
            foreach (ID3SkillModifier modifier in actives)
            {
                itemAttributes += modifier.getBonus(this);
            }

            // Finally, return the dps
            return getHeroDPS(itemAttributes);
        }

        public ItemValueRange getHeroDPS(ItemAttributes addedBonus)
        {
            heroStatsItem.setLevelBonus(levelAttributes);
            heroStatsItem.setParagonLevelBonus(paragonLevelAttributes);
            heroStatsItem.setSkillsBonus(addedBonus);
            update();

            return getHeroDPSAsIs();
        }

        public double getHeroEffectiveHitpoints(int mobLevel)
        {
            double ehp = getHeroHitpoints().min;

            // Update with armor reduction
            ehp /= (1 - getHeroDamageReduction_Armor(mobLevel));

            // Update with lowest resistance reduction
            double resistance = getHeroDamageReduction(mobLevel, "Arcane");
            if (getHeroDamageReduction(mobLevel, "Cold") < resistance) resistance = getHeroDamageReduction(mobLevel, "Cold");
            if (getHeroDamageReduction(mobLevel, "Fire") < resistance) resistance = getHeroDamageReduction(mobLevel, "Fire");
            if (getHeroDamageReduction(mobLevel, "Lightning") < resistance) resistance = getHeroDamageReduction(mobLevel, "Lightning");
            if (getHeroDamageReduction(mobLevel, "Physical") < resistance) resistance = getHeroDamageReduction(mobLevel, "Physical");
            if (getHeroDamageReduction(mobLevel, "Poison") < resistance) resistance = getHeroDamageReduction(mobLevel, "Poison");
            ehp /= (1 - resistance);

            // Update with class reduction
            if ((heroClass == HeroClass.Monk) || (heroClass == HeroClass.Barbarian))
                ehp /= (1 - 0.30);

            return ehp;
        }

        public ItemValueRange getHeroHitpoints()
        {
            // Use hitpoints formula
            ItemValueRange hitpoints;

            switch (heroClass)
            {
                case HeroClass.Barbarian:
                case HeroClass.DemonHunter:
                case HeroClass.Monk:
                case HeroClass.WitchDoctor:
                case HeroClass.Wizard:
                    if (heroLevel < 35)
                        hitpoints = 36 + 4 * heroLevel + 10 * getHeroVitality();
                    else
                        hitpoints = 36 + 4 * heroLevel + (heroLevel - 25) * getHeroVitality();
                    break;
                case HeroClass.EnchantressFollower:
                case HeroClass.ScoundrelFollower:
                    // Missing leveling
                    hitpoints = 6219 + 35 * getHeroVitality();
                    break;
                case HeroClass.TemplarFollower:
                    // Missing leveling
                    hitpoints = 7752 + 35 * getHeroVitality();
                    break;
                default:
                    hitpoints = ItemValueRange.Zero;
                    break;
            }

            // Update with +% Life bonus
            if (heroStatsItem.attributesRaw.hitpointsMaxPercentBonusItem != null)
                hitpoints *= 1 + heroStatsItem.attributesRaw.hitpointsMaxPercentBonusItem.min;

            return hitpoints;
        }

        public ItemValueRange getHeroResistance_All()
        {
            ItemValueRange resist = ItemValueRange.Zero;

            resist += heroStatsItem.getResistance("All");

            // Update with intelligence bonus
            resist += getHeroIntelligence() / 10;

            return resist;
        }

        public ItemValueRange getHeroResistance(string resist)
        {
            ItemValueRange resistance = getHeroResistance_All();

            resistance += heroStatsItem.getResistance(resist);

            return resistance;
        }

        public ItemValueRange getHeroDexterity()
        {
            return heroStatsItem.attributesRaw.dexterityItem;
        }

        public ItemValueRange getHeroIntelligence()
        {
            return heroStatsItem.attributesRaw.intelligenceItem;
        }

        public ItemValueRange getHeroStrength()
        {
            return heroStatsItem.attributesRaw.strengthItem;
        }

        public ItemValueRange getHeroVitality()
        {
            return heroStatsItem.attributesRaw.vitalityItem;
        }

        public ItemValueRange getMainCharacteristic()
        {
            ItemValueRange result = ItemValueRange.Zero;

            switch (heroClass)
            {
                case HeroClass.Monk:
                case HeroClass.DemonHunter:
                case HeroClass.ScoundrelFollower:
                    if (heroStatsItem.attributesRaw.dexterityItem != null)
                        result = heroStatsItem.attributesRaw.dexterityItem;
                    break;
                case HeroClass.WitchDoctor:
                case HeroClass.Wizard:
                case HeroClass.EnchantressFollower:
                    if (heroStatsItem.attributesRaw.intelligenceItem != null)
                        result = heroStatsItem.attributesRaw.intelligenceItem;
                    break;
                case HeroClass.Barbarian:
                case HeroClass.TemplarFollower:
                    if (heroStatsItem.attributesRaw.strengthItem != null)
                        result = heroStatsItem.attributesRaw.strengthItem;
                    break;
                default:
                    break;
            }

            return result;
        }

        public void update()
        {
            heroStatsItem.update();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using ZTn.BNet.D3.Calculator.Helpers;
using ZTn.BNet.D3.Calculator.Heroes;
using ZTn.BNet.D3.Calculator.Skills;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.HeroFollowers;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    public class D3Calculator
    {
        #region >> Fields

        public HeroClass HeroClass;
        public int HeroLevel;

        public StatsItem HeroStatsItem;

        private readonly ItemAttributes levelAttributes;
        private readonly ItemAttributes paragonLevelAttributes;

        #endregion

        #region >> Constants

        readonly string[] damagePrefixes =
        { 
            "damageMin_", "damageBonusMin_",
            "damageDelta_",
            "damageWeaponBonusMinX1_",
            "damageWeaponMin_", "damageWeaponBonusMin_",
            "damageWeaponDelta_", "damageWeaponBonusDelta_"
        };

        readonly string[] damageResists =
        {
            "Arcane", "Cold", "Fire", "Holy", "Lightning", "Physical", "Poison"
        };

        #endregion

        public static Item NakedHandWeapon
        {
            get
            {
                return new Item(new ItemAttributes { attacksPerSecondItem = ItemValueRange.One });
            }
        }

        public static Item BlankWeapon
        {
            get
            {
                return new Item(new ItemAttributes());
            }
        }

        #region >> Constructors

        public D3Calculator(Hero hero, Item mainHand, Item offHand, IEnumerable<Item> items)
        {
            HeroClass = hero.heroClass;
            HeroLevel = hero.level;

            // Build unique item equivalent to items worn
            HeroStatsItem = new StatsItem(mainHand, offHand, items);

            levelAttributes = new ItemAttributesFromLevel(hero);
            paragonLevelAttributes = new ItemAttributesFromParagonLevel(hero);

            Update();
        }

        public D3Calculator(Follower follower, HeroClass heroClass, Item mainHand, Item offHand, IEnumerable<Item> items)
        {
            HeroClass = heroClass;
            HeroLevel = follower.level;

            foreach (var item in items.Union(new[] { mainHand, offHand }))
            {
                ApplyFollowersBonusMalusOnItemAttributes(item.attributesRaw, heroClass);
                if (item.gems != null)
                {
                    foreach (var gem in item.gems)
                        ApplyFollowersBonusMalusOnItemAttributes(gem.attributesRaw, heroClass);
                }
            }

            // Build unique item equivalent to items worn
            HeroStatsItem = new StatsItem(mainHand, offHand, items);

            levelAttributes = new Followers.ItemAttributesFromLevel(follower, heroClass);

            Update();
        }

        #endregion

        private void ApplyFollowersBonusMalusOnItemAttributes(ItemAttributes itemAttributes, HeroClass heroClass)
        {
            double damagePercent;
            switch (heroClass)
            {
                case HeroClass.EnchantressFollower:
                    damagePercent = 0.20;
                    break;
                case HeroClass.ScoundrelFollower:
                    damagePercent = 0.40;
                    break;
                case HeroClass.TemplarFollower:
                    damagePercent = 0.15;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("This class " + heroClass + " is not a follower");
            }

            itemAttributes.dexterityItem *= 2.5;
            itemAttributes.intelligenceItem *= 2.5;
            itemAttributes.strengthItem *= 2.5;
            itemAttributes.vitalityItem *= 2.5;

            foreach (var resist in damageResists)
            {
                foreach (var damage in damagePrefixes)
                {
                    var value = itemAttributes.GetAttributeByName(damage + resist);
                    itemAttributes.SetAttributeByName(damage + resist, damagePercent * value);
                }
            }
        }

        /// <summary>
        /// Return damage multiplier when the non critical hit (normal)
        /// </summary>
        /// <returns></returns>
        public double GetDamageMultiplierNormal()
        {
            double multiplier = 1;

            // Update dps with main statistic
            multiplier *= 1 + GetMainCharacteristic().Min / 100;

            return multiplier;
        }

        /// <summary>
        /// Return damage multiplier for critical hit
        /// </summary>
        /// <returns></returns>
        public double GetDamageMultiplierCritic()
        {
            double multiplier = 1;

            // Update dps with Critic
            double critDamagePercent = 0;
            if (HeroStatsItem.attributesRaw.critDamagePercent != null)
                critDamagePercent += HeroStatsItem.attributesRaw.critDamagePercent.Min;
            multiplier *= 1 + critDamagePercent;

            // Update dps with main statistic
            multiplier *= 1 + GetMainCharacteristic().Min / 100;

            return multiplier;
        }

        /// <summary>
        /// Return average damage multiplier (taking care of critical and normal hits)
        /// </summary>
        /// <returns></returns>
        public ItemValueRange GetDamageMultiplier()
        {
            var multiplier = ItemValueRange.One;

            // Update dps with Critic
            var critPercentBonusCapped = ItemValueRange.Zero;
            if (HeroStatsItem.attributesRaw.critPercentBonusCapped != null)
                critPercentBonusCapped += HeroStatsItem.attributesRaw.critPercentBonusCapped;
            var critDamagePercent = ItemValueRange.Zero;
            if (HeroStatsItem.attributesRaw.critDamagePercent != null)
                critDamagePercent += HeroStatsItem.attributesRaw.critDamagePercent;
            multiplier *= ItemValueRange.One + critPercentBonusCapped * critDamagePercent;

            // Update dps with main statistic
            var characteristic = GetMainCharacteristic();
            multiplier *= ItemValueRange.One + characteristic / 100.0;

            return multiplier;
        }

        public ItemValueRange GetActualAttackSpeed()
        {
            var multiplier = ItemValueRange.One;

            // Update malusMultiplier with Weapon Attack Speed
            multiplier *= HeroStatsItem.GetWeaponAttackPerSecond();

            return multiplier;
        }

        public ItemValueRange GetHeroArmor()
        {
            var armor = ItemValueRange.Zero;

            // Update with base items armor
            armor += HeroStatsItem.attributesRaw.armorItem;

            // Update with items bonus armor
            armor += HeroStatsItem.attributesRaw.armorBonusItem;

            // Update with strength bonus
            armor += GetHeroStrength();

            return armor;
        }

        public double GetHeroDamageReduction_Armor(int mobLevel)
        {
            var armor = GetHeroArmor().Min;

            return armor / (armor + 50 * mobLevel);
        }

        public double GetHeroDamageReduction(int mobLevel, string resist)
        {
            var resistance = GetHeroResistance(resist).Min;

            return resistance / (resistance + 5 * mobLevel);
        }

        public double GetHeroDodge()
        {
            var dexterity = GetHeroDexterity().Min;

            var dex0To100 = (dexterity > 100 ? 100 : dexterity);
            var dex101To500 = (dexterity > 500 ? 500 - 100 : (dexterity > 100 ? dexterity - 100 : 0));
            var dex501To1000 = (dexterity > 1000 ? 1000 - 500 : (dexterity > 500 ? dexterity - 500 : 0));
            var dex1001To8000 = (dexterity > 8000 ? 8000 - 1000 : (dexterity > 1000 ? dexterity - 1000 : 0));

            var dogde = 0.100 * dex0To100 + 0.025 * dex101To500 + 0.020 * dex501To1000 + 0.010 * dex1001To8000;

            return dogde;
        }

        private ItemValueRange GetHeroDpsAsIs()
        {
            var dps = HeroStatsItem.GetWeaponDamage();

            // Update Damage Multiplier
            dps *= GetDamageMultiplier();

            // Update Attack Speed Multiplier
            dps *= GetActualAttackSpeed();

            return dps;
        }

        public ItemValueRange GetHeroDps()
        {
            return GetHeroDps(new List<ID3SkillModifier>(), new List<ID3SkillModifier>());
        }

        public ItemValueRange GetHeroDps(IEnumerable<ID3SkillModifier> passives, IEnumerable<ID3SkillModifier> actives)
        {
            var itemAttributes = new ItemAttributes();

            HeroStatsItem.SetLevelBonus(levelAttributes);
            HeroStatsItem.SetParagonLevelBonus(paragonLevelAttributes);

            Update();

            // Build passive bonuses
            foreach (var modifier in passives)
            {
                itemAttributes += modifier.GetBonus(this);
            }

            // Compute the new unique item state with passives
            Update();

            // Build active bonuses
            foreach (var modifier in actives)
            {
                itemAttributes += modifier.GetBonus(this);
            }

            // Finally, return the dps
            return GetHeroDps(itemAttributes);
        }

        public ItemValueRange GetHeroDps(ItemAttributes addedBonus)
        {
            HeroStatsItem.SetLevelBonus(levelAttributes);
            HeroStatsItem.SetParagonLevelBonus(paragonLevelAttributes);
            HeroStatsItem.SetSkillsBonus(addedBonus);
            Update();

            return GetHeroDpsAsIs();
        }

        public double GetHeroEffectiveHitpoints(int mobLevel)
        {
            var ehp = GetHeroHitpoints().Min;

            // Update with armor reduction
            ehp /= (1 - GetHeroDamageReduction_Armor(mobLevel));

            // Update with lowest resistance reduction
            var resistance = GetHeroDamageReduction(mobLevel, "Arcane");
            if (GetHeroDamageReduction(mobLevel, "Cold") < resistance) resistance = GetHeroDamageReduction(mobLevel, "Cold");
            if (GetHeroDamageReduction(mobLevel, "Fire") < resistance) resistance = GetHeroDamageReduction(mobLevel, "Fire");
            if (GetHeroDamageReduction(mobLevel, "Lightning") < resistance) resistance = GetHeroDamageReduction(mobLevel, "Lightning");
            if (GetHeroDamageReduction(mobLevel, "Physical") < resistance) resistance = GetHeroDamageReduction(mobLevel, "Physical");
            if (GetHeroDamageReduction(mobLevel, "Poison") < resistance) resistance = GetHeroDamageReduction(mobLevel, "Poison");
            ehp /= (1 - resistance);

            // Update with class reduction
            if ((HeroClass == HeroClass.Monk) || (HeroClass == HeroClass.Barbarian))
                ehp /= (1 - 0.30);

            return ehp;
        }

        public ItemValueRange GetHeroHitpoints()
        {
            // Use hitpoints formula
            ItemValueRange hitpoints;

            switch (HeroClass)
            {
                case HeroClass.Barbarian:
                case HeroClass.DemonHunter:
                case HeroClass.Monk:
                case HeroClass.WitchDoctor:
                case HeroClass.Wizard:
                    if (HeroLevel < 35)
                        hitpoints = 36 + 4 * HeroLevel + 10 * GetHeroVitality();
                    else
                        hitpoints = 36 + 4 * HeroLevel + (HeroLevel - 25) * GetHeroVitality();
                    break;
                case HeroClass.EnchantressFollower:
                case HeroClass.ScoundrelFollower:
                    // Missing leveling
                    hitpoints = 6219 + 35 * GetHeroVitality();
                    break;
                case HeroClass.TemplarFollower:
                    // Missing leveling
                    hitpoints = 7752 + 35 * GetHeroVitality();
                    break;
                default:
                    hitpoints = ItemValueRange.Zero;
                    break;
            }

            // Update with +% Life bonus
            if (HeroStatsItem.attributesRaw.hitpointsMaxPercentBonusItem != null)
                hitpoints *= 1 + HeroStatsItem.attributesRaw.hitpointsMaxPercentBonusItem.Min;

            return hitpoints;
        }

        public ItemValueRange getHeroResistance_All()
        {
            var resist = ItemValueRange.Zero;

            resist += HeroStatsItem.GetResistance("All");

            // Update with intelligence bonus
            resist += GetHeroIntelligence() / 10;

            return resist;
        }

        public ItemValueRange GetHeroResistance(string resist)
        {
            var resistance = getHeroResistance_All();

            resistance += HeroStatsItem.GetResistance(resist);

            return resistance;
        }

        public ItemValueRange GetHeroDexterity()
        {
            if (HeroStatsItem.attributesRaw.dexterityItem != null)
                return HeroStatsItem.attributesRaw.dexterityItem;
            return ItemValueRange.Zero;
        }

        public ItemValueRange GetHeroIntelligence()
        {
            if (HeroStatsItem.attributesRaw.intelligenceItem != null)
                return HeroStatsItem.attributesRaw.intelligenceItem;
            return ItemValueRange.Zero;
        }

        public ItemValueRange GetHeroStrength()
        {
            if (HeroStatsItem.attributesRaw.strengthItem != null)
                return HeroStatsItem.attributesRaw.strengthItem;
            return ItemValueRange.Zero;
        }

        public ItemValueRange GetHeroVitality()
        {
            if (HeroStatsItem.attributesRaw.vitalityItem != null)
                return HeroStatsItem.attributesRaw.vitalityItem;
            return ItemValueRange.Zero;
        }

        public ItemValueRange GetMainCharacteristic()
        {
            var result = ItemValueRange.Zero;

            switch (HeroClass)
            {
                case HeroClass.Monk:
                case HeroClass.DemonHunter:
                case HeroClass.ScoundrelFollower:
                    return GetHeroDexterity();

                case HeroClass.WitchDoctor:
                case HeroClass.Wizard:
                case HeroClass.EnchantressFollower:
                    return GetHeroIntelligence();

                case HeroClass.Barbarian:
                case HeroClass.TemplarFollower:
                    return GetHeroStrength();
            }

            return result;
        }

        public void Update()
        {
            HeroStatsItem.Update();
        }
    }
}

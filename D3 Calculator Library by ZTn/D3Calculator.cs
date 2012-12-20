using System.Collections.Generic;
using ZTn.BNet.D3.Calculator.Skills;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    public class D3Calculator
    {
        #region >> Fields

        public Hero hero;
        public StatsItem heroItemStats;

        ItemAttributes itemLevel;
        ItemAttributes itemParagonLevel;

        #endregion

        #region >> Constants

        public static readonly Item nakedHandWeapon = new Item(new ItemAttributes() { attacksPerSecondItem = ItemValueRange.One });

        public static readonly Item blankWeapon = new Item(new ItemAttributes() { });

        #endregion

        #region >> Constructors

        public D3Calculator(Hero hero, Item mainHand, Item offHand, Item[] items)
        {
            this.hero = hero;

            // Build unique gems equivalent to items weared
            heroItemStats = new StatsItem(mainHand, offHand, items);

            itemLevel = new ItemAttributesFromLevel(hero);
            itemParagonLevel = new ItemAttributesFromParagonLevel(hero);

            update();
        }

        #endregion

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
            if (heroItemStats.attributesRaw.critDamagePercent != null)
                critDamagePercent += heroItemStats.attributesRaw.critDamagePercent.min;
            multiplier *= 1 + critDamagePercent;

            // Update dps with main statistic
            multiplier *= 1 + getMainCharacteristic().min / 100;

            return multiplier;
        }

        /// <summary>
        /// Return average damage multiplier (taking care of critical and normal hits)
        /// </summary>
        /// <returns></returns>
        public double getDamageMultiplier()
        {
            double multiplier = 1;

            // Update dps with Critic
            double critPercentBonusCapped = 0;
            if (heroItemStats.attributesRaw.critPercentBonusCapped != null)
                critPercentBonusCapped += heroItemStats.attributesRaw.critPercentBonusCapped.min;
            double critDamagePercent = 0;
            if (heroItemStats.attributesRaw.critDamagePercent != null)
                critDamagePercent += heroItemStats.attributesRaw.critDamagePercent.min;
            multiplier *= 1 + critPercentBonusCapped * critDamagePercent;

            // Update dps with main statistic
            double characteristic = getMainCharacteristic().min;
            multiplier *= 1 + characteristic / 100;

            return multiplier;
        }

        public double getActualAttackSpeed()
        {
            double multiplier = 1;

            // Update malusMultiplier with Weapon Attack Speed
            multiplier *= heroItemStats.getWeaponAttackPerSecond();

            // Update malusMultiplier with Attack Speed
            multiplier *= 1 + getIncreasedAttackSpeed();

            return multiplier;
        }

        public double getHeroArmor()
        {
            double armor = 0;

            // Update with base gems's resistance
            if (heroItemStats.attributesRaw.armorItem != null)
                armor += heroItemStats.attributesRaw.armorItem.min;

            // Update with gems's bonus resistance
            if (heroItemStats.attributesRaw.armorBonusItem != null)
                armor += heroItemStats.attributesRaw.armorBonusItem.min;

            // Update with strength bonus
            armor += getHeroStrength();

            return armor;
        }

        public double getHeroDamageReduction_Armor(int mobLevel)
        {
            double armor = getHeroArmor();

            return armor / (armor + 50 * mobLevel);
        }

        public double getHeroDamageReduction(int mobLevel, string resist)
        {
            double resistance = getHeroResistance(resist);

            return resistance / (resistance + 5 * mobLevel);
        }

        public double getHeroDodge()
        {
            double dogde = 0;
            double dexterity = getHeroDexterity();

            double dex0_100 = (dexterity > 100 ? 100 : dexterity);
            double dex101_500 = (dexterity > 500 ? 500 - 100 : (dexterity > 100 ? dexterity - 100 : 0));
            double dex501_1000 = (dexterity > 1000 ? 1000 - 500 : (dexterity > 500 ? dexterity - 500 : 0));
            double dex1001_8000 = (dexterity > 8000 ? 8000 - 1000 : (dexterity > 1000 ? dexterity - 1000 : 0));

            dogde = 0.100 * dex0_100 + 0.025 * dex101_500 + 0.020 * dex501_1000 + 0.010 * dex1001_8000;

            return dogde;
        }

        private double getHeroDPSAsIs()
        {
            double dps = heroItemStats.getWeaponDamage();

            // Update Damage Multiplier
            dps *= getDamageMultiplier();

            // Update Attack Speed Multiplier
            dps *= getActualAttackSpeed();

            return dps;
        }

        public double getHeroDPS()
        {
            heroItemStats.setLevelBonus(itemLevel);
            heroItemStats.setParagonLevelBonus(itemParagonLevel);
            heroItemStats.update();

            return getHeroDPSAsIs();
        }

        public double getHeroDPS(List<D3SkillModifier> passives, List<D3SkillModifier> actives)
        {
            ItemAttributes itemAttributes = new ItemAttributes();

            // Build passive bonuses
            foreach (D3SkillModifier modifier in passives)
            {
                itemAttributes += modifier.getBonus(this);
            }

            // Compute the new unique gems state with passives
            update();

            // Build active bonuses
            foreach (D3SkillModifier modifier in actives)
            {
                itemAttributes += modifier.getBonus(this);
            }

            // Finally, return the dps
            return getHeroDPS(itemAttributes);
        }

        public double getHeroDPS(ItemAttributes addedBonus)
        {
            heroItemStats.setLevelBonus(itemLevel);
            heroItemStats.setParagonLevelBonus(itemParagonLevel);
            heroItemStats.setSkillsBonus(addedBonus);
            heroItemStats.update();

            double dps = getHeroDPSAsIs();

            return dps;
        }

        public double getHeroEffectiveHitpoints(int mobLevel)
        {
            double ehp = getHeroHitpoints();

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
            if ((hero.heroClass == HeroClass.Monk) || (hero.heroClass == HeroClass.Barbarian))
                ehp /= (1 - 0.30);

            return ehp;
        }

        public double getHeroHitpoints()
        {
            // Use hitpoints formula
            double hitpoints;
            if (hero.level < 35)
                hitpoints = 36 + 4 * hero.level + 10 * getHeroVitality();
            else
                hitpoints = 36 + 4 * hero.level + (hero.level - 25) * getHeroVitality();

            // Update with +% Life bonus
            if (heroItemStats.attributesRaw.hitpointsMaxPercentBonusItem != null)
                hitpoints *= 1 + heroItemStats.attributesRaw.hitpointsMaxPercentBonusItem.min;

            return hitpoints;
        }

        public double getHeroResistance_All()
        {
            double resist = 0;

            resist += heroItemStats.getResistance("All");

            // Update with intelligence bonus
            resist += getHeroIntelligence() / 10;

            return resist;
        }

        public double getHeroResistance(string resist)
        {
            double resistance = getHeroResistance_All();

            resistance += heroItemStats.getResistance(resist);

            return resistance;
        }

        public double getHeroDexterity()
        {
            double characteristic = 0;

            // Update with gems bonus
            if (heroItemStats.attributesRaw.dexterityItem != null)
                characteristic += heroItemStats.attributesRaw.dexterityItem.min;

            return characteristic;
        }

        public double getHeroIntelligence()
        {
            double characteristic = 0;

            // Update with gems bonus
            if (heroItemStats.attributesRaw.intelligenceItem != null)
                characteristic += heroItemStats.attributesRaw.intelligenceItem.min;

            return characteristic;
        }

        public double getHeroStrength()
        {
            double characteristic = 0;

            // Update with gems bonus
            if (heroItemStats.attributesRaw.strengthItem != null)
                characteristic += heroItemStats.attributesRaw.strengthItem.min;

            return characteristic;
        }

        public double getHeroVitality()
        {
            double vitality = 0;

            // Update with gems bonus
            if (heroItemStats.attributesRaw.vitalityItem != null)
                vitality += heroItemStats.attributesRaw.vitalityItem.min;

            return vitality;
        }

        public double getIncreasedAttackSpeed()
        {
            double attackSpeed = 0;

            if (heroItemStats.attributesRaw.attacksPerSecondPercent != null)
                attackSpeed = heroItemStats.attributesRaw.attacksPerSecondPercent.min;

            return attackSpeed;
        }

        public ItemValueRange getMainCharacteristic()
        {
            ItemValueRange result = ItemValueRange.Zero;

            switch (hero.heroClass)
            {
                case HeroClass.Monk:
                case HeroClass.DemonHunter:
                    if (heroItemStats.attributesRaw.dexterityItem != null)
                        result = heroItemStats.attributesRaw.dexterityItem;
                    break;
                case HeroClass.WitchDoctor:
                case HeroClass.Wizard:
                    if (heroItemStats.attributesRaw.intelligenceItem != null)
                        result = heroItemStats.attributesRaw.intelligenceItem;
                    break;
                case HeroClass.Barbarian:
                    if (heroItemStats.attributesRaw.strengthItem != null)
                        result = heroItemStats.attributesRaw.strengthItem;
                    break;
                default:
                    break;
            }

            return result;
        }

        public void update()
        {
            heroItemStats.update();
        }
    }
}

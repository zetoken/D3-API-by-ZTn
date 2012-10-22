using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    public class D3Calculator
    {
        #region >> Fields

        public Hero hero;
        public HeroStuff heroStuff;

        ItemAttributes itemLevel;
        ItemAttributes itemParagonLevel;

        #endregion

        #region >> Constructors

        public D3Calculator(Hero hero, Item mainHand, Item offHand, Item[] items)
        {
            this.hero = hero;

            // Build unique item equivalent to items weared
            heroStuff = new HeroStuff(mainHand, offHand, items);
            heroStuff.update();

            itemLevel = getItemAttributesFromLevel();
            itemParagonLevel = getItemAttributesFromParagonLevel();
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
            multiplier *= 1 + (getMainCharacteristic().min + (7 + 3 * hero.level) + (hero.paragonLevel * 3)) / 100;

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
            double critDamagePercent = 0.5;
            if (heroStuff.attributesRaw.critDamagePercent != null)
                critDamagePercent += heroStuff.attributesRaw.critDamagePercent.min;
            multiplier *= 1 + critDamagePercent;

            // Update dps with main statistic
            multiplier *= 1 + (getMainCharacteristic().min + (7 + 3 * hero.level) + (hero.paragonLevel * 3)) / 100;

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
            double critPercentBonusCapped = 0.05;
            if (heroStuff.attributesRaw.critPercentBonusCapped != null)
                critPercentBonusCapped += heroStuff.attributesRaw.critPercentBonusCapped.min;
            double critDamagePercent = 0.5;
            if (heroStuff.attributesRaw.critDamagePercent != null)
                critDamagePercent += heroStuff.attributesRaw.critDamagePercent.min;
            multiplier *= 1 + critPercentBonusCapped * critDamagePercent;

            // Update dps with main statistic
            double characteristic = getMainCharacteristic().min + (7 + 3 * hero.level) + (hero.paragonLevel * 3);
            multiplier *= 1 + characteristic / 100;

            return multiplier;
        }

        public double getActualAttackSpeed()
        {
            double multiplier = 1;

            // Update malusMultiplier with Weapon Attack Speed
            multiplier *= heroStuff.getWeaponAttackPerSecond();

            // Update malusMultiplier with Attack Speed
            multiplier *= 1 + getIncreasedAttackSpeed();

            return multiplier;
        }

        public double getHeroArmor()
        {
            double armor = 0;

            // Update with base item's resistance
            if (heroStuff.attributesRaw.armorItem != null)
                armor += heroStuff.attributesRaw.armorItem.min;

            // Update with item's bonus resistance
            if (heroStuff.attributesRaw.armorBonusItem != null)
                armor += heroStuff.attributesRaw.armorBonusItem.min;

            // Update with strength bonus
            armor += getHeroStrength();

            return armor;
        }

        public double getHeroDamageReduction_Armor(int mobLevel)
        {
            double armor = getHeroArmor();

            return armor / (armor + 50 * mobLevel);
        }

        public double getHeroDamageReduction_Arcane(int mobLevel)
        {
            double resistance = getHeroResistance_Arcane();

            return resistance / (resistance + 5 * mobLevel);
        }

        public double getHeroDamageReduction_Cold(int mobLevel)
        {
            double resistance = getHeroResistance_Cold();

            return resistance / (resistance + 5 * mobLevel);
        }

        public double getHeroDamageReduction_Fire(int mobLevel)
        {
            double resistance = getHeroResistance_Fire();

            return resistance / (resistance + 5 * mobLevel);
        }

        public double getHeroDamageReduction_Lightning(int mobLevel)
        {
            double resistance = getHeroResistance_Lightning();

            return resistance / (resistance + 5 * mobLevel);
        }

        public double getHeroDamageReduction_Physical(int mobLevel)
        {
            double resistance = getHeroResistance_Physical();

            return resistance / (resistance + 5 * mobLevel);
        }

        public double getHeroDamageReduction_Poison(int mobLevel)
        {
            double resistance = getHeroResistance_Poison();

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
            double dps = heroStuff.getWeaponDamage();

            // Update Damage Multiplier
            dps *= getDamageMultiplier();

            // Update Attack Speed Multiplier
            dps *= getActualAttackSpeed();

            return dps;
        }

        public double getHeroDPS()
        {
            heroStuff.update();

            return getHeroDPSAsIs();
        }

        public double getHeroDPS(Item addedBonus)
        {
            heroStuff.updateWithTalents(addedBonus);

            double dps = getHeroDPSAsIs();

            return dps;
        }

        public double getHeroEffectiveHitpoints(int mobLevel)
        {
            double ehp = getHeroHitpoints();

            // Update with armor reduction
            ehp /= (1 - getHeroDamageReduction_Armor(mobLevel));

            // Update with lowest resistance reduction
            double resistance = getHeroDamageReduction_Arcane(mobLevel);
            if (getHeroDamageReduction_Cold(mobLevel) < resistance) resistance = getHeroDamageReduction_Cold(mobLevel);
            if (getHeroDamageReduction_Fire(mobLevel) < resistance) resistance = getHeroDamageReduction_Fire(mobLevel);
            if (getHeroDamageReduction_Lightning(mobLevel) < resistance) resistance = getHeroDamageReduction_Lightning(mobLevel);
            if (getHeroDamageReduction_Physical(mobLevel) < resistance) resistance = getHeroDamageReduction_Physical(mobLevel);
            if (getHeroDamageReduction_Poison(mobLevel) < resistance) resistance = getHeroDamageReduction_Poison(mobLevel);
            ehp /= (1 - resistance);

            // Update with class reduction
            if ((hero.heroClass == "monk") || (hero.heroClass == "barbarian"))
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
            if (heroStuff.attributesRaw.hitpointsMaxPercentBonusItem != null)
                hitpoints *= 1 + heroStuff.attributesRaw.hitpointsMaxPercentBonusItem.min;

            return hitpoints;
        }

        public double getHeroResistance_All()
        {
            double resist = 0;

            if (heroStuff.attributesRaw.resistance_All != null)
                resist = heroStuff.attributesRaw.resistance_All.min;

            // Update with intelligence bonus
            resist += getHeroIntelligence() / 10;

            return resist;
        }

        public double getHeroResistance_Arcane()
        {
            double resist = getHeroResistance_All();

            if (heroStuff.attributesRaw.resistance_Arcane != null)
                resist += heroStuff.attributesRaw.resistance_Arcane.min;

            return resist;
        }

        public double getHeroResistance_Cold()
        {
            double resist = getHeroResistance_All();

            if (heroStuff.attributesRaw.resistance_Cold != null)
                resist += heroStuff.attributesRaw.resistance_Cold.min;

            return resist;
        }

        public double getHeroResistance_Fire()
        {
            double resist = getHeroResistance_All();

            if (heroStuff.attributesRaw.resistance_Fire != null)
                resist += heroStuff.attributesRaw.resistance_Fire.min;

            return resist;
        }

        public double getHeroResistance_Lightning()
        {
            double resist = getHeroResistance_All();

            if (heroStuff.attributesRaw.resistance_Lightning != null)
                resist += heroStuff.attributesRaw.resistance_Lightning.min;

            return resist;
        }

        public double getHeroResistance_Physical()
        {
            double resist = getHeroResistance_All();

            if (heroStuff.attributesRaw.resistance_Physical != null)
                resist += heroStuff.attributesRaw.resistance_Physical.min;

            return resist;
        }

        public double getHeroResistance_Poison()
        {
            double resist = getHeroResistance_All();

            if (heroStuff.attributesRaw.resistance_Poison != null)
                resist += heroStuff.attributesRaw.resistance_Poison.min;

            return resist;
        }

        public double getHeroDexterity()
        {
            double characteristic = 0;

            characteristic += itemLevel.dexterityItem.min;
            characteristic += itemParagonLevel.dexterityItem.min;

            // Update with item bonus
            if (heroStuff.attributesRaw.dexterityItem != null)
                characteristic += heroStuff.attributesRaw.dexterityItem.min;

            return characteristic;
        }

        public double getHeroIntelligence()
        {
            double characteristic = 0;

            characteristic += itemLevel.intelligenceItem.min;
            characteristic += itemParagonLevel.intelligenceItem.min;

            // Update with item bonus
            if (heroStuff.attributesRaw.intelligenceItem != null)
                characteristic += heroStuff.attributesRaw.intelligenceItem.min;

            return characteristic;
        }

        public double getHeroStrength()
        {
            double characteristic = 0;

            characteristic += itemLevel.strengthItem.min;
            characteristic += itemParagonLevel.strengthItem.min;

            // Update with item bonus
            if (heroStuff.attributesRaw.strengthItem != null)
                characteristic += heroStuff.attributesRaw.strengthItem.min;

            return characteristic;
        }

        public double getHeroVitality()
        {
            double vitality = 0;

            vitality += itemLevel.vitalityItem.min;
            vitality += itemParagonLevel.vitalityItem.min;

            // Update with item bonus
            if (heroStuff.attributesRaw.vitalityItem != null)
                vitality += heroStuff.attributesRaw.vitalityItem.min;

            return vitality;
        }

        public double getIncreasedAttackSpeed()
        {
            double attackSpeed = 0;

            if (heroStuff.attributesRaw.attacksPerSecondPercent != null)
                attackSpeed = heroStuff.attributesRaw.attacksPerSecondPercent.min;

            return attackSpeed;
        }

        /// <summary>
        /// Returns an ItemAttributes equivalent to bonuses earned from hero level
        /// </summary>
        /// <returns></returns>
        public ItemAttributes getItemAttributesFromLevel()
        {
            ItemAttributes attr = new ItemAttributes();

            switch (hero.heroClass)
            {
                case "monk":
                case "demon-hunter":
                    attr.dexterityItem = new ItemValueRange(7 + 3 * hero.level);
                    attr.intelligenceItem = new ItemValueRange(7 + 1 * hero.level);
                    attr.strengthItem = new ItemValueRange(7 + 1 * hero.level);
                    break;
                case "witch-doctor":
                case "wizard":
                    attr.dexterityItem = new ItemValueRange(7 + 1 * hero.level);
                    attr.intelligenceItem = new ItemValueRange(7 + 3 * hero.level);
                    attr.strengthItem = new ItemValueRange(7 + 1 * hero.level);
                    break;
                case "barbarian":
                    attr.dexterityItem = new ItemValueRange(7 + 1 * hero.level);
                    attr.intelligenceItem = new ItemValueRange(7 + 1 * hero.level);
                    attr.strengthItem = new ItemValueRange(7 + 3 * hero.level);
                    break;
                default:
                    break;
            }

            attr.vitalityItem = new ItemValueRange(7 + 2 * hero.level);

            return attr;
        }

        /// <summary>
        /// Returns an ItemAttributes equivalent to bonuses earned from hero paragon level
        /// </summary>
        /// <returns></returns>
        public ItemAttributes getItemAttributesFromParagonLevel()
        {
            ItemAttributes attr = new ItemAttributes();

            switch (hero.heroClass)
            {
                case "monk":
                case "demon-hunter":
                    attr.dexterityItem = new ItemValueRange(3 * hero.level);
                    attr.intelligenceItem = new ItemValueRange(1 * hero.level);
                    attr.strengthItem = new ItemValueRange(1 * hero.level);
                    break;
                case "witch-doctor":
                case "wizard":
                    attr.dexterityItem = new ItemValueRange(1 * hero.level);
                    attr.intelligenceItem = new ItemValueRange(3 * hero.level);
                    attr.strengthItem = new ItemValueRange(1 * hero.level);
                    break;
                case "barbarian":
                    attr.dexterityItem = new ItemValueRange(1 * hero.level);
                    attr.intelligenceItem = new ItemValueRange(1 * hero.level);
                    attr.strengthItem = new ItemValueRange(3 * hero.level);
                    break;
                default:
                    break;
            }

            attr.vitalityItem = new ItemValueRange(2 * hero.level);

            return attr;
        }

        public ItemValueRange getMainCharacteristic()
        {
            ItemValueRange result = ItemValueRange.Zero;

            switch (hero.heroClass)
            {
                case "monk":
                case "demon-hunter":
                    if (heroStuff.attributesRaw.dexterityItem != null)
                        result = heroStuff.attributesRaw.dexterityItem;
                    break;
                case "witch-doctor":
                case "wizard":
                    if (heroStuff.attributesRaw.intelligenceItem != null)
                        result = heroStuff.attributesRaw.intelligenceItem;
                    break;
                case "barbarian":
                    if (heroStuff.attributesRaw.strengthItem != null)
                        result = heroStuff.attributesRaw.strengthItem;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}

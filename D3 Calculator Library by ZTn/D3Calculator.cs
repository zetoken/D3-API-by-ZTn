using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    public class D3Calculator
    {
        #region >> Fields

        public Hero hero;
        public HeroStuff heroStuff;

        public Item addedBonus = new Item(new ItemAttributes());
        public Item multipliedBonus = new Item(new ItemAttributes());
        public double skillBonus = 0;

        #endregion

        #region >> Constructors

        public D3Calculator(Hero hero, Item mainHand, Item offHand, Item[] items)
        {
            this.hero = hero;
            heroStuff = new HeroStuff(mainHand, offHand, items);
            heroStuff.update();
        }

        #endregion

        public double getDamageMultiplierNormal()
        {
            double multiplier = 1;

            // Update dps with main statistic
            multiplier *= 1 + (getMainCharacteristic().min + (7 + 3 * hero.level) + (hero.paragonLevel * 3)) / 100;

            // Update damage with skill bonus
            multiplier *= 1 + skillBonus;

            return multiplier;
        }

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

            // Update damage with skill bonus
            multiplier *= 1 + skillBonus;

            return multiplier;
        }

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

            // Update multiplier with Weapon Attack Speed
            multiplier *= heroStuff.getWeaponAttackPerSecond();

            // Update multiplier with Attack Speed
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

        private double getHeroDPSAsIs()
        {
            double dps = heroStuff.getWeaponDamage();

            // Update damage multiplier
            dps *= getDamageMultiplier();

            // Update dps multiplier
            dps *= getActualAttackSpeed();

            // Update dps with skill bonus
            dps *= 1 + skillBonus;

            return dps;
        }

        public double getHeroDPS()
        {
            heroStuff.update();

            return getHeroDPSAsIs();
        }

        public double getHeroDPS(Item addedBonus)
        {
            this.addedBonus = addedBonus;

            heroStuff.updateWithTalents(addedBonus);

            double dps = getHeroDPSAsIs();

            return dps;
        }

        public double getHeroEffectiveHitpoints(int mobLevel)
        {
            double ehp = getHeroHitpoints();

            // Update with armor reduction
            ehp /= (1 + getHeroDamageReduction_Armor(mobLevel));

            // Update with resistance reduction
            ehp /= (1 + getHeroDamageReduction_Arcane(mobLevel));

            // Update with class reduction
            if ((hero.heroClass == "monk") || (hero.heroClass == "barbarian"))
                ehp /= (1 + 0.30);

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

            if (heroStuff.attributesRaw.resistanceAll != null)
                resist = heroStuff.attributesRaw.resistanceAll.min;

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

            switch (hero.heroClass)
            {
                case "barbarian":
                case "witch-doctor":
                case "wizard":
                    characteristic = 7 + 1 * hero.level + 1 * hero.paragonLevel;
                    break;
                case "monk":
                case "demon-hunter":
                    characteristic = 7 + 3 * hero.level + 3 * hero.paragonLevel;
                    break;
                default:
                    break;
            }

            // Update with item bonus
            if (heroStuff.attributesRaw.dexterityItem != null)
                characteristic += heroStuff.attributesRaw.dexterityItem.min;

            return characteristic;
        }

        public double getHeroIntelligence()
        {
            double characteristic = 0;

            switch (hero.heroClass)
            {
                case "monk":
                case "demon-hunter":
                case "barbarian":
                    characteristic = 7 + 1 * hero.level + 1 * hero.paragonLevel;
                    break;
                case "witch-doctor":
                case "wizard":
                    characteristic = 7 + 3 * hero.level + 3 * hero.paragonLevel;
                    break;
                default:
                    break;
            }

            // Update with item bonus
            if (heroStuff.attributesRaw.intelligenceItem != null)
                characteristic += heroStuff.attributesRaw.intelligenceItem.min;

            return characteristic;
        }

        public double getHeroStrength()
        {
            double characteristic = 0;

            switch (hero.heroClass)
            {
                case "monk":
                case "demon-hunter":
                case "witch-doctor":
                case "wizard":
                    characteristic = 7 + 1 * hero.level + 1 * hero.paragonLevel;
                    break;
                case "barbarian":
                    characteristic = 7 + 3 * hero.level + 3 * hero.paragonLevel;
                    break;
                default:
                    break;
            }

            // Update with item bonus
            if (heroStuff.attributesRaw.strengthItem != null)
                characteristic += heroStuff.attributesRaw.strengthItem.min;

            return characteristic;
        }

        public double getHeroVitality()
        {
            double vitality = 0;

            vitality = 7 + 2 * hero.level + 2 * hero.paragonLevel;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    public class D3Calculator
    {
        #region >> Fields

        public Hero hero;
        public HeroStuff heroStuff;

        #endregion

        #region >> Constructors

        public D3Calculator(Hero hero, Item mainHand, Item offHand, Item[] items)
        {
            this.hero = hero;
            heroStuff = new HeroStuff(mainHand, offHand, items);
        }

        #endregion

        public double getDamageMultiplierNormal(int level, int paragonLevel)
        {
            double multiplier = 1;
            // Update dps with Weapon Attack Speed
            multiplier *= heroStuff.getWeaponAttackPerSecond();

            // Update dps with Attack Speed
            multiplier *= (1 + getIncreasedAttackSpeed());

            // Update dps with Critic
            multiplier *= 1;

            // Update dps with main statistic
            multiplier *= 1 + (getMainCharacteristic().min + (7 + 3 * level) + (paragonLevel * 3)) / 100;

            return multiplier;
        }

        public double getDamageMultiplierCritic(int level, int paragonLevel)
        {
            double multiplier = 1;
            // Update dps with Weapon Attack Speed
            multiplier *= heroStuff.getWeaponAttackPerSecond();

            // Update dps with Attack Speed
            multiplier *= (1 + getIncreasedAttackSpeed());

            // Update dps with Critic
            double critPercentBonusCapped = 1;
            double critDamagePercent = 0.5;
            if (heroStuff.attributesRaw.critDamagePercent != null)
                critDamagePercent += heroStuff.attributesRaw.critDamagePercent.min;
            multiplier *= 1 + critPercentBonusCapped * critDamagePercent;

            // Update dps with main statistic
            multiplier *= 1 + (getMainCharacteristic().min + (7 + 3 * level) + (paragonLevel * 3)) / 100;

            return multiplier;
        }

        public double getDamageMultiplier(int level, int paragonLevel)
        {
            double multiplier = 1;
            // Update dps with Weapon Attack Speed
            multiplier *= heroStuff.getWeaponAttackPerSecond();

            // Update dps with Attack Speed
            multiplier *= (1 + getIncreasedAttackSpeed());

            // Update dps with Critic
            double critPercentBonusCapped = 0.05;
            if (heroStuff.attributesRaw.critPercentBonusCapped != null)
                critPercentBonusCapped += heroStuff.attributesRaw.critPercentBonusCapped.min;
            double critDamagePercent = 0.5;
            if (heroStuff.attributesRaw.critDamagePercent != null)
                critDamagePercent += heroStuff.attributesRaw.critDamagePercent.min;
            multiplier *= 1 + critPercentBonusCapped * critDamagePercent;

            // Update dps with main statistic
            multiplier *= 1 + (getMainCharacteristic().min + (7 + 3 * level) + (paragonLevel * 3)) / 100;

            return multiplier;
        }

        private double getHeroDPSAsIs(int level, int paragonLevel)
        {
            double dps = heroStuff.getWeaponDamage();

            // Update damage multiplier
            dps *= getDamageMultiplier(level, paragonLevel);

            return dps;
        }

        public double getHeroDPS(int level, int paragonLevel)
        {
            heroStuff.update();

            return getHeroDPSAsIs(level, paragonLevel);
        }

        public double getHeroDPS(int level, int paragonLevel, Item addedBonus, Item multipliedBonus, double skillBonus)
        {
            heroStuff.updateWithTalents(addedBonus, multipliedBonus);

            double dps = getHeroDPSAsIs(level, paragonLevel);

            // Update dps with skill bonus
            dps *= 1 + skillBonus;

            return dps;
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
                    result = heroStuff.attributesRaw.dexterityItem;
                    break;
                case "witch-doctor":
                case "wizard":
                    result = heroStuff.attributesRaw.intelligenceItem;
                    break;
                case "barbarian":
                    result = heroStuff.attributesRaw.strengthItem;
                    break;
                default:
                    break;
            }

            return result;
        }

        public double getWeaponDPS()
        {
            return heroStuff.getWeaponDamage() * heroStuff.getWeaponAttackPerSecond();
        }
    }
}

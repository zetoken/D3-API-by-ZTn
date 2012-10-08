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

        public Item addedBonus = new Item(new ItemAttributes());
        public Item multipliedBonus = new Item(new ItemAttributes());
        public double skillBonus = 0;

        #endregion

        #region >> Constructors

        public D3Calculator(Hero hero, Item mainHand, Item offHand, Item[] items)
        {
            this.hero = hero;
            heroStuff = new HeroStuff(mainHand, offHand, items);
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
            multiplier *= 1 + (getMainCharacteristic().min + (7 + 3 * hero.level) + (hero.paragonLevel * 3)) / 100;

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

        public double getHeroDPS(Item addedBonus, Item multipliedBonus, double skillBonus)
        {
            this.addedBonus = addedBonus;
            this.multipliedBonus = multipliedBonus;
            this.skillBonus = skillBonus;

            heroStuff.updateWithTalents(addedBonus, multipliedBonus);

            double dps = getHeroDPSAsIs();

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

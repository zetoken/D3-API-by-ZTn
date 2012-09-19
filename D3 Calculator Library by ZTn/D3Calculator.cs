using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    public class D3Calculator
    {
        #region >> Fields

        public HeroStuff heroStuff;

        #endregion

        #region >> Constructors

        public D3Calculator(Item mainHand, Item offHand, Item[] items)
        {
            heroStuff = new HeroStuff(mainHand, offHand, items);
        }

        #endregion

        public double getWeaponDamage()
        {
            // Compute weapon damage
            double damage = heroStuff.mainHand.getWeaponDamage() + heroStuff.getBonusDamage();
            // Ambidextry
            if (heroStuff.isAmbidextry())
            {
                double attackSpeedMainHand = heroStuff.mainHand.getWeaponAttackSpeed();
                double attackSpeedOffHand = heroStuff.offHand.getWeaponAttackSpeed();
                double attackSpeedAverage = getWeaponAttackSpeed();
                double mainHandDamage = heroStuff.mainHand.getWeaponDamage() + heroStuff.getBonusDamage();
                double offHandDamage = heroStuff.offHand.getWeaponDamage() + heroStuff.getBonusDamage();
                damage = (damage + offHandDamage) / 2;
            }
            return damage;
        }

        public double getWeaponDPS()
        {
            return getWeaponDamage() * getWeaponAttackSpeed();
        }

        public double getWeaponAttackSpeed()
        {
            double weaponAttackSpeed;

            if (!heroStuff.isAmbidextry())
            {
                weaponAttackSpeed = heroStuff.mainHand.getWeaponAttackSpeed();
            }
            else
            {
                // Right formula: 2 * 1 / ( 1 / main + 1 / off ) [found by ZTn]
                weaponAttackSpeed = 2 * 1 / (1 / heroStuff.mainHand.getWeaponAttackSpeed() + 1 / heroStuff.offHand.getWeaponAttackSpeed());
                // Ambidextry gets a 15% bonus
                weaponAttackSpeed *= 1.15;
            }

            return weaponAttackSpeed;
        }

        public double getIncreasedAttackSpeed()
        {
            double attackSpeed = 0;

            if (heroStuff.attributesRaw.attacksPerSecondPercent != null)
                attackSpeed = heroStuff.attributesRaw.attacksPerSecondPercent.min;

            return attackSpeed;
        }

        public double getHeroDPS(int level, int paragonLevel)
        {
            heroStuff.buildUniqueItem();

            double dps = getWeaponDamage();

            // Update dps with Weapon Attack Speed
            dps *= getWeaponAttackSpeed();

            // Update dps with Attack Speed
            dps *= (1 + getIncreasedAttackSpeed());

            // Update dps with Critic
            double critPercentBonusCapped = 0.05;
            if (heroStuff.attributesRaw.critPercentBonusCapped != null)
                critPercentBonusCapped += heroStuff.attributesRaw.critPercentBonusCapped.min;
            double critDamagePercent = 0.5;
            if (heroStuff.attributesRaw.critDamagePercent != null)
                critDamagePercent += heroStuff.attributesRaw.critDamagePercent.min;
            dps *= 1 + critPercentBonusCapped * critDamagePercent;

            // Update dps with main statistic
            dps *= 1 + (heroStuff.attributesRaw.dexterityItem.min + (7 + 3 * level) + (paragonLevel * 3)) / 100;

            return dps;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    public class Weapon
    {
        public Item item;

        public Weapon(Item item)
            : base()
        {
            this.item = item;
        }

        public double getWeaponAttackSpeed()
        {
            double weaponAttackSpeed = item.attributesRaw.attacksPerSecondItem.min;

            if (item.attributesRaw.attacksPerSecondItemPercent != null)
                weaponAttackSpeed *= (1 + item.attributesRaw.attacksPerSecondItemPercent.min);

            return weaponAttackSpeed;
        }

        #region >> getWeaponDamage *

        /// <summary>
        /// Calculate weapon damage
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public double getWeaponDamage()
        {
            double damage = getWeaponResistDamage("Arcane")
                + getWeaponResistDamage("Cold")
                + getWeaponResistDamage("Fire")
                + getWeaponResistDamage("Lightning")
                + getWeaponResistDamage("Physical")
                + getWeaponResistDamage("Poison");

            return damage;
        }

        /// <summary>
        /// Calculate maximum weapon damage
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public double getWeaponDamageMax()
        {
            double damage = getWeaponResistDamageMax("Arcane")
                + getWeaponResistDamageMax("Cold")
                + getWeaponResistDamageMax("Fire")
                + getWeaponResistDamageMax("Lightning")
                + getWeaponResistDamageMax("Physical")
                + getWeaponResistDamageMax("Poison");

            return damage;
        }

        /// <summary>
        /// Calculate minimum weapon damage
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public double getWeaponDamageMin(Item item)
        {
            double damage = getWeaponResistDamageMin("Arcane")
                + getWeaponResistDamageMin("Cold")
                + getWeaponResistDamageMin("Fire")
                + getWeaponResistDamageMin("Lightning")
                + getWeaponResistDamageMin("Physical")
                + getWeaponResistDamageMin("Poison");

            return damage;
        }

        #endregion

        public double getWeaponDPS()
        {
            return getWeaponDamage() * getWeaponAttackSpeed();
        }

        #region >> getWeaponResistDamage *

        /// <summary>
        /// Computes the specific damage for a resist done by a weapon
        /// </summary>
        /// <param name="weapon"></param>
        /// <param name="resist">Must be one of "Arcane", "Cold", "Fire", "Lightning", "Physical", "Poison"</param>
        /// <returns></returns>
        public double getWeaponResistDamage(String resist)
        {
            return (getWeaponResistDamageMin(resist) + getWeaponResistDamageMax(resist)) / 2;
        }

        /// <summary>
        /// Computes the specific maximum damage for a resist done by a weapon
        /// </summary>
        /// <param name="weapon"></param>
        /// <param name="resist">Must be one of "Arcane", "Cold", "Fire", "Lightning", "Physical", "Poison"</param>
        /// <returns></returns>
        public double getWeaponResistDamageMax(String resist)
        {
            Type type = item.attributesRaw.GetType();

            ItemValueRange damageWeaponMin = (ItemValueRange)type.GetField("damageWeaponMin_" + resist).GetValue(item.attributesRaw);
            ItemValueRange damageWeaponDelta = (ItemValueRange)type.GetField("damageWeaponDelta_" + resist).GetValue(item.attributesRaw);
            ItemValueRange damageWeaponBonusDelta = (ItemValueRange)type.GetField("damageWeaponBonusDelta_" + resist).GetValue(item.attributesRaw);
            ItemValueRange damageWeaponPercentBonus = (ItemValueRange)type.GetField("damageWeaponPercentBonus_" + resist).GetValue(item.attributesRaw);

            double min = (damageWeaponMin == null ? 0 : damageWeaponMin.min);
            double delta = (damageWeaponDelta == null ? 0 : damageWeaponDelta.min);
            double bonusDelta = (damageWeaponBonusDelta == null ? 0 : damageWeaponBonusDelta.min);
            double percentBonus = (damageWeaponPercentBonus == null ? 0 : damageWeaponPercentBonus.min);
            double damage = (min + delta + bonusDelta) * (1 + percentBonus);

            return damage;
        }

        /// <summary>
        /// Computes the specific minimum damage for a resist done by a weapon
        /// </summary>
        /// <param name="weapon"></param>
        /// <param name="resist">Must be one of "Arcane", "Cold", "Fire", "Lightning", "Physical", "Poison"</param>
        /// <returns></returns>
        public double getWeaponResistDamageMin(String resist)
        {
            Type type = item.attributesRaw.GetType();

            ItemValueRange damageWeaponMin = (ItemValueRange)type.GetField("damageWeaponMin_" + resist).GetValue(item.attributesRaw);
            ItemValueRange damageWeaponDelta = (ItemValueRange)type.GetField("damageWeaponDelta_" + resist).GetValue(item.attributesRaw);
            ItemValueRange damageWeaponBonusMin = (ItemValueRange)type.GetField("damageWeaponBonusMin_" + resist).GetValue(item.attributesRaw);
            ItemValueRange damageWeaponBonusDelta = (ItemValueRange)type.GetField("damageWeaponBonusDelta_" + resist).GetValue(item.attributesRaw);
            ItemValueRange damageWeaponPercentBonus = (ItemValueRange)type.GetField("damageWeaponPercentBonus_" + resist).GetValue(item.attributesRaw);

            double min = (damageWeaponMin == null ? 0 : damageWeaponMin.min);
            double bonusMin = (damageWeaponBonusMin == null ? 0 : damageWeaponBonusMin.min);
            double percentBonus = (damageWeaponPercentBonus == null ? 0 : damageWeaponPercentBonus.min);
            double damage = (min + bonusMin) * (1 + percentBonus);

            return damage;
        }

        #endregion

        public Boolean isWeapon()
        {
            return (item.attributesRaw.attacksPerSecondItem != null);
        }
    }
}

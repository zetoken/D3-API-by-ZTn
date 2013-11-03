using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Helpers
{
    /// <summary>
    /// Extension class to be used with <see cref="ItemAttributes"/> objects
    /// </summary>
    public static class ItemAttributesExtension
    {
        #region >> Reflection Helpers

        /// <summary>
        /// Returns the value of an attribute of an item given the attribute's name
        /// </summary>
        /// <param name="itemAttributes">Source attributes</param>
        /// <param name="fieldName">Name of the attribute to retrieve</param>
        /// <returns></returns>
        public static ItemValueRange getAttributeByName(this ItemAttributes itemAttributes, String fieldName)
        {
            return (ItemValueRange)typeof(ItemAttributes).GetField(fieldName).GetValue(itemAttributes);
        }

        /// <summary>
        /// Sets the value of an attribute of an ItemAttributes given the attribute's name
        /// </summary>
        /// <param name="itemAttributes">Source attributes</param>
        /// <param name="fieldName">Name of the attribute to retrieve</param>
        /// <param name="value">Value to set</param>
        public static void setAttributeByName(this ItemAttributes itemAttributes, String fieldName, ItemValueRange value)
        {
            typeof(ItemAttributes).GetField(fieldName).SetValue(itemAttributes, value);
        }

        #endregion

        /// <summary>
        /// Computes armor brought by an item.
        /// </summary>
        /// <param name="itemAttr">Attributes of an item.</param>
        /// <returns></returns>
        public static ItemValueRange getArmor(this ItemAttributes itemAttr)
        {
            return itemAttr.armorItem + itemAttr.armorBonusItem;
        }

        /// <summary>
        /// Computes damages other than weapon damages (on rings, amulets, ...).
        /// </summary>
        /// <param name="itemAttr">Attributes of an item.</param>
        /// <returns></returns>
        public static ItemValueRange getRawAverageBonusDamage(this ItemAttributes itemAttr)
        {
            // formula: ( min + max ) / 2
            return (itemAttr.getRawBonusDamageMin() + itemAttr.getRawBonusDamageMax()) / 2;
        }

        #region >> getRawBonusDamageMin *

        /// <summary>
        /// Computes min damage of the item.
        /// </summary>
        /// <param name="itemAttr">Attributes of an item.</param>
        /// <returns></returns>
        public static ItemValueRange getRawBonusDamageMin(this ItemAttributes itemAttr)
        {
            return itemAttr.getRawBonusDamageMin("Arcane") + itemAttr.getRawBonusDamageMin("Cold")
                + itemAttr.getRawBonusDamageMin("Fire") + itemAttr.getRawBonusDamageMin("Holy")
                + itemAttr.getRawBonusDamageMin("Lightning") + itemAttr.getRawBonusDamageMin("Physical")
                + itemAttr.getRawBonusDamageMin("Poison");
        }

        /// <summary>
        /// Computes min damage of the item (based on a specific resist).
        /// </summary>
        /// <param name="itemAttr">Attributes of an item.</param>
        /// <param name="resist">Name of the resist.</param>
        /// <param name="useDamageTypePercentBonus"></param>
        /// <returns></returns>
        public static ItemValueRange getRawBonusDamageMin(this ItemAttributes itemAttr, String resist, bool useDamageTypePercentBonus = true)
        {
            ItemValueRange result = itemAttr.getAttributeByName("damageMin_" + resist) + itemAttr.getAttributeByName("damageBonusMin_" + resist);

            if (useDamageTypePercentBonus && resist != "Physical")
                result += itemAttr.getRawBonusDamageMin("Physical") * itemAttr.getAttributeByName("damageTypePercentBonus_" + resist);

            return result;
        }

        #endregion

        #region >> getRawBonusDamageMax *

        /// <summary>
        /// Computes max damage of the item.
        /// </summary>
        /// <param name="itemAttr">Attributes of an item.</param>
        /// <returns></returns>
        public static ItemValueRange getRawBonusDamageMax(this ItemAttributes itemAttr)
        {
            return itemAttr.getRawBonusDamageMax("Arcane") + itemAttr.getRawBonusDamageMax("Cold")
                + itemAttr.getRawBonusDamageMax("Fire") + itemAttr.getRawBonusDamageMax("Holy")
                + itemAttr.getRawBonusDamageMax("Lightning") + itemAttr.getRawBonusDamageMax("Physical")
                + itemAttr.getRawBonusDamageMax("Poison");
        }

        /// <summary>
        /// Computes max damage of the item (based on a specific resist).
        /// </summary>
        /// <param name="itemAttr">Attributes of an item.</param>
        /// <param name="resist">Name of the resist.</param>
        /// <param name="useDamageTypePercentBonus"></param>
        /// <returns></returns>
        public static ItemValueRange getRawBonusDamageMax(this ItemAttributes itemAttr, String resist, bool useDamageTypePercentBonus = true)
        {
            ItemValueRange result = itemAttr.getAttributeByName("damageMin_" + resist) + itemAttr.getAttributeByName("damageDelta_" + resist);

            if (useDamageTypePercentBonus && resist != "Physical")
                result += itemAttr.getRawBonusDamageMax("Physical") * itemAttr.getAttributeByName("damageTypePercentBonus_" + resist);

            return result;
        }

        #endregion

        /// <summary>
        /// Returns the resistance value given by the gems for the given resist
        /// </summary>
        /// <param name="gems"></param>
        /// <param name="resist"></param>
        /// <returns></returns>
        public static ItemValueRange getResistance(this ItemAttributes itemAttr, String resist)
        {
            return itemAttr.getAttributeByName("resistance_" + resist);
        }

        /// <summary>
        /// Computes weapon attack speed (attack per second).
        /// </summary>
        /// <param name="gems"></param>
        /// <returns></returns>
        public static ItemValueRange getRawWeaponAttackPerSecond(this ItemAttributes itemAttr)
        {
            return itemAttr.getWeaponAttackPerSecond(ItemValueRange.Zero);
        }

        /// <summary>
        /// Computes raw weapon dps ie before all multipliers ( = average damage * attack per second )
        /// </summary>
        /// <param name="gems"></param>
        /// <returns></returns>
        public static ItemValueRange getRawWeaponDPS(this ItemAttributes itemAttr)
        {
            return itemAttr.getRawAverageWeaponDamage() * itemAttr.getRawWeaponAttackPerSecond();
        }

        /// <summary>
        /// Computes weapon only damages
        /// </summary>
        /// <param name="gems"></param>
        /// <returns></returns>
        public static ItemValueRange getRawAverageWeaponDamage(this ItemAttributes itemAttr)
        {
            // formula: ( min + max ) / 2
            return (itemAttr.getRawWeaponDamageMin() + itemAttr.getRawWeaponDamageMax()) / 2;
        }

        /// <summary>
        /// Computes min damage of the weapon without taking account of "+% weapon damage".
        /// </summary>
        /// <param name="weaponAttr">Attributes of a weapon.</param>
        /// <returns></returns>
        public static ItemValueRange getBaseWeaponDamageMin(this ItemAttributes itemAttr, String resist)
        {
            ItemValueRange damage =
                (itemAttr.getAttributeByName("damageWeaponMin_" + resist) + itemAttr.getAttributeByName("damageWeaponBonusMin_" + resist) + itemAttr.getAttributeByName("damageWeaponBonusMinX1_" + resist));

            return damage;
        }

        #region >> getRawWeaponDamageMin *

        /// <summary>
        /// Computes min damage of the weapon.
        /// </summary>
        /// <param name="weaponAttr">Attributes of a weapon.</param>
        /// <returns></returns>
        public static ItemValueRange getRawWeaponDamageMin(this ItemAttributes weaponAttr)
        {
            return weaponAttr.getRawWeaponDamageMin("Arcane") + weaponAttr.getRawWeaponDamageMin("Cold")
                + weaponAttr.getRawWeaponDamageMin("Fire") + weaponAttr.getRawWeaponDamageMin("Holy")
                + weaponAttr.getRawWeaponDamageMin("Lightning") + weaponAttr.getRawWeaponDamageMin("Physical")
                + weaponAttr.getRawWeaponDamageMin("Poison");
        }

        /// <summary>
        /// Computes min damage of the weapon (based on a specific resist).
        /// </summary>
        /// <param name="weaponAttr">Attributes of a weapon.</param>
        /// <param name="resist">Name of the resist.</param>
        /// <param name="useDamageTypePercentBonus"></param>
        /// <returns></returns>
        public static ItemValueRange getRawWeaponDamageMin(this ItemAttributes weaponAttr, String resist, bool useDamageTypePercentBonus = true)
        {
            ItemValueRange damage =
                (weaponAttr.getAttributeByName("damageWeaponMin_" + resist) + weaponAttr.getAttributeByName("damageWeaponBonusMin_" + resist) + weaponAttr.getAttributeByName("damageWeaponBonusMinX1_" + resist))
                * (1 + weaponAttr.getAttributeByName("damageWeaponPercentBonus_" + resist));

            if (useDamageTypePercentBonus && resist != "Physical")
                damage += weaponAttr.getRawWeaponDamageMin("Physical") * weaponAttr.getAttributeByName("damageTypePercentBonus_" + resist);

            return damage;
        }

        #endregion

        /// <summary>
        /// Computes max damage of the weapon without taking account of "+% weapon damage".
        /// </summary>
        /// <param name="weaponAttr">Attributes of a weapon.</param>
        /// <returns></returns>
        public static ItemValueRange getBaseWeaponDamageMax(this ItemAttributes weaponAttr, String resist)
        {
            ItemValueRange damage =
                (weaponAttr.getAttributeByName("damageWeaponMin_" + resist) + weaponAttr.getAttributeByName("damageWeaponDelta_" + resist) + weaponAttr.getAttributeByName("damageWeaponBonusDelta_" + resist));

            return damage;
        }

        #region >> getRawWeaponDamageMax *

        /// <summary>
        /// Computes max damage of the weapon.
        /// </summary>
        /// <param name="weaponAttr">Attributes of a weapon.</param>
        /// <returns></returns>
        public static ItemValueRange getRawWeaponDamageMax(this ItemAttributes weaponAttr)
        {
            return weaponAttr.getRawWeaponDamageMax("Arcane") + weaponAttr.getRawWeaponDamageMax("Cold")
                + weaponAttr.getRawWeaponDamageMax("Fire") + weaponAttr.getRawWeaponDamageMax("Holy")
                + weaponAttr.getRawWeaponDamageMax("Lightning") + weaponAttr.getRawWeaponDamageMax("Physical")
                + weaponAttr.getRawWeaponDamageMax("Poison");
        }

        /// <summary>
        /// Computes max damage of the weapon (based on a specific resist).
        /// </summary>
        /// <param name="weaponAttr">Attributes of a weapon.</param>
        /// <param name="resist">Name of the resist.</param>
        /// <param name="useDamageTypePercentBonus"></param>
        /// <returns></returns>
        public static ItemValueRange getRawWeaponDamageMax(this ItemAttributes weaponAttr, String resist, bool useDamageTypePercentBonus = true)
        {
            ItemValueRange damage =
                (weaponAttr.getAttributeByName("damageWeaponMin_" + resist) + weaponAttr.getAttributeByName("damageWeaponDelta_" + resist) + weaponAttr.getAttributeByName("damageWeaponBonusDelta_" + resist))
                * (ItemValueRange.One + weaponAttr.getAttributeByName("damageWeaponPercentBonus_" + resist));

            if (useDamageTypePercentBonus && resist != "Physical")
                damage += weaponAttr.getRawWeaponDamageMax("Physical") * weaponAttr.getAttributeByName("damageTypePercentBonus_" + resist);

            return damage;
        }

        #endregion

        /// <summary>
        /// Computes weapon attack speed.
        /// </summary>
        /// <param name="weaponAttr">Attributes of used weapon.</param>
        /// <param name="increaseFromOtherItems">Increase Attack Speed from items other than the weapon.</param>
        /// <returns></returns>
        public static ItemValueRange getWeaponAttackPerSecond(this ItemAttributes weaponAttr, ItemValueRange increaseFromOtherItems)
        {
            ItemValueRange weaponAttackSpeed = weaponAttr.attacksPerSecondItem;

            weaponAttackSpeed *= 1 + weaponAttr.attacksPerSecondItemPercent + increaseFromOtherItems;

            return weaponAttackSpeed;
        }

        #region >> checkAndUpdateWeaponDelta *

        /// <summary>
        /// Check a specific case of "invalid" weapon damage values:
        /// If bonus min > delta, then delta should be replaced by bonus min + 1
        /// </summary>
        /// <param name="itemAttr"></param>
        public static ItemAttributes checkAndUpdateWeaponDelta(this ItemAttributes itemAttr)
        {
            return itemAttr
                .checkAndUpdateWeaponDelta("Arcane")
                .checkAndUpdateWeaponDelta("Cold")
                .checkAndUpdateWeaponDelta("Fire")
                .checkAndUpdateWeaponDelta("Holy")
                .checkAndUpdateWeaponDelta("Lightning")
                .checkAndUpdateWeaponDelta("Physical")
                .checkAndUpdateWeaponDelta("Poison");
        }

        /// <summary>
        /// Check a specific case of "invalid" Weapon damage values (based on a specific resist):
        /// If bonus min > delta, then delta should be replaced by bonus min + 1
        /// </summary>
        /// <param name="itemAttr"></param>
        public static ItemAttributes checkAndUpdateWeaponDelta(this ItemAttributes itemAttr, String resist)
        {
            ItemValueRange damageWeaponBonusMin = itemAttr.getAttributeByName("damageWeaponBonusMin_" + resist);
            ItemValueRange damageWeaponDelta = itemAttr.getAttributeByName("damageWeaponDelta_" + resist);

            // Check "black weapon bug"
            if ((damageWeaponDelta != null) && (damageWeaponBonusMin != null) && (damageWeaponDelta.min < damageWeaponBonusMin.min))
                damageWeaponDelta = damageWeaponBonusMin + 1;

            // Store new values
            itemAttr.setAttributeByName("damageWeaponDelta_" + resist, damageWeaponDelta);

            return itemAttr;
        }

        #endregion

        /// <summary>
        /// Informs if the item is a weapon based on its attributes
        /// </summary>
        /// <param name="itemAttr">Attributes of the item.</param>
        /// <returns></returns>
        public static Boolean isWeapon(this ItemAttributes itemAttr)
        {
            return (itemAttr.attacksPerSecondItem != null);
        }

        /// <summary>
        /// Returns a new <see cref="ItemAttributes"/> by aggregating some raw attributes of <paramref name="itemAttr"/> (for easier editing for example).
        /// </summary>
        /// <param name="itemAttr"></param>
        /// <returns>The <paramref name="itemAttr"/> instance.</returns>
        public static ItemAttributes getSimplified(this ItemAttributes itemAttr)
        {
            ItemAttributes attr = new ItemAttributes(itemAttr);

            List<String> resists = new List<string>() { "Arcane", "Cold", "Fire", "Holy", "Lightning", "Physical", "Poison" };

            // Characteristics
            attr.armorItem = itemAttr.getArmor().nullIfZero();
            attr.armorBonusItem = null;

            // Weapon characterics
            attr.attacksPerSecondItem = itemAttr.getRawWeaponAttackPerSecond().nullIfZero();
            attr.attacksPerSecondItemPercent = null;

            itemAttr.checkAndUpdateWeaponDelta();

            foreach (string resist in resists)
            {
                ItemValueRange rawWeaponDamageMin = itemAttr.getBaseWeaponDamageMin(resist);
                ItemValueRange rawWeaponDamageDelta = itemAttr.getBaseWeaponDamageMax(resist) - rawWeaponDamageMin;

                attr.setAttributeByName("damageWeaponMin_" + resist, rawWeaponDamageMin.nullIfZero());
                attr.setAttributeByName("damageWeaponDelta_" + resist, rawWeaponDamageDelta.nullIfZero());
                attr.setAttributeByName("damageWeaponBonusMin_" + resist, null);
                attr.setAttributeByName("damageWeaponBonusDelta_" + resist, null);
                attr.setAttributeByName("damageWeaponBonusMinX1_" + resist, null);
            }

            // Item damage bonuses
            foreach (string resist in resists)
            {
                ItemValueRange rawDamageMin = itemAttr.getRawBonusDamageMin(resist);
                ItemValueRange rawDamageDelta = itemAttr.getRawBonusDamageMax(resist, false) - rawDamageMin;

                attr.setAttributeByName("damageMin_" + resist, rawDamageMin.nullIfZero());
                attr.setAttributeByName("damageDelta_" + resist, rawDamageDelta.nullIfZero());
                attr.setAttributeByName("damageBonusMin_" + resist, null);
            }

            return attr;
        }
    }
}

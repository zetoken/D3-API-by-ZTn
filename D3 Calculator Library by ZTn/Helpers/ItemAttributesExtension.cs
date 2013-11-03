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
        #region >> Reflexion Helpers

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
        /// Computes armor brought by the item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static ItemValueRange getArmor(this ItemAttributes attributesRaw)
        {
            return attributesRaw.armorItem + attributesRaw.armorBonusItem;
        }

        /// <summary>
        /// Computes damages other than ambidextryWeapon damages (on rings, amulets, ...)
        /// </summary>
        /// <param name="gems"></param>
        /// <returns></returns>
        public static ItemValueRange getRawBonusDamage(this ItemAttributes itemAttr)
        {
            // formula: ( min + max ) / 2
            return (itemAttr.getRawBonusDamageMin() + itemAttr.getRawBonusDamageMax()) / 2;
        }

        #region >> getRawBonusDamageMin *

        public static ItemValueRange getRawBonusDamageMin(this ItemAttributes itemAttr)
        {
            return itemAttr.getRawBonusDamageMin("Arcane") + itemAttr.getRawBonusDamageMin("Cold")
                + itemAttr.getRawBonusDamageMin("Fire") + itemAttr.getRawBonusDamageMin("Holy")
                + itemAttr.getRawBonusDamageMin("Lightning") + itemAttr.getRawBonusDamageMin("Physical")
                + itemAttr.getRawBonusDamageMin("Poison");
        }

        public static ItemValueRange getRawBonusDamageMin(this ItemAttributes itemAttr, String resist, bool useDamageTypePercentBonus = true)
        {
            ItemValueRange result = itemAttr.getAttributeByName("damageMin_" + resist) + itemAttr.getAttributeByName("damageBonusMin_" + resist);

            if (useDamageTypePercentBonus && resist != "Physical")
                result += itemAttr.getRawBonusDamageMin("Physical") * itemAttr.getAttributeByName("damageTypePercentBonus_" + resist);

            return result;
        }

        #endregion

        #region >> getRawBonusDamageMax *

        public static ItemValueRange getRawBonusDamageMax(this ItemAttributes itemAttributes)
        {
            return itemAttributes.getRawBonusDamageMax("Arcane") + itemAttributes.getRawBonusDamageMax("Cold")
                + itemAttributes.getRawBonusDamageMax("Fire") + itemAttributes.getRawBonusDamageMax("Holy")
                + itemAttributes.getRawBonusDamageMax("Lightning") + itemAttributes.getRawBonusDamageMax("Physical")
                + itemAttributes.getRawBonusDamageMax("Poison");
        }

        public static ItemValueRange getRawBonusDamageMax(this ItemAttributes itemAttributes, String resist, bool useDamageTypePercentBonus = true)
        {
            ItemValueRange result = itemAttributes.getAttributeByName("damageMin_" + resist) + itemAttributes.getAttributeByName("damageDelta_" + resist);

            if (useDamageTypePercentBonus && resist != "Physical")
                result += itemAttributes.getRawBonusDamageMax("Physical") * itemAttributes.getAttributeByName("damageTypePercentBonus_" + resist);

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
        /// Computes ambidextryWeapon attack speed (attack per second).
        /// </summary>
        /// <param name="gems"></param>
        /// <returns></returns>
        public static ItemValueRange getRawWeaponAttackPerSecond(this ItemAttributes itemAttr)
        {
            return itemAttr.getWeaponAttackPerSecond(ItemValueRange.Zero);
        }

        /// <summary>
        /// Computes raw ambidextryWeapon dps ie before all multipliers ( = average damage * attack per second )
        /// </summary>
        /// <param name="gems"></param>
        /// <returns></returns>
        public static ItemValueRange getRawWeaponDPS(this ItemAttributes itemAttr)
        {
            return itemAttr.getRawWeaponDamage() * itemAttr.getRawWeaponAttackPerSecond();
        }

        /// <summary>
        /// Computes ambidextryWeapon only damages
        /// </summary>
        /// <param name="gems"></param>
        /// <returns></returns>
        public static ItemValueRange getRawWeaponDamage(this ItemAttributes itemAttr)
        {
            // formula: ( min + max ) / 2
            return (itemAttr.getRawWeaponDamageMin() + itemAttr.getRawWeaponDamageMax()) / 2;
        }

        #region >> getRawWeaponDamageMin *

        public static ItemValueRange getRawWeaponDamageMin(this ItemAttributes itemAttr)
        {
            return itemAttr.getRawWeaponDamageMin("Arcane") + itemAttr.getRawWeaponDamageMin("Cold")
                + itemAttr.getRawWeaponDamageMin("Fire") + itemAttr.getRawWeaponDamageMin("Holy")
                + itemAttr.getRawWeaponDamageMin("Lightning") + itemAttr.getRawWeaponDamageMin("Physical")
                + itemAttr.getRawWeaponDamageMin("Poison");
        }

        public static ItemValueRange getRawWeaponDamageMin(this ItemAttributes itemAttr, String resist, bool useDamageTypePercentBonus = true)
        {
            ItemValueRange damage =
                (itemAttr.getAttributeByName("damageWeaponMin_" + resist) + itemAttr.getAttributeByName("damageWeaponBonusMin_" + resist) + itemAttr.getAttributeByName("damageWeaponBonusMinX1_" + resist))
                * (1 + itemAttr.getAttributeByName("damageWeaponPercentBonus_" + resist));

            if (useDamageTypePercentBonus && resist != "Physical")
                damage += itemAttr.getRawWeaponDamageMin("Physical") * itemAttr.getAttributeByName("damageTypePercentBonus_" + resist);

            return damage;
        }

        /// <summary>
        /// D3 Patch 1.0.7: new weapon min attribute added for Ruby Gems
        /// It is not increased by weapon multipliers nor taken into account for min>max comparison
        /// </summary>
        /// <param name="itemAttr"></param>
        /// <param name="resist"></param>
        /// <returns></returns>
        public static ItemValueRange getRawWeaponDamageMinX1(this ItemAttributes itemAttr, String resist)
        {
            ItemValueRange damageWeaponMinX1 = itemAttr.getAttributeByName("damageWeaponBonusMinX1_" + resist);

            return damageWeaponMinX1;
        }

        #endregion

        #region >> getRawWeaponDamageMax *

        public static ItemValueRange getRawWeaponDamageMax(this ItemAttributes itemAttr)
        {
            return itemAttr.getRawWeaponDamageMax("Arcane") + itemAttr.getRawWeaponDamageMax("Cold")
                + itemAttr.getRawWeaponDamageMax("Fire") + itemAttr.getRawWeaponDamageMax("Holy")
                + itemAttr.getRawWeaponDamageMax("Lightning") + itemAttr.getRawWeaponDamageMax("Physical")
                + itemAttr.getRawWeaponDamageMax("Poison");
        }

        public static ItemValueRange getRawWeaponDamageMax(this ItemAttributes itemAttr, String resist, bool useDamageTypePercentBonus = true)
        {
            ItemValueRange damage =
                (itemAttr.getAttributeByName("damageWeaponMin_" + resist) + itemAttr.getAttributeByName("damageWeaponDelta_" + resist) + itemAttr.getAttributeByName("damageWeaponBonusDelta_" + resist))
                * (ItemValueRange.One + itemAttr.getAttributeByName("damageWeaponPercentBonus_" + resist));

            if (useDamageTypePercentBonus && resist != "Physical")
                damage += itemAttr.getRawWeaponDamageMax("Physical") * itemAttr.getAttributeByName("damageTypePercentBonus_" + resist);

            return damage;
        }

        #endregion

        public static ItemValueRange getWeaponAttackPerSecond(this ItemAttributes itemAttr, ItemValueRange increaseFromOtherItems)
        {
            ItemValueRange weaponAttackSpeed = itemAttr.attacksPerSecondItem;

            weaponAttackSpeed *= 1 + itemAttr.attacksPerSecondItemPercent + increaseFromOtherItems;

            return weaponAttackSpeed;
        }

        #region >> checkAndUpdateWeaponDelta *

        /// <summary>
        /// Check a specific case of "invalid" ambidextryWeapon damage values:
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
        /// Informs if the gems is a Weapon based on its characteristics
        /// </summary>
        /// <param name="gems"></param>
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
                ItemValueRange rawWeaponDamageMin = itemAttr.getRawWeaponDamageMin(resist);
                ItemValueRange rawWeaponDamageDelta = itemAttr.getRawWeaponDamageMax(resist, false) - rawWeaponDamageMin;

                attr.setAttributeByName("damageWeaponMin_" + resist, rawWeaponDamageMin.nullIfZero());
                attr.setAttributeByName("damageWeaponDelta_" + resist, rawWeaponDamageDelta.nullIfZero());
                attr.setAttributeByName("damageWeaponBonusMin_" + resist, null);
                attr.setAttributeByName("damageWeaponBonusDelta_" + resist, null);
                attr.setAttributeByName("damageWeaponBonusMinX1_" + resist, null);
                attr.setAttributeByName("damageWeaponPercentBonus_" + resist, null);
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

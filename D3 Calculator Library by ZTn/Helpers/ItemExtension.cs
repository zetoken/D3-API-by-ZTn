using System;

using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Helpers
{
    /// <summary>
    /// Extension class to be used with <see cref="Item"/> objects
    /// </summary>
    public static class ItemExtension
    {
        private static readonly ItemValueRange half = new ItemValueRange(0.5);

        /// <summary>
        /// Computes armor brought by the item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static ItemValueRange getArmor(this Item item)
        {
            return item.attributesRaw.armorItem + item.attributesRaw.armorBonusItem;
        }

        /// <summary>
        /// Returns the value of an attribute of an item given the attribute's name
        /// </summary>
        /// <param name="item">Source item</param>
        /// <param name="fieldName">Name of the attribute to retrieve</param>
        /// <returns></returns>
        public static ItemValueRange getAttributeRangeByName(this Item item, String fieldName)
        {
            return (ItemValueRange)typeof(ItemAttributes).GetField(fieldName).GetValue(item.attributesRaw);
        }

        /// <summary>
        /// Computes damages other than ambidextryWeapon damages (on rings, amulets, ...)
        /// </summary>
        /// <param name="gems"></param>
        /// <returns></returns>
        public static ItemValueRange getRawBonusDamage(this Item item)
        {
            // formula: ( min + max ) / 2
            return (item.getRawBonusDamageMin() + item.getRawBonusDamageMax()) * half;
        }

        #region >> getRawBonusDamageMin *

        public static ItemValueRange getRawBonusDamageMin(this Item item)
        {
            return item.getRawBonusDamageMin("Arcane") + item.getRawBonusDamageMin("Cold") + item.getRawBonusDamageMin("Fire") + item.getRawBonusDamageMin("Holy")
                + item.getRawBonusDamageMin("Lightning") + item.getRawBonusDamageMin("Physical") + item.getRawBonusDamageMin("Poison");
        }

        public static ItemValueRange getRawBonusDamageMin(this Item item, String resist)
        {
            ItemValueRange damageMin = item.getAttributeRangeByName("damageMin_" + resist);
            ItemValueRange damageBonusMin = item.getAttributeRangeByName("damageBonusMin_" + resist);
            ItemValueRange damageTypePercentBonus = item.getAttributeRangeByName("damageTypePercentBonus_" + resist);

            ItemValueRange result = (damageMin + damageBonusMin);

            if (resist != "Physical")
                result += item.getRawBonusDamageMin("Physical") * damageTypePercentBonus;

            return (result == null ? ItemValueRange.Zero : result);
        }

        #endregion

        #region >> getRawBonusDamageMax *

        public static ItemValueRange getRawBonusDamageMax(this Item item)
        {
            return item.getRawBonusDamageMax("Arcane") + item.getRawBonusDamageMax("Cold") + item.getRawBonusDamageMax("Fire") + item.getRawBonusDamageMax("Holy")
                + item.getRawBonusDamageMax("Lightning") + item.getRawBonusDamageMax("Physical") + item.getRawBonusDamageMax("Poison");
        }

        public static ItemValueRange getRawBonusDamageMax(this Item item, String resist)
        {
            ItemValueRange damageMin = item.getAttributeRangeByName("damageMin_" + resist);
            ItemValueRange damageDelta = item.getAttributeRangeByName("damageDelta_" + resist);
            ItemValueRange damageTypePercentBonus = item.getAttributeRangeByName("damageTypePercentBonus_" + resist);

            ItemValueRange result = (damageMin + damageDelta);

            if (resist != "Physical")
                result += item.getRawBonusDamageMax("Physical") * damageTypePercentBonus;

            return (result == null ? ItemValueRange.Zero : result);
        }

        #endregion

        /// <summary>
        /// Returns the resistance value given by the gems for the given resist
        /// </summary>
        /// <param name="gems"></param>
        /// <param name="resist"></param>
        /// <returns></returns>
        public static double getResistance(this Item item, String resist)
        {
            ItemValueRange resistance = item.getAttributeRangeByName("resistance_" + resist);

            if (resistance == null)
                return 0;
            else
                return resistance.min;
        }

        /// <summary>
        /// Computes ambidextryWeapon attack speed (attack per second).
        /// </summary>
        /// <param name="gems"></param>
        /// <returns></returns>
        public static ItemValueRange getRawWeaponAttackPerSecond(this Item item)
        {
            return item.getWeaponAttackPerSecond(ItemValueRange.Zero);
        }

        /// <summary>
        /// Computes raw ambidextryWeapon dps ie before all multipliers ( = average thorns * attack per second )
        /// </summary>
        /// <param name="gems"></param>
        /// <returns></returns>
        public static ItemValueRange getRawWeaponDPS(this Item item)
        {
            return item.getRawWeaponDamage() * item.getRawWeaponAttackPerSecond();
        }

        /// <summary>
        /// Computes ambidextryWeapon only damages
        /// </summary>
        /// <param name="gems"></param>
        /// <returns></returns>
        public static ItemValueRange getRawWeaponDamage(this Item item)
        {
            // formula: ( min + max ) / 2
            return (item.getRawWeaponDamageMin() + item.getRawWeaponDamageMax()) * half;
        }

        #region >> getRawWeaponDamageMin *

        public static ItemValueRange getRawWeaponDamageMin(this Item item)
        {
            return item.getRawWeaponDamageMin("Arcane") + item.getRawWeaponDamageMin("Cold") + item.getRawWeaponDamageMin("Fire") + item.getRawWeaponDamageMin("Holy")
                + item.getRawWeaponDamageMin("Lightning") + item.getRawWeaponDamageMin("Physical") + item.getRawWeaponDamageMin("Poison");
        }

        public static ItemValueRange getRawWeaponDamageMin(this Item item, String resist)
        {
            ItemValueRange damageWeaponMin = item.getAttributeRangeByName("damageWeaponMin_" + resist);
            ItemValueRange damageWeaponBonusMin = item.getAttributeRangeByName("damageWeaponBonusMin_" + resist);
            ItemValueRange damageWeaponPercentBonus = item.getAttributeRangeByName("damageWeaponPercentBonus_" + resist);
            ItemValueRange damageTypePercentBonus = item.getAttributeRangeByName("damageTypePercentBonus_" + resist);

            ItemValueRange damage = (damageWeaponMin + damageWeaponBonusMin) * (ItemValueRange.One + damageWeaponPercentBonus);

            if (resist != "Physical")
                damage += item.getRawWeaponDamageMin("Physical") * damageTypePercentBonus;

            return damage;
        }

        /// <summary>
        /// D3 Patch 1.0.7: new weapon min attribute added for Ruby Gems
        /// It is not increased by weapon multipliers nor taken into account for min>max comparison
        /// </summary>
        /// <param name="item"></param>
        /// <param name="resist"></param>
        /// <returns></returns>
        public static ItemValueRange getRawWeaponDamageMinX1(this Item item, String resist)
        {
            ItemValueRange damageWeaponMinX1 = item.getAttributeRangeByName("damageWeaponMinX1_" + resist);

            return damageWeaponMinX1;
        }

        #endregion

        #region >> getRawWeaponDamageMax *

        public static ItemValueRange getRawWeaponDamageMax(this Item item)
        {
            return item.getRawWeaponDamageMax("Arcane") + item.getRawWeaponDamageMax("Cold") + item.getRawWeaponDamageMax("Fire") + item.getRawWeaponDamageMax("Holy")
                + item.getRawWeaponDamageMax("Lightning") + item.getRawWeaponDamageMax("Physical") + item.getRawWeaponDamageMax("Poison");
        }

        public static ItemValueRange getRawWeaponDamageMax(this Item item, String resist)
        {
            ItemValueRange damageWeaponMin = item.getAttributeRangeByName("damageWeaponMin_" + resist);
            ItemValueRange damageWeaponBonusMin = item.getAttributeRangeByName("damageWeaponBonusMin_" + resist);
            ItemValueRange damageWeaponDelta = item.getAttributeRangeByName("damageWeaponDelta_" + resist);
            ItemValueRange damageWeaponBonusDelta = item.getAttributeRangeByName("damageWeaponBonusDelta_" + resist);
            ItemValueRange damageWeaponPercentBonus = item.getAttributeRangeByName("damageWeaponPercentBonus_" + resist);
            ItemValueRange damageTypePercentBonus = item.getAttributeRangeByName("damageTypePercentBonus_" + resist);

            ItemValueRange damage = (damageWeaponMin + damageWeaponDelta + damageWeaponBonusDelta) * (ItemValueRange.One + damageWeaponPercentBonus);

            if (resist != "Physical")
                damage += item.getRawWeaponDamageMax("Physical") * damageTypePercentBonus;

            return damage;
        }

        #endregion

        public static ItemValueRange getWeaponAttackPerSecond(this Item item, ItemValueRange increaseFromOtherItems)
        {
            ItemValueRange weaponAttackSpeed = item.attributesRaw.attacksPerSecondItem;

            if (weaponAttackSpeed == null)
            {
                weaponAttackSpeed = ItemValueRange.Zero + increaseFromOtherItems;
            }
            else
            {
                weaponAttackSpeed *= (ItemValueRange.One + item.attributesRaw.attacksPerSecondItemPercent + increaseFromOtherItems);
            }

            return weaponAttackSpeed;
        }

        #region >> checkAndUpdateWeaponDelta *

        /// <summary>
        /// Check a specific case of "invalid" ambidextryWeapon damage values:
        /// If bonus min > delta, then delta should be replaced by bonus min + 1
        /// </summary>
        /// <param name="item"></param>
        public static Item checkAndUpdateWeaponDelta(this Item item)
        {
            return item
                .checkAndUpdateWeaponDelta("Arcane")
                .checkAndUpdateWeaponDelta("Cold")
                .checkAndUpdateWeaponDelta("Fire")
                .checkAndUpdateWeaponDelta("Holy")
                .checkAndUpdateWeaponDelta("Lightning")
                .checkAndUpdateWeaponDelta("Physical")
                .checkAndUpdateWeaponDelta("Poison");
        }

        /// <summary>
        /// Check a specific case of "invalid" ambidextryWeapon damage values (based on a specific resist):
        /// If bonus min > delta, then delta should be replaced by bonus min + 1
        /// </summary>
        /// <param name="item"></param>
        public static Item checkAndUpdateWeaponDelta(this Item item, String resist)
        {
            ItemValueRange damageWeaponBonusMin = item.getAttributeRangeByName("damageWeaponBonusMin_" + resist);
            ItemValueRange damageWeaponDelta = item.getAttributeRangeByName("damageWeaponDelta_" + resist);

            if ((damageWeaponDelta != null) && (damageWeaponBonusMin != null) && (damageWeaponDelta.min < damageWeaponBonusMin.min))
                damageWeaponDelta = damageWeaponBonusMin + ItemValueRange.One;
            item.setAttributeByName("damageWeaponDelta_" + resist, damageWeaponDelta);

            return item;
        }

        #endregion

        /// <summary>
        /// Informs if the gems is a ambidextryWeapon based on its characteristics
        /// </summary>
        /// <param name="gems"></param>
        /// <returns></returns>
        public static Boolean isWeapon(this Item item)
        {
            return (item.attributesRaw.attacksPerSecondItem != null);
        }

        /// <summary>
        /// Sets the value of an attribute of an item given the attribute's name
        /// </summary>
        /// <param name="item">Source item</param>
        /// <param name="fieldName">Name of the attribute to retrieve</param>
        /// <param name="value">Value to set</param>
        public static void setAttributeByName(this Item item, String fieldName, ItemValueRange value)
        {
            typeof(ItemAttributes).GetField(fieldName).SetValue(item.attributesRaw, value);
        }
    }
}

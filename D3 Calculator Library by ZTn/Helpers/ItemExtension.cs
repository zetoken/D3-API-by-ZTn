using System;
using System.Collections.Generic;
using System.Linq;
using ZTn.BNet.D3.Items;
using ZTn.BNet.D3.Calculator.Sets;

namespace ZTn.BNet.D3.Calculator.Helpers
{
    /// <summary>
    /// Extension class to be used with <see cref="Item"/> objects
    /// </summary>
    public static class ItemExtension
    {
        public static List<Set> getActivatedSets(this List<Item> items)
        {
            Dictionary<String, Set> itemsOfSets = new Dictionary<string, Set>();

            foreach (Set set in items.Where(item => item.set != null).Select(item => item.set))
            {
                if (!itemsOfSets.ContainsKey(set.slug))
                    itemsOfSets.Add(set.slug, set);
            }

            return itemsOfSets.Values.ToList();
        }

        public static ItemAttributes getActivatedSetBonus(this List<Item> items)
        {
            ItemAttributes attr = new ItemAttributes();

            foreach (Set set in items.getActivatedSets())
            {
                attr += set.getBonus(set.countItemsOfSet(items));
            }

            return attr;
        }

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
        public static ItemValueRange getAttributeByName(this Item item, String fieldName)
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
            return (item.getRawBonusDamageMin() + item.getRawBonusDamageMax()) / 2;
        }

        #region >> getRawBonusDamageMin *

        public static ItemValueRange getRawBonusDamageMin(this Item item)
        {
            return item.getRawBonusDamageMin("Arcane") + item.getRawBonusDamageMin("Cold") + item.getRawBonusDamageMin("Fire") + item.getRawBonusDamageMin("Holy")
                + item.getRawBonusDamageMin("Lightning") + item.getRawBonusDamageMin("Physical") + item.getRawBonusDamageMin("Poison");
        }

        public static ItemValueRange getRawBonusDamageMin(this Item item, String resist, bool useDamageTypePercentBonus = true)
        {
            ItemValueRange result = item.getAttributeByName("damageMin_" + resist) + item.getAttributeByName("damageBonusMin_" + resist);

            if (useDamageTypePercentBonus && resist != "Physical")
                result += item.getRawBonusDamageMin("Physical") * item.getAttributeByName("damageTypePercentBonus_" + resist);

            return result;
        }

        #endregion

        #region >> getRawBonusDamageMax *

        public static ItemValueRange getRawBonusDamageMax(this Item item)
        {
            return item.getRawBonusDamageMax("Arcane") + item.getRawBonusDamageMax("Cold") + item.getRawBonusDamageMax("Fire") + item.getRawBonusDamageMax("Holy")
                + item.getRawBonusDamageMax("Lightning") + item.getRawBonusDamageMax("Physical") + item.getRawBonusDamageMax("Poison");
        }

        public static ItemValueRange getRawBonusDamageMax(this Item item, String resist, bool useDamageTypePercentBonus = true)
        {
            ItemValueRange result = item.getAttributeByName("damageMin_" + resist) + item.getAttributeByName("damageDelta_" + resist);

            if (useDamageTypePercentBonus && resist != "Physical")
                result += item.getRawBonusDamageMax("Physical") * item.getAttributeByName("damageTypePercentBonus_" + resist);

            return result;
        }

        #endregion

        /// <summary>
        /// Returns the resistance value given by the gems for the given resist
        /// </summary>
        /// <param name="gems"></param>
        /// <param name="resist"></param>
        /// <returns></returns>
        public static ItemValueRange getResistance(this Item item, String resist)
        {
            return item.getAttributeByName("resistance_" + resist);
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
        /// Computes raw ambidextryWeapon dps ie before all multipliers ( = average damage * attack per second )
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
            return (item.getRawWeaponDamageMin() + item.getRawWeaponDamageMax()) / 2;
        }

        #region >> getRawWeaponDamageMin *

        public static ItemValueRange getRawWeaponDamageMin(this Item item)
        {
            return item.getRawWeaponDamageMin("Arcane") + item.getRawWeaponDamageMin("Cold") + item.getRawWeaponDamageMin("Fire") + item.getRawWeaponDamageMin("Holy")
                + item.getRawWeaponDamageMin("Lightning") + item.getRawWeaponDamageMin("Physical") + item.getRawWeaponDamageMin("Poison");
        }

        public static ItemValueRange getRawWeaponDamageMin(this Item item, String resist, bool useDamageTypePercentBonus = true)
        {
            ItemValueRange damage =
                (item.getAttributeByName("damageWeaponMin_" + resist) + item.getAttributeByName("damageWeaponBonusMin_" + resist) + item.getAttributeByName("damageWeaponBonusMinX1_" + resist))
                * (1 + item.getAttributeByName("damageWeaponPercentBonus_" + resist));

            if (useDamageTypePercentBonus && resist != "Physical")
                damage += item.getRawWeaponDamageMin("Physical") * item.getAttributeByName("damageTypePercentBonus_" + resist);

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
            ItemValueRange damageWeaponMinX1 = item.getAttributeByName("damageWeaponMinX1_" + resist);

            return damageWeaponMinX1;
        }

        #endregion

        #region >> getRawWeaponDamageMax *

        public static ItemValueRange getRawWeaponDamageMax(this Item item)
        {
            return item.getRawWeaponDamageMax("Arcane") + item.getRawWeaponDamageMax("Cold") + item.getRawWeaponDamageMax("Fire") + item.getRawWeaponDamageMax("Holy")
                + item.getRawWeaponDamageMax("Lightning") + item.getRawWeaponDamageMax("Physical") + item.getRawWeaponDamageMax("Poison");
        }

        public static ItemValueRange getRawWeaponDamageMax(this Item item, String resist, bool useDamageTypePercentBonus = true)
        {
            ItemValueRange damage =
                (item.getAttributeByName("damageWeaponMin_" + resist) + item.getAttributeByName("damageWeaponDelta_" + resist) + item.getAttributeByName("damageWeaponBonusDelta_" + resist))
                * (ItemValueRange.One + item.getAttributeByName("damageWeaponPercentBonus_" + resist));

            if (useDamageTypePercentBonus && resist != "Physical")
                damage += item.getRawWeaponDamageMax("Physical") * item.getAttributeByName("damageTypePercentBonus_" + resist);

            return damage;
        }

        #endregion

        public static ItemValueRange getWeaponAttackPerSecond(this Item item, ItemValueRange increaseFromOtherItems)
        {
            ItemValueRange weaponAttackSpeed = item.attributesRaw.attacksPerSecondItem;

            weaponAttackSpeed *= 1 + item.attributesRaw.attacksPerSecondItemPercent + increaseFromOtherItems;

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
            ItemValueRange damageWeaponBonusMin = item.getAttributeByName("damageWeaponBonusMin_" + resist);
            ItemValueRange damageWeaponDelta = item.getAttributeByName("damageWeaponDelta_" + resist);

            // Check "black weapon bug"
            if ((damageWeaponDelta != null) && (damageWeaponBonusMin != null) && (damageWeaponDelta.min < damageWeaponBonusMin.min))
                damageWeaponDelta = damageWeaponBonusMin + 1;

            // Store new values
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

        /// <summary>
        /// Updates the <paramref name="item"/> by aggregating some raw attributes for easier editing for example.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>The <paramref name="item"/> instance.</returns>
        public static Item simplifyItem(this Item item)
        {
            ItemAttributes attr = new ItemAttributes(item.attributesRaw);

            List<String> resists = new List<string>() { "Arcane", "Cold", "Fire", "Holy", "Lightning", "Physical", "Poison" };

            // Characteristics
            attr.armorItem = item.getArmor();
            attr.armorBonusItem = null;

            // Weapon characterics
            attr.attacksPerSecondItem = item.getRawWeaponAttackPerSecond();
            attr.attacksPerSecondItemPercent = null;

            item.checkAndUpdateWeaponDelta();

            foreach (string resist in resists)
            {
                ItemValueRange rawWeaponDamageMin = item.getRawWeaponDamageMin(resist);
                attr.setAttributeByName("damageWeaponMin_" + resist, rawWeaponDamageMin);
                attr.setAttributeByName("damageWeaponDelta_" + resist, item.getRawWeaponDamageMax(resist, false) - rawWeaponDamageMin);
                attr.setAttributeByName("damageWeaponBonusDelta_" + resist, null);
                attr.setAttributeByName("damageWeaponBonusMinX1_" + resist, null);
                attr.setAttributeByName("damageWeaponPercentBonus_" + resist, null);
            }

            // Item damage bonuses
            foreach (string resist in resists)
            {
                ItemValueRange rawDamageMin = item.getRawBonusDamageMin(resist);
                attr.setAttributeByName("damageMin_" + resist, rawDamageMin);
                attr.setAttributeByName("damageDelta_" + resist, item.getRawBonusDamageMax(resist, false) - rawDamageMin);
                attr.setAttributeByName("damageBonusMin_" + resist, null);
            }

            item.attributesRaw = attr;

            return item;
        }
    }
}

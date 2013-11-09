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
        #region >> Reflection Helpers

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
        /// Sets the value of an attribute of an item given the attribute's name
        /// </summary>
        /// <param name="item">Source item</param>
        /// <param name="fieldName">Name of the attribute to retrieve</param>
        /// <param name="value">Value to set</param>
        public static void setAttributeByName(this Item item, String fieldName, ItemValueRange value)
        {
            typeof(ItemAttributes).GetField(fieldName).SetValue(item.attributesRaw, value);
        }

        #endregion

        /// <summary>
        /// Computes the list of <see cref="Set"/> actually worn.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Computes the <see cref=" ItemAttributes"/> brought by the set bonuses.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
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
            return item.attributesRaw.getArmor();
        }

        /// <summary>
        /// Computes damages other than weapon damages (on rings, amulets, ...)
        /// </summary>
        /// <param name="gems"></param>
        /// <returns></returns>
        public static ItemValueRange getRawAverageBonusDamage(this Item item)
        {
            return item.attributesRaw.getRawAverageBonusDamage();
        }

        #region >> getRawBonusDamageMin *

        public static ItemValueRange getRawBonusDamageMin(this Item item)
        {
            return item.attributesRaw.getRawBonusDamageMin();
        }

        public static ItemValueRange getRawBonusDamageMin(this Item item, String resist, bool useDamageTypePercentBonus = true)
        {
            return item.attributesRaw.getRawBonusDamageMin(resist, useDamageTypePercentBonus);
        }

        #endregion

        #region >> getRawBonusDamageMax *

        public static ItemValueRange getRawBonusDamageMax(this Item item)
        {
            return item.attributesRaw.getRawBonusDamageMax();
        }

        public static ItemValueRange getRawBonusDamageMax(this Item item, String resist)
        {
            return item.attributesRaw.getRawBonusDamageMax(resist);
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
            return item.attributesRaw.getAttributeByName("resistance_" + resist);
        }

        /// <summary>
        /// Computes weapon attack speed (attack per second).
        /// </summary>
        /// <param name="gems"></param>
        /// <returns></returns>
        public static ItemValueRange getRawWeaponAttackPerSecond(this Item item)
        {
            return item.attributesRaw.getRawWeaponAttackPerSecond();
        }

        /// <summary>
        /// Computes raw weapon dps ie before all multipliers ( = average damage * attack per second )
        /// </summary>
        /// <param name="gems"></param>
        /// <returns></returns>
        public static ItemValueRange getRawWeaponDPS(this Item item)
        {
            return item.attributesRaw.getRawWeaponDPS();
        }

        /// <summary>
        /// Computes weapon only damages
        /// </summary>
        /// <param name="gems"></param>
        /// <returns></returns>
        public static ItemValueRange getRawAverageWeaponDamage(this Item item)
        {
            return item.attributesRaw.getRawAverageWeaponDamage();
        }

        #region >> getRawWeaponDamageMin *

        public static ItemValueRange getRawWeaponDamageMin(this Item item)
        {
            return item.attributesRaw.getRawWeaponDamageMin();
        }

        public static ItemValueRange getRawWeaponDamageMin(this Item item, String resist, bool useDamageTypePercentBonus = true)
        {
            return item.attributesRaw.getRawWeaponDamageMin(resist, useDamageTypePercentBonus);
        }

        #endregion

        #region >> getRawWeaponDamageMax *

        public static ItemValueRange getRawWeaponDamageMax(this Item item)
        {
            return item.attributesRaw.getRawWeaponDamageMax();
        }

        public static ItemValueRange getRawWeaponDamageMax(this Item item, String resist, bool useDamageTypePercentBonus = true)
        {
            return item.attributesRaw.getRawWeaponDamageMax(resist, useDamageTypePercentBonus);
        }

        #endregion

        public static ItemValueRange getWeaponAttackPerSecond(this Item item, ItemValueRange increaseFromOtherItems)
        {
            return item.attributesRaw.getWeaponAttackPerSecond(increaseFromOtherItems);
        }

        #region >> checkAndUpdateWeaponDelta *

        /// <summary>
        /// Check a specific case of "invalid" weapon damage values:
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
        /// Check a specific case of "invalid" weapon damage values (based on a specific resist):
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

        #region >> isItemType*

        public static Boolean isItemTypeHelm(this Item item)
        {
            return ItemHelper.helmTypeIds.Any(id => item.id.Contains(id));
        }

        public static Boolean isItemTypeWeapon(this Item item)
        {
            return ItemHelper.weaponTypeIds.Any(id => item.id == id);
        }

        public static Boolean isItemTypeOther(this Item item)
        {
            return !item.isItemTypeHelm() && !item.isWeapon();
        }

        #endregion

        /// <summary>
        /// Informs if the gems is a weapon based on its characteristics
        /// </summary>
        /// <param name="gems"></param>
        /// <returns></returns>
        public static Boolean isWeapon(this Item item)
        {
            return item.attributesRaw.isWeapon();
        }

        /// <summary>
        /// Merge socketed gems in the <paramref name="item"/>.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Item mergeSocketedGems(this Item item)
        {
            foreach (SocketedGem gem in item.gems)
            {
                item.attributesRaw += gem.attributesRaw;
            }
            item.gems = null;

            return item;
        }

        /// <summary>
        /// Simplifies the <paramref name="item"/> by aggregating some raw attributes (for easier editing for example).
        /// </summary>
        /// <param name="item"></param>
        /// <returns>The <paramref name="item"/> instance.</returns>
        public static Item simplify(this Item item)
        {
            ItemAttributes attr = item.attributesRaw.getSimplified();

            // Set new attributes to item
            item.attributesRaw = attr;

            return item.UpdateStats();
        }

        /// <summary>
        /// Updates some general <paramref name="item"/> stats based on its attributesRaw.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Item UpdateStats(this Item item)
        {
            ItemAttributes attr = item.attributesRaw;

            // Update some item stats
            item.armor = (attr.armorItem == null ? null : new ItemValueRange(attr.armorItem));
            item.attacksPerSecond = (attr.attacksPerSecondItem == null ? null : new ItemValueRange(attr.attacksPerSecondItem));
            item.minDamage = item.getRawWeaponDamageMin().nullIfZero();
            item.maxDamage = item.getRawWeaponDamageMax().nullIfZero();
            item.dps = item.getRawWeaponDPS().nullIfZero();

            return item;
        }
    }
}

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
        public static ItemValueRange GetAttributeByName(this Item item, String fieldName)
        {
            return (ItemValueRange)typeof(ItemAttributes).GetField(fieldName).GetValue(item.attributesRaw);
        }

        /// <summary>
        /// Sets the value of an attribute of an item given the attribute's name
        /// </summary>
        /// <param name="item">Source item</param>
        /// <param name="fieldName">Name of the attribute to retrieve</param>
        /// <param name="value">Value to set</param>
        public static void SetAttributeByName(this Item item, String fieldName, ItemValueRange value)
        {
            typeof(ItemAttributes).GetField(fieldName).SetValue(item.attributesRaw, value);
        }

        #endregion

        /// <summary>
        /// Computes the list of <see cref="Set"/> actually worn.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static List<Set> GetActivatedSets(this List<Item> items)
        {
            var itemsOfSets = new Dictionary<string, Set>();

            foreach (var set in items.Where(item => item.set != null).Select(item => item.set))
            {
                if (!itemsOfSets.ContainsKey(set.slug))
                {
                    itemsOfSets.Add(set.slug, set);
                }
            }

            return itemsOfSets.Values.ToList();
        }

        /// <summary>
        /// Computes the <see cref=" ItemAttributes"/> brought by the set bonuses.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static ItemAttributes GetActivatedSetBonus(this List<Item> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            return items.GetActivatedSets().Aggregate(new ItemAttributes(), (current, set) => current + set.GetBonus(set.CountItemsOfSet(items)));
        }

        /// <summary>
        /// Computes armor brought by the item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static ItemValueRange GetArmor(this Item item)
        {
            return item.attributesRaw.GetArmor();
        }

        /// <summary>
        /// Computes damages other than weapon damages (on rings, amulets, ...)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static ItemValueRange GetRawAverageBonusDamage(this Item item)
        {
            return item.attributesRaw.GetRawAverageBonusDamage();
        }

        #region >> getRawBonusDamageMin *

        public static ItemValueRange GetRawBonusDamageMin(this Item item)
        {
            return item.attributesRaw.GetRawBonusDamageMin();
        }

        public static ItemValueRange GetRawBonusDamageMin(this Item item, String resist, bool useDamageTypePercentBonus = true)
        {
            return item.attributesRaw.GetRawBonusDamageMin(resist, useDamageTypePercentBonus);
        }

        #endregion

        #region >> getRawBonusDamageMax *

        public static ItemValueRange GetRawBonusDamageMax(this Item item)
        {
            return item.attributesRaw.GetRawBonusDamageMax();
        }

        public static ItemValueRange GetRawBonusDamageMax(this Item item, String resist)
        {
            return item.attributesRaw.GetRawBonusDamageMax(resist);
        }

        #endregion

        /// <summary>
        /// Returns the resistance value given by the gems for the given resist
        /// </summary>
        /// <param name="item"></param>
        /// <param name="resist"></param>
        /// <returns></returns>
        public static ItemValueRange GetResistance(this Item item, String resist)
        {
            return item.attributesRaw.GetAttributeByName("resistance_" + resist);
        }

        /// <summary>
        /// Computes weapon attack speed (attack per second).
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static ItemValueRange GetRawWeaponAttackPerSecond(this Item item)
        {
            return item.attributesRaw.GetRawWeaponAttackPerSecond();
        }

        /// <summary>
        /// Computes raw weapon dps ie before all multipliers ( = average damage * attack per second )
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static ItemValueRange GetRawWeaponDps(this Item item)
        {
            return item.attributesRaw.GetRawWeaponDps();
        }

        /// <summary>
        /// Computes weapon only damages
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static ItemValueRange GetRawAverageWeaponDamage(this Item item)
        {
            return item.attributesRaw.GetRawAverageWeaponDamage();
        }

        #region >> getRawWeaponDamageMin *

        public static ItemValueRange GetRawWeaponDamageMin(this Item item)
        {
            return item.attributesRaw.GetRawWeaponDamageMin();
        }

        public static ItemValueRange GetRawWeaponDamageMin(this Item item, String resist, bool useDamageTypePercentBonus = true)
        {
            return item.attributesRaw.GetRawWeaponDamageMin(resist, useDamageTypePercentBonus);
        }

        #endregion

        #region >> getRawWeaponDamageMax *

        public static ItemValueRange GetRawWeaponDamageMax(this Item item)
        {
            return item.attributesRaw.GetRawWeaponDamageMax();
        }

        public static ItemValueRange GetRawWeaponDamageMax(this Item item, String resist, bool useDamageTypePercentBonus = true)
        {
            return item.attributesRaw.GetRawWeaponDamageMax(resist, useDamageTypePercentBonus);
        }

        #endregion

        public static ItemValueRange GetWeaponAttackPerSecond(this Item item, ItemValueRange increaseFromOtherItems)
        {
            return item.attributesRaw.GetWeaponAttackPerSecond(increaseFromOtherItems);
        }

        #region >> checkAndUpdateWeaponDelta *

        /// <summary>
        /// Check a specific case of "invalid" weapon damage values:
        /// If bonus min > delta, then delta should be replaced by bonus min + 1
        /// </summary>
        /// <param name="item"></param>
        public static Item CheckAndUpdateWeaponDelta(this Item item)
        {
            return item
                .CheckAndUpdateWeaponDelta("Arcane")
                .CheckAndUpdateWeaponDelta("Cold")
                .CheckAndUpdateWeaponDelta("Fire")
                .CheckAndUpdateWeaponDelta("Holy")
                .CheckAndUpdateWeaponDelta("Lightning")
                .CheckAndUpdateWeaponDelta("Physical")
                .CheckAndUpdateWeaponDelta("Poison");
        }

        /// <summary>
        /// Check a specific case of "invalid" weapon damage values (based on a specific resist):
        /// If bonus min > delta, then delta should be replaced by bonus min + 1
        /// </summary>
        /// <param name="item"></param>
        /// <param name="resist"></param>
        public static Item CheckAndUpdateWeaponDelta(this Item item, String resist)
        {
            var damageWeaponBonusMin = item.GetAttributeByName("damageWeaponBonusMin_" + resist);
            var damageWeaponDelta = item.GetAttributeByName("damageWeaponDelta_" + resist);

            // Check "black weapon bug"
            if ((damageWeaponDelta != null) && (damageWeaponBonusMin != null) && (damageWeaponDelta.Min < damageWeaponBonusMin.Min))
                damageWeaponDelta = damageWeaponBonusMin + 1;

            // Store new values
            item.SetAttributeByName("damageWeaponDelta_" + resist, damageWeaponDelta);

            return item;
        }

        #endregion

        #region >> isItemType*

        public static Boolean IsItemTypeHelm(this Item item)
        {
            return ItemHelper.HelmTypeIds.Any(id => item.id.Contains(id));
        }

        public static Boolean IsItemTypeWeapon(this Item item)
        {
            return ItemHelper.WeaponTypeIds.Any(id => item.id == id);
        }

        public static Boolean IsItemTypeOther(this Item item)
        {
            return !item.IsItemTypeHelm() && !item.IsWeapon();
        }

        #endregion

        /// <summary>
        /// Informs if the gems is a weapon based on its characteristics
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Boolean IsWeapon(this Item item)
        {
            return item.attributesRaw.IsWeapon();
        }

        /// <summary>
        /// Merge socketed gems in the <paramref name="item"/>.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Item MergeSocketedGems(this Item item)
        {
            item.attributesRaw += item.gems.Aggregate(new ItemAttributes(), (current, gem) => current + gem.attributesRaw);

            item.gems = null;

            return item;
        }

        /// <summary>
        /// Simplifies the <paramref name="item"/> by aggregating some raw attributes (for easier editing for example).
        /// </summary>
        /// <param name="item"></param>
        /// <returns>The <paramref name="item"/> instance.</returns>
        public static Item Simplify(this Item item)
        {
            var attr = item.attributesRaw.GetSimplified();

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
            var attr = item.attributesRaw;

            // Update some item stats
            item.armor = (attr.armorItem == null ? null : new ItemValueRange(attr.armorItem));
            item.attacksPerSecond = (attr.attacksPerSecondItem == null ? null : new ItemValueRange(attr.attacksPerSecondItem));
            item.minDamage = item.GetRawWeaponDamageMin().NullIfZero();
            item.maxDamage = item.GetRawWeaponDamageMax().NullIfZero();
            item.dps = item.GetRawWeaponDps().NullIfZero();

            return item;
        }
    }
}

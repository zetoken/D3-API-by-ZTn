using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ZTn.BNet.D3.Calculator.Sets;
using ZTn.BNet.D3.Helpers;
using ZTn.BNet.D3.Items;

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
            return (ItemValueRange)typeof(ItemAttributes).GetTypeInfo().GetDeclaredField(fieldName).GetValue(item.AttributesRaw);
        }

        /// <summary>
        /// Sets the value of an attribute of an item given the attribute's name
        /// </summary>
        /// <param name="item">Source item</param>
        /// <param name="fieldName">Name of the attribute to retrieve</param>
        /// <param name="value">Value to set</param>
        public static Item SetAttributeByName(this Item item, String fieldName, ItemValueRange value)
        {
            typeof(ItemAttributes).GetTypeInfo().GetDeclaredField(fieldName).SetValue(item.AttributesRaw, value);

            return item;
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

            foreach (var set in items.Where(item => item.Set != null).Select(item => item.Set).Where(set => !itemsOfSets.ContainsKey(set.slug)))
            {
                itemsOfSets.Add(set.slug, set);
            }

            return itemsOfSets.Values.ToList();
        }

        /// <summary>
        /// Computes the <see cref="ItemAttributes"/> brought by the set bonuses.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static ItemAttributes GetActivatedSetBonus(this List<Item> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            var attributeSetItemDiscount = items
                .Select(i => i.AttributesRaw.AttributeSetItemDiscount)
                .Where(asid => asid != null)
                .Aggregate(ItemValueRange.Zero, (asid, current) => current + asid);

            var result = new ItemAttributes();
            foreach (var set in items.GetActivatedSets())
            {
                var setItemsCount = set.CountItemsOfSet(items);
                if (setItemsCount >= 2)
                {
                    setItemsCount += (int)Math.Round(attributeSetItemDiscount.Min);
                }
                result += set.GetBonus(setItemsCount);
            }

            return result;
        }

        /// <summary>
        /// Computes armor brought by the item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static ItemValueRange GetArmor(this Item item)
        {
            return item.AttributesRaw.GetArmor();
        }

        /// <summary>
        /// Computes damages other than weapon damages (on rings, amulets, ...)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static ItemValueRange GetRawAverageBonusDamage(this Item item)
        {
            return item.AttributesRaw.GetRawAverageBonusDamage();
        }

        public static ItemValueRange GetRawBonusDamageMin(this Item item)
        {
            return item.AttributesRaw.GetRawBonusDamageMin();
        }

        public static ItemValueRange GetRawBonusDamageMax(this Item item)
        {
            return item.AttributesRaw.GetRawBonusDamageMax();
        }

        /// <summary>
        /// Returns the resistance value given by the gems for the given resist
        /// </summary>
        /// <param name="item"></param>
        /// <param name="resist"></param>
        /// <returns></returns>
        public static ItemValueRange GetResistance(this Item item, String resist)
        {
            return item.AttributesRaw.GetAttributeByName("resistance_" + resist);
        }

        /// <summary>
        /// Computes weapon attack speed (attack per second).
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static ItemValueRange GetRawWeaponAttackPerSecond(this Item item)
        {
            return item.AttributesRaw.GetRawWeaponAttackPerSecond();
        }

        /// <summary>
        /// Computes raw weapon dps ie before all multipliers ( = average damage * attack per second )
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static ItemValueRange GetRawWeaponDps(this Item item)
        {
            return item.AttributesRaw.GetRawWeaponDps();
        }

        /// <summary>
        /// Computes weapon only damages
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static ItemValueRange GetRawAverageWeaponDamage(this Item item)
        {
            return item.AttributesRaw.GetRawAverageWeaponDamage();
        }

        public static ItemValueRange GetRawWeaponDamageMin(this Item item)
        {
            return item.AttributesRaw.GetRawWeaponDamageMin();
        }

        public static ItemValueRange GetRawWeaponDamageMax(this Item item)
        {
            return item.AttributesRaw.GetRawWeaponDamageMax();
        }

        public static ItemValueRange GetWeaponAttackPerSecond(this Item item, ItemValueRange increaseFromOtherItems)
        {
            return item.AttributesRaw.GetWeaponAttackPerSecond(increaseFromOtherItems);
        }

        /// <summary>
        /// Check a specific case of "invalid" weapon damage values:
        /// If bonus min > delta, then delta should be replaced by bonus min + 1
        /// </summary>
        /// <param name="item"></param>
        public static Item CheckAndUpdateWeaponDelta(this Item item)
        {
            item.AttributesRaw.CheckAndUpdateWeaponDelta();

            return item;
        }

        #region >> isItemType*

        public static Boolean IsItemTypeHelm(this Item item)
        {
            return ItemHelper.HelmTypeIds.Any(id => item.Id.Contains(id));
        }

        public static Boolean IsItemTypeWeapon(this Item item)
        {
            return ItemHelper.WeaponTypeIds.Any(id => item.Id == id);
        }

        public static Boolean IsItemTypeOther(this Item item)
        {
            return !item.IsItemTypeHelm() && !item.IsWeapon();
        }

        #endregion

        /// <summary>
        /// Informs if the item is ancient based on its attributes.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool IsAncient(this Item item)
        {
            return item.AttributesRaw.IsAncient();
        }

        /// <summary>
        /// Informs if the item is a legendary jewel based on its attributes.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool IsJewel(this Item item)
        {
            return item.AttributesRaw.IsJewel();
        }

        /// <summary>
        /// Informs if the item is a weapon based on its characteristics
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool IsWeapon(this Item item)
        {
            return item.AttributesRaw.IsWeapon();
        }

        /// <summary>
        /// Merge socketed gems in the <paramref name="item"/>.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Item MergeSocketedGems(this Item item)
        {
            item.AttributesRaw += item.Gems.Select(g => g.AttributesRaw).Sum();

            item.Gems = null;

            return item;
        }

        /// <summary>
        /// Simplifies the <paramref name="item"/> by aggregating some raw attributes (for easier editing for example).
        /// </summary>
        /// <param name="item"></param>
        /// <returns>The <paramref name="item"/> instance.</returns>
        public static Item Simplify(this Item item)
        {
            var attr = item.AttributesRaw.GetSimplified();

            // Set new attributes to item
            item.AttributesRaw = attr;

            return item.UpdateStats();
        }

        /// <summary>
        /// Updates some general <paramref name="item"/> stats based on its attributesRaw.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Item UpdateStats(this Item item)
        {
            var attr = item.AttributesRaw;

            // Update some item stats
            item.Armor = (attr.armorItem == null ? null : new ItemValueRange(attr.armorItem));
            item.AttacksPerSecond = (attr.attacksPerSecondItem == null ? null : new ItemValueRange(attr.attacksPerSecondItem));
            item.MinDamage = item.GetRawWeaponDamageMin().NullIfZero();
            item.MaxDamage = item.GetRawWeaponDamageMax().NullIfZero();
            item.Dps = item.GetRawWeaponDps().NullIfZero();

            return item;
        }
    }
}
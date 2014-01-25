using System;
using System.Collections.Generic;
using System.Linq;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Sets
{
    public static class SetExtension
    {
        /// <summary>
        /// Returns final bonus the <paramref name="set"/> give when <paramref name="count"/> items from the set are weared
        /// </summary>
        /// <param name="set"></param>
        /// <param name="count">Number of items from set weared</param>
        /// <returns></returns>
        public static ItemAttributes GetBonus(this Set set, int count)
        {
            var attr = new ItemAttributes();

            if (count > 1)
            {
                attr = set.ranks
                    .Where(rank => count >= rank.required)
                    .Aggregate(attr, (current, setRank) => current + setRank.attributesRaw);
            }

            return attr;
        }

        /// <summary>
        /// Returns final attributes description (string[]) the <paramref name="set"/> give when <paramref name="count"/> items from the set are weared
        /// </summary>
        /// <param name="set"></param>
        /// <param name="count">Number of items from set weared</param>
        /// <returns></returns>
        public static String[] GetBonusAttributes(this Set set, int count)
        {
            var attributes = new List<string>();

            if (count > 1)
            {
                foreach (var setRank in set.ranks.Where(rank => count >= rank.required))
                    attributes.AddRange(setRank.attributes);
            }

            return attributes.ToArray();
        }

        /// <summary>
        /// Returns the list of <c>id</c> of all of the items from the <paramref name="set"/>
        /// </summary>
        /// <param name="set"></param>
        /// <returns></returns>
        public static List<String> GetSetItemIds(this Set set)
        {
            return set.items.Select(item => item.id).ToList();
        }

        public static List<Item> FindItemsOfSet(this Set set, List<Item> items)
        {
            var setItemIds = set.GetSetItemIds();

            return items.Where(item => setItemIds.IndexOf(item.id) != -1).ToList();
        }

        public static List<ItemSummary> FindItemsOfSet(this Set set, List<ItemSummary> items)
        {
            var setItemIds = set.GetSetItemIds();

            return items.Where(item => setItemIds.IndexOf(item.id) != -1).ToList();
        }

        public static int CountItemsOfSet(this Set set, List<Item> items)
        {
            return set.FindItemsOfSet(items).Count;
        }

        public static int CountItemsOfSet(this Set set, List<ItemSummary> items)
        {
            return set.FindItemsOfSet(items).Count;
        }
    }
}

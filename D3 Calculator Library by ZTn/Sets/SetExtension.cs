using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public static ItemAttributes getBonus(this Set set, int count)
        {
            ItemAttributes attr = new ItemAttributes();

            if (count > 1)
            {
                foreach (SetRank setRank in set.ranks.Where(rank => count >= rank.required))
                    attr += setRank.attributesRaw;
            }

            return attr;
        }

        /// <summary>
        /// Returns final attributes description (string[]) the <paramref name="set"/> give when <paramref name="count"/> items from the set are weared
        /// </summary>
        /// <param name="set"></param>
        /// <param name="count">Number of items from set weared</param>
        /// <returns></returns>
        public static String[] getBonusAttributes(this Set set, int count)
        {
            List<String> attributes = new List<string>();

            if (count > 1)
            {
                foreach (SetRank setRank in set.ranks.Where(rank => count >= rank.required))
                    attributes.AddRange(setRank.attributes);
            }

            return attributes.ToArray();
        }

        /// <summary>
        /// Returns the list of <c>id</c> of all of the items from the <paramref name="set"/>
        /// </summary>
        /// <param name="set"></param>
        /// <returns></returns>
        public static List<String> getSetItemIds(this Set set)
        {
            return set.items.Select(item => item.id).ToList();
        }

        public static List<Item> findItemsOfSet(this Set set, List<Item> items)
        {
            List<String> setItemIds = set.getSetItemIds();

            return items.Where(item => setItemIds.IndexOf(item.id) != -1).ToList();
        }

        public static List<ItemSummary> findItemsOfSet(this Set set, List<ItemSummary> items)
        {
            List<String> setItemIds = set.getSetItemIds();

            return items.Where(item => setItemIds.IndexOf(item.id) != -1).ToList(); ;
        }

        public static int countItemsOfSet(this Set set, List<Item> items)
        {
            return set.findItemsOfSet(items).Count;
        }

        public static int countItemsOfSet(this Set set, List<ItemSummary> items)
        {
            return set.findItemsOfSet(items).Count;
        }
    }
}

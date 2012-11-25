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
                foreach (SetRank setRank in set.ranks)
                {
                    if (count >= setRank.required)
                        attr += setRank.attributesRaw;
                }
            }

            return attr;
        }

        /// <summary>
        /// Returns the list of <c>id</c> of all of the items from the <paramref name="set"/>
        /// </summary>
        /// <param name="set"></param>
        /// <returns></returns>
        public static List<String> getSetItemIds(this Set set)
        {
            List<String> setItemIds = new List<string>();
            foreach (ItemSummary setItem in set.items)
            {
                setItemIds.Add(setItem.id);
            }
            return setItemIds;
        }

        public static List<Item> findItemsOfSet(this Set set, List<Item> items)
        {
            List<Item> setItemsFound = new List<Item>();
            List<String> setItemIds = set.getSetItemIds();

            foreach (Item item in items)
            {
                if (setItemIds.IndexOf(item.id) != -1)
                    setItemsFound.Add(item);
            }

            return setItemsFound;
        }

        public static List<ItemSummary> findItemsOfSet(this Set set, List<ItemSummary> items)
        {
            List<ItemSummary> setItemsFound = new List<ItemSummary>();
            List<String> setItemIds = set.getSetItemIds();

            foreach (Item item in items)
            {
                if (setItemIds.IndexOf(item.id) != -1)
                    setItemsFound.Add(item);
            }

            return setItemsFound;
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ZTn.BNet.D3.Items;
using ZTn.BNet.D3.Helpers;

namespace ZTn.BNet.D3.Calculator.Sets
{
    [DataContract]
    public class KnownSets
    {
        #region >> Fields

        [DataMember]
        public Set[] sets;

        #endregion

        #region >> Constructors

        public KnownSets(Set[] sets)
        {
            this.sets = sets;
        }

        #endregion

        public ItemAttributes getActivatedSetBonus(List<Item> items)
        {
            ItemAttributes attr = new ItemAttributes();

            foreach (Set set in sets)
            {
                attr += set.getBonus(set.countItemsOfSet(items));
            }

            return attr;
        }

        public ItemAttributes getActivatedSetBonus(List<ItemSummary> items)
        {
            ItemAttributes attr = new ItemAttributes();

            foreach (Set set in sets)
            {
                attr += set.getBonus(set.countItemsOfSet(items));
            }

            return attr;
        }

        public static KnownSets getKnownSetsFromJSonStream(Stream stream)
        {
            Set[] sets = JsonHelpers.getFromJSonStream<Set[]>(stream);
            return new KnownSets(sets);
        }

        public static KnownSets getKnownSetsFromJSonString(String json)
        {
            Set[] sets = JsonHelpers.getFromJSonString<Set[]>(json);
            return new KnownSets(sets);
        }

        public static KnownSets getKnownSetsFromJsonFile(String fileName)
        {
            Set[] sets = JsonHelpers.getFromJsonFile<Set[]>(fileName);
            return new KnownSets(sets);
        }
    }
}

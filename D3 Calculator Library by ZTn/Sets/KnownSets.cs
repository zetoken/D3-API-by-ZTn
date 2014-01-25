using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using ZTn.BNet.D3.Items;
using ZTn.BNet.D3.Helpers;

namespace ZTn.BNet.D3.Calculator.Sets
{
    [DataContract]
    public class KnownSets
    {
        #region >> Fields

        [DataMember]
        public Set[] Sets;

        #endregion

        #region >> Constructors

        public KnownSets(Set[] sets)
        {
            Sets = sets;
        }

        #endregion

        public ItemAttributes GetActivatedSetBonus(List<Item> items)
        {
            var attr = new ItemAttributes();

            foreach (var set in Sets)
            {
                attr += set.GetBonus(set.CountItemsOfSet(items));
            }

            return attr;
        }

        public ItemAttributes GetActivatedSetBonus(List<ItemSummary> items)
        {
            var attr = new ItemAttributes();

            foreach (var set in Sets)
            {
                attr += set.GetBonus(set.CountItemsOfSet(items));
            }

            return attr;
        }

        public static KnownSets CreateFromJSonStream(Stream stream)
        {
            var sets = stream.CreateFromJsonStream<Set[]>();
            return new KnownSets(sets);
        }

        public static KnownSets CreateFromJSonString(String json)
        {
            var sets = json.CreateFromJsonString<Set[]>();
            return new KnownSets(sets);
        }

        public static KnownSets CreateFromJsonFile(String fileName)
        {
            var sets = fileName.CreateFromJsonFile<Set[]>();
            return new KnownSets(sets);
        }
    }
}

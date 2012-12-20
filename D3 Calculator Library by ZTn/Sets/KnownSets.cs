using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ZTn.BNet.D3.Items;

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
            JsonSerializer serializer = new JsonSerializer();
            Set[] sets;
            using (StreamReader streamReader = new StreamReader(stream))
            {
                sets = (Set[])serializer.Deserialize(streamReader, typeof(Set[]));
            }
            return new KnownSets(sets);
        }

        public static KnownSets getKnownSetsFromJSonString(String json)
        {
            KnownSets knownSets;
            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.Default.GetBytes(json)))
            {
                knownSets = getKnownSetsFromJSonStream(stream);
            }
            return knownSets;
        }

        public static KnownSets getKnownSetsFromJsonFile(String fileName)
        {
            KnownSets knownSets;
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                knownSets = KnownSets.getKnownSetsFromJSonStream(fileStream);
            }
            return knownSets;
        }
    }
}

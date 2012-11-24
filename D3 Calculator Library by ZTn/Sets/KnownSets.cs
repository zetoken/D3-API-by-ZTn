using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
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

        public static KnownSets getKnownSetFromJSonStream(Stream stream)
        {
            DataContractJsonSerializer jsSerializer = new DataContractJsonSerializer(typeof(Set[]));
            Set[] sets = (Set[])jsSerializer.ReadObject(stream);
            return new KnownSets(sets);
        }

        public static KnownSets getKnownSetsFromJSonString(String json)
        {
            KnownSets knownSets;
            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.Default.GetBytes(json)))
            {
                knownSets = getKnownSetFromJSonStream(stream);
            }
            return knownSets;
        }

        public static KnownSets getKnownSetsFromJsonFile(String fileName)
        {
            KnownSets knownSets;
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                knownSets = KnownSets.getKnownSetFromJSonStream(fileStream);
            }
            return knownSets;
        }
    }
}

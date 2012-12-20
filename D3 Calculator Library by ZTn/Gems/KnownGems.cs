using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Gems
{
    [DataContract]
    public class KnownGems
    {
        #region >> Fields

        [DataMember]
        public Item[] gems;

        #endregion

        #region >> Constructors

        public KnownGems(Item[] gems)
        {
            this.gems = gems;
        }

        #endregion

        //public ItemAttributes getActivatedSetBonus(List<Item> items)
        //{
        //    ItemAttributes attr = new ItemAttributes();

        //    foreach (Set set in gems)
        //    {
        //        attr += set.getBonus(set.countItemsOfSet(items));
        //    }

        //    return attr;
        //}

        //public ItemAttributes getActivatedSetBonus(List<ItemSummary> items)
        //{
        //    ItemAttributes attr = new ItemAttributes();

        //    foreach (Set set in gems)
        //    {
        //        attr += set.getBonus(set.countItemsOfSet(items));
        //    }

        //    return attr;
        //}

        public static KnownGems getKnownGemsFromJSonStream(Stream stream)
        {
            JsonSerializer serializer = new JsonSerializer();
            Item[] gems;
            using (StreamReader streamReader = new StreamReader(stream))
            {
                gems = (Item[])serializer.Deserialize(streamReader, typeof(Item[]));
            }
            return new KnownGems(gems);
        }

        public static KnownGems getKnownGemsFromJSonString(String json)
        {
            KnownGems knownSets;
            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.Default.GetBytes(json)))
            {
                knownSets = getKnownGemsFromJSonStream(stream);
            }
            return knownSets;
        }

        public static KnownGems getKnownGemsFromJsonFile(String fileName)
        {
            KnownGems knownSets;
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                knownSets = KnownGems.getKnownGemsFromJSonStream(fileStream);
            }
            return knownSets;
        }
    }
}

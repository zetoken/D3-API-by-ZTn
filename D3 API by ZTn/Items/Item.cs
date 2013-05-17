using System;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ZTn.BNet.D3.Artisans;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class Item : ItemSummary
    {
        #region >> Properties

        [DataMember]
        public int requiredLevel { get; set; }
        [DataMember]
        public int itemLevel;
        [DataMember]
        public int bonusAffixes;
        [DataMember(EmitDefaultValue = false)]
        public String flavorText;
        [DataMember]
        public String typeName;
        [DataMember]
        public ItemType type;
        [DataMember(EmitDefaultValue = false)]
        public ItemValueRange dps;
        [DataMember(EmitDefaultValue = false)]
        public ItemValueRange attacksPerSecond;
        [DataMember(EmitDefaultValue = false)]
        public ItemValueRange minDamage;
        [DataMember(EmitDefaultValue = false)]
        public ItemValueRange maxDamage;
        [DataMember(EmitDefaultValue = false)]
        public ItemValueRange armor;
        [DataMember]
        public String[] attributes;
        [DataMember]
        public ItemAttributes attributesRaw;
        [DataMember]
        public SocketEffect[] socketEffects;
        [DataMember]
        public ItemSalvageComponent[] salvage;
        [DataMember(EmitDefaultValue = false)]
        public Set set;
        [DataMember]
        public SocketedGem[] gems;

        #endregion

        #region >> Constructors

        public Item()
        {
        }

        public Item(ItemAttributes itemAttributes)
        {
            this.attributesRaw = itemAttributes;
        }

        #endregion

        public static Item getItemFromTooltipParams(String tooltipParams)
        {
            return D3Api.getItemFromTooltipParams(tooltipParams);
        }

        public static Item getItemFromJSonStream(Stream stream)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader streamReader = new StreamReader(stream))
            {
                return (Item)serializer.Deserialize(streamReader, typeof(Item));
            }
        }

        public static Item getItemFromJSonString(String json)
        {
            Item item;
            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.Default.GetBytes(json)))
            {
                item = getItemFromJSonStream(stream);
            }
            return item;
        }
    }
}

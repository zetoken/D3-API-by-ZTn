using System;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ZTn.BNet.D3.Artisans;
using ZTn.BNet.D3.Helpers;
using System.Reflection;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class Item : ItemSummary
    {
        #region >> Properties

        [DataMember]
        public int requiredLevel { get; set; }
        [DataMember]
        public int itemLevel { get; set; }
        [DataMember]
        public int bonusAffixes { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int bonusAffixesMax { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public bool accountBound { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public String flavorText { get; set; }
        [DataMember]
        public String typeName { get; set; }
        [DataMember]
        public ItemType type { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public ItemValueRange dps { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public ItemValueRange attacksPerSecond { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public ItemValueRange minDamage { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public ItemValueRange maxDamage { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public ItemValueRange armor { get; set; }
        [DataMember]
        public String[] attributes { get; set; }
        [DataMember]
        public ItemAttributes attributesRaw { get; set; }
        [DataMember]
        public SocketEffect[] socketEffects { get; set; }
        [DataMember]
        public ItemSalvageComponent[] salvage { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Set set { get; set; }
        [DataMember]
        public SocketedGem[] gems { get; set; }

        #endregion

        #region >> Constructors

        public Item()
        {
        }

        /// <summary>
        /// Creates a new instance by copying fields of <paramref name="item"/> (deep copy).
        /// </summary>
        /// <param name="item"></param>
        public Item(Item item)
        {
            D3DeepCopy.deepCopy<Item>(item, this);
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
            return JsonHelpers.getFromJSonStream<Item>(stream);
        }

        public static Item getItemFromJSonString(String json)
        {
            return JsonHelpers.getFromJSonString<Item>(json);
        }
    }
}

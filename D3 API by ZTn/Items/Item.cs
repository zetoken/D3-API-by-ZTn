using System;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ZTn.BNet.D3.Artisans;
using ZTn.BNet.D3.Helpers;

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
        public int bonusAffixesMax;
        [DataMember(EmitDefaultValue = false)]
        public bool accountBound;
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
            return JsonHelpers.getFromJSonStream<Item>(stream);
        }

        public static Item getItemFromJSonString(String json)
        {
            return JsonHelpers.getFromJSonString<Item>(json);
        }
    }
}

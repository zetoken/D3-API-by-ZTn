using System;
using System.IO;
using System.Runtime.Serialization;
using ZTn.BNet.D3.Helpers;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class Item : ItemSummary
    {
        #region >> Properties

        [DataMember]
        public int RequiredLevel { get; set; }

        [DataMember]
        public int ItemLevel { get; set; }

        [DataMember]
        public int BonusAffixes { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int BonusAffixesMax { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool AccountBound { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public String FlavorText { get; set; }

        [DataMember]
        public String TypeName { get; set; }

        [DataMember]
        public ItemType Type { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ItemValueRange Dps { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ItemValueRange AttacksPerSecond { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ItemValueRange MinDamage { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ItemValueRange MaxDamage { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ItemValueRange Armor { get; set; }

        [DataMember]
        public ItemTextAttributes Attributes { get; set; }

        [DataMember]
        public ItemAttributes AttributesRaw { get; set; }

        [DataMember]
        public SocketEffect[] SocketEffects { get; set; }

        [DataMember]
        public ItemSalvageComponent[] Salvage { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Set Set { get; set; }

        [DataMember]
        public SocketedGem[] Gems { get; set; }

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
            item.DeepCopy(this);
        }

        public Item(ItemAttributes itemAttributes)
        {
            AttributesRaw = itemAttributes;
        }

        #endregion

        public static Item CreateFromTooltipParams(String tooltipParams)
        {
            return D3Api.GetItemFromTooltipParams(tooltipParams);
        }

        public static void CreateFromTooltipParams(String tooltipParams, Action<Item> onSuccess, Action onFailure)
        {
            D3Api.GetItemFromTooltipParams(tooltipParams, onSuccess, onFailure);
        }

        public static Item CreateFromJSonStream(Stream stream)
        {
            return stream.CreateFromJsonStream<Item>();
        }

        public static Item CreateFromJSonString(String json)
        {
            return json.CreateFromJsonString<Item>();
        }
    }
}
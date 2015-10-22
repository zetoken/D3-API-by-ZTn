using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using ZTn.BNet.D3.Helpers;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class Item : ItemSummary
    {
        #region >> Properties

        [DataMember(EmitDefaultValue = false)]
        public int RequiredLevel { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int ItemLevel { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int BonusAffixes { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int BonusAffixesMax { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool AccountBound { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string FlavorText { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string TypeName { get; set; }

        [DataMember(EmitDefaultValue = false)]
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

        [DataMember(EmitDefaultValue = false)]
        public ItemTextAttributes Attributes { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ItemAttributes AttributesRaw { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public SocketEffect[] SocketEffects { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ItemSalvageComponent[] Salvage { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Set Set { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public SocketedGem[] Gems { get; set; }

        [DataMember(Name = "slots", EmitDefaultValue = false)]
        protected string[] SSlots
        {
            get
            {
                return Slots?.Select(s => s.ToEnumString()).ToArray();
            }
            set
            {
                Slots = value.Select(s => s.ParseAsEnum<Slot>()).ToArray();
            }
        }

        [IgnoreDataMember]
        public Slot[] Slots { get; set; }

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

        public static Item CreateFromTooltipParams(string tooltipParams)
        {
            return D3Api.GetItemFromTooltipParams(tooltipParams);
        }

        [Obsolete("Deprecated")]
        public static void CreateFromTooltipParams(string tooltipParams, Action<Item> onSuccess, Action onFailure)
        {
            D3Api.GetItemFromTooltipParams(tooltipParams, onSuccess, onFailure);
        }

        public static async Task<Item> CreateFromTooltipParamsAsync(string tooltipParams)
        {
            return await D3Api.GetItemFromTooltipParamsAsync(tooltipParams);
        }

        public static Item CreateFromJSonStream(Stream stream)
        {
            return stream.CreateFromJsonStream<Item>();
        }

        public static Item CreateFromJSonString(string json)
        {
            return json.CreateFromJsonString<Item>();
        }
    }
}
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using ZTn.BNet.D3.Artisans;
using ZTn.BNet.D3.Helpers;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class ItemSummary : D3Object
    {
        #region >> Properties

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Icon { get; set; }

        [DataMember]
        public string DisplayColor { get; set; }

        [DataMember]
        public string TooltipParams { get; set; }

        [DataMember]
        public Recipe Recipe { get; set; }

        [DataMember]
        public RandomAffix[] RandomAffixes { get; set; }

        [DataMember]
        public Recipe[] CraftedBy { get; set; }

        [DataMember]
        public string[] SetItemsEquipped { get; set; }

        #endregion

        public Item GetFullItem()
        {
            return Item.CreateFromTooltipParams(TooltipParams);
        }

        [Obsolete("Deprecated by *Async method.")]
        public void GetFullItem(Action<Item> onSuccess, Action onFailure) =>
            Item.CreateFromTooltipParams(TooltipParams, onSuccess, onFailure);

        public async Task<Item> GetFullItemAsync() =>
            await Item.CreateFromTooltipParamsAsync(TooltipParams);

        #region >> Constructor

        public ItemSummary()
        {
        }

        /// <summary>
        /// Creates a new instance by copying fields of <paramref name="itemSummary"/> (deep copy).
        /// </summary>
        /// <param name="itemSummary"></param>
        public ItemSummary(ItemSummary itemSummary)
        {
            itemSummary.DeepCopy(this);
        }

        #endregion

        #region >> Object

        /// <inheritdoc />
        public override string ToString()
        {
            return $"[{Id}]";
        }

        #endregion
    }
}
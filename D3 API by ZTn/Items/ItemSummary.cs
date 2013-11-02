using System;
using System.Reflection;
using System.Runtime.Serialization;
using ZTn.BNet.D3.Artisans;
using ZTn.BNet.D3.Helpers;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class ItemSummary
    {
        #region >> Properties

        [DataMember]
        public String id { get; set; }
        [DataMember]
        public String name { get; set; }
        [DataMember]
        public String icon { get; set; }
        [DataMember]
        public String displayColor { get; set; }
        [DataMember]
        public String tooltipParams { get; set; }
        [DataMember]
        public Recipe recipe { get; set; }
        [DataMember]
        public Recipe[] craftedBy { get; set; }

        #endregion

        public Item getFullItem()
        {
            return Item.getItemFromTooltipParams(tooltipParams);
        }

        #region >> Constructor

        public ItemSummary()
        {
        }

        /// <summary>
        /// Creates a new instance by copying fields of <paramref name="item"/> (deep copy).
        /// </summary>
        /// <param name="itemSummary"></param>
        public ItemSummary(ItemSummary itemSummary)
        {
            D3DeepCopy.deepCopy<ItemSummary>(itemSummary, this);
        }

        #endregion

        #region >> Object

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + id + "]";
        }

        #endregion
    }
}

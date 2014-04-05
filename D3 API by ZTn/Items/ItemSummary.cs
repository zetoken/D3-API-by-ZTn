using System;
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
        public String Id { get; set; }

        [DataMember]
        public String Name { get; set; }

        [DataMember]
        public String Icon { get; set; }

        [DataMember]
        public String DisplayColor { get; set; }

        [DataMember]
        public String TooltipParams { get; set; }

        [DataMember]
        public Recipe Recipe { get; set; }

        [DataMember]
        public Object[] RandomAffixes { get; set; }

        [DataMember]
        public Recipe[] CraftedBy { get; set; }

        #endregion

        public Item GetFullItem()
        {
            return Item.CreateFromTooltipParams(TooltipParams);
        }

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
            return "[" + Id + "]";
        }

        #endregion
    }
}
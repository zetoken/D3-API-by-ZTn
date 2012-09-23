using System;
using System.Runtime.Serialization;

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

        #endregion

        public Item getFullItem()
        {
            return Item.getItemFromTooltipParams(tooltipParams);
        }
    }
}

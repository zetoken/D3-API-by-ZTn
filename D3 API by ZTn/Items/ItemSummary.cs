using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class ItemSummary
    {
        #region >> Properties

        [DataMember]
        public String id;
        [DataMember]
        public String name;
        [DataMember]
        public String icon;
        [DataMember]
        public String displayColor;
        [DataMember]
        public String tooltipParams;

        #endregion

        public Item getFullItem()
        {
            return Item.getItemFromTooltipParams(tooltipParams);
        }
    }
}

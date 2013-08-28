using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class SocketedGem
    {
        #region >> Fields

        [DataMember]
        public ItemSummary item;
        [DataMember]
        public ItemAttributes attributesRaw;
        [DataMember]
        public String[] attributes;

        #endregion

        #region >> Constructors

        public SocketedGem()
        {
        }

        public SocketedGem(Item item)
        {
            this.item = item;
            this.attributes = item.attributes;
            this.attributesRaw = item.attributesRaw;
        }

        #endregion
    }
}

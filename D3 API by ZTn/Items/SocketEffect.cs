using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class SocketEffect
    {
        #region >> Fields

        [DataMember]
        public String itemTypeId;
        [DataMember]
        public String itemTypeName;
        [DataMember]
        public ItemAttributes attributesRaw;
        [DataMember]
        public String[] attributes;

        #endregion
    }
}

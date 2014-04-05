using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class SocketEffect
    {
        #region >> Fields

        [DataMember]
        public String ItemTypeId;

        [DataMember]
        public String ItemTypeName;

        [DataMember]
        public ItemAttributes AttributesRaw;

        [DataMember]
        public ItemTextAttributes Attributes;

        #endregion
    }
}
using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class SetRank
    {
        #region >> Fields

        [DataMember]
        public int Required;

        [DataMember]
        public ItemTextAttributes Attributes;

        [DataMember]
        public ItemAttributes AttributesRaw;

        #endregion
    }
}
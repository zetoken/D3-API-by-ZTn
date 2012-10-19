using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class SetRank
    {
        #region >> Fields

        [DataMember]
        public int required;
        [DataMember]
        public String[] attributes;

        #endregion
    }
}

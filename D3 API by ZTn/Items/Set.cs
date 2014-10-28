using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class Set : D3Object
    {
        #region >> Fields

        [DataMember]
        public String slug;

        [DataMember]
        public String name;

        [DataMember]
        public SetRank[] ranks;

        [DataMember]
        public ItemSummary[] items;

        #endregion

        #region >> Object

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + slug + "]";
        }

        #endregion
    }
}
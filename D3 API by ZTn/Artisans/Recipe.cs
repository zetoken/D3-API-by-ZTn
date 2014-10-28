using System;
using System.Runtime.Serialization;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Artisans
{
    [DataContract]
    public class Recipe : D3Object
    {
        #region >> Fields

        [DataMember]
        public String Slug;

        [DataMember]
        public String Name;

        [DataMember]
        public int Cost;

        [DataMember]
        public Reagent[] Reagents;

        [DataMember]
        public ItemSummary ItemProduced;

        #endregion

        #region >> Object

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + Slug + "]";
        }

        #endregion
    }
}
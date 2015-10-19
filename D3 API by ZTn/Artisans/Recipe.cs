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
        public String Slug { get; set; }

        [DataMember]
        public String Name { get; set; }

        [DataMember]
        public int Cost { get; set; }

        [DataMember]
        public Reagent[] Reagents { get; set; }

        [DataMember]
        public ItemSummary ItemProduced { get; set; }

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
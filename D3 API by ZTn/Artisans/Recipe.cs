using System;
using System.Runtime.Serialization;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Artisans
{
    [DataContract]
    public class Recipe
    {
        #region >> Fields

        [DataMember]
        public String slug;
        [DataMember]
        public String name;
        [DataMember]
        public int cost;
        [DataMember]
        public Reagent[] reagents;
        [DataMember]
        public ItemSummary itemProduced;

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

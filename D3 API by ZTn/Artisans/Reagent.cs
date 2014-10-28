using System.Runtime.Serialization;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Artisans
{
    [DataContract]
    public class Reagent : D3Object
    {
        #region >> Fields

        [DataMember]
        public int Quantity;

        [DataMember]
        public ItemSummary Item;

        #endregion

        #region >> Object

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + Item + " qty:" + Quantity + "]";
        }

        #endregion
    }
}
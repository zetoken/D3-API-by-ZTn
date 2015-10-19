using System.Runtime.Serialization;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Artisans
{
    [DataContract]
    public class Reagent : D3Object
    {
        #region >> Fields

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public ItemSummary Item { get; set; }

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
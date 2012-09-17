using System.Runtime.Serialization;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Artisans
{
    [DataContract]
    public class Reagent
    {
        #region >> Fields

        [DataMember]
        public int quantity;
        [DataMember]
        public ItemSummary item;

        #endregion
    }
}

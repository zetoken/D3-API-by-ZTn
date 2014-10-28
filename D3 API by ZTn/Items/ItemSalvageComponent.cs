using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class ItemSalvageComponent : D3Object
    {
        #region >> Properties

        [DataMember]
        public double Chance;

        [DataMember]
        public ItemSummary Item;

        [DataMember]
        public int Quantity;

        #endregion
    }
}
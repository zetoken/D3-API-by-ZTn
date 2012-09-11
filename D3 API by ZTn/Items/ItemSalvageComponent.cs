using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class ItemSalvageComponent
    {
        #region >> Properties

        [DataMember]
        public double chance;
        [DataMember]
        public ItemSummary item;
        [DataMember]
        public int quantity;

        #endregion
    }
}

using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class ItemValueRange
    {
        #region >> Properties

        [DataMember]
        public double min;
        [DataMember]
        public double max;

        #endregion
    }
}

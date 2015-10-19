using System.Runtime.Serialization;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.HeroFollowers
{
    [DataContract]
    public class FollowerItems : D3Object
    {
        #region >> Fields

        [DataMember]
        public ItemSummary Special { get; set; }

        [DataMember]
        public ItemSummary MainHand { get; set; }

        [DataMember]
        public ItemSummary OffHand { get; set; }

        [DataMember]
        public ItemSummary RightFinger { get; set; }

        [DataMember]
        public ItemSummary LeftFinger { get; set; }

        [DataMember]
        public ItemSummary Neck { get; set; }

        #endregion
    }
}
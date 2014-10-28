using System.Runtime.Serialization;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.HeroFollowers
{
    [DataContract]
    public class FollowerItems : D3Object
    {
        #region >> Fields

        [DataMember]
        public ItemSummary Special;

        [DataMember]
        public ItemSummary MainHand;

        [DataMember]
        public ItemSummary OffHand;

        [DataMember]
        public ItemSummary RightFinger;

        [DataMember]
        public ItemSummary LeftFinger;

        [DataMember]
        public ItemSummary Neck;

        #endregion
    }
}
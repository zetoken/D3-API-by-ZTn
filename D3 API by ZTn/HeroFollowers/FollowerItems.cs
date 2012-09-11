using System.Runtime.Serialization;

using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.HeroFollowers
{
    [DataContract]
    public class FollowerItems
    {
        #region >> Fields

        [DataMember]
        public ItemSummary special;
        [DataMember]
        public ItemSummary mainHand;
        [DataMember]
        public ItemSummary offHand;
        [DataMember]
        public ItemSummary rightFinger;
        [DataMember]
        public ItemSummary leftFinger;
        [DataMember]
        public ItemSummary neck;

        #endregion
    }
}

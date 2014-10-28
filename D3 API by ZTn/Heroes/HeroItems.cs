using System.Runtime.Serialization;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Heroes
{
    [DataContract]
    public class HeroItems : D3Object
    {
        #region >> Properties

        [DataMember]
        public ItemSummary Head;

        [DataMember]
        public ItemSummary Torso;

        [DataMember]
        public ItemSummary Feet;

        [DataMember]
        public ItemSummary Hands;

        [DataMember]
        public ItemSummary Shoulders;

        [DataMember]
        public ItemSummary Legs;

        [DataMember]
        public ItemSummary Bracers;

        [DataMember]
        public ItemSummary MainHand;

        [DataMember]
        public ItemSummary OffHand;

        [DataMember]
        public ItemSummary Waist;

        [DataMember]
        public ItemSummary RightFinger;

        [DataMember]
        public ItemSummary LeftFinger;

        [DataMember]
        public ItemSummary Neck;

        #endregion
    }
}
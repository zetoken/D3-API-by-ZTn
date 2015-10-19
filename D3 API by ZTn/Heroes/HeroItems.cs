using System.Runtime.Serialization;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Heroes
{
    [DataContract]
    public class HeroItems : D3Object
    {
        #region >> Properties

        [DataMember]
        public ItemSummary Head { get; set; }

        [DataMember]
        public ItemSummary Torso { get; set; }

        [DataMember]
        public ItemSummary Feet { get; set; }

        [DataMember]
        public ItemSummary Hands { get; set; }

        [DataMember]
        public ItemSummary Shoulders { get; set; }

        [DataMember]
        public ItemSummary Legs { get; set; }

        [DataMember]
        public ItemSummary Bracers { get; set; }

        [DataMember]
        public ItemSummary MainHand { get; set; }

        [DataMember]
        public ItemSummary OffHand { get; set; }

        [DataMember]
        public ItemSummary Waist { get; set; }

        [DataMember]
        public ItemSummary RightFinger { get; set; }

        [DataMember]
        public ItemSummary LeftFinger { get; set; }

        [DataMember]
        public ItemSummary Neck { get; set; }

        #endregion
    }
}
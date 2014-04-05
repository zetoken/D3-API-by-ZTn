using System.Runtime.Serialization;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Heroes
{
    [DataContract]
    public class HeroItems
    {
        #region >> Properties

        [DataMember]
        public ItemSummary head;

        [DataMember]
        public ItemSummary torso;

        [DataMember]
        public ItemSummary feet;

        [DataMember]
        public ItemSummary hands;

        [DataMember]
        public ItemSummary shoulders;

        [DataMember]
        public ItemSummary legs;

        [DataMember]
        public ItemSummary bracers;

        [DataMember]
        public ItemSummary mainHand;

        [DataMember]
        public ItemSummary offHand;

        [DataMember]
        public ItemSummary waist;

        [DataMember]
        public ItemSummary rightFinger;

        [DataMember]
        public ItemSummary leftFinger;

        [DataMember]
        public ItemSummary neck;

        #endregion
    }
}
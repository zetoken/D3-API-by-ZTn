using System.Runtime.Serialization;

namespace ZTn.BNet.D3.HeroFollowers
{
    [DataContract]
    public class FollowerStats : D3Object
    {
        #region >> Fields

        [DataMember]
        public int GoldFind { get; set; }

        [DataMember]
        public int MagicFind { get; set; }

        [DataMember]
        public int ExperienceBonus { get; set; }

        #endregion
    }
}
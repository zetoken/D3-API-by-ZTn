using System.Runtime.Serialization;

namespace ZTn.BNet.D3.HeroFollowers
{
    [DataContract]
    public class FollowerStats : D3Object
    {
        #region >> Fields

        [DataMember]
        public int GoldFind;

        [DataMember]
        public int MagicFind;

        [DataMember]
        public int ExperienceBonus;

        #endregion
    }
}
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.HeroFollowers
{
    [DataContract]
    public class FollowerStats
    {
        #region >> Fields

        [DataMember]
        public int goldFind;
        [DataMember]
        public int magicFind;
        [DataMember]
        public int experienceBonus;

        #endregion
    }
}

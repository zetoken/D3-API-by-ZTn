using System.Runtime.Serialization;

namespace ZTn.BNet.D3.HeroFollowers
{
    [DataContract]
    public class Followers
    {
        #region >> Fields

        [DataMember]
        public Follower templar;
        [DataMember]
        public Follower scoundrel;
        [DataMember]
        public Follower enchantress;

        #endregion
    }
}

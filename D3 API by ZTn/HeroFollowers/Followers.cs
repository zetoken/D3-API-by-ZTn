using System.Runtime.Serialization;

namespace ZTn.BNet.D3.HeroFollowers
{
    [DataContract]
    public class Followers : D3Object
    {
        #region >> Fields

        [DataMember]
        public Follower Templar;

        [DataMember]
        public Follower Scoundrel;

        [DataMember]
        public Follower Enchantress;

        #endregion
    }
}
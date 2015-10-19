using System.Runtime.Serialization;

namespace ZTn.BNet.D3.HeroFollowers
{
    [DataContract]
    public class Followers : D3Object
    {
        #region >> Fields

        [DataMember]
        public Follower Templar { get; set; }

        [DataMember]
        public Follower Scoundrel { get; set; }

        [DataMember]
        public Follower Enchantress { get; set; }

        #endregion
    }
}
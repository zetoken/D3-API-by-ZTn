using System;
using System.Runtime.Serialization;

using ZTn.BNet.D3.Skills;

namespace ZTn.BNet.D3.HeroFollowers
{
    [DataContract]
    public class Follower
    {
        #region >> Fields

        [DataMember]
        public String slug;
        [DataMember]
        public int level;
        [DataMember]
        public FollowerItems items;
        [DataMember]
        public FollowerStats stats;
        [DataMember]
        public Skill[] skills;

        #endregion
    }
}

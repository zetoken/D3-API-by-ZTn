using System;
using System.Runtime.Serialization;

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
        public FollowerSkill[] skills;

        #endregion

        #region >> Object

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + slug + " lvl:" + level + "]";
        }

        #endregion
    }
}

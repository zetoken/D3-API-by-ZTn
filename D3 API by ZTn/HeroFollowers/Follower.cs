using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.HeroFollowers
{
    [DataContract]
    public class Follower : D3Object
    {
        #region >> Fields

        [DataMember]
        public String Slug { get; set; }

        [DataMember]
        public int Level { get; set; }

        [DataMember]
        public FollowerItems Items { get; set; }

        [DataMember]
        public FollowerStats Stats { get; set; }

        [DataMember]
        public FollowerSkill[] Skills { get; set; }

        #endregion

        #region >> Object

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + Slug + " lvl:" + Level + "]";
        }

        #endregion
    }
}
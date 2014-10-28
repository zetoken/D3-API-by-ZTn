using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.HeroFollowers
{
    [DataContract]
    public class Follower : D3Object
    {
        #region >> Fields

        [DataMember]
        public String Slug;

        [DataMember]
        public int Level;

        [DataMember]
        public FollowerItems Items;

        [DataMember]
        public FollowerStats Stats;

        [DataMember]
        public FollowerSkill[] Skills;

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
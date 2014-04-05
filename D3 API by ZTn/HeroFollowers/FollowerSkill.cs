using System.Runtime.Serialization;
using ZTn.BNet.D3.Skills;

namespace ZTn.BNet.D3.HeroFollowers
{
    [DataContract]
    public class FollowerSkill
    {
        #region >> Fields

        [DataMember]
        public Skill skill;

        #endregion
    }
}
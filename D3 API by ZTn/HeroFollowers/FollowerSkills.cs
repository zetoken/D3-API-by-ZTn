using System.Runtime.Serialization;

using ZTn.BNet.D3.Skills;

namespace ZTn.BNet.D3.HeroFollowers
{
    [DataContract]
    public class FollowerSkills
    {
        #region >> Fields

        [DataMember]
        public Skill[] skills;

        #endregion
    }
}

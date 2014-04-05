using System.Runtime.Serialization;
using ZTn.BNet.D3.Skills;

namespace ZTn.BNet.D3.Heroes
{
    [DataContract]
    public class HeroSkills
    {
        #region >> Fields

        [DataMember]
        public ActiveSkill[] active;

        [DataMember]
        public PassiveSkill[] passive;

        #endregion
    }
}
using System.Runtime.Serialization;
using ZTn.BNet.D3.Skills;

namespace ZTn.BNet.D3.Heroes
{
    [DataContract]
    public class HeroSkills : D3Object
    {
        #region >> Fields

        [DataMember]
        public ActiveSkill[] Active { get; set; }

        [DataMember]
        public PassiveSkill[] Passive { get; set; }

        #endregion
    }
}
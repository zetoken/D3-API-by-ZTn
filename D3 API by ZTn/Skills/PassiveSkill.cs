using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Skills
{
    [DataContract]
    public class PassiveSkill
    {
        #region >> Fields

        [DataMember]
        public Skill skill;

        #endregion
    }
}

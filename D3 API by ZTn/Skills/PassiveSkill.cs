using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Skills
{
    [DataContract]
    public class PassiveSkill : D3Object
    {
        #region >> Fields

        [DataMember]
        public Skill Skill;

        #endregion

        #region >> Object

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + Skill + "]";
        }

        #endregion
    }
}
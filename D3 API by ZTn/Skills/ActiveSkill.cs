using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Skills
{
    [DataContract]
    public class ActiveSkill : D3Object
    {
        #region >> Fields

        [DataMember]
        public Skill Skill;

        [DataMember]
        public Rune Rune;

        #endregion

        #region >> Object

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + Skill + " " + Rune + "]";
        }

        #endregion
    }
}
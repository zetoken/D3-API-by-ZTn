using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Skills
{
    [DataContract]
    public class ActiveSkill
    {
        #region >> Fields

        [DataMember]
        public Skill skill;

        [DataMember]
        public Rune rune;

        #endregion

        #region >> Object

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + skill + " " + rune + "]";
        }

        #endregion
    }
}
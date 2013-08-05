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

        #region >> Object

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + skill + "]";
        }

        #endregion

    }
}

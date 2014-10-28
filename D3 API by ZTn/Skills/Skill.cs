using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Skills
{
    [DataContract]
    public class Skill : D3Object
    {
        #region >> Fields

        [DataMember]
        public String Slug;

        [DataMember]
        public String Name;

        [DataMember]
        public String Icon;

        [DataMember]
        public String TooltipUrl;

        [DataMember]
        public String Description;

        [DataMember]
        public String Flavor;

        [DataMember]
        public String SkillCalcId;

        [DataMember]
        public int Level;

        #endregion

        #region >> Object

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + Slug + "]";
        }

        #endregion
    }
}
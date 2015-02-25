using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Skills
{
    [DataContract]
    public class Skill : D3Object
    {
        #region >> Fields

        [DataMember]
        public string Slug;

        [DataMember]
        public string categorySlug;

        [DataMember]
        public string Name;

        [DataMember]
        public string Icon;

        [DataMember]
        public string TooltipUrl;

        [DataMember]
        public string Description;

        [DataMember]
        public string SimpleDescription;

        [DataMember]
        public string Flavor;

        [DataMember]
        public string SkillCalcId;

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
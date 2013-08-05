using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Skills
{
    [DataContract]
    public class Skill
    {
        #region >> Fields

        [DataMember]
        public String slug;
        [DataMember]
        public String name;
        [DataMember]
        public String icon;
        [DataMember]
        public String tooltipUrl;
        [DataMember]
        public String description;
        [DataMember]
        public String flavor;
        [DataMember]
        public String skillCalcId;
        [DataMember]
        public int level;

        #endregion

        #region >> Object

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + slug + "]";
        }

        #endregion
    }
}

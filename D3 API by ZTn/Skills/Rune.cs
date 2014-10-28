using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Skills
{
    [DataContract]
    public class Rune : D3Object
    {
        #region >> Fields

        [DataMember]
        public String Slug;

        [DataMember]
        public String Type;

        [DataMember]
        public String Name;

        [DataMember]
        public int Level;

        [DataMember]
        public String Description;

        [DataMember]
        public String SimpleDescription;

        [DataMember]
        public String TooltipParams;

        [DataMember]
        public String SkillCalcId;

        [DataMember]
        public int Order;

        #endregion

        #region >> Object

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + Slug + " lvl:" + Level + "]";
        }

        #endregion
    }
}
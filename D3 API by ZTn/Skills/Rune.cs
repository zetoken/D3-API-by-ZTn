using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Skills
{
    [DataContract]
    public class Rune
    {
        #region >> Fields

        [DataMember]
        public String slug;
        [DataMember]
        public String type;
        [DataMember]
        public String name;
        [DataMember]
        public int level;
        [DataMember]
        public String description;
        [DataMember]
        public String simpleDescription;
        [DataMember]
        public String tooltipParams;
        [DataMember]
        public String skillCalcId;
        [DataMember]
        public int order;

        #endregion
    }
}

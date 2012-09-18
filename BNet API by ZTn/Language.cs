using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.BattleNet
{
    [DataContract]
    public class Language
    {
        #region >> Properties

        [DataMember]
        public String name { get; set; }
        [DataMember]
        public String code { get; set; }

        #endregion

        #region >> Constructors

        public Language()
        {
            name = "";
            code = "";
        }

        public Language(String name, String code)
        {
            this.name = name;
            this.code = code;
        }

        #endregion
    }
}

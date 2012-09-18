using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.BattleNet
{
    [DataContract]
    public class Host
    {
        #region >> Properties

        [DataMember]
        public String name { get; set; }
        [DataMember]
        public String url { get; set; }

        #endregion

        #region >> Constructors

        public Host()
        {
            name = "";
            url = "";
        }

        public Host(String name, String url)
        {
            this.name = name;
            this.url = url;
        }

        #endregion
    }
}

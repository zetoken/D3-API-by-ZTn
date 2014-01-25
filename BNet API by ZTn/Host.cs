using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.BattleNet
{
    [DataContract]
    public class Host
    {
        #region >> Properties

        /// <summary>
        /// Name of the host.
        /// </summary>
        [DataMember]
        public String Name { get; set; }

        /// <summary>
        /// Url of the host.
        /// </summary>
        [DataMember]
        public String Url { get; set; }

        #endregion

        #region >> Constructors

        /// <summary>
        /// Creates a new empty <see cref="Host"/> instance.
        /// </summary>
        public Host()
        {
            Name = "";
            Url = "";
        }

        /// <summary>
        /// Creates a new <see cref="Host"/> instance.
        /// </summary>
        /// <param name="name">Name of the host.</param>
        /// <param name="url">Url of the host.</param>
        public Host(String name, String url)
        {
            Name = name;
            Url = url;
        }

        #endregion
    }
}

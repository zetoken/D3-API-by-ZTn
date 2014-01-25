using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.BattleNet
{
    [DataContract]
    public class Language
    {
        #region >> Properties

        /// <summary>
        /// Language name.
        /// </summary>
        [DataMember]
        public String Name { get; set; }

        /// <summary>
        /// Language code for use in requests.
        /// </summary>
        [DataMember]
        public String Code { get; set; }

        #endregion

        #region >> Constructors

        /// <summary>
        /// Creates a new empty <see cref="Language"/> instance.
        /// </summary>
        public Language()
        {
            Name = "";
            Code = "";
        }

        /// <summary>
        /// Creates a new <see cref="Language"/> instance.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="code"></param>
        public Language(String name, String code)
        {
            Name = name;
            Code = code;
        }

        #endregion
    }
}

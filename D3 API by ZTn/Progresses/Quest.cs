using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Progresses
{
    [DataContract]
    public class Quest
    {
        #region >> Fields

        [DataMember]
        public String slug;
        [DataMember]
        public String name;

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

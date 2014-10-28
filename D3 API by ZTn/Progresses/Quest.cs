using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Progresses
{
    [DataContract]
    public class Quest : D3Object
    {
        #region >> Fields

        [DataMember]
        public String Slug;

        [DataMember]
        public String Name;

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
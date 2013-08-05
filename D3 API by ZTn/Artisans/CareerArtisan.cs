using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Artisans
{
    [DataContract]
    public class CareerArtisan
    {
        #region >> Properties

        [DataMember]
        public String slug;
        [DataMember]
        public int level;
        [DataMember]
        public int stepCurrent;
        [DataMember]
        public int stepMax;

        #endregion

        #region >> Object

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + slug + " lvl:" + level + "]";
        }

        #endregion
    }
}

using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Artisans
{
    [DataContract]
    public class Artisan
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
    }
}

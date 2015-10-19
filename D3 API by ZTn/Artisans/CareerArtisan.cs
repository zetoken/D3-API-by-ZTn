using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Artisans
{
    [DataContract]
    public class CareerArtisan : D3Object
    {
        #region >> Properties

        [DataMember]
        public String Slug { get; set; }

        [DataMember]
        public int Level { get; set; }

        [DataMember]
        public int StepCurrent { get; set; }

        [DataMember]
        public int StepMax { get; set; }

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
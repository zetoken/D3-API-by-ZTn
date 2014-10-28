using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Artisans
{
    [DataContract]
    public class CareerArtisan : D3Object
    {
        #region >> Properties

        [DataMember]
        public String Slug;

        [DataMember]
        public int Level;

        [DataMember]
        public int StepCurrent;

        [DataMember]
        public int StepMax;

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
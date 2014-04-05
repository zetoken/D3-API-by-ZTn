using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3
{
    /// <summary>
    /// Represents a battle.net response when an error occured.
    /// </summary>
    [DataContract]
    public class FailureObject
    {
        #region >> Fields

        /// <summary>
        /// Response field containing an error code.
        /// </summary>
        [DataMember]
        public String Code { get; set; }

        /// <summary>
        /// Response field containing an error description.
        /// </summary>
        [DataMember]
        public String Reason { get; set; }

        #endregion

        /// <summary>
        /// Returns true if the object indicates that a previous request failed.
        /// </summary>
        /// <returns></returns>
        public Boolean IsFailureObject()
        {
            return (Code != null || Reason != null);
        }
    }
}
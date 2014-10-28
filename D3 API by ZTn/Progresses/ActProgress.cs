using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Progresses
{
    [DataContract]
    public class ActProgress : D3Object
    {
        #region >> Fields

        [DataMember]
        public Boolean Completed;

        [DataMember]
        public Quest[] CompletedQuests;

        #endregion
    }
}
using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Progresses
{
    [DataContract]
    public class ActProgress
    {
        #region >> Fields

        [DataMember]
        public Boolean completed;
        [DataMember]
        public Quest[] completedQuests;

        #endregion
    }
}

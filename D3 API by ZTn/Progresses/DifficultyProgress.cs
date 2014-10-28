using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Progresses
{
    [DataContract]
    public class DifficultyProgress : D3Object
    {
        #region >> Fields

        [DataMember]
        public ActProgress Act1;

        [DataMember]
        public ActProgress Act2;

        [DataMember]
        public ActProgress Act3;

        [DataMember]
        public ActProgress Act4;

        #endregion
    }
}
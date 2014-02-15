using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Progresses
{
    [DataContract]
    public class DifficultyProgress
    {
        #region >> Fields

        [DataMember]
        public ActProgress act1;
        [DataMember]
        public ActProgress act2;
        [DataMember]
        public ActProgress act3;
        [DataMember]
        public ActProgress act4;

        #endregion
    }
}

using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Progresses
{
    [DataContract]
    public class Progress
    {
        #region >> Fields

        [DataMember]
        public DifficultyProgress normal;
        [DataMember]
        public DifficultyProgress nightmare;
        [DataMember]
        public DifficultyProgress hell;
        [DataMember]
        public DifficultyProgress inferno;

        #endregion
    }
}

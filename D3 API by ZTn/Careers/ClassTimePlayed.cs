using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Careers
{
    [DataContract]
    public class ClassTimePlayed
    {
        #region >> Fields

        [DataMember]
        public double barbarian;
        [DataMember(Name="demon-hunter")]
        public double demonHunter;
        [DataMember]
        public double monk;
        [DataMember(Name = "witch-doctor")]
        public double witchDoctor;
        [DataMember]
        public double wizard;

        #endregion
    }
}

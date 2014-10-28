using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Careers
{
    [DataContract]
    public class ClassTimePlayed : D3Object
    {
        #region >> Fields

        [DataMember]
        public double Barbarian;

        [DataMember]
        public double Crusader;

        [DataMember(Name = "demon-hunter")]
        public double DemonHunter;

        [DataMember]
        public double Monk;

        [DataMember(Name = "witch-doctor")]
        public double WitchDoctor;

        [DataMember]
        public double Wizard;

        #endregion
    }
}
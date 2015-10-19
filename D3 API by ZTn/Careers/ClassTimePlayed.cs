using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Careers
{
    [DataContract]
    public class ClassTimePlayed : D3Object
    {
        #region >> Fields

        [DataMember]
        public double Barbarian { get; set; }

        [DataMember]
        public double Crusader { get; set; }

        [DataMember(Name = "demon-hunter")]
        public double DemonHunter { get; set; }

        [DataMember]
        public double Monk { get; set; }

        [DataMember(Name = "witch-doctor")]
        public double WitchDoctor { get; set; }

        [DataMember]
        public double Wizard { get; set; }

        #endregion
    }
}
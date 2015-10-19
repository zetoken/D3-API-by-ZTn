using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Careers
{
    [DataContract]
    public class CareerKills : D3Object
    {
        #region >> Properties

        [DataMember]
        public int Monsters { get; set; }

        [DataMember]
        public int Elites { get; set; }

        [DataMember]
        public int HardcoreMonsters { get; set; }

        #endregion
    }
}
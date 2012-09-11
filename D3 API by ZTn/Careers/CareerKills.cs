using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Careers
{
    [DataContract]
    public class CareerKills
    {
        #region >> Properties

        [DataMember]
        public int monsters;
        [DataMember]
        public int elites;
        [DataMember]
        public int hardcoreMonsters;

        #endregion
    }
}

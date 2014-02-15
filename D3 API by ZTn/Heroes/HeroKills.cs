using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Heroes
{
    [DataContract]
    public class HeroKills
    {
        #region >> Properties

        [DataMember]
        public int elites;

        #endregion
    }
}

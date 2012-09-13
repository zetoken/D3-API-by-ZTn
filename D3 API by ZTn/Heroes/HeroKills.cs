using System.Runtime.Serialization;
using ZTn.BNet.D3.Careers;

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

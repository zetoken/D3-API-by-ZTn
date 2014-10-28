using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Heroes
{
    [DataContract]
    public class HeroKills : D3Object
    {
        #region >> Properties

        [DataMember]
        public int Elites;

        #endregion
    }
}
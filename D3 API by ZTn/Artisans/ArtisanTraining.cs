using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Artisans
{
    [DataContract]
    public class ArtisanTraining
    {
        #region >> Fields

        [DataMember]
        public ArtisanTier[] tiers;

        #endregion
    }
}

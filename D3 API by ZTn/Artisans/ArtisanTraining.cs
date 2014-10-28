using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Artisans
{
    [DataContract]
    public class ArtisanTraining : D3Object
    {
        #region >> Fields

        [DataMember]
        public ArtisanTier[] Tiers;

        #endregion
    }
}
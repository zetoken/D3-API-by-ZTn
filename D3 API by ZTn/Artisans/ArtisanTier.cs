using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Artisans
{
    [DataContract]
    public class ArtisanTier
    {
        #region >> Fields

        [DataMember]
        public int tier;
        [DataMember]
        public ArtisanLevel[] levels;

        #endregion
    }
}

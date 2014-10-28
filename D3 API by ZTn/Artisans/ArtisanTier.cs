using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Artisans
{
    [DataContract]
    public class ArtisanTier : D3Object
    {
        #region >> Fields

        [DataMember]
        public int Tier;

        [DataMember]
        public ArtisanLevel[] Levels;

        #endregion
    }
}
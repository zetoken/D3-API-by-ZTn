using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Artisans
{
    [DataContract]
    public class ArtisanTier : D3Object
    {
        #region >> Fields

        [DataMember]
        public int Tier { get; set; }

        [DataMember]
        public ArtisanLevel[] Levels { get; set; }

        #endregion
    }
}
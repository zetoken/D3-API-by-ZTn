using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Artisans
{
    [DataContract]
    public class ArtisanLevel : D3Object
    {
        #region >> Fields

        [DataMember]
        public int Level { get; set; }

        [DataMember]
        public int TierLevel { get; set; }

        [DataMember]
        public int Percent { get; set; }

        [DataMember]
        public Recipe[] TrainedRecipes { get; set; }

        [DataMember]
        public Recipe[] TaughtRecipes { get; set; }

        [DataMember]
        public int UpgradeCost { get; set; }

        [DataMember]
        public Reagent[] UpgradeItems { get; set; }

        #endregion
    }
}
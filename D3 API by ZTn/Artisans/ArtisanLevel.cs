using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Artisans
{
    [DataContract]
    public class ArtisanLevel : D3Object
    {
        #region >> Fields

        [DataMember]
        public int Level;

        [DataMember]
        public int TierLevel;

        [DataMember]
        public int Percent;

        [DataMember]
        public Recipe[] TrainedRecipes;

        [DataMember]
        public Recipe[] TaughtRecipes;

        [DataMember]
        public int UpgradeCost;

        [DataMember]
        public Reagent[] UpgradeItems;

        #endregion
    }
}
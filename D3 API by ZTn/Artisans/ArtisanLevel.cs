using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Artisans
{
    [DataContract]
    public class ArtisanLevel
    {
        #region >> Fields

        [DataMember]
        public int level;
        [DataMember]
        public int tierLevel;
        [DataMember]
        public int percent;
        [DataMember]
        public Recipe[] trainedRecipes;
        [DataMember]
        public Recipe[] taughtRecipes;
        [DataMember]
        public int upgradeCost;
        [DataMember]
        public Reagent[] upgradeItems;

        #endregion
    }
}

using System;
using System.Runtime.Serialization;
using ZTn.BNet.BattleNet;
using ZTn.BNet.D3.Helpers;

namespace ZTn.BNet.D3.Heroes
{
    [DataContract]
    public class HeroSummary : D3Object
    {
        #region >> Properties

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public int Level { get; set; }

        [DataMember]
        public bool Seasonal { get; set; }

        [DataMember]
        public bool Hardcore { get; set; }

        [DataMember]
        public int ParagonLevel { get; set; }

        [DataMember]
        public HeroGender Gender { get; set; }

        [DataMember]
        public bool Dead { get; set; }

        [DataMember]
        public HeroKills Kills { get; set; }

        [DataMember(Name = "class")]
        protected string SHeroClass
        {
            set
            {
                HeroClass = value.ParseAsEnum<HeroClass>();
            }
            get
            {
                return HeroClass.ToEnumString();
            }
        }

        [IgnoreDataMember]
        public HeroClass HeroClass { get; set; }

        [DataMember(Name = "last-updated")]
        protected long SLastUpdated
        {
            set { LastUpdated = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(value).ToLocalTime(); }
            get { return LastUpdated.Second - new DateTime(1970, 1, 1, 0, 0, 0, 0).Second; }
        }

        [IgnoreDataMember]
        public DateTime LastUpdated { get; set; }

        #endregion

        public Hero GetHeroFromBattleTag(BattleTag battleTag)
        {
            return Hero.CreateFromHeroId(battleTag, Id);
        }

        #region >> Object

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + Id + " " + Name + "]";
        }

        #endregion
    }
}
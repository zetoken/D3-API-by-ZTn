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
        public string Name;

        [DataMember]
        public string Id;

        [DataMember]
        public int Level;

        [DataMember]
        public bool Seasonal;

        [DataMember]
        public bool Hardcore;

        [DataMember]
        public int ParagonLevel;

        [DataMember]
        public HeroGender Gender;

        [DataMember]
        public bool Dead;

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
        public HeroClass HeroClass;

        [DataMember(Name = "last-updated")]
        protected long SLastUpdated
        {
            set { LastUpdated = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(value).ToLocalTime(); }
            get { return LastUpdated.Second - new DateTime(1970, 1, 1, 0, 0, 0, 0).Second; }
        }

        [IgnoreDataMember]
        public DateTime LastUpdated;

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
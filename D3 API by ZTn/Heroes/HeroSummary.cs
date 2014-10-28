using System;
using System.Runtime.Serialization;
using ZTn.BNet.BattleNet;

namespace ZTn.BNet.D3.Heroes
{
    [DataContract]
    public class HeroSummary : D3Object
    {
        #region >> Properties

        [DataMember]
        public String Name;

        [DataMember]
        public String Id;

        [DataMember]
        public int Level;

        [DataMember]
        public Boolean Seasonal;

        [DataMember]
        public Boolean Hardcore;

        [DataMember]
        public int ParagonLevel;

        [DataMember]
        public HeroGender Gender;

        [DataMember]
        public Boolean Dead;

        [DataMember(Name = "class")]
        protected String SHeroClass
        {
            set
            {
                switch (value)
                {
                    case "barbarian":
                        HeroClass = HeroClass.Barbarian;
                        break;
                    case "crusader":
                        HeroClass = HeroClass.Crusader;
                        break;
                    case "demon-hunter":
                        HeroClass = HeroClass.DemonHunter;
                        break;
                    case "monk":
                        HeroClass = HeroClass.Monk;
                        break;
                    case "witch-doctor":
                        HeroClass = HeroClass.WitchDoctor;
                        break;
                    case "wizard":
                        HeroClass = HeroClass.Wizard;
                        break;
                    default:
                        HeroClass = HeroClass.Unknown;
                        break;
                }
            }
            get
            {
                switch (HeroClass)
                {
                    case HeroClass.Barbarian:
                        return "barbarian";
                    case HeroClass.Crusader:
                        return "crusader";
                    case HeroClass.DemonHunter:
                        return "demon-hunter";
                    case HeroClass.Monk:
                        return "monk";
                    case HeroClass.WitchDoctor:
                        return "witch-doctor";
                    case HeroClass.Wizard:
                        return "wizard";
                    default:
                        return null;
                }
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
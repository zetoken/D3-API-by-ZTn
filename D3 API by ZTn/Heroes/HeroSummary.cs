using System;
using System.Runtime.Serialization;
using ZTn.BNet.BattleNet;

namespace ZTn.BNet.D3.Heroes
{
    [DataContract]
    public class HeroSummary
    {
        #region >> Properties

        [DataMember]
        public String name;
        [DataMember]
        public String id;
        [DataMember]
        public int level;
        [DataMember]
        public Boolean hardcore;
        [DataMember]
        public int paragonLevel;
        [DataMember]
        public HeroGender gender;
        [DataMember]
        public Boolean dead;
        [DataMember(Name = "class")]
        protected String s_heroClass
        {
            set
            {
                switch (value)
                {
                    case "barbarian": heroClass = HeroClass.Barbarian; break;
                    case "demon-hunter": heroClass = HeroClass.DemonHunter; break;
                    case "monk": heroClass = HeroClass.Monk; break;
                    case "witch-doctor": heroClass = HeroClass.WitchDoctor; break;
                    case "wizard": heroClass = HeroClass.Wizard; break;
                    default: heroClass = HeroClass.Unknown; break;
                }
            }
            get
            {
                switch (heroClass)
                {
                    case HeroClass.Barbarian: return "barbarian";
                    case HeroClass.DemonHunter: return "demon-hunter";
                    case HeroClass.Monk: return "monk";
                    case HeroClass.WitchDoctor: return "witch-doctor";
                    case HeroClass.Wizard: return "wizard";
                    default: return null;
                }
            }
        }
        [IgnoreDataMember]
        public HeroClass heroClass;
        [DataMember(Name = "last-updated")]
        protected long s_lastUpdated
        {
            set { lastUpdated = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(value); }
            get { return lastUpdated.Ticks - (new DateTime(1970, 1, 1, 0, 0, 0, 0)).Ticks; }
        }
        [IgnoreDataMember]
        public DateTime lastUpdated;

        #endregion

        public Hero getHeroFromBattleTag(BattleTag battleTag)
        {
            return Hero.getHeroFromHeroId(battleTag, id);
        }

        #region >> Object

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + id + " " + name + "]";
        }

        #endregion
    }
}

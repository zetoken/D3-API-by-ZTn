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
        public String gender;
        [DataMember]
        public Boolean dead;
        [DataMember(Name = "class")]
        public String heroClass;
        [DataMember(Name = "last-updated")]
        public long s_lastUpdated
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
    }
}

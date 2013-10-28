using System;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ZTn.BNet.BattleNet;
using ZTn.BNet.D3.Artisans;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Progresses;
using ZTn.BNet.D3.Helpers;

namespace ZTn.BNet.D3.Careers
{
    [DataContract]
    public class Career
    {
        #region >> Fields

        [DataMember(Name = "battleTag")]
        private String s_battleTag
        {
            set { battleTag = new BattleNet.BattleTag(value); }
            get { return battleTag.id; }
        }
        [IgnoreDataMember]
        public BattleNet.BattleTag battleTag = new BattleNet.BattleTag("undefined#0000");
        [DataMember]
        public HeroSummary[] heroes;
        [DataMember]
        public String lastHeroPlayed;
        [DataMember]
        public CareerArtisan[] artisans;
        [DataMember]
        public CareerArtisan[] hardcoreArtisans;
        [DataMember]
        public CareerKills kills;
        [DataMember]
        public ClassTimePlayed timePlayed;
        [DataMember]
        public HeroSummary[] fallenHeroes;
        [DataMember]
        public Progress progression;

        #endregion

        public static Career getCareerFromBattleTag(BattleTag battleTag)
        {
            return D3Api.getCareerFromBattleTag(battleTag);
        }

        public static Career getCareerFromJSonStream(Stream stream)
        {
            return JsonHelpers.getFromJSonStream<Career>(stream);
        }

        public static Career getCareerFromJSonString(String json)
        {
            return JsonHelpers.getFromJSonString<Career>(json);
        }
    }
}

using System;
using System.IO;
using System.Runtime.Serialization;
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
            set { battleTag = new BattleTag(value); }
            get { return battleTag.Id; }
        }
        [IgnoreDataMember]
        public BattleTag battleTag = new BattleTag("undefined#0000");
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

        public static Career CreateFromBattleTag(BattleTag battleTag)
        {
            return D3Api.GetCareerFromBattleTag(battleTag);
        }

        public static Career CreateFromJSonStream(Stream stream)
        {
            return stream.CreateFromJsonStream<Career>();
        }

        public static Career CreateFromJSonString(String json)
        {
            return json.CreateFromJsonString<Career>();
        }
    }
}

using System;
using System.IO;
using System.Runtime.Serialization;
using ZTn.BNet.BattleNet;
using ZTn.BNet.D3.Annotations;
using ZTn.BNet.D3.Artisans;
using ZTn.BNet.D3.Helpers;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Progresses;

namespace ZTn.BNet.D3.Careers
{
    [DataContract]
    public class Career
    {
        #region >> Fields

        [DataMember(Name = "battleTag"), UsedImplicitly]
        private String SBattleTag
        {
            set { BattleTag = new BattleTag(value); }
            get { return BattleTag.Id; }
        }

        [IgnoreDataMember]
        public BattleTag BattleTag = new BattleTag("undefined#0000");

        [DataMember(Name = "heroes")]
        public HeroSummary[] Heroes;

        [DataMember(Name = "lastHeroPlayed")]
        public String LastHeroPlayed;

        [DataMember(Name = "artisans")]
        public CareerArtisan[] Artisans;

        [DataMember(Name = "hardcoreArtisans")]
        public CareerArtisan[] HardcoreArtisans;

        [DataMember(Name = "kills")]
        public CareerKills Kills;

        [DataMember(Name = "timePlayed")]
        public ClassTimePlayed TimePlayed;

        [DataMember(Name = "fallenHeroes")]
        public HeroSummary[] FallenHeroes;

        [DataMember(Name = "paragonLevel")]
        public int ParagonLevel;

        [DataMember(Name = "paragonLevelHardcore")]
        public int ParagonLevelHardcore;

        [DataMember(Name = "progression")]
        public Progress Progression;

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
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
    public class Career : D3Object
    {
        #region >> Fields

        [DataMember(Name = "battleTag"), UsedImplicitly]
        private string SBattleTag
        {
            set { BattleTag = new BattleTag(value); }
            get { return BattleTag.Id; }
        }

        [IgnoreDataMember]
        public BattleTag BattleTag = new BattleTag("undefined#0000");

        [DataMember(Name = "guildName")]
        public string GuildName { get; set; }

        [DataMember(Name = "heroes")]
        public HeroSummary[] Heroes { get; set; }

        [DataMember(Name = "lastHeroPlayed")]
        public string LastHeroPlayed { get; set; }

        [DataMember(Name = "lastUpdated")]
        protected long SLastUpdated
        {
            set { LastUpdated = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(value).ToLocalTime(); }
            get { return LastUpdated.Second - new DateTime(1970, 1, 1, 0, 0, 0, 0).Second; }
        }

        [IgnoreDataMember]
        public DateTime LastUpdated { get; set; }

        #region >> Artisans

        [DataMember(Name = "blacksmith")]
        public CareerArtisan Blacksmith;

        [DataMember(Name = "jeweler")]
        public CareerArtisan Jeweler;

        [DataMember(Name = "mystic")]
        public CareerArtisan Mystic;

        [DataMember(Name = "blacksmithHardcore")]
        public CareerArtisan BlacksmithHardcore;

        [DataMember(Name = "jewelerHardcore")]
        public CareerArtisan JewelerHardcore;

        [DataMember(Name = "mysticHardcore")]
        public CareerArtisan MysticHardcore;

        [DataMember(Name = "blacksmithSeason")]
        public CareerArtisan BlacksmithSeason;

        [DataMember(Name = "jewelerSeason")]
        public CareerArtisan JewelerSeason;

        [DataMember(Name = "mysticSeason")]
        public CareerArtisan MysticSeason;

        [DataMember(Name = "blacksmithSeasonHardcore")]
        public CareerArtisan BlacksmithSeasonHardcore;

        [DataMember(Name = "jewelerSeasonHardcore")]
        public CareerArtisan JewelerSeasonHardcore;

        [DataMember(Name = "mysticSeasonHardcore")]
        public CareerArtisan MysticSeasonHardcore;

        #endregion

        [DataMember(Name = "kills")]
        public CareerKills Kills { get; set; }

        [DataMember(Name = "highestHardcoreLevel")]
        public int HighestHardcoreLevel { get; set; }

        [DataMember(Name = "timePlayed")]
        public ClassTimePlayed TimePlayed { get; set; }

        [DataMember(Name = "fallenHeroes")]
        public HeroSummary[] FallenHeroes { get; set; }

        [DataMember(Name = "paragonLevel")]
        public int ParagonLevel { get; set; }

        [DataMember(Name = "paragonLevelHardcore")]
        public int ParagonLevelHardcore { get; set; }

        [DataMember(Name = "paragonLevelSeason")]
        public int ParagonLevelSeason { get; set; }

        [DataMember(Name = "paragonLevelSeasonHardcore")]
        public int ParagonLevelSeasonHardcore { get; set; }

        [DataMember(Name = "progression")]
        public CareerProgress Progression { get; set; }

        [DataMember(Name = "seasonalProfiles")]
        public SeasonalProfiles SeasonalProfiles { get; set; }

        #endregion

        public static Career CreateFromBattleTag(BattleTag battleTag)
        {
            return D3Api.GetCareerFromBattleTag(battleTag);
        }

        public static Career CreateFromJSonStream(Stream stream)
        {
            return stream.CreateFromJsonStream<Career>();
        }

        public static Career CreateFromJSonString(string json)
        {
            return json.CreateFromJsonString<Career>();
        }
    }
}
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using ZTn.BNet.BattleNet;
using ZTn.BNet.D3.Artisans;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Progresses;

namespace ZTn.BNet.D3.Careers
{
    [DataContract]
    public class Career
    {
        #region >> Fields

        [IgnoreDataMember]
        public BattleNet.BattleTag battleTag = new BattleNet.BattleTag("undefined#0000");
        [DataMember]
        public HeroSummary[] heroes;
        [DataMember]
        public String lastHeroPlayed;
        [DataMember]
        public Artisan[] artisans;
        [DataMember]
        public Artisan[] hardcoreArtisans;
        [DataMember]
        public CareerKills kills;
        [DataMember]
        public ClassTimePlayed timePlayed;
        [DataMember]
        public HeroSummary[] fallenHeroes;
        [DataMember]
        public Progress progression;

        #endregion

        #region >> Properties

        [DataMember(Name = "battleTag")]
        public String s_battleTag
        {
            set { battleTag = new BattleNet.BattleTag(value); }
            get { return battleTag.id; }
        }

        #endregion

        public static Career getCareerFromBattleTag(BattleTag battleTag)
        {
            return D3Api.getCareerFromBattleTag(battleTag);
        }

        public static Career getCareerFromJSonStream(Stream stream)
        {
            DataContractJsonSerializer jsSerializer = new DataContractJsonSerializer(typeof(Career));
            Career career = (Career)jsSerializer.ReadObject(stream);
            return career;
        }

        public static Career getCareerFromJSonString(String json)
        {
            return getCareerFromJSonStream(new MemoryStream(System.Text.Encoding.Default.GetBytes(json)));
        }
    }
}

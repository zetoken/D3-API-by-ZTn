using System;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using ZTn.BNet.BattleNet;
using ZTn.BNet.D3.Helpers;
using ZTn.BNet.D3.HeroFollowers;
using ZTn.BNet.D3.Progresses;

namespace ZTn.BNet.D3.Heroes
{
    [DataContract]
    public class Hero : HeroSummary
    {
        #region >> Fields

        [DataMember]
        public int SeasonCreated { get; set; }

        [DataMember]
        public HeroSkills Skills { get; set; }

        [DataMember]
        public LegendaryPower[] LegendaryPowers { get; set; }

        [DataMember]
        public HeroItems Items { get; set; }

        [DataMember]
        public Followers Followers { get; set; }

        [DataMember]
        public HeroStats Stats { get; set; }

        [DataMember]
        public HeroKills Kills { get; set; }

        [DataMember]
        public HeroProgress Progression { get; set; }

        #endregion

        [Obsolete("Deprecated by *Async method.")]
        public static Hero CreateFromHeroId(BattleTag battleTag, string heroId)
        {
            return D3Api.GetHeroFromHeroId(battleTag, heroId);
        }

        public static async Task<Hero> CreateFromHeroIdAsync(BattleTag battleTag, string heroId)
        {
            return await D3Api.GetHeroFromHeroIdAsync(battleTag, heroId);
        }

        public static Hero CreateFromJSonStream(Stream stream)
        {
            return stream.CreateFromJsonStream<Hero>();
        }

        public static Hero CreateFromJSonString(string json)
        {
            return json.CreateFromJsonString<Hero>();
        }
    }
}
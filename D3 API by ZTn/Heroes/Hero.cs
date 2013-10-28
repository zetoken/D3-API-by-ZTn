using System;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ZTn.BNet.BattleNet;
using ZTn.BNet.D3.HeroFollowers;
using ZTn.BNet.D3.Progresses;
using ZTn.BNet.D3.Helpers;

namespace ZTn.BNet.D3.Heroes
{
    [DataContract]
    public class Hero : HeroSummary
    {
        #region >> Fields

        [DataMember]
        public HeroSkills skills;
        [DataMember]
        public HeroItems items;
        [DataMember]
        public Followers followers;
        [DataMember]
        public HeroStats stats;
        [DataMember]
        public HeroKills kills;
        [DataMember]
        public Progress progress;

        #endregion

        public static Hero getHeroFromHeroId(BattleTag battleTag, String heroId)
        {
            return D3Api.getHeroFromHeroID(battleTag, heroId);
        }

        public static Hero getHeroFromJSonStream(Stream stream)
        {
            return JsonHelpers.getFromJSonStream<Hero>(stream);
        }

        public static Hero getHeroFromJSonString(String json)
        {
            return JsonHelpers.getFromJSonString<Hero>(json);
        }
    }
}

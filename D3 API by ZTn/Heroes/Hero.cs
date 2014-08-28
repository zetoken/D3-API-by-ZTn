using System;
using System.IO;
using System.Runtime.Serialization;
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
        public HeroSkills Skills;

        [DataMember]
        public HeroItems Items;

        [DataMember]
        public Followers Followers;

        [DataMember]
        public HeroStats Stats;

        [DataMember]
        public HeroKills Kills;

        [DataMember]
        public HeroProgress Progression;

        #endregion

        public static Hero CreateFromHeroId(BattleTag battleTag, String heroId)
        {
            return D3Api.GetHeroFromHeroId(battleTag, heroId);
        }

        public static Hero CreateFromJSonStream(Stream stream)
        {
            return stream.CreateFromJsonStream<Hero>();
        }

        public static Hero CreateFromJSonString(String json)
        {
            return json.CreateFromJsonString<Hero>();
        }
    }
}
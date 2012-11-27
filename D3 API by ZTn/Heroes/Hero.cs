using System;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ZTn.BNet.BattleNet;
using ZTn.BNet.D3.HeroFollowers;
using ZTn.BNet.D3.Progresses;

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
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader streamReader = new StreamReader(stream))
            {
                return (Hero)serializer.Deserialize(streamReader, typeof(Hero));
            }
        }

        public static Hero getHeroFromJSonString(String json)
        {
            Hero hero;
            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.Default.GetBytes(json)))
            {
                hero = getHeroFromJSonStream(stream);
            }
            return hero;
        }
    }
}

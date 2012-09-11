using System;
using System.Net;
using ZTn.BNet.BattleNet;
using ZTn.BNet.D3.Careers;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3
{
    public class D3Api
    {
        #region >> Properties

        public static String protocolPrefix = "http://";
        public static String host = "eu.battle.net";
        public static String apiPath = "/api/d3/";
        public static String apiUrl
        {
            get { return protocolPrefix + host + apiPath; }
        }

        #endregion

        public static String getCareerUrl(BattleTag battleTag)
        {
            return apiUrl + "profile/" + battleTag.name + "-" + battleTag.code + "/";
        }

        public static String getHeroUrlFromHeroId(BattleTag battleTag, String heroId)
        {
            return getCareerUrl(battleTag) + "hero/" + heroId;
        }

        public static String getItemUrlFromTooltipParams(String tooltipParams)
        {
            return apiUrl + "data/" + tooltipParams;
        }

        public static Career getCareerFromBattleTag(BattleTag battleTag)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(getCareerUrl(battleTag));
            return Career.getCareerFromJSonStream(httpWebRequest.GetResponse().GetResponseStream());
        }

        public static Hero getHeroFromHeroID(BattleTag battleTag, String heroId)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(D3Api.getHeroUrlFromHeroId(battleTag, heroId));
            return Hero.getHeroFromJSonStream(httpWebRequest.GetResponse().GetResponseStream());
        }

        public static Item getItemFromTooltipParams(String tooltipParams)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(D3Api.getItemUrlFromTooltipParams(tooltipParams));
            return Item.getItemFromJSonStream(httpWebRequest.GetResponse().GetResponseStream());
        }
    }
}

using System;
using System.IO;
using System.Net;
using System.Web;
using ZTn.BNet.BattleNet;
using ZTn.BNet.D3.Artisans;
using ZTn.BNet.D3.Careers;
using ZTn.BNet.D3.DataProviders;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;
using ZTn.BNet.D3.Medias;

namespace ZTn.BNet.D3
{
    public class D3Api
    {
        #region >> Fields

        public static String protocolPrefix = "http://";
        public static String host = "eu.battle.net";
        public static String apiPath = "/api/d3/";
        public static String locale = "en";
        public static String mediaPath = "http://media.blizzard.com/d3/";

        public static ID3DataProvider dataProvider = new HttpRequestDataProvider();

        #endregion

        #region >> Properties

        public static String apiUrl
        {
            get { return protocolPrefix + host + apiPath; }
        }
        public static String apiLocaleSuffix
        {
            get { return "?locale=" + locale; }
        }

        #endregion

        public static Artisan getArtisanFromSlug(String slug)
        {
            Artisan artisan;
            using (Stream stream = dataProvider.fetchData(D3Api.getArtisanUrlFromSlug(slug) + apiLocaleSuffix))
            {
                artisan = Artisan.getArtisanFromJSonStream(stream);
            }
            return artisan;
        }

        public static String getArtisanUrlFromSlug(String slug)
        {
            return apiUrl + "data/artisan/" + slug;
        }

        public static Career getCareerFromBattleTag(BattleTag battleTag)
        {
            Career career;
            using (Stream stream = dataProvider.fetchData(getCareerUrl(battleTag) + "/index" + apiLocaleSuffix))
            {
                career = Career.getCareerFromJSonStream(stream);
            }
            return career;
        }

        public static String getCareerUrl(BattleTag battleTag)
        {
            return apiUrl + "profile/" + HttpUtility.UrlEncode(battleTag.name) + "-" + battleTag.code + "/";
        }

        public static Hero getHeroFromHeroID(BattleTag battleTag, String heroId)
        {
            Hero hero;
            using (Stream stream = dataProvider.fetchData(D3Api.getHeroUrlFromHeroId(battleTag, heroId) + apiLocaleSuffix))
            {
                hero = Hero.getHeroFromJSonStream(stream);
            }
            return hero;
        }

        public static String getHeroUrlFromHeroId(BattleTag battleTag, String heroId)
        {
            return getCareerUrl(battleTag) + "hero/" + heroId;
        }

        public static Item getItemFromTooltipParams(String tooltipParams)
        {
            Item item;
            using (Stream stream = dataProvider.fetchData(D3Api.getItemUrlFromTooltipParams(tooltipParams) + apiLocaleSuffix))
            {
                item = Item.getItemFromJSonStream(stream);
            }
            return item;
        }

        public static String getItemUrlFromTooltipParams(String tooltipParams)
        {
            return apiUrl + "data/" + tooltipParams;
        }

        public static String getItemIconUrl(String icon, String size)
        {
            return mediaPath + "icons/items/" + size + "/" + icon + ".png";
        }

        public static D3Picture getItemIcon(String icon)
        {
            D3Picture picture;
            using (Stream stream = dataProvider.fetchData(D3Api.getItemIconUrl(icon, "small")))
            {
                picture = new D3Picture(stream);
            }
            return picture;
        }

        public static D3Picture getItemIcon(String icon, String size)
        {
            D3Picture picture;
            using (Stream stream = dataProvider.fetchData(D3Api.getItemIconUrl(icon, size)))
            {
                picture = new D3Picture(stream);
            }
            return picture;
        }

        public static String getSkillIconUrl(String icon, String size)
        {
            return mediaPath + "icons/skills/" + size + "/" + icon + ".png";
        }

        public static D3Picture getSkillIcon(String icon)
        {
            return getSkillIcon(icon, "42");
        }

        public static D3Picture getSkillIcon(String icon, String size)
        {
            D3Picture picture;
            using (Stream stream = dataProvider.fetchData(D3Api.getSkillIconUrl(icon, size)))
            {
                picture = new D3Picture(stream);
            }
            return picture;
        }
    }
}

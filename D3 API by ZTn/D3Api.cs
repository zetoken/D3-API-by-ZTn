using System;
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
        public static String ProtocolPrefix = "http://";
        public static String Host = "eu.battle.net";
        public static String ApiPath = "/api/d3/";
        public static String Locale = "en";
        public static String MediaPath = "http://media.blizzard.com/d3/";

        public static ID3DataProvider DataProvider = new HttpRequestDataProvider();

        public static String ApiUrl
        {
            get { return ProtocolPrefix + Host + ApiPath; }
        }

        public static String ApiLocaleSuffix
        {
            get { return "?locale=" + Locale; }
        }

        public static Artisan GetArtisanFromSlug(String slug)
        {
            Artisan artisan;
            using (var stream = DataProvider.FetchData(GetArtisanUrlFromSlug(slug) + ApiLocaleSuffix))
            {
                artisan = Artisan.CreateFromJSonStream(stream);
            }
            return artisan;
        }

        public static String GetArtisanUrlFromSlug(String slug)
        {
            return ApiUrl + "data/artisan/" + slug;
        }

        public static Career GetCareerFromBattleTag(BattleTag battleTag)
        {
            Career career;
            using (var stream = DataProvider.FetchData(GetCareerUrl(battleTag) + "/index" + ApiLocaleSuffix))
            {
                career = Career.CreateFromJSonStream(stream);
            }
            return career;
        }

        public static String GetCareerUrl(BattleTag battleTag)
        {
            return ApiUrl + "profile/" + Uri.EscapeUriString(battleTag.Name) + "-" + battleTag.Code + "/";
        }

        public static Hero GetHeroFromHeroId(BattleTag battleTag, String heroId)
        {
            Hero hero;
            using (var stream = DataProvider.FetchData(GetHeroUrlFromHeroId(battleTag, heroId) + ApiLocaleSuffix))
            {
                hero = Hero.CreateFromJSonStream(stream);
            }
            return hero;
        }

        public static String GetHeroUrlFromHeroId(BattleTag battleTag, String heroId)
        {
            return GetCareerUrl(battleTag) + "hero/" + heroId;
        }

        public static Item GetItemFromTooltipParams(String tooltipParams)
        {
            Item item;
            using (var stream = DataProvider.FetchData(GetItemUrlFromTooltipParams(tooltipParams) + ApiLocaleSuffix))
            {
                item = Item.CreateFromJSonStream(stream);
            }
            return item;
        }

        public static String GetItemUrlFromTooltipParams(String tooltipParams)
        {
            return ApiUrl + "data/" + tooltipParams;
        }

        public static String GetItemIconUrl(String icon, String size)
        {
            return MediaPath + "icons/items/" + size + "/" + icon + ".png";
        }

        public static D3Picture GetItemIcon(String icon)
        {
            D3Picture picture;
            using (var stream = DataProvider.FetchData(GetItemIconUrl(icon, "small")))
            {
                picture = new D3Picture(stream);
            }
            return picture;
        }

        public static D3Picture GetItemIcon(String icon, String size)
        {
            D3Picture picture;
            using (var stream = DataProvider.FetchData(GetItemIconUrl(icon, size)))
            {
                picture = new D3Picture(stream);
            }
            return picture;
        }

        public static String GetSkillIconUrl(String icon, String size)
        {
            return MediaPath + "icons/skills/" + size + "/" + icon + ".png";
        }

        public static D3Picture GetSkillIcon(String icon)
        {
            return GetSkillIcon(icon, "42");
        }

        public static D3Picture GetSkillIcon(String icon, String size)
        {
            D3Picture picture;
            using (var stream = DataProvider.FetchData(GetSkillIconUrl(icon, size)))
            {
                picture = new D3Picture(stream);
            }
            return picture;
        }
    }
}
using System;
using System.IO;
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
        public static String ProtocolPrefix = "https://";
        public static String Host = "eu.api.battle.net";
        public static String ApiPath = "/d3/";
        public static String Locale = "en";
        public static String MediaPath = "http://media.blizzard.com/d3/";

        public static ID3DataProvider DataProvider = new HttpRequestDataProvider();

        public static String ApiKey { get; set; }

        public static String ApiKeySuffix
        {
            get
            {
                if (ApiKey == null)
                {
                    throw new MissingApiKey();
                }

                return "&apikey=" + ApiKey;
            }
        }

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
            using (var stream = DataProvider.FetchData(GetArtisanUrlFromSlug(slug) + ApiLocaleSuffix + ApiKeySuffix))
            {
                artisan = Artisan.CreateFromJSonStream(stream);
            }
            return artisan != null && artisan.IsValidObject() ? artisan : null;
        }

        public static void GetArtisanFromSlug(String slug, Action<Artisan> onSuccess, Action onFailure)
        {
            DataProvider.FetchData(GetArtisanUrlFromSlug(slug) + ApiLocaleSuffix + ApiKeySuffix,
                stream =>
                {
                    var artisan = Artisan.CreateFromJSonStream(stream);
                    stream.Dispose();
                    if (artisan.IsValidObject())
                    {
                        onSuccess(artisan);
                    }
                    else
                    {
                        onFailure();
                    }
                },
                onFailure
                );
        }

        public static String GetArtisanUrlFromSlug(String slug)
        {
            return ApiUrl + "data/artisan/" + slug;
        }

        public static Career GetCareerFromBattleTag(BattleTag battleTag)
        {
            Career career;
            using (var stream = DataProvider.FetchData(GetCareerUrl(battleTag) + "/index" + ApiLocaleSuffix + ApiKeySuffix))
            {
                career = Career.CreateFromJSonStream(stream);
            }

            return career != null && career.IsValidObject() ? career : null;
        }

        public static void GetCareerFromBattleTag(BattleTag battleTag, Action<Career> onSuccess, Action onFailure)
        {
            DataProvider.FetchData(GetCareerUrl(battleTag) + "/index" + ApiLocaleSuffix + ApiKeySuffix,
                stream =>
                {
                    var career = Career.CreateFromJSonStream(stream);
                    stream.Dispose();
                    if (career != null && career.IsValidObject())
                    {
                        onSuccess(career);
                    }
                    else
                    {
                        onFailure();
                    }
                },
                onFailure
                );
        }

        public static String GetCareerUrl(BattleTag battleTag)
        {
            return ApiUrl + "profile/" + Uri.EscapeUriString(battleTag.Name) + "-" + battleTag.Code + "/";
        }

        public static Hero GetHeroFromHeroId(BattleTag battleTag, String heroId)
        {
            Hero hero;
            using (var stream = DataProvider.FetchData(GetHeroUrlFromHeroId(battleTag, heroId) + ApiLocaleSuffix + ApiKeySuffix))
            {
                hero = Hero.CreateFromJSonStream(stream);
            }
            return hero != null && hero.IsValidObject() ? hero : null;
        }

        public static void GetHeroFromHeroId(BattleTag battleTag, String heroId, Action<Hero> onSuccess, Action onFailure)
        {
            DataProvider.FetchData(GetHeroUrlFromHeroId(battleTag, heroId) + ApiLocaleSuffix + ApiKeySuffix,
                stream =>
                {
                    var hero = Hero.CreateFromJSonStream(stream);
                    stream.Dispose();
                    if (hero.IsValidObject())
                    {
                        onSuccess(hero);
                    }
                    else
                    {
                        onFailure();
                    }
                },
                onFailure
                );
        }

        public static String GetHeroUrlFromHeroId(BattleTag battleTag, String heroId)
        {
            return GetCareerUrl(battleTag) + "hero/" + heroId;
        }

        public static Item GetItemFromTooltipParams(String tooltipParams)
        {
            Item item;
            using (var stream = DataProvider.FetchData(GetItemUrlFromTooltipParams(tooltipParams) + ApiLocaleSuffix + ApiKeySuffix))
            {
                item = Item.CreateFromJSonStream(stream);
            }
            return item != null && item.IsValidObject() ? item : null;
        }

        public static void GetItemFromTooltipParams(String tooltipParams, Action<Item> onSuccess, Action onFailure)
        {
            DataProvider.FetchData(GetItemUrlFromTooltipParams(tooltipParams) + ApiLocaleSuffix + ApiKeySuffix,
                stream =>
                {
                    var item = Item.CreateFromJSonStream(stream);
                    stream.Dispose();
                    if (item.IsValidObject())
                    {
                        onSuccess(item);
                    }
                    else
                    {
                        onFailure();
                    }
                },
                onFailure
                );
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

        public static void GetItemIcon(String icon, Action<D3Picture> onSuccess, Action onFailure)
        {
            GetItemIcon(icon, "small", onSuccess, onFailure);
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

        public static void GetItemIcon(String icon, String size, Action<D3Picture> onSuccess, Action onFailure)
        {
            DataProvider.FetchData(GetItemIconUrl(icon, size),
                stream => OnSuccessStreamToD3Picture(stream, onSuccess),
                onFailure
                );
        }

        public static String GetSkillIconUrl(String icon, String size)
        {
            return MediaPath + "icons/skills/" + size + "/" + icon + ".png";
        }

        public static D3Picture GetSkillIcon(String icon)
        {
            return GetSkillIcon(icon, "42");
        }

        public static void GetSkillIcon(String icon, Action<D3Picture> onSuccess, Action onFailure)
        {
            GetSkillIcon(icon, "42", onSuccess, onFailure);
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

        public static void GetSkillIcon(string icon, string size, Action<D3Picture> onSuccess, Action onFailure)
        {
            DataProvider.FetchData(GetSkillIconUrl(icon, size),
                stream => OnSuccessStreamToD3Picture(stream, onSuccess),
                onFailure
                );
        }

        /// <summary>
        /// Callback
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="onSuccess"></param>
        private static void OnSuccessStreamToD3Picture(Stream stream, Action<D3Picture> onSuccess)
        {
            var picture = new D3Picture(stream);
            stream.Dispose();
            onSuccess(picture);
        }
    }
}
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
    public class D3ApiRequester
    {
        public string ProtocolPrefix { get; set; } = "https://";

        public string Host { get; set; } = "eu.api.battle.net";

        public string ApiPath { get; set; } = "/d3/";

        public string Locale { get; set; } = "en";

        public string MediaPath { get; set; } = "http://media.blizzard.com/d3/";

        public ID3DataProvider DataProvider { get; set; }

        public string ApiKey { get; set; }

        private string ApiKeySuffix
        {
            get
            {
                if (ApiKey == null)
                {
                    throw new MissingApiKey();
                }

                return $"&apikey={ApiKey}";
            }
        }

        private string ApiUrl => $"{ProtocolPrefix}{Host}{ApiPath}";

        private string ApiLocaleSuffix => $"?locale={Locale}";

        #region >> Constructors

        public D3ApiRequester()
            : this(new HttpRequestDataProvider())
        {
        }

        private D3ApiRequester(ID3DataProvider dataProvider)
        {
            DataProvider = dataProvider;
        }

        #endregion

        public Artisan GetArtisanFromSlug(string slug)
        {
            Artisan artisan;
            using (var stream = DataProvider.FetchData($"{GetArtisanUrlFromSlug(slug)}{ApiLocaleSuffix}{ApiKeySuffix}"))
            {
                artisan = Artisan.CreateFromJSonStream(stream);
            }
            return artisan != null && artisan.IsValidObject() ? artisan : null;
        }

        public void GetArtisanFromSlug(string slug, Action<Artisan> onSuccess, Action onFailure)
        {
            DataProvider.FetchData($"{GetArtisanUrlFromSlug(slug)}{ApiLocaleSuffix}{ApiKeySuffix}",
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

        public string GetArtisanUrlFromSlug(string slug)
        {
            return $"{ApiUrl}data/artisan/{slug}";
        }

        public Career GetCareerFromBattleTag(BattleTag battleTag)
        {
            Career career;
            using (var stream = DataProvider.FetchData($"{GetCareerUrl(battleTag)}{$"index{ApiLocaleSuffix}{ApiKeySuffix}"}"))
            {
                career = Career.CreateFromJSonStream(stream);
            }

            return career != null && career.IsValidObject() ? career : null;
        }

        public void GetCareerFromBattleTag(BattleTag battleTag, Action<Career> onSuccess, Action onFailure)
        {
            DataProvider.FetchData($"{GetCareerUrl(battleTag)}/index{ApiLocaleSuffix}{ApiKeySuffix}",
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

        public string GetCareerUrl(BattleTag battleTag)
        {
            return $"{ApiUrl}profile/{Uri.EscapeUriString(battleTag.Name)}-{battleTag.Code}/";
        }

        public Hero GetHeroFromHeroId(BattleTag battleTag, string heroId)
        {
            Hero hero;
            using (var stream = DataProvider.FetchData($"{GetHeroUrlFromHeroId(battleTag, heroId)}{ApiLocaleSuffix}{ApiKeySuffix}"))
            {
                hero = Hero.CreateFromJSonStream(stream);
            }
            return hero != null && hero.IsValidObject() ? hero : null;
        }

        public void GetHeroFromHeroId(BattleTag battleTag, string heroId, Action<Hero> onSuccess, Action onFailure)
        {
            DataProvider.FetchData($"{GetHeroUrlFromHeroId(battleTag, heroId)}{ApiLocaleSuffix}{ApiKeySuffix}",
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

        public string GetHeroUrlFromHeroId(BattleTag battleTag, string heroId)
        {
            return $"{GetCareerUrl(battleTag)}hero/{heroId}";
        }

        public Item GetItemFromTooltipParams(string tooltipParams)
        {
            Item item;
            using (var stream = DataProvider.FetchData($"{GetItemUrlFromTooltipParams(tooltipParams)}{ApiLocaleSuffix}{ApiKeySuffix}"))
            {
                item = Item.CreateFromJSonStream(stream);
            }
            return item != null && item.IsValidObject() ? item : null;
        }

        public void GetItemFromTooltipParams(string tooltipParams, Action<Item> onSuccess, Action onFailure)
        {
            DataProvider.FetchData($"{GetItemUrlFromTooltipParams(tooltipParams)}{ApiLocaleSuffix}{ApiKeySuffix}",
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

        public string GetItemUrlFromTooltipParams(string tooltipParams)
        {
            return $"{ApiUrl}data/{tooltipParams}";
        }

        public string GetItemIconUrl(string icon, string size)
        {
            return $"{MediaPath}icons/items/{size}/{icon}.png";
        }

        public D3Picture GetItemIcon(string icon)
        {
            D3Picture picture;
            using (var stream = DataProvider.FetchData(GetItemIconUrl(icon, "small")))
            {
                picture = new D3Picture(stream);
            }
            return picture;
        }

        public void GetItemIcon(string icon, Action<D3Picture> onSuccess, Action onFailure)
        {
            GetItemIcon(icon, "small", onSuccess, onFailure);
        }

        public D3Picture GetItemIcon(string icon, string size)
        {
            D3Picture picture;
            using (var stream = DataProvider.FetchData(GetItemIconUrl(icon, size)))
            {
                picture = new D3Picture(stream);
            }
            return picture;
        }

        public void GetItemIcon(string icon, string size, Action<D3Picture> onSuccess, Action onFailure)
        {
            DataProvider.FetchData(GetItemIconUrl(icon, size),
                stream => OnSuccessStreamToD3Picture(stream, onSuccess),
                onFailure
                );
        }

        public string GetSkillIconUrl(string icon, string size)
        {
            return $"{MediaPath}icons/skills/{size}/{icon}.png";
        }

        public D3Picture GetSkillIcon(string icon)
        {
            return GetSkillIcon(icon, "42");
        }

        public void GetSkillIcon(string icon, Action<D3Picture> onSuccess, Action onFailure)
        {
            GetSkillIcon(icon, "42", onSuccess, onFailure);
        }

        public D3Picture GetSkillIcon(string icon, string size)
        {
            D3Picture picture;
            using (var stream = DataProvider.FetchData(GetSkillIconUrl(icon, size)))
            {
                picture = new D3Picture(stream);
            }
            return picture;
        }

        public void GetSkillIcon(string icon, string size, Action<D3Picture> onSuccess, Action onFailure)
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

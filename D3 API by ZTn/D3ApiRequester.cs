using System;
using System.Threading.Tasks;
using ZTn.BNet.BattleNet;
using ZTn.BNet.D3.Artisans;
using ZTn.BNet.D3.Careers;
using ZTn.BNet.D3.DataProviders;
using ZTn.BNet.D3.Helpers;
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

        public Artisan GetArtisanFromSlug(string slug) =>
            GetFromDataProvider<Artisan>(GetArtisanUrlFromSlug(slug, true));

        public Task<Artisan> GetArtisanFromSlugAsync(string slug) =>
            GetFromDataProviderAsync<Artisan>(GetArtisanUrlFromSlug(slug, true));

        public string GetArtisanUrlFromSlug(string slug, bool fullUrl = false)
        {
            return fullUrl ?
                $"{ApiUrl}data/artisan/{slug}{ApiLocaleSuffix}{ApiKeySuffix}" :
                $"{ApiUrl}data/artisan/{slug}";
        }

        public Career GetCareerFromBattleTag(BattleTag battleTag) =>
            GetFromDataProvider<Career>(GetCareerUrl(battleTag, true));

        public Task<Career> GetCareerFromBattleTagAsync(BattleTag battleTag) =>
            GetFromDataProviderAsync<Career>(GetCareerUrl(battleTag, true));

        public string GetCareerUrl(BattleTag battleTag, bool fullUrl = false)
        {
            return fullUrl ?
                $"{ApiUrl}profile/{Uri.EscapeUriString(battleTag.Name)}-{battleTag.Code}/index{ApiLocaleSuffix}{ApiKeySuffix}" :
                $"{ApiUrl}profile/{Uri.EscapeUriString(battleTag.Name)}-{battleTag.Code}/";
        }

        public Hero GetHeroFromHeroId(BattleTag battleTag, string heroId) =>
            GetFromDataProvider<Hero>(GetHeroUrlFromHeroId(battleTag, heroId, true));

        public Task<Hero> GetHeroFromHeroIdAsync(BattleTag battleTag, string heroId) =>
            GetFromDataProviderAsync<Hero>(GetHeroUrlFromHeroId(battleTag, heroId, true));

        public string GetHeroUrlFromHeroId(BattleTag battleTag, string heroId, bool fullUrl = false)
        {
            return fullUrl ?
                $"{GetCareerUrl(battleTag)}hero/{heroId}{ApiLocaleSuffix}{ApiKeySuffix}" :
                $"{GetCareerUrl(battleTag)}hero/{heroId}";
        }

        public Item GetItemFromTooltipParams(string tooltipParams) =>
            GetFromDataProvider<Item>(GetItemUrlFromTooltipParams(tooltipParams, true));

        public Task<Item> GetItemFromTooltipParamsAsync(string tooltipParams) =>
            GetFromDataProviderAsync<Item>(GetItemUrlFromTooltipParams(tooltipParams, true));

        public string GetItemUrlFromTooltipParams(string tooltipParams, bool fullUrl = false)
        {
            return fullUrl ?
                $"{ApiUrl}data/{tooltipParams}{ApiLocaleSuffix}{ApiKeySuffix}" :
                $"{ApiUrl}data/{tooltipParams}";
        }

        public D3Picture GetItemIcon(string icon) =>
            GetPictureFromDataProvider(GetItemIconUrl(icon, "small"));

        public D3Picture GetItemIcon(string icon, string size) =>
            GetPictureFromDataProvider(GetItemIconUrl(icon, size));

        public Task<D3Picture> GetItemIconAsync(string icon) =>
            GetPictureFromDataProviderAsync(GetItemIconUrl(icon, "small"));

        public string GetItemIconUrl(string icon, string size) =>
            $"{MediaPath}icons/items/{size}/{icon}.png";

        public D3Picture GetSkillIcon(string icon) =>
            GetSkillIcon(icon, "42");

        public D3Picture GetSkillIcon(string icon, string size) =>
            GetPictureFromDataProvider(GetSkillIconUrl(icon, size));

        public string GetSkillIconUrl(string icon, string size) =>
            $"{MediaPath}icons/skills/{size}/{icon}.png";

        private T GetFromDataProvider<T>(string url) where T : D3Object
        {
            T data;

            using (var stream = DataProvider.FetchData(url))
            {
                data = stream.CreateFromJsonStream<T>();
            }

            return data != null && data.IsValidObject() ? data : null;
        }

        private async Task<T> GetFromDataProviderAsync<T>(string url) where T : D3Object
        {
            T data;

            using (var stream = await DataProvider.FetchDataAsync(url).ConfigureAwait(false))
            {
                data = await stream.CreateFromJsonStreamAsync<T>().ConfigureAwait(false);
            }

            return data != null && data.IsValidObject() ? data : null;
        }

        private D3Picture GetPictureFromDataProvider(string url)
        {
            D3Picture picture;

            using (var stream = DataProvider.FetchData(url))
            {
                picture = new D3Picture(stream);
            }

            return picture;
        }

        private async Task<D3Picture> GetPictureFromDataProviderAsync(string url)
        {
            D3Picture picture;

            using (var stream = await DataProvider.FetchDataAsync(url))
            {
                picture = new D3Picture(stream);
            }

            return picture;
        }
    }
}

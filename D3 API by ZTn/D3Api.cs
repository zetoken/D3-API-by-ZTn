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
    public class D3Api
    {
        private static readonly D3ApiRequester Requester = new D3ApiRequester();

        public static string ProtocolPrefix
        {
            get { return Requester.ProtocolPrefix; }
            set { Requester.ProtocolPrefix = value; }
        }

        public static string Host
        {
            get { return Requester.Host; }
            set { Requester.Host = value; }
        }

        public static string ApiPath
        {
            get { return Requester.ApiPath; }
            set { Requester.ApiPath = value; }
        }

        public static string Locale
        {
            get { return Requester.Locale; }
            set { Requester.Locale = value; }
        }

        public static string MediaPath
        {
            get { return Requester.MediaPath; }
            set { Requester.MediaPath = value; }
        }

        public static ID3DataProvider DataProvider
        {
            get { return Requester.DataProvider; }
            set { Requester.DataProvider = value; }
        }

        public static string ApiKey
        {
            get { return Requester.ApiKey; }
            set { Requester.ApiKey = value; }
        }

        static D3Api()
        {
            DataProvider = new HttpRequestDataProvider();
        }

        public static Artisan GetArtisanFromSlug(string slug) =>
            Requester.GetArtisanFromSlug(slug);

        [Obsolete("Deprecated by *Async method.")]
        public static void GetArtisanFromSlug(string slug, Action<Artisan> onSuccess, Action onFailure) =>
            GetFromDataProvider(Requester.GetArtisanUrlFromSlug(slug, true), onSuccess, onFailure);

        public static Task<Artisan> GetArtisanFromSlugAsync(string slug) =>
            Requester.GetArtisanFromSlugAsync(slug);

        public static string GetArtisanUrlFromSlug(string slug) =>
            Requester.GetArtisanUrlFromSlug(slug);

        public static Career GetCareerFromBattleTag(BattleTag battleTag) =>
            Requester.GetCareerFromBattleTag(battleTag);

        [Obsolete("Deprecated by *Async method.")]
        public static void GetCareerFromBattleTag(BattleTag battleTag, Action<Career> onSuccess, Action onFailure) =>
            GetFromDataProvider(Requester.GetCareerUrl(battleTag, true), onSuccess, onFailure);

        public static Task<Career> GetCareerFromBattleTagAsync(BattleTag battleTag) =>
            Requester.GetCareerFromBattleTagAsync(battleTag);

        public static string GetCareerUrl(BattleTag battleTag) =>
            Requester.GetCareerUrl(battleTag);

        public static Hero GetHeroFromHeroId(BattleTag battleTag, string heroId) =>
            Requester.GetHeroFromHeroId(battleTag, heroId);

        [Obsolete("Deprecated by *Async method.")]
        public static void GetHeroFromHeroId(BattleTag battleTag, string heroId, Action<Hero> onSuccess, Action onFailure) =>
            GetFromDataProvider($"{Requester.GetHeroUrlFromHeroId(battleTag, heroId, true)}", onSuccess, onFailure);

        public static Task<Hero> GetHeroFromHeroIdAsync(BattleTag battleTag, string heroId) =>
            Requester.GetHeroFromHeroIdAsync(battleTag, heroId);

        public static string GetHeroUrlFromHeroId(BattleTag battleTag, string heroId) =>
            Requester.GetHeroUrlFromHeroId(battleTag, heroId);

        public static Item GetItemFromTooltipParams(string tooltipParams) =>
            Requester.GetItemFromTooltipParams(tooltipParams);

        [Obsolete("Deprecated by *Async method.")]
        public static void GetItemFromTooltipParams(string tooltipParams, Action<Item> onSuccess, Action onFailure) =>
            GetFromDataProvider(Requester.GetItemUrlFromTooltipParams(tooltipParams, true), onSuccess, onFailure);

        public static Task<Item> GetItemFromTooltipParamsAsync(string tooltipParams) =>
            Requester.GetItemFromTooltipParamsAsync(tooltipParams);

        public static string GetItemUrlFromTooltipParams(string tooltipParams) =>
            Requester.GetItemUrlFromTooltipParams(tooltipParams);

        public static D3Picture GetItemIcon(string icon) =>
            Requester.GetItemIcon(icon);

        public static D3Picture GetItemIcon(string icon, string size) =>
            Requester.GetItemIcon(icon, size);

        [Obsolete("Deprecated by *Async method.")]
        public static void GetItemIcon(string icon, Action<D3Picture> onSuccess, Action onFailure) =>
            GetPictureFromDataProvider(GetItemIconUrl(icon, "small"), onSuccess, onFailure);

        [Obsolete("Deprecated by *Async method.")]
        public static void GetItemIcon(string icon, string size, Action<D3Picture> onSuccess, Action onFailure) =>
            GetPictureFromDataProvider(GetItemIconUrl(icon, size), onSuccess, onFailure);

        public static string GetItemIconUrl(string icon, string size) =>
            Requester.GetItemIconUrl(icon, size);

        public static D3Picture GetSkillIcon(string icon) =>
            Requester.GetSkillIcon(icon);

        public static D3Picture GetSkillIcon(string icon, string size) =>
            Requester.GetSkillIcon(icon, size);

        [Obsolete("Deprecated by *Async method.")]
        public static void GetSkillIcon(string icon, Action<D3Picture> onSuccess, Action onFailure) =>
            GetPictureFromDataProvider(GetSkillIconUrl(icon, "42"), onSuccess, onFailure);

        [Obsolete("Deprecated by *Async method.")]
        public static void GetSkillIcon(string icon, string size, Action<D3Picture> onSuccess, Action onFailure) =>
            GetPictureFromDataProvider(GetSkillIconUrl(icon, size), onSuccess, onFailure);

        public static string GetSkillIconUrl(string icon, string size) =>
            Requester.GetSkillIconUrl(icon, size);

        [Obsolete("For D3 API v2 compatibility.", false)]
        private static void GetFromDataProvider<T>(string url, Action<T> onSuccess, Action onFailure) where T : D3Object
        {
            DataProvider.FetchData(url,
                stream =>
                {
                    var data = stream.CreateFromJsonStream<T>();
                    stream.Dispose();
                    if (data.IsValidObject())
                    {
                        onSuccess(data);
                    }
                    else
                    {
                        onFailure();
                    }
                },
                onFailure
                );
        }

        [Obsolete("For D3 API v2 compatibility.", false)]
        private static void GetPictureFromDataProvider(string url, Action<D3Picture> onSuccess, Action onFailure)
        {
            DataProvider.FetchData(url,
                stream =>
                {
                    var picture = new D3Picture(stream);
                    stream.Dispose();
                    onSuccess(picture);
                },
                onFailure
                );
        }
    }
}
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

        public static Artisan GetArtisanFromSlug(string slug)
        {
            return Requester.GetArtisanFromSlug(slug);
        }

        public static void GetArtisanFromSlug(string slug, Action<Artisan> onSuccess, Action onFailure)
        {
            Requester.GetArtisanFromSlug(slug, onSuccess, onFailure);
        }

        public static string GetArtisanUrlFromSlug(string slug)
        {
            return Requester.GetArtisanUrlFromSlug(slug);
        }

        public static Career GetCareerFromBattleTag(BattleTag battleTag)
        {
            return Requester.GetCareerFromBattleTag(battleTag);
        }

        public static void GetCareerFromBattleTag(BattleTag battleTag, Action<Career> onSuccess, Action onFailure)
        {
            Requester.GetCareerFromBattleTag(battleTag, onSuccess, onFailure);
        }

        public static string GetCareerUrl(BattleTag battleTag)
        {
            return Requester.GetCareerUrl(battleTag);
        }

        public static Hero GetHeroFromHeroId(BattleTag battleTag, string heroId)
        {
            return Requester.GetHeroFromHeroId(battleTag, heroId);
        }

        public static void GetHeroFromHeroId(BattleTag battleTag, string heroId, Action<Hero> onSuccess, Action onFailure)
        {
            Requester.GetHeroFromHeroId(battleTag, heroId, onSuccess, onFailure);
        }

        public static string GetHeroUrlFromHeroId(BattleTag battleTag, string heroId)
        {
            return Requester.GetHeroUrlFromHeroId(battleTag, heroId);
        }

        public static Item GetItemFromTooltipParams(string tooltipParams)
        {
            return Requester.GetItemFromTooltipParams(tooltipParams);
        }

        public static void GetItemFromTooltipParams(string tooltipParams, Action<Item> onSuccess, Action onFailure)
        {
            Requester.GetItemFromTooltipParams(tooltipParams, onSuccess, onFailure);
        }

        public static string GetItemUrlFromTooltipParams(string tooltipParams)
        {
            return Requester.GetItemUrlFromTooltipParams(tooltipParams);
        }

        public static string GetItemIconUrl(string icon, string size)
        {
            return Requester.GetItemIconUrl(icon, size);
        }

        public static D3Picture GetItemIcon(string icon)
        {
            return Requester.GetItemIcon(icon);
        }

        public static void GetItemIcon(string icon, Action<D3Picture> onSuccess, Action onFailure)
        {
            Requester.GetItemIcon(icon, onSuccess, onFailure);
        }

        public static D3Picture GetItemIcon(string icon, string size)
        {
            return Requester.GetItemIcon(icon, size);
        }

        public static void GetItemIcon(string icon, string size, Action<D3Picture> onSuccess, Action onFailure)
        {
            Requester.GetItemIcon(icon, size, onSuccess, onFailure);
        }

        public static string GetSkillIconUrl(string icon, string size)
        {
            return Requester.GetSkillIconUrl(icon, size);
        }

        public static D3Picture GetSkillIcon(string icon)
        {
            return Requester.GetSkillIcon(icon);
        }

        public static void GetSkillIcon(string icon, Action<D3Picture> onSuccess, Action onFailure)
        {
            Requester.GetSkillIcon(icon, onSuccess, onFailure);
        }

        public static D3Picture GetSkillIcon(string icon, string size)
        {
            return Requester.GetSkillIcon(icon, size);
        }

        public static void GetSkillIcon(string icon, string size, Action<D3Picture> onSuccess, Action onFailure)
        {
            Requester.GetSkillIcon(icon, size, onSuccess, onFailure);
        }
    }
}
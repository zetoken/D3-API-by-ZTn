using System.IO;
using System.Text;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using ZTn.BNet.BattleNet;
using ZTn.BNet.D3.Artisans;
using ZTn.BNet.D3.Careers;
using ZTn.BNet.D3.DataProviders;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;
using ZTn.BNet.D3.Medias;

namespace ZTn.BNet.D3
{
    [TestFixture]
    public class D3ApiUnitTest
    {
        private readonly BattleTag battleTag = new BattleTag("tok#2360");

        [Test]
        public void GetArtisanUrlFromSlug()
        {
            var url = D3Api.GetArtisanUrlFromSlug("whatsoever");
            Assert.AreEqual("http://eu.battle.net/api/d3/data/artisan/whatsoever", url);
        }

        [Test]
        public void GetArtisanFromSlug()
        {
            var mock = new Mock<ID3DataProvider>();
            mock.Setup(p => p.FetchData("http://eu.battle.net/api/d3/data/artisan/whatsoever?locale=en"))
                .Returns<string>(p => new MemoryStream(Encoding.Default.GetBytes(JsonConvert.SerializeObject(new Artisan()))));
            D3Api.DataProvider = mock.Object;

            var obj = D3Api.GetArtisanFromSlug("whatsoever");

            Assert.IsNotNull(obj);
        }

        [Test]
        public void GetCareerUrl()
        {
            var url = D3Api.GetCareerUrl(battleTag);
            Assert.AreEqual("http://eu.battle.net/api/d3/profile/tok-2360/", url);
        }

        [Test]
        public void GetCareerFromBattleTag()
        {
            var mock = new Mock<ID3DataProvider>();
            mock.Setup(p => p.FetchData("http://eu.battle.net/api/d3/profile/tok-2360//index?locale=en"))
                .Returns<string>(p => new MemoryStream(Encoding.Default.GetBytes(JsonConvert.SerializeObject(new Career()))));
            D3Api.DataProvider = mock.Object;

            var obj = D3Api.GetCareerFromBattleTag(battleTag);

            Assert.IsNotNull(obj);
        }

        [Test]
        public void GetHeroUrlFromHeroId()
        {
            var url = D3Api.GetHeroUrlFromHeroId(battleTag, "whatsoever");
            Assert.AreEqual("http://eu.battle.net/api/d3/profile/tok-2360/hero/whatsoever", url);
        }

        [Test]
        public void GetHeroFromHeroId()
        {
            var mock = new Mock<ID3DataProvider>();
            mock.Setup(p => p.FetchData("http://eu.battle.net/api/d3/profile/tok-2360/hero/whatsoever?locale=en"))
                .Returns<string>(p => new MemoryStream(Encoding.Default.GetBytes(JsonConvert.SerializeObject(new Hero()))));
            D3Api.DataProvider = mock.Object;

            var obj = D3Api.GetHeroFromHeroId(battleTag, "whatsoever");

            Assert.IsNotNull(obj);
        }

        [Test]
        public void GetItemIconUrl()
        {
            var url = D3Api.GetItemIconUrl("whatsoever", "64");
            Assert.AreEqual("http://media.blizzard.com/d3/icons/items/64/whatsoever.png", url);
        }

        [Test]
        public void GetItemIcon()
        {
            var mock = new Mock<ID3DataProvider>();
            mock.Setup(p => p.FetchData("http://media.blizzard.com/d3/icons/items/64/whatsoever.png"))
                .Returns<string>(p => new MemoryStream(Encoding.Default.GetBytes(JsonConvert.SerializeObject(new D3Picture()))));
            D3Api.DataProvider = mock.Object;

            var obj = D3Api.GetItemIcon("whatsoever", "64");

            Assert.IsNotNull(obj);
        }

        [Test]
        public void GetItemUrlFromTooltipParams()
        {
            var url = D3Api.GetItemUrlFromTooltipParams("whatsoever");
            Assert.AreEqual("http://eu.battle.net/api/d3/data/whatsoever", url);
        }

        [Test]
        public void GetItemFromTooltipParams()
        {
            var mock = new Mock<ID3DataProvider>();
            mock.Setup(p => p.FetchData("http://eu.battle.net/api/d3/data/whatsoever?locale=en"))
                .Returns<string>(p => new MemoryStream(Encoding.Default.GetBytes(JsonConvert.SerializeObject(new Item()))));
            D3Api.DataProvider = mock.Object;

            var obj = D3Api.GetItemFromTooltipParams("whatsoever");

            Assert.IsNotNull(obj);
        }

        [Test]
        public void GetSkillIconUrl()
        {
            var url = D3Api.GetSkillIconUrl("whatsoever", "64");
            Assert.AreEqual("http://media.blizzard.com/d3/icons/skills/64/whatsoever.png", url);
        }

        [Test]
        public void GetSkillIcon()
        {
            var mock = new Mock<ID3DataProvider>();
            mock.Setup(p => p.FetchData("http://media.blizzard.com/d3/icons/skills/64/whatsoever.png"))
                .Returns<string>(p => new MemoryStream(Encoding.Default.GetBytes(JsonConvert.SerializeObject(new D3Picture()))));
            D3Api.DataProvider = mock.Object;

            var obj = D3Api.GetSkillIcon("whatsoever", "64");

            Assert.IsNotNull(obj);
        }
    }
}
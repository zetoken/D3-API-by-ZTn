using NUnit.Framework;
using ZTn.BNet.D3.Careers;
using ZTn.BNet.D3.Helpers;

namespace ZTn.BNet.D3.DataProviders
{
    [TestFixture]
    public class FakeDataProviderUnitTest
    {
        private const string Url = "http://eu.battle.net/whatsoever";

        [TestFixtureSetUp]
        public void PclInitialization()
        {
        }

        [Test]
        public void FetchData()
        {
            var provider = new FakeDataProvider<Career>();
            var stream = provider.FetchData(Url);
            Assert.IsNotNull(stream);
            Assert.AreNotEqual(0, stream.Length);
            var response = stream.CreateFromJsonStream<Career>();
            Assert.IsNotNull(response);
        }
    }
}

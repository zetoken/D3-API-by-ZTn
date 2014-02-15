using NUnit.Framework;
using ZTn.BNet.D3.Helpers;

namespace ZTn.BNet.D3.DataProviders
{
    [TestFixture]
    public class FakeFailureDataProviderUnitTest
    {
        private const string url = "http://eu.battle.net/whatsoever";

        [Test]
        public void FetchData()
        {
            var provider = new FakeFailureDataProvider();
            var stream = provider.FetchData(url);
            Assert.IsNotNull(stream);
            Assert.AreNotEqual(0, stream.Length);
            var response = stream.CreateFromJsonStream<FailureObject>();
            Assert.IsNotNull(response);
            Assert.AreEqual("OK", response.Code);
            Assert.AreEqual(url, response.Reason);
        }
    }
}

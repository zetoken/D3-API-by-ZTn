using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ZTn.BNet.D3.DataProviders
{
    /// <summary>
    /// Fake <see cref="ID3DataProvider"/> always fetching a <see cref="FailureObject"/> instance.
    /// </summary>
    public class FakeFailureDataProvider : ID3DataProvider
    {
        #region >> ID3DataProvider

        /// <inheritdoc />
        public Stream fetchData(string url)
        {
            var responseObject = new FailureObject { Code = "OK", Reason = url };

            var json = JsonConvert.SerializeObject(responseObject);

            return new MemoryStream(Encoding.Default.GetBytes(json));
        }

        #endregion
    }
}
using System.IO;
using Newtonsoft.Json;
#if PORTABLE
using ZTn.Bnet.Portable;
#else
using System.Text;
#endif

namespace ZTn.BNet.D3.DataProviders
{
    /// <summary>
    /// Fake <see cref="ID3DataProvider"/> always fetching a <see cref="FailureObject"/> instance.
    /// </summary>
    public class FakeFailureDataProvider : ID3DataProvider
    {
        #region >> ID3DataProvider

        /// <inheritdoc />
        public Stream FetchData(string url)
        {
            var responseObject = new FailureObject { Code = "OK", Reason = url };

            var json = JsonConvert.SerializeObject(responseObject);

#if PORTABLE
            return new MemoryStream(PortableEncoding.Default.GetBytes(json));
#else
            return new MemoryStream(Encoding.Default.GetBytes(json));
#endif
        }

        #endregion
    }
}
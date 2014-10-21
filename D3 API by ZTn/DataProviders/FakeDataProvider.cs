using System;
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
    /// Fake <see cref="ID3DataProvider"/> fecthing an empty <typeparamref name="T"/> instance.
    /// </summary>
    public class FakeDataProvider<T> : ID3DataProvider where T : class, new()
    {
        #region >> ID3DataProvider

        /// <inheritdoc />
        public Stream FetchData(string url)
        {
            var responseObject = new T();

            var json = JsonConvert.SerializeObject(responseObject);

#if PORTABLE
            return new MemoryStream(PortableEncoding.Default.GetBytes(json));
#else
            return new MemoryStream(Encoding.Default.GetBytes(json));
#endif
        }

        /// <inheritdoc />
        public void FetchData(string url, Action<Stream> onSuccess, Action onFailure)
        {
            onSuccess(FetchData(url));
        }

        #endregion
    }
}
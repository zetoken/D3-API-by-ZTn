using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZTn.Bnet.Portable;

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

            return new MemoryStream(PortableEncoding.Default.GetBytes(json));
        }

        /// <inheritdoc />
        public void FetchData(string url, Action<Stream> onSuccess, Action onFailure)
        {
            onSuccess(FetchData(url));
        }

        /// <inheritdoc />
        public Task<Stream> FetchDataAsync(string url)
        {
            return Task.Run(() => FetchData(url));
        }

        #endregion
    }
}
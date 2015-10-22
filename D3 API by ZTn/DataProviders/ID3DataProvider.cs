using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ZTn.BNet.D3.DataProviders
{
    /// <summary>
    /// Interface to be implemented by a Diablo 3 data provider.
    /// </summary>
    public interface ID3DataProvider
    {
        /// <summary>
        /// Returns a data stream referenced by the <paramref name="url"/>.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Stream FetchData(string url);

        /// <summary>
        /// Asynchronously fetches the <paramref name="url"/> using callbacks.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="onSuccess">Callback called if the fetch succeeded.</param>
        /// <param name="onFailure">Callback called if the fetch failed.</param>
        [Obsolete("Deprecated by *Async method.")]
        void FetchData(string url, Action<Stream> onSuccess, Action onFailure);

        /// <summary>
        /// Asynchronously fetches the <paramref name="url"/>.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<Stream> FetchDataAsync(string url);
    }
}
using System;
using System.IO;

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
        /// Asynchronously fetches the <paramref name="url"/>.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="onSuccess">Callback called if the fetch succeeded.</param>
        /// <param name="onFailure">Callback called if the fetch failed.</param>
        void FetchData(String url, Action<Stream> onSuccess, Action onFailure);
    }
}
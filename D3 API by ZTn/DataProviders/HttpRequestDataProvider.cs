using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ZTn.BNet.D3.DataProviders
{
    public class HttpRequestDataProvider : ID3DataProvider
    {
        public int MaxRetries { get; set; } = 3;

        public Stream FetchData(string url)
        {
            var task = FetchDataAsync(url);

            task.Wait();

            return task.Result;
        }

        public void FetchData(string url, Action<Stream> onSuccess, Action onFailure)
        {
            var task = FetchDataAsync(url);

            task.Wait();

            if (task.Result == null)
            {
                onFailure();
            }
            else
            {
                onSuccess(task.Result);
            }
        }

        public async Task<Stream> FetchDataAsync(string url)
        {
            Debug.WriteLine("FetchDataAsync({0},...): {1}", url, "Start");

            var remainingTries = MaxRetries;

            var httpClient = new HttpClient();

            do
            {
                var response = await httpClient.GetAsync(url).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var memoryStream = new MemoryStream();
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    {
                        responseStream.CopyTo(memoryStream);
                    }
                    memoryStream.Position = 0;

                    return memoryStream;
                }

                remainingTries--;

            } while (remainingTries > 0);

            return null;
        }
    }
}
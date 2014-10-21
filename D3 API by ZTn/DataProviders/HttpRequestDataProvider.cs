using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ZTn.BNet.D3.DataProviders
{
    public class HttpRequestDataProvider : ID3DataProvider
    {
        public Stream FetchData(String url)
        {
            var resetEvent = new ManualResetEvent(false);

            Stream outputStream = null;
            FetchData(url,
                stream =>
                {
                    outputStream = stream;
                    resetEvent.Set();
                },
                () => { });

            resetEvent.WaitOne();

            return outputStream;
        }

        public void FetchData(String url, Action<Stream> onSuccess, Action onFailure)
        {
            FetchData(url, onSuccess, onFailure, 3);
        }

        private void FetchData(String url, Action<Stream> onSuccess, Action onFailure, int remainingTries)
        {
            Debug.WriteLine("FetchData({0},...): {1}", url, "Start");

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.BeginGetResponse(OnFetchDataCompleted, new RequestState(httpWebRequest, onSuccess, onFailure, remainingTries));
        }

        private void OnFetchDataCompleted(IAsyncResult asyncResult)
        {
            var requestState = (RequestState)asyncResult.AsyncState;

            HttpWebResponse httpWebResponse = null;
            try
            {
                try
                {
                    httpWebResponse = (HttpWebResponse)requestState.Request.EndGetResponse(asyncResult);
                }
                catch (WebException exception)
                {
                    httpWebResponse = (HttpWebResponse)exception.Response;

                    // Forbidden code is received when too much requests are sent in a given time.
                    if (httpWebResponse.StatusCode == HttpStatusCode.Forbidden && requestState.RemainingTries != 0)
                    {
                        Debug.WriteLine("FetchData({0},...): {1}", requestState.Request.RequestUri, "Retry allowed");

                        Task.Delay(100);

                        FetchData(requestState.Request.RequestUri.AbsoluteUri, requestState.OnSuccess, requestState.OnFailure, requestState.RemainingTries - 1);
                    }
                    else
                    {
                        Debug.WriteLine("FetchData({0},...): {1}", requestState.Request.RequestUri, exception.Message);

                        requestState.OnFailure();
                    }

                    throw;
                }
                catch (Exception exception)
                {
                    Debug.WriteLine("FetchData({0},...): {1}", requestState.Request.RequestUri, exception);

                    requestState.OnFailure();

                    throw;
                }

                var memoryStream = new MemoryStream();
                using (var responseStream = httpWebResponse.GetResponseStream())
                {
                    responseStream.CopyTo(memoryStream);
                }
                memoryStream.Position = 0;

                // If no exception occurred then the request was a success
                requestState.OnSuccess(memoryStream);
            }
            finally
            {
                // Don't forget to always dispose the response !
                if (httpWebResponse != null)
                {
                    httpWebResponse.Dispose();
                }
            }
        }

        private class RequestState
        {
            public readonly Action OnFailure;
            public readonly Action<Stream> OnSuccess;
            public readonly int RemainingTries;
            public readonly HttpWebRequest Request;

            public RequestState(HttpWebRequest request, Action<Stream> onSuccess, Action onFailure, int remainingTries)
            {
                Request = request;
                OnSuccess = onSuccess;
                OnFailure = onFailure;
                RemainingTries = remainingTries;
            }
        }
    }
}
using System;
using System.IO;
using System.Net;
using ZTn.BNet.D3.Helpers;
#if PORTABLE
using ZTn.Bnet.Portable;
#endif

namespace ZTn.BNet.D3.DataProviders
{
    public class HttpRequestDataProvider : ID3DataProvider
    {
        public static FailureObject GetFailedObjectFromJSonStream(Stream stream)
        {
            return stream.CreateFromJsonPersistentStream<FailureObject>();
        }

        public Stream FetchData(String url)
        {
            System.Diagnostics.Debug.WriteLine("FetchData({0}): {1}", url, "Start");

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse httpWebResponse;
            try
            {
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch (WebException exception)
            {
                var response = (HttpWebResponse)exception.Response;

                System.Diagnostics.Debug.WriteLine("FetchData({0}): {1}", url, response.StatusCode);

                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    throw new BNetResponse403Exception();
                }

                throw new BNetResponseFailedException();
            }

            if (httpWebResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new BNetResponseFailedException();
            }

            using (var responseStream = httpWebResponse.GetResponseStream())
            {
                // Get the response and try to detect if server returned an object indicating a failure
                // Note: Do not use "using" statement, as we want the stream not to be closed to be used outside !
                var memoryStream = new MemoryStream();
                responseStream.CopyTo(memoryStream);
                memoryStream.Position = 0;

                // if json object is returned, test if it is an error message
                if (httpWebResponse.ContentType.Contains("application/json"))
                {
                    var failureObject = GetFailedObjectFromJSonStream(memoryStream);

                    if (failureObject.IsFailureObject())
                    {
                        System.Diagnostics.Debug.WriteLine("FetchData({0}): {1}", url, failureObject);

                        memoryStream.Dispose();
                        throw new BNetFailureObjectReturnedException(failureObject);
                    }

                    memoryStream.Position = 0;
                }

                return memoryStream;
            }
        }
    }
}
using System;
using System.IO;
using System.Net;
using ZTn.BNet.D3.Helpers;

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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            if (httpWebResponse.StatusCode != HttpStatusCode.OK)
                throw new BNetResponseFailedException();

            using (var responseStream = httpWebResponse.GetResponseStream())
            {
                // Get the response an try to detect if server returned an object indicating a failure
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
                        memoryStream.Close();
                        throw new BNetFailureObjectReturnedException(failureObject);
                    }

                    memoryStream.Position = 0;
                }

                return memoryStream;
            }
        }
    }
}

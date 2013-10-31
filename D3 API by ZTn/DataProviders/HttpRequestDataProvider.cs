using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using ZTn.BNet.D3.Helpers;

namespace ZTn.BNet.D3.DataProviders
{
    public class HttpRequestDataProvider : ID3DataProvider
    {
        #region >> Constructors

        public HttpRequestDataProvider()
        {
        }

        #endregion

        public static FailureObject getFailedObjectFromJSonStream(Stream stream)
        {
            return JsonHelpers.getFromJSonPersistentStream<FailureObject>(stream);
        }

        public Stream fetchData(String url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            if (httpWebResponse.StatusCode != HttpStatusCode.OK)
                throw new BNetResponseFailedException();

            using (Stream responseStream = httpWebResponse.GetResponseStream())
            {
                // Get the response an try to detect if server returned an object indicating a failure
                // Note: Do not use "using" statement, as we want the stream not to be closed to be used outside !
                MemoryStream memoryStream = new MemoryStream();
                responseStream.CopyTo(memoryStream);
                memoryStream.Position = 0;

                // if json object is returned, test if it is an error message
                if (httpWebResponse.ContentType.Contains("application/json"))
                {
                    FailureObject failureObject = getFailedObjectFromJSonStream(memoryStream);

                    if (failureObject.isFailureObject())
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

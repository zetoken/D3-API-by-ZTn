using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using ZTn.BNet.D3.Careers;

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
            DataContractJsonSerializer jsSerializer = new DataContractJsonSerializer(typeof(FailureObject));
            FailureObject failureObject = (FailureObject)jsSerializer.ReadObject(stream);
            return failureObject;
        }

        public Stream fetchData(String url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            if (httpWebResponse.StatusCode != HttpStatusCode.OK)
                throw new BNetResponseFailed();

            Stream responseStream = httpWebResponse.GetResponseStream();

            // if json object is returned, test if it is an error message
            if (httpWebResponse.ContentType.Contains("application/json"))
            {
                // Get the response an try to detect if server returned an object indicating a failure
                MemoryStream memoryStream = new MemoryStream();
                responseStream.CopyTo(memoryStream);
                memoryStream.Position = 0;
                FailureObject failureObject = getFailedObjectFromJSonStream(memoryStream);

                if (failureObject.isFailureObject())
                    throw new BNetFailureObjectReturned(failureObject);

                memoryStream.Position = 0;

                return memoryStream;
            }
            else
            {
                return responseStream;
            }
        }
    }
}

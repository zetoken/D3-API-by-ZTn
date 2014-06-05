using System.Net;
using System.Threading;

namespace ZTn.Bnet.Portable
{
    public static class HttpWebResponseExtension
    {
        public static WebResponse GetResponse(this HttpWebRequest request)
        {
            WebResponse response = null;

            var gotResponse = new AutoResetEvent(false);

            request.BeginGetResponse(
                a =>
                {
                    response = request.EndGetResponse(a);
                    gotResponse.Set();
                },
                request
                );

            gotResponse.WaitOne();

            return response;
        }
    }
}
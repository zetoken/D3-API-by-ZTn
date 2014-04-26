using System.Net;

namespace ZTn.Bnet.Portable
{
    public static class HttpWebResponseExtension
    {
        public static WebResponse GetResponse(this HttpWebRequest request)
        {
            var result = request.BeginGetResponse(null, null);
            return request.EndGetResponse(result);
        }
    }
}

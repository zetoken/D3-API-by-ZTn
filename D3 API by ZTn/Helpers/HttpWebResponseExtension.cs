using System;
using System.Net;
using System.Threading.Tasks;

namespace ZTn.BNet.D3.Helpers
{
    public static class HttpWebResponseExtension
    {
        public static WebResponse GetResponse(this HttpWebRequest request)
        {
            try
            {
                var task = Task.Factory.FromAsync(
                    (callback, state) => ((HttpWebRequest)state).BeginGetResponse(callback, state),
                    result => ((HttpWebRequest)result.AsyncState).EndGetResponse(result),
                    request);

                task.Wait();

                return task.Result;
            }
            catch (AggregateException exception)
            {
                // If an exception occured in the task, it is encapsulated into an AggregateException object.
                throw exception.InnerException;
            }
        }
    }
}
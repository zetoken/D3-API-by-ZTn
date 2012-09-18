using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

        public Stream fetchData(String url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            return httpWebRequest.GetResponse().GetResponseStream();
        }
    }
}

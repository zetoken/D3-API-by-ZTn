using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTn.BNet.D3.DataProviders
{
    public class BNetResponseFailed : Exception
    {
        public BNetResponseFailed()
            : base("Battle.net failed at sending back a valid response")
        {
        }
    }
}

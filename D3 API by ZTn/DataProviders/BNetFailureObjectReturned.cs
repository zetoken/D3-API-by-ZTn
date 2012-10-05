using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTn.BNet.D3.DataProviders
{
    public class BNetFailureObjectReturned : Exception
    {
        public FailureObject failureObject;

        public BNetFailureObjectReturned()
            : base("Battle.net returned an object indicating a failure")
        {
        }

        public BNetFailureObjectReturned(FailureObject failureObject) :
            this()
        {
            this.failureObject = failureObject;
        }
    }
}

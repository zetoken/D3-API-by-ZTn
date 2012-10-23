using System;

namespace ZTn.BNet.D3.DataProviders
{
    [Serializable]
    public class BNetFailureObjectReturned : Exception
    {
        [NonSerialized]
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

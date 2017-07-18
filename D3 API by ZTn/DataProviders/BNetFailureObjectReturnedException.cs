using System;

namespace ZTn.BNet.D3.DataProviders
{
    public sealed class BNetFailureObjectReturnedException : Exception
    {
        public FailureObject FailureObject;

        public BNetFailureObjectReturnedException()
            : base("Battle.net returned an object indicating a failure")
        {
        }

        public BNetFailureObjectReturnedException(FailureObject failureObject)
            :
                this()
        {
            FailureObject = failureObject;
        }
    }
}
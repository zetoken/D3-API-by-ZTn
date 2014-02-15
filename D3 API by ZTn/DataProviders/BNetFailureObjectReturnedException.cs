using System;

namespace ZTn.BNet.D3.DataProviders
{
    [Serializable]
    public sealed class BNetFailureObjectReturnedException : Exception
    {
        [NonSerialized]
        public FailureObject FailureObject;

        public BNetFailureObjectReturnedException()
            : base("Battle.net returned an object indicating a failure")
        {
        }

        public BNetFailureObjectReturnedException(FailureObject failureObject) :
            this()
        {
            FailureObject = failureObject;
        }
    }
}

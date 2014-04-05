using System;

namespace ZTn.BNet.D3.DataProviders
{
#if !PORTABLE
    [Serializable]
#endif
    public sealed class BNetFailureObjectReturnedException : Exception
    {
#if !PORTABLE
        [NonSerialized]
#endif
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
using System;

namespace ZTn.BNet.D3.DataProviders
{
    [Serializable]
    public class BNetResponseFailed : Exception
    {
        public BNetResponseFailed()
            : base("Battle.net failed at sending back a valid response")
        {
        }
    }
}

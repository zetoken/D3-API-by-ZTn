using System;

namespace ZTn.BNet.D3.DataProviders
{
#if !PORTABLE
    [Serializable]
#endif
    public sealed class BNetResponse403Exception : Exception
    {
        public BNetResponse403Exception()
            : base("Battle.net answered with a 403 status code")
        {
        }
    }
}
using System;

namespace ZTn.BNet.D3
{
    public class MissingApiKey : Exception
    {
        public MissingApiKey()
            : this("Battle.net API Key is missing !")
        {
        }

        public MissingApiKey(string message)
            : base(message)
        { }
    }
}

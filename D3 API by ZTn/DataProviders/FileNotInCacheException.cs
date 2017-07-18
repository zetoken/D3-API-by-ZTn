using System;

namespace ZTn.BNet.D3.DataProviders
{
    public class FileNotInCacheException : Exception
    {
        public FileNotInCacheException()
            : base("Object was not found in cache")
        {
        }
    }
}
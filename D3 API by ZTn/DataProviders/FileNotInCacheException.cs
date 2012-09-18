using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTn.BNet.D3.DataProviders
{
    public class FileNotInCacheException: Exception
    {
        public FileNotInCacheException()
            : base("Object was not found in cache")
        {
        }
    }
}

using System;
using System.IO;

namespace ZTn.BNet.D3.DataProviders
{
    public interface ID3DataProvider
    {
        Stream fetchData(string url);
    }
}

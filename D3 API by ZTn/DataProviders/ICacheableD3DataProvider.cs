namespace ZTn.BNet.D3.DataProviders
{
    public interface ICacheableD3DataProvider : ID3DataProvider
    {
        FetchMode FetchMode { get; set; }

        string StoragePath { get; set; }

        string GetCachedFileName(string url);
    }
}
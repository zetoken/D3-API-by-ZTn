namespace ZTn.BNet.D3.DataProviders
{
    public class CachedDataProvider : CacheableDataProvider
    {
        public CachedDataProvider()
            : base(@"cache/")
        {
        }

        public CachedDataProvider(ID3DataProvider dataProvider)
            : base(@"cache/", dataProvider)
        {
        }
    }
}
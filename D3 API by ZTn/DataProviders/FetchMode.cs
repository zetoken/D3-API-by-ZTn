namespace ZTn.BNet.D3.DataProviders
{
    /// <summary>
    /// Enumeration representing the condition to go online
    /// </summary>
    public enum FetchMode
    {
        /// <summary>
        /// Never go online
        /// </summary>
        Offline,

        /// <summary>
        /// Always go online
        /// </summary>
        Online,

        /// <summary>
        /// Go online only if looked up data is missing in cache
        /// </summary>
        OnlineIfMissing
    }
}
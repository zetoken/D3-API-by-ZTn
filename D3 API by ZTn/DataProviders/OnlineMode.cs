using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZTn.BNet.D3.DataProviders
{
    /// <summary>
    /// Enumeration representing the condition to go online
    /// </summary>
    public enum OnlineMode
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

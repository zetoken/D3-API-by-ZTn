using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ZTn.BNet.D3
{
    /// <summary>
    /// Base Diablo 3 object that can be fetched from Battle.net hosts.
    /// </summary>
    public class D3Object
    {
        [JsonExtensionData]
        public IDictionary<string, JToken> UnmanagedAttributes { get; set; }

        /// <summary>
        /// Returns <c>true</c> if the D3 object is a valid one by looking for "code" and "reason" attributes.
        /// </summary>
        public bool IsValidObject()
        {
            if (UnmanagedAttributes == null)
            {
                return true;
            }

            return !(UnmanagedAttributes.ContainsKey("code") && UnmanagedAttributes.ContainsKey("reason"));
        }
    }
}
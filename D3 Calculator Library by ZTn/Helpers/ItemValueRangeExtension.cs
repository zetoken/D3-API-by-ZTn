using System;
using System.Collections.Generic;
using System.Linq;
using ZTn.BNet.D3.Items;
using ZTn.BNet.D3.Calculator.Sets;

namespace ZTn.BNet.D3.Calculator.Helpers
{
    /// <summary>
    /// Extension class to be used with <see cref="ItemValueRange"/> objects
    /// </summary>
    public static class ItemValueRangeExtension
    {
        /// <summary>
        /// Returns <c>null</c> if <paramref name="value"/> is 0-0 of the value if different.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ItemValueRange nullIfZero(this ItemValueRange value)
        {
            if (value == null)
                return null;
            if (value.min == 0 && value.max == 0)
                return null;
            return value;
        }
    }
}
using ZTn.BNet.D3.Items;

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
        public static ItemValueRange NullIfZero(this ItemValueRange value)
        {
            if (value == null)
                return null;
            if (value.Min == 0 && value.Max == 0)
                return null;
            return value;
        }
    }
}
using System;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Helpers
{
    /// <summary>
    /// Extension class to be used with <see cref="ItemValueRange"/> objects
    /// </summary>
    public static class ItemValueRangeExtension
    {
        public const double Tolerance = 0.0001;

        /// <summary>
        /// Returns <c>null</c> if <paramref name="value"/> is 0-0 of the value if different.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ItemValueRange NullIfZero(this ItemValueRange value)
        {
            return value.IsZero() ? null : value;
        }

        /// <summary>
        /// Checks if <paramref name="value.Min"/> and <paramref name="value.Max"/> are both 0 or almost 0 (using <see cref="Tolerance"/>).
        /// A <c>null</c> <paramref name="value"/> is considered to be 0.
        /// </summary>
        /// <param name="value"></param>
        /// <returns><c>true</c> if <paramref name="value"/> is null or smaller than <see cref="Tolerance"/>.</returns>
        public static bool IsZero(this ItemValueRange value)
        {
            if (value == null)
            {
                return true;
            }

            return Math.Abs(value.Min) < Tolerance && Math.Abs(value.Max) < Tolerance;
        }
    }
}
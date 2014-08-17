using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Helpers
{
    public static class ItemValueRangeExtension
    {
        /// <summary>
        /// Computes the sum of a sequence of <see cref="ItemValueRange"/> values.
        /// </summary>
        /// <param name="itemValueRanges">A sequence of <see cref="ItemValueRange"/> values to calculate the sum of.</param>
        /// <returns></returns>
        public static ItemValueRange Sum(this IEnumerable<ItemValueRange> itemValueRanges)
        {
            var target = new ItemValueRange();

            foreach (var attr in itemValueRanges.Where(i => i != null))
            {
                ItemValueRange.SumIntoLeftOperand(target, attr);
            }

            return target;
        }

        public static ItemValueRange SumAsPercentOnRemaining(this IEnumerable<ItemValueRange> itemValueRanges)
        {
            var target = new ItemValueRange();

            foreach (var attr in itemValueRanges.Where(i => i != null))
            {
                ItemValueRange.SumAsPercentOnRemainingIntoLeftOperand(target, attr);
            }

            return target;
        }
    }
}

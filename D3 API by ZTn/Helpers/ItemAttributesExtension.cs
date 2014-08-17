using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Helpers
{
    public static class ItemAttributesExtension
    {
        /// <summary>
        /// Computes the sum of a sequence of <see cref="ItemAttributes"/> values.
        /// </summary>
        /// <param name="itemAttributes">A sequence of <see cref="ItemAttributes"/> values to calculate the sum of.</param>
        /// <returns></returns>
        public static ItemAttributes Sum(this IEnumerable<ItemAttributes> itemAttributes)
        {
            var target = new ItemAttributes();

            foreach (var attr in itemAttributes.Where(a => a != null))
            {
                ItemAttributes.SumIntoLeftOperand(target, attr);
            }

            return target;
        }
    }
}

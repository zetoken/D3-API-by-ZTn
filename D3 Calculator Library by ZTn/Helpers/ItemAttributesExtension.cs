using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Helpers
{
    /// <summary>
    /// Extension class to be used with <see cref="ItemAttributes"/> objects
    /// </summary>
    public static class ItemAttributesExtension
    {
        /// <summary>
        /// Returns the value of an attribute of an item given the attribute's name
        /// </summary>
        /// <param name="itemAttributes">Source attributes</param>
        /// <param name="fieldName">Name of the attribute to retrieve</param>
        /// <returns></returns>
        public static ItemValueRange getAttributeByName(this ItemAttributes itemAttributes, String fieldName)
        {
            return (ItemValueRange)typeof(ItemAttributes).GetField(fieldName).GetValue(itemAttributes);
        }

        /// <summary>
        /// Sets the value of an attribute of an ItemAttributes given the attribute's name
        /// </summary>
        /// <param name="itemAttributes">Source attributes</param>
        /// <param name="fieldName">Name of the attribute to retrieve</param>
        /// <param name="value">Value to set</param>
        public static void setAttributeByName(this ItemAttributes itemAttributes, String fieldName, ItemValueRange value)
        {
            typeof(ItemAttributes).GetField(fieldName).SetValue(itemAttributes, value);
        }
    }
}

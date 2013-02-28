using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Helpers
{
    public static class ItemAttributesHelper
    {
        public static ItemValueRange getFieldValueByName(this ItemAttributes obj, String fieldName)
        {
            return (ItemValueRange)typeof(ItemAttributes).GetField(fieldName).GetValue(obj);
        }
    }
}

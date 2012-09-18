using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    public class D3Calculator
    {
        Item[] items;
        Item globalItem;

        #region >> Constructors

        public D3Calculator(Item[] items)
        {
            this.items = items;
        }

        #endregion

        public Item getGlobalItem()
        {
            globalItem = new Item();
            globalItem.attributesRaw = new ItemAttributes();

            foreach (Item item in items)
            {
                Type type = item.attributesRaw.GetType();

                foreach (FieldInfo fieldInfo in type.GetFields())
                {
                    if (fieldInfo.GetValue(item.attributesRaw) != null)
                    {
                        ItemValueRange itemValueRange = (ItemValueRange)fieldInfo.GetValue(item.attributesRaw);
                        ItemValueRange globalItemValueRange = (ItemValueRange)fieldInfo.GetValue(globalItem.attributesRaw);
                        if (globalItemValueRange == null)
                            globalItemValueRange = new ItemValueRange();
                        globalItemValueRange.min += itemValueRange.min;
                        globalItemValueRange.max += itemValueRange.max;
                        fieldInfo.SetValue(globalItem.attributesRaw, globalItemValueRange);
                    }
                }
            }

            return globalItem;
        }
    }
}

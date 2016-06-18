using System.Linq;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Helpers
{
    public static class ItemExtensions
    {
        /// <summary>
        /// Builds a new legendary power item given an item by filtering attributes.
        /// </summary>
        /// <param name="item">Source item.</param>
        /// <returns></returns>
        public static Item AsLegendaryPowerItem(this Item item)
        {
            return new Item
            {
                Attributes = new ItemTextAttributes
                {
                    Primary = item.Attributes.Primary.Where(ta => ta.Color == "orange").ToArray(),
                    Secondary = item.Attributes.Secondary.Where(ta => ta.Color == "orange").ToArray(),
                    Passive = item.Attributes.Passive.Where(ta => ta.Color == "orange").ToArray()
                },
                AttributesRaw = new ItemAttributes
                {
                    AttributeSetItemDiscount = item.AttributesRaw.AttributeSetItemDiscount
                },
                DisplayColor = item.DisplayColor,
                FlavorText = item.FlavorText,
                Icon = item.Icon,
                Id = item.Id,
                Name = item.Name,
                Slots = item.Slots,
                Type = item.Type,
                TypeName = item.TypeName,
                TooltipParams = item.TooltipParams
            };
        }
    }
}

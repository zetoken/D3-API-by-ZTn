using System.Linq;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Helpers
{
    public static class SocketEffectExtension
    {
        public static bool IsAttributesFieldEmpty(this SocketEffect item)
        {
            return (item.Attributes.Primary == null || !item.Attributes.Primary.Any())
                && (item.Attributes.Secondary == null || !item.Attributes.Secondary.Any())
                && (item.Attributes.Passive == null || !item.Attributes.Passive.Any());
        }
    }
}

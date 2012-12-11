using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills
{
    public class NullModifier : D3SkillModifier
    {
        public override ItemAttributes getBonus(D3Calculator calculator)
        {
            return new ItemAttributes();
        }
    }
}

using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills
{
    /// <summary>
    /// Skill modifier that brings no bonus
    /// </summary>
    public class NullModifier : D3SkillModifier
    {
        public override ItemAttributes getBonus(D3Calculator calculator)
        {
            return new ItemAttributes();
        }
    }
}

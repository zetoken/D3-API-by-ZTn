using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Wizard
{
    public class GalvanizingWard : D3SkillModifier
    {
        public override ItemAttributes getBonus(D3Calculator calculator)
        {
            return new ItemAttributes() { hitpointsRegenPerSecond = new ItemValueRange(310) };
        }
    }
}

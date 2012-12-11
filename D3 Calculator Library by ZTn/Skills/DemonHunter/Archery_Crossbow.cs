using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.DemonHunter
{
    internal class Archery_Crossbow : D3SkillModifier
    {
        public override ItemAttributes getBonus(D3Calculator calculator)
        {
            return new ItemAttributes() { critDamagePercent = new ItemValueRange(0.50) };
        }
    }
}

using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.DemonHunter
{
    internal class Archery_Bow : D3SkillModifier
    {
        readonly double multiplier = 0.15;

        public override ItemAttributes getBonus(D3Calculator calculator)
        {
            return (new DamageMultiplier(multiplier)).getBonus(calculator);
        }
    }
}

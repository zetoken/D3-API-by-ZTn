using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Barbarian
{
    public class NervesOfSteel : D3SkillModifier
    {
        public override ItemAttributes getBonus(D3Calculator calculator)
        {
            return new ItemAttributes() { armorBonusItem = new ItemValueRange(calculator.getHeroVitality()) };
        }
    }
}

using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Followers
{
    public class PoweredArmor : D3SkillModifier
    {
        public override ItemAttributes getBonus(D3Calculator calculator)
        {
            return new ItemAttributes() { armorBonusItem = new ItemValueRange(0.15 * calculator.getHeroArmor()) };
        }
    }
}

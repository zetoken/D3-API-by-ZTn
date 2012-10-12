using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Barbarian
{
    public class WeaponsMaster_PolearmSpear : D3SkillModifier
    {
        public override ItemAttributes getBonus(D3Calculator calculator)
        {
            return new ItemAttributes() { attacksPerSecondItem = new ItemValueRange(0.10) };
        }
    }
}

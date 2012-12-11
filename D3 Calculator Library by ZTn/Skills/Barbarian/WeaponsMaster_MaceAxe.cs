using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Barbarian
{
    internal class WeaponsMaster_MaceAxe : D3SkillModifier
    {
        public override ItemAttributes getBonus(D3Calculator calculator)
        {
            return new ItemAttributes() { critPercentBonusCapped = new ItemValueRange(0.10) };
        }
    }
}

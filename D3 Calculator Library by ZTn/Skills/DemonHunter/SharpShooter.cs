using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.DemonHunter
{
    public class SharpShooter : D3SkillModifier
    {
        public override ItemAttributes getBonus(D3Calculator calculator)
        {
            ItemAttributes stuff = calculator.heroStuff.attributesRaw;
            ItemAttributes attr = new ItemAttributes();

            if (stuff.critPercentBonusCapped != null)
                attr.critPercentBonusCapped = ItemValueRange.One - stuff.critPercentBonusCapped;
            else
                attr.critPercentBonusCapped = ItemValueRange.One;

            return attr;
        }
    }
}

using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Wizard
{
    public class GlassCannon : D3SkillModifier
    {
        double multiplier = 0.15;
        double malusMultiplier = -0.10;

        public override ItemAttributes getBonus(D3Calculator calculator)
        {
            ItemAttributes stuff = calculator.heroStuff.attributesRaw;
            ItemAttributes attr;

            attr = (new DamageMultiplier(multiplier)).getBonus(calculator);

            attr.armorBonusItem = new ItemValueRange(malusMultiplier * calculator.getHeroArmor());

            attr += (new ResistancesMultiplier(malusMultiplier)).getBonus(calculator);

            return attr;
        }
    }
}

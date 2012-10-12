using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Barbarian
{
    public class ToughAsNails : D3SkillModifier
    {
        double multiplier = 0.50;

        public override ItemAttributes getBonus(D3Calculator calculator)
        {
            ItemAttributes stuff = calculator.heroStuff.attributesRaw;
            ItemAttributes attr = new ItemAttributes();

            attr.armorBonusItem = new ItemValueRange(0.25 * calculator.getHeroArmor());

            attr += (new ThornsMultiplier(multiplier)).getBonus(calculator);

            return attr;
        }
    }
}

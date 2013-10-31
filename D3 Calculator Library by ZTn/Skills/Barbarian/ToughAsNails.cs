using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Barbarian
{
    public sealed class ToughAsNails : ID3SkillModifier
    {
        double multiplier = 0.50;

        #region >> ID3SkillModifier

        /// <inheritdoc />
        public ItemAttributes getBonus(D3Calculator calculator)
        {
            ItemAttributes stuff = calculator.heroStatsItem.attributesRaw;
            ItemAttributes attr = new ItemAttributes();

            attr.armorBonusItem = 0.25 * calculator.getHeroArmor();

            attr += new ThornsMultiplier(multiplier).getBonus(calculator);

            return attr;
        }

        #endregion
    }
}

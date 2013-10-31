using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.DemonHunter
{
    public sealed class SharpShooter : ID3SkillModifier
    {
        #region >> ID3SkillModifier

        /// <inheritdoc />
        public ItemAttributes getBonus(D3Calculator calculator)
        {
            ItemAttributes stuff = calculator.heroStatsItem.attributesRaw;
            ItemAttributes attr = new ItemAttributes();

            if (stuff.critPercentBonusCapped != null)
                attr.critPercentBonusCapped = ItemValueRange.One - stuff.critPercentBonusCapped;
            else
                attr.critPercentBonusCapped = ItemValueRange.One;

            return attr;
        }

        #endregion
    }
}

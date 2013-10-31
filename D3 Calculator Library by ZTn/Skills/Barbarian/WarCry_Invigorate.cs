using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Barbarian
{
    public sealed class WarCry_Invigorate : ID3SkillModifier
    {
        #region >> ID3SkillModifier

        /// <inheritdoc />
        public ItemAttributes getBonus(D3Calculator calculator)
        {
            ItemAttributes attr = new ItemAttributes();

            attr.armorBonusItem = 0.20 * calculator.getHeroArmor();

            attr.hitpointsRegenPerSecond = new ItemValueRange(620);

            return attr;

        }

        #endregion
    }
}

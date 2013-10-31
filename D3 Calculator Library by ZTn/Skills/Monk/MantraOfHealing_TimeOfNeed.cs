using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Monk
{
    public sealed class MantraOfHealing_TimeOfNeed : ID3SkillModifier
    {
        readonly double multiplier = 0.20;

        #region >> ID3SkillModifier

        /// <inheritdoc />
        public ItemAttributes getBonus(D3Calculator calculator)
        {
            ItemAttributes attr = new ItemAttributes();

            attr.hitpointsRegenPerSecond = new ItemValueRange(620);

            attr += (new ResistancesMultiplier(multiplier)).getBonus(calculator);

            return attr;
        }

        #endregion
    }
}

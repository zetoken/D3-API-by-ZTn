using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Wizard
{
    public sealed class GalvanizingWard : ID3SkillModifier
    {
        #region >> ID3SkillModifier

        /// <inheritdoc />
        public ItemAttributes getBonus(D3Calculator calculator)
        {
            return new ItemAttributes() { hitpointsRegenPerSecond = new ItemValueRange(620) };
        }

        #endregion
    }
}

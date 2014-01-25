using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Wizard
{
    public sealed class GalvanizingWard : ID3SkillModifier
    {
        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass HeroClass
        {
            get { return HeroClass.Wizard; }
        }

        /// <inheritdoc />
        public string Slug
        {
            get { return "galvanizing-ward"; }
        }

        /// <inheritdoc />
        public ItemAttributes GetBonus(D3Calculator calculator)
        {
            return new ItemAttributes { hitpointsRegenPerSecond = new ItemValueRange(620) };
        }

        #endregion
    }
}

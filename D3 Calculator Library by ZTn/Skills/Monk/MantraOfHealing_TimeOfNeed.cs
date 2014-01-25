using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Monk
{
    public sealed class MantraOfHealing_TimeOfNeed : ID3SkillModifier
    {
        private const double multiplier = 0.20;

        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass HeroClass
        {
            get { return HeroClass.Monk; }
        }

        /// <inheritdoc />
        public string Slug
        {
            get { return "mantra-of-healing-time-of-need"; }
        }

        /// <inheritdoc />
        public ItemAttributes GetBonus(D3Calculator calculator)
        {
            var attr = new ItemAttributes { hitpointsRegenPerSecond = new ItemValueRange(620) };

            attr += (new ResistancesMultiplier(multiplier)).GetBonus(calculator);

            return attr;
        }

        #endregion
    }
}

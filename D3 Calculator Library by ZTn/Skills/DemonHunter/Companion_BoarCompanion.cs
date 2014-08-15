using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.DemonHunter
{
    public sealed class Companion_BoarCompanion : ID3SkillModifier
    {
        private const double multiplier = 0.10;

        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass HeroClass
        {
            get { return HeroClass.DemonHunter; }
        }

        /// <inheritdoc />
        public string Slug
        {
            get { return "companion-boar-companion"; }
        }

        /// <inheritdoc />
        public ItemAttributes GetBonus(D3Calculator calculator)
        {
            var attr = new ItemAttributes { hitpointsRegenPerSecond = new ItemValueRange(4126) };

            attr += (new ResistancesMultiplier(0.20)).GetBonus(calculator);

            return attr;
        }

        #endregion
    }
}

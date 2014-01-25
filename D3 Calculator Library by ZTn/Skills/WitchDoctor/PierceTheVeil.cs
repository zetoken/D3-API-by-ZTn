using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.WitchDoctor
{
    public sealed class PierceTheVeil : ID3SkillModifier
    {
        private const double multiplier = 0.20;

        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass HeroClass
        {
            get { return HeroClass.WitchDoctor; }
        }

        /// <inheritdoc />
        public string Slug
        {
            get { return "pierce-the-veil"; }
        }

        /// <inheritdoc />
        public ItemAttributes GetBonus(D3Calculator calculator)
        {
            return new DamageMultiplier(multiplier).GetBonus(calculator);
        }

        #endregion
    }
}

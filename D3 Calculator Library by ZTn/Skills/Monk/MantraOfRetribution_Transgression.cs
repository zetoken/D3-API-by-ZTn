using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Monk
{
    public sealed class MantraOfRetribution_Transgression : ID3SkillModifier
    {
        private const double multiplier = 0.10;

        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass HeroClass
        {
            get { return HeroClass.Monk; }
        }

        /// <inheritdoc />
        public string Slug
        {
            get { return "mantra-of-retribution-transgression"; }
        }

        /// <inheritdoc />
        public ItemAttributes GetBonus(D3Calculator calculator)
        {
            var attr = new ItemAttributes { attacksPerSecondPercent = multiplier * calculator.GetActualAttackSpeed() };

            return attr;
        }

        #endregion
    }
}

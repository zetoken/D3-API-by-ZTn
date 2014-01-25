using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Wizard
{
    public sealed class GlassCannon : ID3SkillModifier
    {
        private const double multiplier = 0.15;
        private const double malusMultiplier = -0.10;

        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass HeroClass
        {
            get { return HeroClass.Wizard; }
        }

        /// <inheritdoc />
        public string Slug
        {
            get { return "glass-cannon"; }
        }

        /// <inheritdoc />
        public ItemAttributes GetBonus(D3Calculator calculator)
        {
            var attr = new DamageMultiplier(multiplier).GetBonus(calculator);

            attr.armorBonusItem = malusMultiplier * calculator.GetHeroArmor();

            attr += new ResistancesMultiplier(malusMultiplier).GetBonus(calculator);

            return attr;
        }

        #endregion
    }
}

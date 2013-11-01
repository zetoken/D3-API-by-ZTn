using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Wizard
{
    public sealed class GlassCannon : ID3SkillModifier
    {
        double multiplier = 0.15;
        double malusMultiplier = -0.10;

        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass heroClass
        {
            get { return HeroClass.Wizard; }
        }

        /// <inheritdoc />
        public string slug
        {
            get { return "glass-cannon"; }
        }

        /// <inheritdoc />
        public ItemAttributes getBonus(D3Calculator calculator)
        {
            ItemAttributes stuff = calculator.heroStatsItem.attributesRaw;
            ItemAttributes attr;

            attr = new DamageMultiplier(multiplier).getBonus(calculator);

            attr.armorBonusItem = malusMultiplier * calculator.getHeroArmor();

            attr += new ResistancesMultiplier(malusMultiplier).getBonus(calculator);

            return attr;
        }

        #endregion
    }
}

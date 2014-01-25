using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Barbarian
{
    public sealed class ToughAsNails : ID3SkillModifier
    {
        private const double multiplier = 0.50;

        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass HeroClass
        {
            get { return HeroClass.Barbarian; }
        }

        /// <inheritdoc />
        public string Slug
        {
            get { return "tough-as-nails"; }
        }

        /// <inheritdoc />
        public ItemAttributes GetBonus(D3Calculator calculator)
        {
            var attr = new ItemAttributes { armorBonusItem = 0.25 * calculator.GetHeroArmor() };

            attr += new ThornsMultiplier(multiplier).GetBonus(calculator);

            return attr;
        }

        #endregion
    }
}

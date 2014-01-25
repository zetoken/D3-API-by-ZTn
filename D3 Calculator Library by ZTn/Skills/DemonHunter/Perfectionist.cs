using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.DemonHunter
{
    public sealed class Perfectionist : ID3SkillModifier
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
            get { return "perfectionist"; }
        }

        /// <inheritdoc />
        public ItemAttributes GetBonus(D3Calculator calculator)
        {
            var attr = new ItemAttributes
            {
                hitpointsMaxPercentBonusItem = new ItemValueRange(0.10),
                armorBonusItem = multiplier * calculator.GetHeroArmor()
            };

            attr += (new ResistancesMultiplier(multiplier)).GetBonus(calculator);

            return attr;
        }

        #endregion
    }
}

using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Monk
{
    public sealed class MantraOfEvasion_HardTarget : ID3SkillModifier
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
            get { return "mantra-of-evasion-hard-target"; }
        }

        /// <inheritdoc />
        public ItemAttributes GetBonus(D3Calculator calculator)
        {
            var attr = new ItemAttributes { armorBonusItem = multiplier * calculator.GetHeroArmor() };

            return attr;
        }

        #endregion
    }
}

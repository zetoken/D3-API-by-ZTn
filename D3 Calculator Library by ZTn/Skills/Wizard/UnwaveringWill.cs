using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Wizard
{
    public sealed class UnwaveringWill : ID3SkillModifier
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
            get { return "unwavering-will"; }
        }

        /// <inheritdoc />
        public ItemAttributes GetBonus(D3Calculator calculator)
        {
            var attr = new DamageMultiplier(0.10).GetBonus(calculator);

            attr.armorBonusItem = 0.20 * calculator.GetHeroArmor();

            attr += new ResistancesMultiplier(0.20).GetBonus(calculator);

            return attr;
        }

        #endregion
    }
}

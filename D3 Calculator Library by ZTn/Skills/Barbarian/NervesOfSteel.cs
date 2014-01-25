using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Barbarian
{
    public sealed class NervesOfSteel : ID3SkillModifier
    {
        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass HeroClass
        {
            get { return HeroClass.Barbarian; }
        }

        /// <inheritdoc />
        public string Slug
        {
            get { return "nerves-of-steel"; }
        }

        /// <inheritdoc />
        public ItemAttributes GetBonus(D3Calculator calculator)
        {
            return new ItemAttributes { armorBonusItem = new ItemValueRange(calculator.GetHeroVitality()) };
        }

        #endregion
    }
}

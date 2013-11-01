using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Followers
{
    public sealed class PoweredArmor : ID3SkillModifier
    {
        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass heroClass
        {
            get { return HeroClass.EnchantressFollower; }
        }

        /// <inheritdoc />
        public string slug
        {
            get { return "powered-armor"; }
        }

        /// <inheritdoc />
        public ItemAttributes getBonus(D3Calculator calculator)
        {
            return new ItemAttributes() { armorBonusItem = 0.05 * calculator.getHeroArmor() };
        }

        #endregion
    }
}

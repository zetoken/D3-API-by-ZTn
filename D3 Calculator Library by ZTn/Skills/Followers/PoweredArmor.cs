using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Followers
{
    public sealed class PoweredArmor : ID3SkillModifier
    {
        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass HeroClass
        {
            get { return HeroClass.EnchantressFollower; }
        }

        /// <inheritdoc />
        public string Slug
        {
            get { return "powered-armor"; }
        }

        /// <inheritdoc />
        public ItemAttributes GetBonus(D3Calculator calculator)
        {
            return new ItemAttributes { armorBonusItem = 0.05 * calculator.GetHeroArmor() };
        }

        #endregion
    }
}

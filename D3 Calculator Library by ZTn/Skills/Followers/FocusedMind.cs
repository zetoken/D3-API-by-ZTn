using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Followers
{
    public sealed class FocusedMind : ID3SkillModifier
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
            get { return "focused-mind"; }
        }

        /// <inheritdoc />
        public ItemAttributes GetBonus(D3Calculator calculator)
        {
            return new ItemAttributes { attacksPerSecondItem = new ItemValueRange(0.03) };
        }

        #endregion
    }
}

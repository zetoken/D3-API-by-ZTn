using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Followers
{
    public sealed class Anatomy : ID3SkillModifier
    {
        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass heroClass
        {
            get { return HeroClass.ScoundrelFollower; }
        }

        /// <inheritdoc />
        public string slug
        {
            get { return "anatomy"; }
        }

        /// <inheritdoc />
        public ItemAttributes getBonus(D3Calculator calculator)
        {
            return new ItemAttributes() { critPercentBonusCapped = new ItemValueRange(0.03) };
        }

        #endregion
    }
}

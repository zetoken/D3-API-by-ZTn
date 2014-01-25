using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Followers
{
    public sealed class Anatomy : ID3SkillModifier
    {
        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass HeroClass
        {
            get { return HeroClass.ScoundrelFollower; }
        }

        /// <inheritdoc />
        public string Slug
        {
            get { return "anatomy"; }
        }

        /// <inheritdoc />
        public ItemAttributes GetBonus(D3Calculator calculator)
        {
            return new ItemAttributes { critPercentBonusCapped = new ItemValueRange(0.03) };
        }

        #endregion
    }
}

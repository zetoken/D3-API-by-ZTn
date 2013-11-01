using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills
{
    /// <summary>
    /// Skill modifier that brings no bonus
    /// </summary>
    public sealed class NullModifier : ID3SkillModifier
    {
        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass heroClass
        {
            get { return HeroClass.Unknown; }
        }

        /// <inheritdoc />
        public string slug
        {
            get { return ""; }
        }

        /// <inheritdoc />
        public ItemAttributes getBonus(D3Calculator calculator)
        {
            return new ItemAttributes();
        }

        #endregion
    }
}

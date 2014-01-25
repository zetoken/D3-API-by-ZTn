using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.DemonHunter
{
    public sealed class SharpShooter : ID3SkillModifier
    {
        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass HeroClass
        {
            get { return HeroClass.DemonHunter; }
        }

        /// <inheritdoc />
        public string Slug
        {
            get { return "sharp-shooter"; }
        }

        /// <inheritdoc />
        public ItemAttributes GetBonus(D3Calculator calculator)
        {
            var stuff = calculator.HeroStatsItem.attributesRaw;
            var attr = new ItemAttributes();

            if (stuff.critPercentBonusCapped != null)
                attr.critPercentBonusCapped = ItemValueRange.One - stuff.critPercentBonusCapped;
            else
                attr.critPercentBonusCapped = ItemValueRange.One;

            return attr;
        }

        #endregion
    }
}

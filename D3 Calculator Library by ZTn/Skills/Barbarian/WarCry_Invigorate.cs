using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Barbarian
{
    public sealed class WarCry_Invigorate : ID3SkillModifier
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
            get { return "warcry-invigorate"; }
        }

        /// <inheritdoc />
        public ItemAttributes GetBonus(D3Calculator calculator)
        {
            var attr = new ItemAttributes
            {
                armorBonusItem = 0.20 * calculator.GetHeroArmor(),
                hitpointsMaxPercentBonusItem = new ItemValueRange(0.10),
                hitpointsRegenPerSecond = new ItemValueRange(8253)
            };

            return attr;

        }

        #endregion
    }
}

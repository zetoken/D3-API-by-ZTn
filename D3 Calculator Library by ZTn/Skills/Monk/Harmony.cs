using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Monk
{
    public sealed class Harmony : ID3SkillModifier
    {
        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass HeroClass
        {
            get { return HeroClass.Monk; }
        }

        /// <inheritdoc />
        public string Slug
        {
            get { return "harmony"; }
        }

        /// <inheritdoc />
        public ItemAttributes GetBonus(D3Calculator calculator)
        {
            var stuff = calculator.HeroStatsItem.AttributesRaw;
            var attr = new ItemAttributes
            {
                resistance_All = 0.40 *
                                 (stuff.resistance_Arcane
                                  + stuff.resistance_Cold
                                  + stuff.resistance_Fire
                                  + stuff.resistance_Lightning
                                  + stuff.resistance_Physical
                                  + stuff.resistance_Poison)
            };

            return attr;
        }

        #endregion
    }
}
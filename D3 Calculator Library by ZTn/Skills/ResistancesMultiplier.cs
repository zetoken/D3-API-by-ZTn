using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills
{
    /// <summary>
    /// Skill modifier that brings % resistances bonus
    /// </summary>
    public sealed class ResistancesMultiplier : ID3SkillModifier
    {
        readonly ItemValueRange multiplier;

        #region >> Constructors

        public ResistancesMultiplier(double multiplier)
        {
            this.multiplier = new ItemValueRange(multiplier);
        }

        #endregion

        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass HeroClass
        {
            get { return HeroClass.Unknown; }
        }

        /// <inheritdoc />
        public string Slug
        {
            get { return ""; }
        }

        /// <inheritdoc />
        public ItemAttributes GetBonus(D3Calculator calculator)
        {
            Item stuff = calculator.HeroStatsItem;
            var attr = new ItemAttributes
            {
                resistance_All = multiplier*stuff.AttributesRaw.resistance_All,
                resistance_Arcane = multiplier*stuff.AttributesRaw.resistance_Arcane,
                resistance_Cold = multiplier*stuff.AttributesRaw.resistance_Cold,
                resistance_Fire = multiplier*stuff.AttributesRaw.resistance_Fire,
                resistance_Lightning = multiplier*stuff.AttributesRaw.resistance_Lightning,
                resistance_Physical = multiplier*stuff.AttributesRaw.resistance_Physical,
                resistance_Poison = multiplier*stuff.AttributesRaw.resistance_Poison
            };

            return attr;
        }

        #endregion
    }
}

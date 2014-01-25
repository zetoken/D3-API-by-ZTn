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
                resistance_All = multiplier*stuff.attributesRaw.resistance_All,
                resistance_Arcane = multiplier*stuff.attributesRaw.resistance_Arcane,
                resistance_Cold = multiplier*stuff.attributesRaw.resistance_Cold,
                resistance_Fire = multiplier*stuff.attributesRaw.resistance_Fire,
                resistance_Lightning = multiplier*stuff.attributesRaw.resistance_Lightning,
                resistance_Physical = multiplier*stuff.attributesRaw.resistance_Physical,
                resistance_Poison = multiplier*stuff.attributesRaw.resistance_Poison
            };

            return attr;
        }

        #endregion
    }
}

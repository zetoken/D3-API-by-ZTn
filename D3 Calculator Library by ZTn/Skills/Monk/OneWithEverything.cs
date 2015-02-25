using System.Linq;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Monk
{
    public sealed class OneWithEverything : ID3SkillModifier
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
            get { return "one-with-everything"; }
        }

        /// <inheritdoc />
        public ItemAttributes GetBonus(D3Calculator calculator)
        {
            var stuff = calculator.HeroStatsItem.AttributesRaw;
            var attr = new ItemAttributes();

            var resistances = new[]
            {
                calculator.GetHeroResistance("Arcane").Min,
                calculator.GetHeroResistance("Cold").Min,
                calculator.GetHeroResistance("Fire").Min,
                calculator.GetHeroResistance("Lightning").Min,
                calculator.GetHeroResistance("Physical").Min,
                calculator.GetHeroResistance("Poison").Min
            };

            var maxResist = resistances.Max();

            if (stuff.resistance_Arcane != null)
                attr.resistance_Arcane = ItemValueRange.Zero - stuff.resistance_Arcane;
            if (stuff.resistance_Cold != null)
                attr.resistance_Cold = ItemValueRange.Zero - stuff.resistance_Cold;
            if (stuff.resistance_Fire != null)
                attr.resistance_Fire = ItemValueRange.Zero - stuff.resistance_Fire;
            if (stuff.resistance_Lightning != null)
                attr.resistance_Lightning = ItemValueRange.Zero - stuff.resistance_Lightning;
            if (stuff.resistance_Physical != null)
                attr.resistance_Physical = ItemValueRange.Zero - stuff.resistance_Physical;
            if (stuff.resistance_Poison != null)
                attr.resistance_Poison = ItemValueRange.Zero - stuff.resistance_Poison;
            if (stuff.resistance_All != null)
                attr.resistance_All = new ItemValueRange(maxResist - calculator.GetHeroResistance_All());

            return attr;
        }

        #endregion
    }
}

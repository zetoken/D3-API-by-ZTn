using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills
{
    public class ResistancesMultiplier : D3SkillModifier
    {
        ItemValueRange multiplier;

        #region >> Constructors

        public ResistancesMultiplier(double multiplier)
        {
            this.multiplier = new ItemValueRange(multiplier);
        }

        #endregion

        public override ItemAttributes getBonus(D3Calculator calculator)
        {
            Item stuff = calculator.heroStuff;
            ItemAttributes attr = new ItemAttributes();

            if (stuff.attributesRaw.resistance_All != null)
                attr.resistance_All = multiplier * stuff.attributesRaw.resistance_All;
            if (stuff.attributesRaw.resistance_Arcane != null)
                attr.resistance_Arcane = multiplier * stuff.attributesRaw.resistance_Arcane;
            if (stuff.attributesRaw.resistance_Cold != null)
                attr.resistance_Cold = multiplier * stuff.attributesRaw.resistance_Cold;
            if (stuff.attributesRaw.resistance_Fire != null)
                attr.resistance_Fire = multiplier * stuff.attributesRaw.resistance_Fire;
            if (stuff.attributesRaw.resistance_Lightning != null)
                attr.resistance_Lightning = multiplier * stuff.attributesRaw.resistance_Lightning;
            if (stuff.attributesRaw.resistance_Physical != null)
                attr.resistance_Physical = multiplier * stuff.attributesRaw.resistance_Physical;
            if (stuff.attributesRaw.resistance_Poison != null)
                attr.resistance_Poison = multiplier * stuff.attributesRaw.resistance_Poison;

            return attr;
        }
    }
}

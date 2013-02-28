﻿using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills
{
    /// <summary>
    /// Skill modifier that brings % resistances bonus
    /// </summary>
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
            Item stuff = calculator.heroStatsItem;
            ItemAttributes attr = new ItemAttributes();

            attr.resistance_All = multiplier * stuff.attributesRaw.resistance_All;
            attr.resistance_Arcane = multiplier * stuff.attributesRaw.resistance_Arcane;
            attr.resistance_Cold = multiplier * stuff.attributesRaw.resistance_Cold;
            attr.resistance_Fire = multiplier * stuff.attributesRaw.resistance_Fire;
            attr.resistance_Lightning = multiplier * stuff.attributesRaw.resistance_Lightning;
            attr.resistance_Physical = multiplier * stuff.attributesRaw.resistance_Physical;
            attr.resistance_Poison = multiplier * stuff.attributesRaw.resistance_Poison;

            return attr;
        }
    }
}

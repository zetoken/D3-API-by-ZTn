using System;

using ZTn.BNet.D3.Calculator.Helpers;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills
{
    public sealed class ThornsMultiplier : ID3SkillModifier
    {
        #region >> Constants

        readonly String[] thornsPrefixes = new String[] { 
            "thornsFixed_"
        };

        readonly String[] damageResists = new String[] {
            "Arcane", "Cold", "Fire", "Holy", "Lightning", "Physical", "Poison"
        };

        #endregion

        ItemValueRange multiplier;

        #region >> Constructors

        public ThornsMultiplier(double multiplier)
        {
            this.multiplier = new ItemValueRange(multiplier);
        }

        #endregion

        #region >> ID3SkillModifier

        /// <inheritdoc />
        public ItemAttributes getBonus(D3Calculator calculator)
        {
            Item stuff = calculator.heroStatsItem;
            ItemAttributes attr = new ItemAttributes();

            foreach (String resist in damageResists)
            {
                foreach (String thorns in thornsPrefixes)
                {
                    ItemValueRange value = stuff.getAttributeByName(thorns + resist);
                    attr.setAttributeByName(thorns + resist, multiplier * value);
                }
            }

            return attr;
        }

        #endregion
    }
}

using System;
using ZTn.BNet.D3.Calculator.Helpers;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills
{
    public sealed class ThornsMultiplier : ID3SkillModifier
    {
        #region >> Constants

        readonly String[] thornsPrefixes =
        { 
            "thornsFixed_"
        };

        readonly String[] damageResists =
        {
            "Arcane", "Cold", "Fire", "Holy", "Lightning", "Physical", "Poison"
        };

        #endregion

        readonly ItemValueRange multiplier;

        #region >> Constructors

        public ThornsMultiplier(double multiplier)
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
            var attr = new ItemAttributes();

            foreach (var resist in damageResists)
            {
                foreach (var thorns in thornsPrefixes)
                {
                    var value = stuff.GetAttributeByName(thorns + resist);
                    attr.SetAttributeByName(thorns + resist, multiplier * value);
                }
            }

            return attr;
        }

        #endregion
    }
}

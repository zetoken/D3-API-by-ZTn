using System;
using ZTn.BNet.D3.Calculator.Helpers;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills
{
    /// <summary>
    /// Skill modifier that brings % damage bonus
    /// </summary>
    public sealed class DamageMultiplier : ID3SkillModifier
    {
        #region >> Constants

        readonly String[] damagePrefixes =
        { 
            "damageMin_", "damageBonusMin_",
            "damageDelta_", 
            "damageWeaponMin_", "damageWeaponBonusMin_",
            "damageWeaponDelta_", "damageWeaponBonusDelta_", 
            "damageWeaponPercentBonus_"
        };

        readonly String[] damageResists =
        {
            "Arcane", "Cold", "Fire", "Holy", "Lightning", "Physical", "Poison"
        };

        #endregion

        readonly ItemValueRange multiplier;

        #region >> Constructors

        public DamageMultiplier(double multiplier)
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
                foreach (var damage in damagePrefixes)
                {
                    var value = stuff.GetAttributeByName(damage + resist);
                    attr.SetAttributeByName(damage + resist, multiplier * value);
                }
            }

            return attr;
        }

        #endregion
    }
}

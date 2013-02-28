using System;

using ZTn.BNet.D3.Calculator.Helpers;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills
{
    public class DamageMultiplier : D3SkillModifier
    {
        #region >> Constants

        readonly String[] damagePrefixes = new String[] { 
            "damageMin_", "damageBonusMin_",
            "damageDelta_", 
            "damageWeaponMin_", "damageWeaponBonusMin_",
            "damageWeaponDelta_", "damageWeaponBonusDelta_", 
            "damageWeaponPercentBonus_"
        };

        readonly String[] damageResists = new String[] {
            "Arcane", "Cold", "Fire", "Holy", "Lightning", "Physical", "Poison"
        };

        #endregion

        ItemValueRange multiplier;

        #region >> Constructors

        public DamageMultiplier(double multiplier)
        {
            this.multiplier = new ItemValueRange(multiplier);
        }

        #endregion

        public override ItemAttributes getBonus(D3Calculator calculator)
        {
            Item stuff = calculator.heroItemStats;
            ItemAttributes attr = new ItemAttributes();

            foreach (String resist in damageResists)
            {
                foreach (String damage in damagePrefixes)
                {
                    ItemValueRange value = stuff.getAttributeRangeByName(damage + resist);
                    if (value != null)
                        attr.setAttributeByName(damage + resist, multiplier * value);
                }
            }

            return attr;
        }
    }
}

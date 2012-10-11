using System;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.DemonHunter
{
    public abstract class DamageMultiplier : D3SkillModifier
    {
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

        protected ItemAttributes getBonus(D3Calculator calculator, ItemValueRange multiplier)
        {
            ItemAttributes stuff = calculator.heroStuff.attributesRaw;
            ItemAttributes attr = new ItemAttributes();

            Type type = typeof(ItemAttributes);
            foreach (String resist in damageResists)
            {
                foreach (String damage in damagePrefixes)
                {
                    ItemValueRange value = (ItemValueRange)type.GetField(damage + resist).GetValue(stuff);
                    if (value != null)
                        type.GetField(damage + resist).SetValue(attr, multiplier * value);
                }
            }

            return attr;
        }
    }
}

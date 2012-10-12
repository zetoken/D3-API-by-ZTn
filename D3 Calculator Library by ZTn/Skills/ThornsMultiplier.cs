using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills
{
    public class ThornsMultiplier : D3SkillModifier
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

        public override ItemAttributes getBonus(D3Calculator calculator)
        {
            ItemAttributes stuff = calculator.heroStuff.attributesRaw;
            ItemAttributes attr = new ItemAttributes();

            Type type = typeof(ItemAttributes);
            foreach (String resist in damageResists)
            {
                foreach (String thorns in thornsPrefixes)
                {
                    ItemValueRange value = (ItemValueRange)type.GetField(thorns + resist).GetValue(stuff);
                    if (value != null)
                        type.GetField(thorns + resist).SetValue(attr, multiplier * value);
                }
            }

            return attr;
        }
    }
}

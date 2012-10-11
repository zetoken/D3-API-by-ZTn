using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Monk
{
    public class MantraOfHealing_TimeOfNeed : D3SkillModifier
    {
        public override ItemAttributes getBonus(D3Calculator calculator)
        {
            Item stuff = calculator.heroStuff;
            ItemAttributes attr = new ItemAttributes();

            if (stuff.attributesRaw.resistanceAll != null)
                attr.resistanceAll = new ItemValueRange(0.20 * stuff.attributesRaw.resistanceAll.min);
            if (stuff.attributesRaw.resistance_Arcane != null)
                attr.resistance_Arcane = new ItemValueRange(0.20 * stuff.attributesRaw.resistance_Arcane.min);
            if (stuff.attributesRaw.resistance_Cold != null)
                attr.resistance_Cold = new ItemValueRange(0.20 * stuff.attributesRaw.resistance_Cold.min);
            if (stuff.attributesRaw.resistance_Fire != null)
                attr.resistance_Fire = new ItemValueRange(0.20 * stuff.attributesRaw.resistance_Fire.min);
            if (stuff.attributesRaw.resistance_Lightning != null)
                attr.resistance_Lightning = new ItemValueRange(0.20 * stuff.attributesRaw.resistance_Lightning.min);
            if (stuff.attributesRaw.resistance_Physical != null)
                attr.resistance_Physical = new ItemValueRange(0.20 * stuff.attributesRaw.resistance_Physical.min);
            if (stuff.attributesRaw.resistance_Poison != null)
                attr.resistance_Poison = new ItemValueRange(0.20 * stuff.attributesRaw.resistance_Poison.min);

            return attr;
        }
    }
}

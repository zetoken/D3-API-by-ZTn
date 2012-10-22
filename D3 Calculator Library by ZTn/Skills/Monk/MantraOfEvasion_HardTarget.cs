using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Monk
{
    public class MantraOfEvasion_HardTarget:D3SkillModifier
    {
        readonly double multiplier = 0.20;

        public override ItemAttributes getBonus(D3Calculator calculator)
        {
            ItemAttributes attr = new ItemAttributes();

            attr.armorBonusItem = new ItemValueRange(multiplier * calculator.getHeroArmor());

            return attr;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.DemonHunter
{
    public class Perfectionist : D3SkillModifier
    {
        readonly double multiplier = 0.10;

        public override ItemAttributes getBonus(D3Calculator calculator)
        {
            ItemAttributes attr = new ItemAttributes();

            attr.hitpointsMaxPercentBonusItem = new ItemValueRange(0.10);

            attr.armorBonusItem = multiplier * calculator.getHeroArmor();

            attr += (new ResistancesMultiplier(multiplier)).getBonus(calculator);

            return attr;
        }
    }
}

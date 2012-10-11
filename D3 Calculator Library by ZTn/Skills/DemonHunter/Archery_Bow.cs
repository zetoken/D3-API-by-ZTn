using System;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.DemonHunter
{
    public class Archery_Bow : DamageMultiplier
    {
        readonly ItemValueRange multiplier = new ItemValueRange(0.15);

        public override ItemAttributes getBonus(D3Calculator calculator)
        {
            return getBonus(calculator, multiplier);
        }
    }
}

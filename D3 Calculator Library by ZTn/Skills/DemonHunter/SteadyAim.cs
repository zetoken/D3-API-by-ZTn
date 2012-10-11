using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.DemonHunter
{
    public class SteadyAim : DamageMultiplier
    {
        readonly ItemValueRange multiplier = new ItemValueRange(0.20);

        public override ItemAttributes getBonus(D3Calculator calculator)
        {
            return getBonus(calculator, multiplier);
        }
    }
}

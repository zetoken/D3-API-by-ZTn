using System;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills
{
    /// <summary>
    /// Abstract class that allows to compute bonuses brought by a skill
    /// </summary>
    public interface ID3SkillModifier
    {
        /// <summary>
        /// Computes bonus based on calculator
        /// </summary>
        /// <param name="calculator"></param>
        /// <returns></returns>
        ItemAttributes getBonus(D3Calculator calculator);
    }
}

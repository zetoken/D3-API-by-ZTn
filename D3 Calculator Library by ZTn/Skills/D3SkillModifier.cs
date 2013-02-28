using System;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills
{
    /// <summary>
    /// Abstract class that allows to compute bonuses brought by a skill
    /// </summary>
    public abstract class D3SkillModifier
    {
        #region >> Constructors

        public D3SkillModifier()
        {
        }

        #endregion

        /// <summary>
        /// Computes bonus based on calculator
        /// </summary>
        /// <param name="calculator"></param>
        /// <returns></returns>
        public abstract ItemAttributes getBonus(D3Calculator calculator);
    }
}

using System;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills
{
    public abstract class D3SkillModifier
    {
        #region >> Constructors

        public D3SkillModifier()
        {
        }

        #endregion

        public abstract ItemAttributes getBonus(D3Calculator calculator);
    }
}

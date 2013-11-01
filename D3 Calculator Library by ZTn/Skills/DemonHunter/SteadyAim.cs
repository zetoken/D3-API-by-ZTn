using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.DemonHunter
{
    public sealed class SteadyAim : ID3SkillModifier
    {
        readonly double multiplier = 0.20;

        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass heroClass
        {
            get { return HeroClass.DemonHunter; }
        }

        /// <inheritdoc />
        public string slug
        {
            get { return "steady-aim"; }
        }

        /// <inheritdoc />
        public ItemAttributes getBonus(D3Calculator calculator)
        {
            return new DamageMultiplier(multiplier).getBonus(calculator);
        }

        #endregion
    }
}

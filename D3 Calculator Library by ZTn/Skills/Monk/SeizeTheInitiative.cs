using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Monk
{
    public sealed class SeizeTheInitiative : ID3SkillModifier
    {
        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass HeroClass
        {
            get { return HeroClass.Monk; }
        }

        /// <inheritdoc />
        public string Slug
        {
            get { return "seize-the-initiative"; }
        }

        /// <inheritdoc />
        public ItemAttributes GetBonus(D3Calculator calculator)
        {
            return new ItemAttributes { armorBonusItem = new ItemValueRange(calculator.GetHeroDexterity()) * (new ItemValueRange(0.5)) };
        }

        #endregion
    }
}

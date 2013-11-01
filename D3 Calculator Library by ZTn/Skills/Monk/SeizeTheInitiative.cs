using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Monk
{
    public sealed class SeizeTheInitiative : ID3SkillModifier
    {
        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass heroClass
        {
            get { return HeroClass.Monk; }
        }

        /// <inheritdoc />
        public string slug
        {
            get { return "seize-the-initiative"; }
        }

        /// <inheritdoc />
        public ItemAttributes getBonus(D3Calculator calculator)
        {
            return new ItemAttributes() { armorBonusItem = new ItemValueRange(calculator.getHeroDexterity()) * (new ItemValueRange(0.5)) };
        }

        #endregion
    }
}

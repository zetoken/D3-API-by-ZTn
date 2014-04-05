using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Barbarian
{
    public sealed class WeaponsMaster : ID3SkillModifier
    {
        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass HeroClass
        {
            get { return HeroClass.Barbarian; }
        }

        /// <inheritdoc />
        public string Slug
        {
            get { return "weapons-master"; }
        }

        /// <inheritdoc />
        public ItemAttributes GetBonus(D3Calculator calculator)
        {
            switch (calculator.HeroStatsItem.MainHand.Type.id)
            {
                case "Sword":
                case "Sword2H":
                case "Dagger":
                    return getBonus_SwordDagger(calculator);
                case "Axe":
                case "Axe2H":
                case "Mace":
                case "Mace2H":
                    return getBonus_MaceAxe();
                case "Polearm":
                case "Spear":
                    return getBonus_PolearmSpear();
                default:
                    return new ItemAttributes();
            }
        }

        #endregion

        static ItemAttributes getBonus_MaceAxe()
        {
            return new ItemAttributes { critPercentBonusCapped = new ItemValueRange(0.10) };
        }

        static ItemAttributes getBonus_PolearmSpear()
        {
            return new ItemAttributes { attacksPerSecondItem = new ItemValueRange(0.10) };
        }

        static ItemAttributes getBonus_SwordDagger(D3Calculator calculator)
        {
            return new DamageMultiplier(0.15).GetBonus(calculator);
        }
    }
}


using ZTn.BNet.D3.Items;
namespace ZTn.BNet.D3.Calculator.Skills.Barbarian
{
    public sealed class WeaponsMaster : ID3SkillModifier
    {
        #region >> ID3SkillModifier

        /// <inheritdoc />
        public ItemAttributes getBonus(D3Calculator calculator)
        {
            switch (calculator.heroStatsItem.mainHand.type.id)
            {
                case "Sword":
                case "Sword2H":
                case "Dagger":
                    return getBonus_SwordDagger(calculator);
                case "Axe":
                case "Axe2H":
                case "Mace":
                case "Mace2H":
                    return getBonus_MaceAxe(calculator);
                case "Polearm":
                case "Spear":
                    return getBonus_PolearmSpear(calculator);
                default:
                    return new ItemAttributes();
            }
        }

        #endregion

        ItemAttributes getBonus_MaceAxe(D3Calculator calculator)
        {
            return new ItemAttributes() { critPercentBonusCapped = new ItemValueRange(0.10) };
        }

        ItemAttributes getBonus_PolearmSpear(D3Calculator calculator)
        {
            return new ItemAttributes() { attacksPerSecondItem = new ItemValueRange(0.10) };
        }

        ItemAttributes getBonus_SwordDagger(D3Calculator calculator)
        {
            return new DamageMultiplier(0.15).getBonus(calculator);
        }
    }
}

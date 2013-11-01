
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;
namespace ZTn.BNet.D3.Calculator.Skills.DemonHunter
{
    public sealed class Archery : ID3SkillModifier
    {
        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass heroClass
        {
            get { return HeroClass.DemonHunter; }
        }

        /// <inheritdoc />
        public string slug
        {
            get { return "archery"; }
        }

        /// <inheritdoc />
        public ItemAttributes getBonus(D3Calculator calculator)
        {
            switch (calculator.heroStatsItem.mainHand.type.id)
            {
                case "Bow":
                    return getBonus_Bow(calculator);
                case "Crossbow":
                    return getBonus_Crossbow(calculator);
                case "HandCrossbow":
                    return getBonus_HandCrossbow(calculator);
                default:
                    return new ItemAttributes();
            }
        }

        #endregion

        ItemAttributes getBonus_Bow(D3Calculator calculator)
        {
            return new DamageMultiplier(0.15).getBonus(calculator);
        }

        ItemAttributes getBonus_Crossbow(D3Calculator calculator)
        {
            return new ItemAttributes() { critDamagePercent = new ItemValueRange(0.50) };
        }

        ItemAttributes getBonus_HandCrossbow(D3Calculator calculator)
        {
            return new ItemAttributes() { critPercentBonusCapped = new ItemValueRange(0.10) };
        }
    }
}

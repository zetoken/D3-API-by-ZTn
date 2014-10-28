using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.DemonHunter
{
    public sealed class Archery : ID3SkillModifier
    {
        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass HeroClass
        {
            get { return HeroClass.DemonHunter; }
        }

        /// <inheritdoc />
        public string Slug
        {
            get { return "archery"; }
        }

        /// <inheritdoc />
        public ItemAttributes GetBonus(D3Calculator calculator)
        {
            switch (calculator.HeroStatsItem.MainHand.Type.Id)
            {
                case "Bow":
                    return getBonus_Bow(calculator);
                case "Crossbow":
                    return getBonus_Crossbow();
                case "HandCrossbow":
                    return getBonus_HandCrossbow();
                default:
                    return new ItemAttributes();
            }
        }

        #endregion

        static ItemAttributes getBonus_Bow(D3Calculator calculator)
        {
            return new DamageMultiplier(0.15).GetBonus(calculator);
        }

        static ItemAttributes getBonus_Crossbow()
        {
            return new ItemAttributes { critDamagePercent = new ItemValueRange(0.50) };
        }

        static ItemAttributes getBonus_HandCrossbow()
        {
            return new ItemAttributes { critPercentBonusCapped = new ItemValueRange(0.10) };
        }
    }
}

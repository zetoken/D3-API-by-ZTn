
namespace ZTn.BNet.D3.Calculator.Skills.DemonHunter
{
    public class Archery : D3SkillModifier
    {
        public override Items.ItemAttributes getBonus(D3Calculator calculator)
        {
            D3SkillModifier skillModifier;
            switch (calculator.heroStatsItem.mainHand.type.id)
            {
                case "Bow":
                    skillModifier = new Archery_Bow();
                    break;
                case "Crossbow":
                    skillModifier = new Archery_Crossbow();
                    break;
                case "HandCrossbow":
                    skillModifier = new Archery_HandCrossbow();
                    break;
                default:
                    skillModifier = new NullModifier();
                    break;
            }
            return skillModifier.getBonus(calculator);
        }
    }
}

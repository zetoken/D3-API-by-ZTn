
namespace ZTn.BNet.D3.Calculator.Skills.Barbarian
{
    public class WeaponsMaster : D3SkillModifier
    {
        public override Items.ItemAttributes getBonus(D3Calculator calculator)
        {
            D3SkillModifier skillModifier;
            switch (calculator.heroStatsItem.mainHand.type.id)
            {
                case "Sword":
                case "Sword2H":
                case "Dagger":
                    skillModifier = new WeaponsMaster_SwordDagger();
                    break;
                case "Axe":
                case "Axe2H":
                case "Mace":
                case "Mace2H":
                    skillModifier = new WeaponsMaster_MaceAxe();
                    break;
                case "Polearm":
                case "Spear":
                    skillModifier = new WeaponsMaster_PolearmSpear();
                    break;
                default:
                    skillModifier = new NullModifier();
                    break;
            }
            return skillModifier.getBonus(calculator);
        }
    }
}

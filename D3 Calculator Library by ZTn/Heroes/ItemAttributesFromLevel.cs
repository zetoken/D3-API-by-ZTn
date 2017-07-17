using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Heroes
{
    public class ItemAttributesFromLevel : ItemAttributes
    {
        public ItemAttributesFromLevel(Hero hero)
        {
            switch (hero.HeroClass)
            {
                case HeroClass.Monk:
                case HeroClass.DemonHunter:
                    dexterityItem = new ItemValueRange(7 + 3 * hero.Level);
                    intelligenceItem = new ItemValueRange(7 + 1 * hero.Level);
                    strengthItem = new ItemValueRange(7 + 1 * hero.Level);
                    break;
                case HeroClass.Necromancer:
                case HeroClass.WitchDoctor:
                case HeroClass.Wizard:
                    dexterityItem = new ItemValueRange(7 + 1 * hero.Level);
                    intelligenceItem = new ItemValueRange(7 + 3 * hero.Level);
                    strengthItem = new ItemValueRange(7 + 1 * hero.Level);
                    break;
                case HeroClass.Barbarian:
                case HeroClass.Crusader:
                    dexterityItem = new ItemValueRange(7 + 1 * hero.Level);
                    intelligenceItem = new ItemValueRange(7 + 1 * hero.Level);
                    strengthItem = new ItemValueRange(7 + 3 * hero.Level);
                    break;
            }

            vitalityItem = new ItemValueRange(7 + 2 * hero.Level);

            critDamagePercent = new ItemValueRange(0.5);
            critPercentBonusCapped = new ItemValueRange(0.05);
        }
    }
}

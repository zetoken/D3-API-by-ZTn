using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Heroes
{
    public class ItemAttributesFromParagonLevel : ItemAttributes
    {
        public ItemAttributesFromParagonLevel(Hero hero)
        {
            switch (hero.HeroClass)
            {
                case HeroClass.Monk:
                case HeroClass.DemonHunter:
                case HeroClass.Necromancer:
                case HeroClass.WitchDoctor:
                case HeroClass.Wizard:
                case HeroClass.Barbarian:
                case HeroClass.Crusader:
                    break;
            }
        }
    }
}
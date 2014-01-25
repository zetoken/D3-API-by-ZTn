using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Heroes
{
    public class ItemAttributesFromParagonLevel : ItemAttributes
    {
        public ItemAttributesFromParagonLevel(Hero hero)
        {
            switch (hero.heroClass)
            {
                case HeroClass.Monk:
                case HeroClass.DemonHunter:
                    dexterityItem = new ItemValueRange(3 * hero.paragonLevel);
                    intelligenceItem = new ItemValueRange(1 * hero.paragonLevel);
                    strengthItem = new ItemValueRange(1 * hero.paragonLevel);
                    break;
                case HeroClass.WitchDoctor:
                case HeroClass.Wizard:
                    dexterityItem = new ItemValueRange(1 * hero.paragonLevel);
                    intelligenceItem = new ItemValueRange(3 * hero.paragonLevel);
                    strengthItem = new ItemValueRange(1 * hero.paragonLevel);
                    break;
                case HeroClass.Barbarian:
                    dexterityItem = new ItemValueRange(1 * hero.paragonLevel);
                    intelligenceItem = new ItemValueRange(1 * hero.paragonLevel);
                    strengthItem = new ItemValueRange(3 * hero.paragonLevel);
                    break;
            }

            vitalityItem = new ItemValueRange(2 * hero.paragonLevel);

            goldFind = new ItemValueRange(0.03 * hero.paragonLevel);
            magicFind = new ItemValueRange(0.03 * hero.paragonLevel);
        }
    }
}

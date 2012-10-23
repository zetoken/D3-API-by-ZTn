using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    public class ItemAttributesFromParagonLevel : ItemAttributes
    {
        public ItemAttributesFromParagonLevel(Hero hero)
        {
            switch (hero.heroClass)
            {
                case "monk":
                case "demon-hunter":
                    dexterityItem = new ItemValueRange(3 * hero.paragonLevel);
                    intelligenceItem = new ItemValueRange(1 * hero.paragonLevel);
                    strengthItem = new ItemValueRange(1 * hero.paragonLevel);
                    break;
                case "witch-doctor":
                case "wizard":
                    dexterityItem = new ItemValueRange(1 * hero.paragonLevel);
                    intelligenceItem = new ItemValueRange(3 * hero.paragonLevel);
                    strengthItem = new ItemValueRange(1 * hero.paragonLevel);
                    break;
                case "barbarian":
                    dexterityItem = new ItemValueRange(1 * hero.paragonLevel);
                    intelligenceItem = new ItemValueRange(1 * hero.paragonLevel);
                    strengthItem = new ItemValueRange(3 * hero.paragonLevel);
                    break;
                default:
                    break;
            }

            vitalityItem = new ItemValueRange(2 * hero.paragonLevel);

            goldFind = new ItemValueRange(3 * hero.paragonLevel);
            magicFind = new ItemValueRange(3 * hero.paragonLevel);
        }
    }
}

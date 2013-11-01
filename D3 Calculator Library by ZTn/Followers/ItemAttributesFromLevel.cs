using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.HeroFollowers;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Followers
{
    public class ItemAttributesFromLevel : ItemAttributes
    {
        public ItemAttributesFromLevel(Follower follower, HeroClass heroClass)
        {
            switch (heroClass)
            {
                case HeroClass.ScoundrelFollower:
                    dexterityItem = new ItemValueRange(8 + 3 * follower.level);
                    intelligenceItem = new ItemValueRange(8 + 1 * follower.level);
                    strengthItem = new ItemValueRange(9 + 1 * follower.level);
                    break;
                case HeroClass.EnchantressFollower:
                    dexterityItem = new ItemValueRange(9 + 1 * follower.level);
                    intelligenceItem = new ItemValueRange(5 + 3 * follower.level);
                    strengthItem = new ItemValueRange(9 + 1 * follower.level);
                    break;
                case HeroClass.TemplarFollower:
                    dexterityItem = new ItemValueRange(8 + 1 * follower.level);
                    intelligenceItem = new ItemValueRange(10 + 1 * follower.level);
                    strengthItem = new ItemValueRange(7 + 3 * follower.level);
                    break;
                default:
                    break;
            }

            vitalityItem = new ItemValueRange(7 + 2 * follower.level);
        }
    }
}

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
                    dexterityItem = new ItemValueRange(8 + 3 * follower.Level);
                    intelligenceItem = new ItemValueRange(8 + 1 * follower.Level);
                    strengthItem = new ItemValueRange(9 + 1 * follower.Level);
                    vitalityItem = new ItemValueRange(7 + 2 * follower.Level);
                    break;
                case HeroClass.EnchantressFollower:
                    dexterityItem = new ItemValueRange(9 + 1 * follower.Level);
                    intelligenceItem = new ItemValueRange(5 + 3 * follower.Level);
                    strengthItem = new ItemValueRange(9 + 1 * follower.Level);
                    vitalityItem = new ItemValueRange(7 + 2 * follower.Level);
                    break;
                case HeroClass.TemplarFollower:
                    dexterityItem = new ItemValueRange(8 + 1 * follower.Level);
                    intelligenceItem = new ItemValueRange(10 + 1 * follower.Level);
                    strengthItem = new ItemValueRange(7 + 3 * follower.Level);
                    vitalityItem = new ItemValueRange(9 + 2 * follower.Level);
                    break;
            }

            critDamagePercent = new ItemValueRange(0.5);
        }
    }
}

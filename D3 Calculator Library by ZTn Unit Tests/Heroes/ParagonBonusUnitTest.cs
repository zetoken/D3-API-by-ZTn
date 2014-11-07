using NUnit.Framework;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Heroes
{
    [TestFixture]
    public class ParagonBonusUnitTest
    {
        [Test]
        public void Constructor()
        {
            var paragonBonus = new ParagonBonus("dexterityItem", new ItemValueRange(5), 50);

            Assert.AreEqual(paragonBonus.AttributeName, "dexterityItem");
            Assert.AreEqual(paragonBonus.BonusPerPoint, new ItemValueRange(5));
            Assert.AreEqual(paragonBonus.MaxPoints, 50);
            Assert.AreEqual(paragonBonus.CurrentPoints, 0);
        }

        [Test]
        public void GetBonus()
        {
            var paragonBonus = new ParagonBonus("dexterityItem", new ItemValueRange(5), 50);
            paragonBonus.CurrentPoints = 5;
            var bonus = paragonBonus.GetBonus();

            Assert.AreEqual(bonus.dexterityItem, new ItemValueRange(25));
            Assert.AreEqual(bonus.intelligenceItem, null);
        }
    }
}
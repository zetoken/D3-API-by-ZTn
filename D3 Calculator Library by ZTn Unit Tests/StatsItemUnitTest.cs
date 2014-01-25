using System.Collections.Generic;
using NUnit.Framework;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    [TestFixture]
    public class StatsItemUnitTest
    {
        [Test]
        public void Constructor1()
        {
            var item = new StatsItem(null, null, new List<Item>());

            item.Update();

            Assert.IsNotNull(item.MainHand);
            Assert.IsFalse(item.IsAmbidexterity());
            Assert.AreEqual(1, item.GetWeaponAttackPerSecond().Min);
        }

        [Test]
        public void Constructor2()
        {
            var mainHand = new Item(new ItemAttributes { attacksPerSecondItem = new ItemValueRange(1.4) });
            var item = new StatsItem(mainHand, null, new List<Item>());

            item.Update();

            Assert.AreEqual(mainHand, item.MainHand);
            Assert.IsFalse(item.IsAmbidexterity());
            Assert.AreEqual(1.4, item.GetWeaponAttackPerSecond().Min);
        }

        [Test]
        public void Constructor3()
        {
            var mainHand = new Item(new ItemAttributes { attacksPerSecondItem = new ItemValueRange(1.4) });
            var offHand = new Item(new ItemAttributes { attacksPerSecondItem = new ItemValueRange(1.2) });
            var item = new StatsItem(mainHand, offHand, new List<Item>());

            item.Update();

            Assert.AreEqual(mainHand, item.MainHand);
            Assert.IsTrue(item.IsAmbidexterity());
            Assert.AreEqual(1.15 * 2 * 1 / (1 / 1.4 + 1 / 1.2), item.GetWeaponAttackPerSecond().Min);
        }
    }
}

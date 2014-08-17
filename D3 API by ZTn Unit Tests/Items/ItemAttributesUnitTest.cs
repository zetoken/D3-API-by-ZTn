using NUnit.Framework;

namespace ZTn.BNet.D3.Items
{
    [TestFixture]
    class ItemAttributesUnitTest
    {
        [Test]
        public void OperatorAddLeftAndRight()
        {
            var left = new ItemAttributes { armorItem = new ItemValueRange(1), powerCooldownReductionPercentAll = new ItemValueRange(0.10) };
            var right = new ItemAttributes { armorItem = new ItemValueRange(2), powerCooldownReductionPercentAll = new ItemValueRange(0.20) };

            var sum = left + right;

            Assert.AreEqual(new ItemValueRange(3), sum.armorItem);
            Assert.AreEqual(new ItemValueRange(0.28), sum.powerCooldownReductionPercentAll);
        }

        [Test]
        public void OperatorAddLeftAndNull()
        {
            var left = new ItemAttributes { armorItem = new ItemValueRange(1), powerCooldownReductionPercentAll = new ItemValueRange(0.10) };

            var sum = left + null;

            Assert.AreEqual(new ItemValueRange(1), sum.armorItem);
            Assert.AreEqual(new ItemValueRange(0.10), sum.powerCooldownReductionPercentAll);
        }

        [Test]
        public void OperatorAddNullAndRight()
        {
            var right = new ItemAttributes { armorItem = new ItemValueRange(2), powerCooldownReductionPercentAll = new ItemValueRange(0.20) };

            var sum = null + right;

            Assert.AreEqual(new ItemValueRange(2), sum.armorItem);
            Assert.AreEqual(new ItemValueRange(0.20), sum.powerCooldownReductionPercentAll);
        }
    }
}

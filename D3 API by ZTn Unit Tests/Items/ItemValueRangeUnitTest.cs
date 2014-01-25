using NUnit.Framework;

namespace ZTn.BNet.D3.Items
{
    [TestFixture]
    class ItemValueRangeUnitTest
    {
        private readonly ItemValueRange left = new ItemValueRange(1, 8);
        private readonly ItemValueRange right = new ItemValueRange(2, 4);

        private const double leftDouble = 1;
        private const double rightDouble = 2;

        [Test]
        public void Constructor()
        {
            var valueRange = new ItemValueRange();

            Assert.AreEqual(0, valueRange.Min);
            Assert.AreEqual(0, valueRange.Max);
        }

        [Test]
        public void ConstructorCopy()
        {
            var valueRange = new ItemValueRange(left);

            Assert.AreEqual(left.Min, valueRange.Min);
            Assert.AreEqual(left.Max, valueRange.Max);
        }

        [Test]
        public void ConstructorValue()
        {
            var valueRange = new ItemValueRange(1);

            Assert.AreEqual(1, valueRange.Min);
            Assert.AreEqual(1, valueRange.Max);
        }

        [Test]
        public void ConstructorMinMax()
        {
            var valueRange = new ItemValueRange(1, 2);

            Assert.AreEqual(1, valueRange.Min);
            Assert.AreEqual(2, valueRange.Max);
        }

        [Test]
        public void OperatorAdd1()
        {
            var result = left + right;

            Assert.AreEqual(left.Min + right.Min, result.Min);
            Assert.AreEqual(left.Max + right.Max, result.Max);
        }

        [Test]
        public void OperatorAdd2()
        {
            var result = left + rightDouble;

            Assert.AreEqual(left.Min + rightDouble, result.Min);
            Assert.AreEqual(left.Max + rightDouble, result.Max);
        }

        [Test]
        public void OperatorAdd3()
        {
            var result = leftDouble + right;

            Assert.AreEqual(leftDouble + right.Min, result.Min);
            Assert.AreEqual(leftDouble + right.Max, result.Max);
        }

        [Test]
        public void OperatorSub1()
        {
            var result = left - right;

            Assert.AreEqual(left.Min - right.Min, result.Min);
            Assert.AreEqual(left.Max - right.Max, result.Max);
        }

        [Test]
        public void OperatorSub2()
        {
            var result = left - rightDouble;

            Assert.AreEqual(left.Min - rightDouble, result.Min);
            Assert.AreEqual(left.Max - rightDouble, result.Max);
        }

        [Test]
        public void OperatorSub3()
        {
            var result = leftDouble - right;

            Assert.AreEqual(leftDouble - right.Min, result.Min);
            Assert.AreEqual(leftDouble - right.Max, result.Max);
        }

        [Test]
        public void OperatorMultiply1()
        {
            var result = left * right;

            Assert.AreEqual(left.Min * right.Min, result.Min);
            Assert.AreEqual(left.Max * right.Max, result.Max);
        }

        [Test]
        public void OperatorMultiply2()
        {
            var result = left * rightDouble;

            Assert.AreEqual(left.Min * rightDouble, result.Min);
            Assert.AreEqual(left.Max * rightDouble, result.Max);
        }

        [Test]
        public void OperatorMultiply3()
        {
            var result = leftDouble * right;

            Assert.AreEqual(leftDouble * right.Min, result.Min);
            Assert.AreEqual(leftDouble * right.Max, result.Max);
        }

        [Test]
        public void OperatorDivide1()
        {
            var result = left / right;

            Assert.AreEqual(left.Min / right.Min, result.Min);
            Assert.AreEqual(left.Max / right.Max, result.Max);
        }

        [Test]
        public void OperatorDivide2()
        {
            var result = left / rightDouble;

            Assert.AreEqual(left.Min / rightDouble, result.Min);
            Assert.AreEqual(left.Max / rightDouble, result.Max);
        }

        [Test]
        public void OperatorDivide3()
        {
            var result = leftDouble / right;

            Assert.AreEqual(leftDouble / right.Min, result.Min);
            Assert.AreEqual(leftDouble / right.Max, result.Max);
        }

        [Test]
        public void OperatorDivideByZero1()
        {
            var result = left / new ItemValueRange(0);

            Assert.IsTrue(double.IsInfinity(result.Min));
            Assert.IsTrue(double.IsInfinity(result.Max));
        }

        [Test]
        public void OperatorDivideByZero2()
        {
            var result = left / 0;

            Assert.IsTrue(double.IsInfinity(result.Min));
            Assert.IsTrue(double.IsInfinity(result.Max));
        }

        [Test]
        public void OperatorDivideByZero3()
        {
            var result = leftDouble / new ItemValueRange(0);

            Assert.IsTrue(double.IsInfinity(result.Min));
            Assert.IsTrue(double.IsInfinity(result.Max));
        }
    }
}

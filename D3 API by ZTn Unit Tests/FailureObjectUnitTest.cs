using NUnit.Framework;

namespace ZTn.BNet.D3
{
    [TestFixture]
    public class FailureObjectUnitTest
    {
        [Test]
        public void IsFailureFalse()
        {
            var obj = new FailureObject();

            Assert.IsFalse(obj.IsFailureObject());
            Assert.IsNull(obj.Code);
            Assert.IsNull(obj.Reason);
        }

        [Test]
        public void IsFailureCode()
        {
            var obj = new FailureObject { Code = "100" };

            Assert.IsTrue(obj.IsFailureObject());
            Assert.AreEqual("100", obj.Code);
            Assert.IsNull(obj.Reason);
        }

        [Test]
        public void IsFailureReason()
        {
            var obj = new FailureObject { Reason = "Server error" };

            Assert.IsTrue(obj.IsFailureObject());
            Assert.IsNull(obj.Code);
            Assert.AreEqual("Server error", obj.Reason);
        }

        [Test]
        public void IsFailureCodeReason()
        {
            var obj = new FailureObject { Code = "100", Reason = "Server error" };

            Assert.IsTrue(obj.IsFailureObject());
            Assert.AreEqual("100", obj.Code);
            Assert.AreEqual("Server error", obj.Reason);
        }
    }
}

using System;
using NUnit.Framework;

namespace ZTn.BNet.BattleNet
{
    [TestFixture]
    public class BattleTagUnitTest
    {
        [Test]
        public void ConstructorSuccess()
        {
            var tag = new BattleTag("tok#2360");

            Assert.AreEqual("tok", tag.Name);
            Assert.AreEqual("2360", tag.Code);
            Assert.AreEqual("tok#2360", tag.Id);
        }

        [Test]
        public void ConstructorFailure()
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentException>(() => new BattleTag("tok@2360"));
        }

        [Test]
        public void ConstructorFailure2()
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentException>(() => new BattleTag("tok#"));
        }
    }
}
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
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorFailure()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new BattleTag("tok@2360");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorFailure2()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new BattleTag("tok#");
        }
    }
}
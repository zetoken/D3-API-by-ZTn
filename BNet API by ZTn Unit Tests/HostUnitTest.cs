using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace ZTn.BNet.BattleNet
{
    [TestFixture]
    class HostUnitTest
    {
        [Test]
        public void ConstructorEmpty()
        {
            var host = new Host();

            Assert.AreEqual(String.Empty, host.Name);
            Assert.AreEqual(String.Empty, host.Url);
        }

        [Test]
        public void ConstructorFull()
        {
            var host = new Host("EU", "http://eu.battle.net/");

            Assert.AreEqual("EU", host.Name);
            Assert.AreEqual("http://eu.battle.net/", host.Url);
        }

        [Test]
        public void Properties()
        {
            var host = new Host { Name = "EU", Url = "http://eu.battle.net/" };

            Assert.AreEqual("EU", host.Name);
            Assert.AreEqual("http://eu.battle.net/", host.Url);
        }
    }
}

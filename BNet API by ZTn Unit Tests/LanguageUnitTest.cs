using System;
using NUnit.Framework;

namespace ZTn.BNet.BattleNet
{
    [TestFixture]
    public class LanguageUnitTest
    {
        [Test]
        public void ConstructorEmpty()
        {
            var lang = new Language();

            Assert.AreEqual(String.Empty, lang.Name);
            Assert.AreEqual(String.Empty, lang.Code);
        }

        [Test]
        public void ConstructorFull()
        {
            var lang = new Language("english", "en");

            Assert.AreEqual("english", lang.Name);
            Assert.AreEqual("en", lang.Code);
        }

        [Test]
        public void Properties()
        {
            var lang = new Language { Name = "english", Code = "en" };

            Assert.AreEqual("english", lang.Name);
            Assert.AreEqual("en", lang.Code);
        }
    }
}

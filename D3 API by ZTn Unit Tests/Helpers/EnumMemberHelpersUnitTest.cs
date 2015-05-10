using NUnit.Framework;
using ZTn.BNet.D3.Heroes;

namespace ZTn.BNet.D3.Helpers
{
    [TestFixture]
    public class EnumMemberHelpersUnitTest
    {
        [Test]
        public void EnumValueShouldReturnValidString()
        {
            var result = HeroClass.WitchDoctor.ToEnumString();

            Assert.AreEqual("witch-doctor", result);
        }

        [Test]
        public void ValidStringShouldReturnEnumValue()
        {
            var result = "witch-doctor".ParseAsEnum<HeroClass>();

            Assert.AreEqual(HeroClass.WitchDoctor, result);
        }

        [Test]
        public void ParsingAnUnknownStringShouldReturnUnknown()
        {
            var result = "UnknownValueInEnum".ParseAsEnum<HeroClass>();

            Assert.AreEqual(HeroClass.Unknown, result);
        }
    }
}

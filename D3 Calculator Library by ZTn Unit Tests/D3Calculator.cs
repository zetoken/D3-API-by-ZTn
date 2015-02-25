using NUnit.Framework;
using ZTn.BNet.D3.Heroes;

namespace ZTn.BNet.D3.Calculator
{
    [TestFixture]
    public class D3CalculatorUnitTest
    {
        [Test]
        public void GetHitpointsPerVitalityFactor()
        {
            Assert.AreEqual(100, D3Calculator.GetHitpointsPerVitalityFactor(HeroClass.Monk, 70));
            Assert.AreEqual(90, D3Calculator.GetHitpointsPerVitalityFactor(HeroClass.Monk, 69));
            Assert.AreEqual(80, D3Calculator.GetHitpointsPerVitalityFactor(HeroClass.Monk, 68));
            Assert.AreEqual(70, D3Calculator.GetHitpointsPerVitalityFactor(HeroClass.Monk, 67));
            Assert.AreEqual(60, D3Calculator.GetHitpointsPerVitalityFactor(HeroClass.Monk, 66));
            Assert.AreEqual(55, D3Calculator.GetHitpointsPerVitalityFactor(HeroClass.Monk, 65));
            Assert.AreEqual(25, D3Calculator.GetHitpointsPerVitalityFactor(HeroClass.Monk, 50));
            Assert.AreEqual(11, D3Calculator.GetHitpointsPerVitalityFactor(HeroClass.Monk, 36));
            Assert.AreEqual(10, D3Calculator.GetHitpointsPerVitalityFactor(HeroClass.Monk, 35));
            Assert.AreEqual(10, D3Calculator.GetHitpointsPerVitalityFactor(HeroClass.Monk, 1));
        }
    }
}

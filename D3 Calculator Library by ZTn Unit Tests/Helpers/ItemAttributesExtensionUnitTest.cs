using NUnit.Framework;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Helpers
{
    [TestFixture]
    public class ItemAttributesExtensionUnitTest
    {
        #region >> ItemAttributes constants

        private readonly ItemAttributes damageAttr = new ItemAttributes
        {
            damageMin_Cold = new ItemValueRange(1, 10),
            damageBonusMin_Cold = new ItemValueRange(2, 20),
            damageDelta_Cold = new ItemValueRange(6, 60),
            damageTypePercentBonus_Cold = new ItemValueRange(0.1, 0.1),
            damageMin_Physical = new ItemValueRange(2, 20),
            damageBonusMin_Physical = new ItemValueRange(4, 40),
            damageDelta_Physical = new ItemValueRange(12, 120),
        };

        private readonly ItemAttributes resistAttr = new ItemAttributes
        {
            resistance_All = new ItemValueRange(1, 10),
            resistance_Arcane = new ItemValueRange(2, 20),
            resistance_Cold = new ItemValueRange(3, 30),
            resistance_Fire = new ItemValueRange(4, 40),
            resistance_Lightning = new ItemValueRange(5, 50),
            resistance_Physical = new ItemValueRange(6, 60),
            resistance_Poison = new ItemValueRange(7, 70)
        };

        private readonly ItemAttributes weaponAttr = new ItemAttributes
        {
            damageWeaponMin_Arcane = new ItemValueRange(1, 10),
            damageWeaponBonusMinX1_Arcane = new ItemValueRange(2, 20),
            damageWeaponBonusMin_Arcane = new ItemValueRange(3, 30),
            damageWeaponDelta_Arcane = new ItemValueRange(4, 40),
            damageWeaponBonusDelta_Arcane = new ItemValueRange(5, 50),
            damageWeaponBonusFlat_Arcane = new ItemValueRange(6, 60),
            damageWeaponPercentBonus_Arcane = new ItemValueRange(0.2, 0.2),
            damageTypePercentBonus_Arcane = new ItemValueRange(0.1, 0.1),
            damageWeaponMin_Physical = new ItemValueRange(2, 20),
            damageWeaponBonusMinX1_Physical = new ItemValueRange(4, 40),
            damageWeaponBonusMin_Physical = new ItemValueRange(6, 60),
            damageWeaponDelta_Physical = new ItemValueRange(8, 80),
            damageWeaponBonusDelta_Physical = new ItemValueRange(10, 100),
            damageWeaponBonusFlat_Physical = new ItemValueRange(12, 120),
            damageWeaponPercentBonus_Physical = null
        };

        #endregion

        [Test]
        public void GetBaseWeaponDamageMax()
        {
            Assert.AreEqual(new ItemValueRange(18, 180), weaponAttr.GetBaseWeaponDamageMax("Arcane"));
            Assert.AreEqual(new ItemValueRange(36, 360), weaponAttr.GetBaseWeaponDamageMax("Physical"));
        }

        [Test]
        public void GetBaseWeaponDamageMin()
        {
            Assert.AreEqual(new ItemValueRange(12, 120), weaponAttr.GetBaseWeaponDamageMin("Arcane"));
            Assert.AreEqual(new ItemValueRange(24, 240), weaponAttr.GetBaseWeaponDamageMin("Physical"));
        }

        [Test]
        public void GetRawWeaponDamageMax()
        {
            Assert.AreEqual(new ItemValueRange(25.2, 252), weaponAttr.GetRawWeaponDamageMax("Arcane"));
            Assert.AreEqual(new ItemValueRange(36, 360), weaponAttr.GetRawWeaponDamageMax("Physical"));
        }

        [Test]
        public void GetRawWeaponDamageMin()
        {
            Assert.AreEqual(new ItemValueRange(16.8, 168), weaponAttr.GetRawWeaponDamageMin("Arcane"));
            Assert.AreEqual(new ItemValueRange(24, 240), weaponAttr.GetRawWeaponDamageMin("Physical"));
        }

        [Test]
        public void GetResistance()
        {
            Assert.AreEqual(new ItemValueRange(1, 10), resistAttr.GetResistance("All"));
            Assert.AreEqual(new ItemValueRange(2, 20), resistAttr.GetResistance("Arcane"));
            Assert.AreEqual(new ItemValueRange(3, 30), resistAttr.GetResistance("Cold"));
            Assert.AreEqual(new ItemValueRange(4, 40), resistAttr.GetResistance("Fire"));
            Assert.AreEqual(new ItemValueRange(5, 50), resistAttr.GetResistance("Lightning"));
            Assert.AreEqual(new ItemValueRange(6, 60), resistAttr.GetResistance("Physical"));
            Assert.AreEqual(new ItemValueRange(7, 70), resistAttr.GetResistance("Poison"));
        }

        [Test]
        public void GetSimplifiedWithDamageOnly()
        {
            var attr = (weaponAttr + damageAttr).GetSimplified();

            Assert.AreNotSame(weaponAttr, attr);

            Assert.AreEqual(new ItemValueRange(12, 120), attr.damageWeaponMin_Arcane);
            Assert.AreEqual(new ItemValueRange(6, 60), attr.damageWeaponDelta_Arcane);
            Assert.IsNull(attr.damageWeaponBonusMin_Arcane);
            Assert.IsNull(attr.damageWeaponBonusDelta_Arcane);
            Assert.IsNull(attr.damageWeaponBonusMinX1_Arcane);
            Assert.IsNull(attr.damageWeaponBonusFlat_Arcane);
            Assert.AreEqual(weaponAttr.damageTypePercentBonus_Arcane, attr.damageTypePercentBonus_Arcane);

            Assert.AreEqual(new ItemValueRange(24, 240), attr.damageWeaponMin_Physical);
            Assert.AreEqual(new ItemValueRange(12, 120), attr.damageWeaponDelta_Physical);
            Assert.IsNull(attr.damageWeaponBonusMin_Physical);
            Assert.IsNull(attr.damageWeaponBonusDelta_Physical);
            Assert.IsNull(attr.damageWeaponBonusMinX1_Physical);
            Assert.IsNull(attr.damageWeaponBonusFlat_Physical);

            Assert.AreEqual(new ItemValueRange(3, 30), attr.damageMin_Cold);
            Assert.AreEqual(new ItemValueRange(4, 40), attr.damageDelta_Cold);
            Assert.IsNull(attr.damageBonusMin_Cold);
            Assert.AreEqual(damageAttr.damageTypePercentBonus_Cold, attr.damageTypePercentBonus_Cold);

            Assert.AreEqual(new ItemValueRange(6, 60), attr.damageMin_Physical);
            Assert.AreEqual(new ItemValueRange(8, 80), attr.damageDelta_Physical);
            Assert.IsNull(attr.damageBonusMin_Physical);
        }

        [Test]
        public void GetSimplifiedWithItemDamageOnly()
        {
            var attr = damageAttr.GetSimplified();

            Assert.AreNotSame(damageAttr, attr);

            Assert.AreEqual(new ItemValueRange(3, 30), attr.damageMin_Cold);
            Assert.AreEqual(new ItemValueRange(4, 40), attr.damageDelta_Cold);
            Assert.IsNull(attr.damageBonusMin_Cold);
            Assert.AreEqual(damageAttr.damageTypePercentBonus_Cold, attr.damageTypePercentBonus_Cold);

            Assert.AreEqual(new ItemValueRange(6, 60), attr.damageMin_Physical);
            Assert.AreEqual(new ItemValueRange(8, 80), attr.damageDelta_Physical);
            Assert.IsNull(attr.damageBonusMin_Physical);
        }

        [Test]
        public void GetSimplifiedWithWeaponDamageOnly()
        {
            var attr = weaponAttr.GetSimplified();

            Assert.AreNotSame(weaponAttr, attr);

            Assert.AreEqual(new ItemValueRange(12, 120), attr.damageWeaponMin_Arcane);
            Assert.AreEqual(new ItemValueRange(6, 60), attr.damageWeaponDelta_Arcane);
            Assert.IsNull(attr.damageWeaponBonusMin_Arcane);
            Assert.IsNull(attr.damageWeaponBonusDelta_Arcane);
            Assert.IsNull(attr.damageWeaponBonusMinX1_Arcane);
            Assert.IsNull(attr.damageWeaponBonusFlat_Arcane);
            Assert.AreEqual(weaponAttr.damageTypePercentBonus_Arcane, attr.damageTypePercentBonus_Arcane);

            Assert.AreEqual(new ItemValueRange(24, 240), attr.damageWeaponMin_Physical);
            Assert.AreEqual(new ItemValueRange(12, 120), attr.damageWeaponDelta_Physical);
            Assert.IsNull(attr.damageWeaponBonusMin_Physical);
            Assert.IsNull(attr.damageWeaponBonusDelta_Physical);
            Assert.IsNull(attr.damageWeaponBonusMinX1_Physical);
            Assert.IsNull(attr.damageWeaponBonusFlat_Physical);
        }
    }
}
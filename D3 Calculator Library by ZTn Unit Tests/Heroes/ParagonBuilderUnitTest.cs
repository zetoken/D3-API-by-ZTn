using NUnit.Framework;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Heroes
{
    [TestFixture]
    public class ParagonBuilderUnitTest
    {
        [Test]
        public void ClassBarbarian()
        {
            var paragon = new ParagonBuilder(HeroClass.Barbarian)
            {
                CharacteristicsMain = { CurrentPoints = 50 },
                CharacteristicsVitality = { CurrentPoints = 0 },
                CharacteristicsMovement = { CurrentPoints = 25 },
                CharacteristicsResourceMax = { CurrentPoints = 0 },
                AttackPerSecond = { CurrentPoints = 50 },
                AttackCooldownReduction = { CurrentPoints = 50 },
                AttackCritChance = { CurrentPoints = 0 },
                AttackCritDamage = { CurrentPoints = 0 },
                DefenseHitpoints = { CurrentPoints = 0 },
                DefenseArmor = { CurrentPoints = 25 },
                DefenseResistAll = { CurrentPoints = 50 },
                DefenseRegen = { CurrentPoints = 0 },
                OtherAreaDamage = { CurrentPoints = 0 },
                OtherResourceReduction = { CurrentPoints = 50 },
                OtherHitpointsOnHit = { CurrentPoints = 0 },
                OtherGold = { CurrentPoints = 0 }
            };

            var bonus = paragon.GetBonus();
            paragon.UpdateMaxPoints();

            Assert.AreEqual(398, paragon.MaxPoints);
            Assert.AreEqual("strengthItem", paragon.CharacteristicsMain.AttributeName);
            Assert.AreEqual(new ItemValueRange(250), bonus.strengthItem);
        }

        [Test]
        public void ClassCrusader()
        {
            var paragon = new ParagonBuilder(HeroClass.Crusader);

            Assert.AreEqual("strengthItem", paragon.CharacteristicsMain.AttributeName);
        }

        [Test]
        public void ClassDemonHunter()
        {
            var paragon = new ParagonBuilder(HeroClass.DemonHunter);

            Assert.AreEqual("dexterityItem", paragon.CharacteristicsMain.AttributeName);
        }

        [Test]
        public void ClassMonk()
        {
            var paragon = new ParagonBuilder(HeroClass.Monk)
            {
                MaxPoints = 475,
                CharacteristicsMain = { CurrentPoints = 20 },
                CharacteristicsVitality = { CurrentPoints = 74 },
                CharacteristicsMovement = { CurrentPoints = 25 },
                CharacteristicsResourceMax = { CurrentPoints = 0 },
                AttackPerSecond = { CurrentPoints = 50 },
                AttackCooldownReduction = { CurrentPoints = 50 },
                AttackCritChance = { CurrentPoints = 19 },
                AttackCritDamage = { CurrentPoints = 0 },
                DefenseHitpoints = { CurrentPoints = 19 },
                DefenseArmor = { CurrentPoints = 50 },
                DefenseResistAll = { CurrentPoints = 50 },
                DefenseRegen = { CurrentPoints = 0 },
                OtherAreaDamage = { CurrentPoints = 18 },
                OtherResourceReduction = { CurrentPoints = 50 },
                OtherHitpointsOnHit = { CurrentPoints = 50 },
                OtherGold = { CurrentPoints = 0 }
            };

            var bonus = paragon.GetBonus();

            Assert.AreEqual("dexterityItem", paragon.CharacteristicsMain.AttributeName);

            Assert.AreEqual(new ItemValueRange(100), bonus.dexterityItem);
            Assert.AreEqual(new ItemValueRange(370), bonus.vitalityItem);
            Assert.AreEqual(new ItemValueRange(12.5), bonus.movementScalar);
            Assert.AreEqual(new ItemValueRange(0), bonus.resourceMaxBonus);

            Assert.AreEqual(new ItemValueRange(10), bonus.attacksPerSecondPercent);
            Assert.AreEqual(new ItemValueRange(10), bonus.powerCooldownReductionPercentAll);
            Assert.AreEqual(new ItemValueRange(1.9), bonus.critPercentBonusCapped);
            Assert.AreEqual(new ItemValueRange(0), bonus.critDamagePercent);

            Assert.AreEqual(new ItemValueRange(9.5), bonus.hitpointsPercent);
            // TODO Assert.AreEqual(new ItemValueRange(25), bonus.armorItem);
            Assert.AreEqual(new ItemValueRange(250), bonus.resistance_All);
            Assert.AreEqual(new ItemValueRange(0), bonus.hitpointsRegenPerSecond);

            Assert.AreEqual(new ItemValueRange(18), bonus.splashDamageEffectPercent);
            Assert.AreEqual(new ItemValueRange(10), bonus.resourceCostReductionPercentAll);
            Assert.AreEqual(new ItemValueRange(8046.3), bonus.hitpointsOnHit);
            Assert.AreEqual(new ItemValueRange(0), bonus.goldFind);

            Assert.AreEqual(475, paragon.UpdateMaxPoints());
        }

        [Test]
        public void ClassWitchDoctor()
        {
            var paragon = new ParagonBuilder(HeroClass.WitchDoctor);

            Assert.AreEqual("intelligenceItem", paragon.CharacteristicsMain.AttributeName);
        }

        [Test]
        public void ClassWizard()
        {
            var paragon = new ParagonBuilder(HeroClass.Wizard);

            Assert.AreEqual("intelligenceItem", paragon.CharacteristicsMain.AttributeName);
        }

        [Test]
        public void MaxPoints0()
        {
            var paragon = new ParagonBuilder(HeroClass.Monk) { MaxPoints = 0 };

            Assert.AreEqual(0, paragon.MaxCharacteristicsPoints);
            Assert.AreEqual(0, paragon.MaxAttackPoints);
            Assert.AreEqual(0, paragon.MaxDefensePoints);
            Assert.AreEqual(0, paragon.MaxOtherPoints);
        }

        [Test]
        public void MaxPoints41()
        {
            var paragon = new ParagonBuilder(HeroClass.Monk) { MaxPoints = 41 };

            Assert.AreEqual(11, paragon.MaxCharacteristicsPoints);
            Assert.AreEqual(10, paragon.MaxAttackPoints);
            Assert.AreEqual(10, paragon.MaxDefensePoints);
            Assert.AreEqual(10, paragon.MaxOtherPoints);
        }

        [Test]
        public void MaxPoints475()
        {
            var paragon = new ParagonBuilder(HeroClass.Monk) { MaxPoints = 475 };

            Assert.AreEqual(119, paragon.MaxCharacteristicsPoints);
            Assert.AreEqual(119, paragon.MaxAttackPoints);
            Assert.AreEqual(119, paragon.MaxDefensePoints);
            Assert.AreEqual(118, paragon.MaxOtherPoints);
        }
    }
}
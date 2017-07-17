using System;
using System.Dynamic;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Heroes
{
    public class ParagonBuilder
    {
        public ParagonBonus CharacteristicsMain { get; private set; }
        public ParagonBonus CharacteristicsVitality { get; private set; }
        public ParagonBonus CharacteristicsMovement { get; private set; }
        public ParagonBonus CharacteristicsResourceMax { get; private set; }

        public ParagonBonus AttackPerSecond { get; private set; }
        public ParagonBonus AttackCooldownReduction { get; private set; }
        public ParagonBonus AttackCritChance { get; private set; }
        public ParagonBonus AttackCritDamage { get; private set; }

        public ParagonBonus DefenseHitpoints { get; private set; }
        public ParagonBonus DefenseArmor { get; private set; }
        public ParagonBonus DefenseResistAll { get; private set; }
        public ParagonBonus DefenseRegen { get; private set; }

        public ParagonBonus OtherAreaDamage { get; private set; }
        public ParagonBonus OtherResourceReduction { get; private set; }
        public ParagonBonus OtherHitpointsOnHit { get; private set; }
        public ParagonBonus OtherGold { get; private set; }

        /// <summary>
        /// Get paragon points spent in "characteristics".
        /// </summary>
        public int CurrentCharacteristicsPoints
        {
            get
            {
                return CharacteristicsMain.CurrentPoints
                       + CharacteristicsVitality.CurrentPoints
                       + CharacteristicsMovement.CurrentPoints
                       + CharacteristicsResourceMax.CurrentPoints;
            }
        }

        /// <summary>
        /// Get paragon points spent in "attack".
        /// </summary>
        public int CurrentAttackPoints
        {
            get
            {
                return AttackPerSecond.CurrentPoints
                    + AttackCooldownReduction.CurrentPoints
                    + AttackCritChance.CurrentPoints
                    + AttackCritDamage.CurrentPoints;
            }
        }

        /// <summary>
        /// Get paragon points spent in "defense".
        /// </summary>
        public int CurrentDefensePoints
        {
            get
            {
                return DefenseHitpoints.CurrentPoints
                    + DefenseArmor.CurrentPoints
                    + DefenseResistAll.CurrentPoints
                    + DefenseRegen.CurrentPoints;
            }
        }

        /// <summary>
        /// Get paragon points spent in "other".
        /// </summary>
        public int CurrentOtherPoints
        {
            get
            {
                return OtherAreaDamage.CurrentPoints
                   + OtherResourceReduction.CurrentPoints
                   + OtherHitpointsOnHit.CurrentPoints
                   + OtherGold.CurrentPoints;
            }
        }

        /// <summary>
        /// Get or set maximum paragon points to spend.
        /// </summary>
        public int MaxPoints { get; set; }

        /// <summary>
        /// Get the maximum paragon points to spend in characteristics.
        /// </summary>
        public int MaxCharacteristicsPoints
        {
            get { return (MaxPoints + 3) / 4; }
        }

        /// <summary>
        /// Get the maximum paragon points to spend in attack.
        /// </summary>
        public int MaxAttackPoints
        {
            get { return (MaxPoints + 2) / 4; }
        }

        /// <summary>
        /// Get the maximum paragon points to spend in defense.
        /// </summary>
        public int MaxDefensePoints
        {
            get { return (MaxPoints + 1) / 4; }
        }

        /// <summary>
        /// Get the maximum paragon points to spend in other.
        /// </summary>
        public int MaxOtherPoints
        {
            get { return MaxPoints / 4; }
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="heroClass"></param>
        public ParagonBuilder(HeroClass heroClass)
        {
            var mainCharacteristicName = String.Empty;
            switch (heroClass)
            {
                case HeroClass.Barbarian:
                case HeroClass.Crusader:
                    mainCharacteristicName = "strengthItem";
                    break;

                case HeroClass.DemonHunter:
                case HeroClass.Monk:
                    mainCharacteristicName = "dexterityItem";
                    break;

                case HeroClass.Necromancer:
                case HeroClass.WitchDoctor:
                case HeroClass.Wizard:
                    mainCharacteristicName = "intelligenceItem";
                    break;
            }

            CharacteristicsMain = new ParagonBonus(mainCharacteristicName, new ItemValueRange(5), 0);
            CharacteristicsVitality = new ParagonBonus("vitalityItem", new ItemValueRange(5), 0);
            CharacteristicsMovement = new ParagonBonus("movementScalar", new ItemValueRange(0.5), 50);
            CharacteristicsResourceMax = new ParagonBonus("resourceMaxBonus", new ItemValueRange(1), 50);

            AttackPerSecond = new ParagonBonus("attacksPerSecondPercent", new ItemValueRange(0.2), 50);
            AttackCooldownReduction = new ParagonBonus("powerCooldownReductionPercentAll", new ItemValueRange(0.2), 50);
            AttackCritChance = new ParagonBonus("critPercentBonusCapped", new ItemValueRange(0.1), 50);
            AttackCritDamage = new ParagonBonus("critDamagePercent", new ItemValueRange(1), 50);

            DefenseHitpoints = new ParagonBonus("hitpointsPercent", new ItemValueRange(0.5), 50);
            DefenseArmor = new ParagonBonus(null /* TODO "armorBonusPercent"*/, new ItemValueRange(0.5), 50);
            DefenseResistAll = new ParagonBonus("resistance_All", new ItemValueRange(5), 50);
            DefenseRegen = new ParagonBonus("hitpointsRegenPerSecond", new ItemValueRange(214.6), 50);

            OtherAreaDamage = new ParagonBonus("splashDamageEffectPercent", new ItemValueRange(1), 50);
            OtherResourceReduction = new ParagonBonus("resourceCostReductionPercentAll", new ItemValueRange(0.2), 50);
            OtherHitpointsOnHit = new ParagonBonus("hitpointsOnHit", new ItemValueRange(160.926), 50);
            OtherGold = new ParagonBonus("goldFind", new ItemValueRange(1), 50);
        }

        /// <summary>
        /// Updates <see cref="MaxPoints"/> needed to use current bonus.
        /// </summary>
        public int UpdateMaxPoints()
        {
            var characteristicsPoints = CurrentCharacteristicsPoints;
            var attackPoints = CurrentAttackPoints;
            var defensePoints = CurrentDefensePoints;
            var otherPoints = CurrentOtherPoints;

            var neededPoints = 0;
            if (characteristicsPoints > 0)
            {
                neededPoints = characteristicsPoints * 4 - 3;
            }
            if (attackPoints >= characteristicsPoints)
            {
                neededPoints = attackPoints * 4 - 2;
            }
            if (defensePoints >= attackPoints)
            {
                neededPoints = attackPoints * 4 - 1;
            }
            if (otherPoints >= defensePoints)
            {
                neededPoints = otherPoints * 4;
            }

            MaxPoints = neededPoints;
            return MaxPoints;
        }

        /// <summary>
        /// Returns the final paragon bonus as an <see cref="ItemAttributes"/> instance.
        /// </summary>
        /// <returns></returns>
        public ItemAttributes GetBonus()
        {
            return CharacteristicsMain.GetBonus()
                   + CharacteristicsVitality.GetBonus()
                   + CharacteristicsMovement.GetBonus()
                   + CharacteristicsResourceMax.GetBonus()
                   + AttackPerSecond.GetBonus()
                   + AttackCooldownReduction.GetBonus()
                   + AttackCritChance.GetBonus()
                   + AttackCritDamage.GetBonus()
                   + DefenseHitpoints.GetBonus()
                   + DefenseArmor.GetBonus()
                   + DefenseResistAll.GetBonus()
                   + DefenseRegen.GetBonus()
                   + OtherAreaDamage.GetBonus()
                   + OtherResourceReduction.GetBonus()
                   + OtherHitpointsOnHit.GetBonus()
                   + OtherGold.GetBonus();
        }
    }
}
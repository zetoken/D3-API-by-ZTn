using System;

namespace ZTn.BNet.D3.Heroes
{
    public class HeroStats : D3Object
    {
        #region >> Fields

        public double Toughness { get; set; }
        public double Healing { get; set; }
        public double Life { get; set; }
        public double Damage { get; set; }
        public double AttackSpeed { get; set; }
        public int Armor { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Vitality { get; set; }
        public int Intelligence { get; set; }
        public int PhysicalResist { get; set; }
        public int FireResist { get; set; }
        public int ColdResist { get; set; }
        public int LightningResist { get; set; }
        public int PoisonResist { get; set; }
        public int ArcaneResist { get; set; }
        public double CritDamage { get; set; }
        public double DamageIncrease { get; set; }
        public double CritChance { get; set; }
        public double DamageReduction { get; set; }
        public double BlockChance { get; set; }
        public double Thorns { get; set; }
        public double LifeSteal { get; set; }
        public double LifePerKill { get; set; }
        public double GoldFind { get; set; }
        public double MagicFind { get; set; }
        public double BlockAmountMin { get; set; }
        public double BlockAmountMax { get; set; }
        public double LifeOnHit { get; set; }
        public int PrimaryResource { get; set; }
        public int SecondaryResource { get; set; }

        #endregion
    }
}
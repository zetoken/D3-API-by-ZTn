using System.Collections.Generic;
using System.Linq;
using ZTn.BNet.D3.Calculator.Helpers;
using ZTn.BNet.D3.Calculator.Heroes;
using ZTn.BNet.D3.Calculator.Skills;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.HeroFollowers;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    public class D3Calculator
    {
        #region >> Fields

        public HeroClass HeroClass;
        public int HeroLevel;

        public StatsItem HeroStatsItem;

        private readonly ItemAttributes levelAttributes;
        private readonly ItemAttributes paragonLevelAttributes;

        #endregion

        #region >> Constants

        public static readonly string[] DamagePrefixes =
        {
            "damageMin_", "damageBonusMin_",
            "damageDelta_",
            "damageWeaponBonusMinX1_",
            "damageWeaponBonusFlat_",
            "damageWeaponMin_", "damageWeaponBonusMin_",
            "damageWeaponDelta_", "damageWeaponBonusDelta_"
        };

        public static readonly string[] DamageResists =
        {
            "Arcane", "Cold", "Fire", "Holy", "Lightning", "Physical", "Poison"
        };

        #endregion

        public static Item NakedHandWeapon
        {
            get { return new Item(new ItemAttributes { attacksPerSecondItem = ItemValueRange.One }); }
        }

        public static Item BlankWeapon
        {
            get { return new Item(new ItemAttributes()); }
        }

        #region >> Constructors

        public D3Calculator(Hero hero, Item mainHand, Item offHand, IEnumerable<Item> items)
        {
            HeroClass = hero.HeroClass;
            HeroLevel = hero.Level;

            // Build unique item equivalent to items worn
            HeroStatsItem = new StatsItem(mainHand, offHand, items);

            levelAttributes = new ItemAttributesFromLevel(hero);
            paragonLevelAttributes = new ItemAttributesFromParagonLevel(hero);

            Update();
        }

        public D3Calculator(Follower follower, HeroClass heroClass, Item mainHand, Item offHand, IEnumerable<Item> items)
        {
            HeroClass = heroClass;
            HeroLevel = follower.Level;

            foreach (var item in items.Union(new[] { mainHand, offHand }))
            {
                ApplyFollowersBonusMalusOnItemAttributes(item.AttributesRaw, heroClass);
                if (item.Gems != null)
                {
                    foreach (var gem in item.Gems)
                    {
                        ApplyFollowersBonusMalusOnItemAttributes(gem.AttributesRaw, heroClass);
                    }
                }
            }

            // Build unique item equivalent to items worn
            HeroStatsItem = new StatsItem(mainHand, offHand, items);

            levelAttributes = new Followers.ItemAttributesFromLevel(follower, heroClass);

            Update();
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemAttributes"></param>
        /// <param name="heroClass"></param>
        /// <remarks>No more damage malus applied on followers since Reaper of Souls.</remarks>
        private void ApplyFollowersBonusMalusOnItemAttributes(ItemAttributes itemAttributes, HeroClass heroClass)
        {
            itemAttributes.dexterityItem *= 2.5;
            itemAttributes.intelligenceItem *= 2.5;
            itemAttributes.strengthItem *= 2.5;
            itemAttributes.vitalityItem *= 2.5;

            foreach (var resist in DamageResists)
            {
                foreach (var damage in DamagePrefixes)
                {
                    var value = itemAttributes.GetAttributeByName(damage + resist);
                    itemAttributes.SetAttributeByName(damage + resist, value);
                }
            }
        }

        /// <summary>
        /// Return damage multiplier when the non critical hit (normal)
        /// </summary>
        /// <returns></returns>
        public double GetDamageMultiplierNormal()
        {
            double multiplier = 1;

            // Update dps with main statistic
            multiplier *= 1 + GetMainCharacteristic().Min / 100;

            return multiplier;
        }

        /// <summary>
        /// Return damage multiplier for critical hit
        /// </summary>
        /// <returns></returns>
        public double GetDamageMultiplierCritic()
        {
            double multiplier = 1;

            // Update dps with Critic
            double critDamagePercent = 0;
            if (HeroStatsItem.AttributesRaw.critDamagePercent != null)
            {
                critDamagePercent += HeroStatsItem.AttributesRaw.critDamagePercent.Min;
            }
            multiplier *= 1 + critDamagePercent;

            // Update dps with main statistic
            multiplier *= 1 + GetMainCharacteristic().Min / 100;

            return multiplier;
        }

        /// <summary>
        /// Return average damage multiplier (taking care of critical and normal hits)
        /// </summary>
        /// <returns></returns>
        public ItemValueRange GetDamageMultiplier()
        {
            var multiplier = ItemValueRange.One;

            // Update dps with Critic
            var critPercentBonusCapped = ItemValueRange.Zero;
            if (HeroStatsItem.AttributesRaw.critPercentBonusCapped != null)
            {
                critPercentBonusCapped += HeroStatsItem.AttributesRaw.critPercentBonusCapped;
            }
            var critDamagePercent = ItemValueRange.Zero;
            if (HeroStatsItem.AttributesRaw.critDamagePercent != null)
            {
                critDamagePercent += HeroStatsItem.AttributesRaw.critDamagePercent;
            }
            multiplier *= ItemValueRange.One + critPercentBonusCapped * critDamagePercent;

            // Update dps with main statistic
            var characteristic = GetMainCharacteristic();
            multiplier *= ItemValueRange.One + characteristic / 100.0;

            return multiplier;
        }

        public ItemValueRange GetActualAttackSpeed()
        {
            var multiplier = ItemValueRange.One;

            // Update malusMultiplier with Weapon Attack Speed
            multiplier *= HeroStatsItem.GetWeaponAttackPerSecond();

            return multiplier;
        }

        public ItemValueRange GetHeroArmor()
        {
            var armor = ItemValueRange.Zero;

            // Update with base items armor
            armor += HeroStatsItem.AttributesRaw.armorItem;

            // Update with items bonus armor
            armor += HeroStatsItem.AttributesRaw.armorBonusItem;

            // Update with strength bonus
            armor += GetHeroStrength();

            return armor;
        }

        public double GetHeroDamageReduction_Armor(int mobLevel)
        {
            var armor = GetHeroArmor().Min;

            return armor / (armor + 50 * mobLevel);
        }

        public double GetHeroDamageReduction(int mobLevel, string resist)
        {
            var resistance = GetHeroResistance(resist).Min;

            return resistance / (resistance + 5 * mobLevel);
        }

        public double GetHeroDodge()
        {
            var dexterity = GetHeroDexterity().Min;

            var dogde = dexterity / (0.00031 * HeroLevel * HeroLevel * HeroLevel + 0.0186 * HeroLevel * HeroLevel + 0.25 * HeroLevel + 1.93);

            return dogde;
        }

        private ItemValueRange GetHeroDpsAsIs()
        {
            var dps = HeroStatsItem.GetWeaponDamage();

            // Update Damage Multiplier
            dps *= GetDamageMultiplier();

            // Update Attack Speed Multiplier
            dps *= GetActualAttackSpeed();

            return dps;
        }

        public ItemValueRange GetHeroDps()
        {
            return GetHeroDps(new List<ID3SkillModifier>(), new List<ID3SkillModifier>());
        }

        public ItemValueRange GetHeroDps(IEnumerable<ID3SkillModifier> passives, IEnumerable<ID3SkillModifier> actives)
        {
            var itemAttributes = new ItemAttributes();

            HeroStatsItem.SetLevelBonus(levelAttributes);
            HeroStatsItem.SetParagonLevelBonus(paragonLevelAttributes);

            Update();

            // Build passive bonuses
            foreach (var modifier in passives)
            {
                itemAttributes += modifier.GetBonus(this);
            }

            // Compute the new unique item state with passives
            Update();

            // Build active bonuses
            foreach (var modifier in actives)
            {
                itemAttributes += modifier.GetBonus(this);
            }

            // Finally, return the dps
            return GetHeroDps(itemAttributes);
        }

        public ItemValueRange GetHeroDps(ItemAttributes addedBonus)
        {
            HeroStatsItem.SetLevelBonus(levelAttributes);
            HeroStatsItem.SetParagonLevelBonus(paragonLevelAttributes);
            HeroStatsItem.SetSkillsBonus(addedBonus);
            Update();

            return GetHeroDpsAsIs();
        }

        public double GetHeroEffectiveHitpoints(int mobLevel)
        {
            var ehp = GetHeroHitpoints().Min;

            // Update with armor reduction
            ehp /= (1 - GetHeroDamageReduction_Armor(mobLevel));

            // Update with lowest resistance reduction
            var resistance = GetHeroDamageReduction(mobLevel, "Arcane");
            if (GetHeroDamageReduction(mobLevel, "Cold") < resistance)
            {
                resistance = GetHeroDamageReduction(mobLevel, "Cold");
            }
            if (GetHeroDamageReduction(mobLevel, "Fire") < resistance)
            {
                resistance = GetHeroDamageReduction(mobLevel, "Fire");
            }
            if (GetHeroDamageReduction(mobLevel, "Lightning") < resistance)
            {
                resistance = GetHeroDamageReduction(mobLevel, "Lightning");
            }
            if (GetHeroDamageReduction(mobLevel, "Physical") < resistance)
            {
                resistance = GetHeroDamageReduction(mobLevel, "Physical");
            }
            if (GetHeroDamageReduction(mobLevel, "Poison") < resistance)
            {
                resistance = GetHeroDamageReduction(mobLevel, "Poison");
            }
            ehp /= (1 - resistance);

            // Update with class reduction
            if ((HeroClass == HeroClass.Monk) || (HeroClass == HeroClass.Barbarian) || (HeroClass == HeroClass.Crusader))
            {
                ehp /= (1 - 0.30);
            }

            return ehp;
        }

        /// <summary>
        /// Computes the hit points per vitality factor.
        /// </summary>
        /// <param name="heroClass">Class of the hero (can be a follower).</param>
        /// <param name="heroLevel">Level of the hero.</param>
        /// <returns></returns>
        public static int GetHitpointsPerVitalityFactor(HeroClass heroClass, int heroLevel)
        {
            switch (heroClass)
            {
                case HeroClass.Barbarian:
                case HeroClass.Crusader:
                case HeroClass.DemonHunter:
                case HeroClass.Monk:
                case HeroClass.WitchDoctor:
                case HeroClass.Wizard:
                    if (heroLevel <= 35)
                    {
                        return 10;
                    }
                    if (heroLevel <= 60)
                    {
                        return heroLevel - 25;
                    }
                    if (heroLevel <= 65)
                    {
                        return 35 + 4 * (heroLevel - 60);
                    }
                    return 50 + 10 * (heroLevel - 65);
                case HeroClass.EnchantressFollower:
                case HeroClass.ScoundrelFollower:
                case HeroClass.TemplarFollower:
                    // Missing leveling
                    return 35 + 5 * (heroLevel - 61);
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Computes the hero maximum hit points.
        /// </summary>
        /// <returns></returns>
        public ItemValueRange GetHeroHitpoints()
        {
            // Use hitpoints formula
            ItemValueRange hitPoints;

            switch (HeroClass)
            {
                case HeroClass.Barbarian:
                case HeroClass.Crusader:
                case HeroClass.DemonHunter:
                case HeroClass.Monk:
                case HeroClass.WitchDoctor:
                case HeroClass.Wizard:
                    if (HeroLevel <= 35)
                    {
                        hitPoints = 36 + 4 * HeroLevel + 10 * GetHeroVitality();
                    }
                    else if (HeroLevel <= 60)
                    {
                        hitPoints = 36 + 4 * HeroLevel + GetHitpointsPerVitalityFactor(HeroClass, HeroLevel) * GetHeroVitality();
                    }
                    else if (HeroLevel <= 65)
                    {
                        hitPoints = 36 + 4 * HeroLevel + GetHitpointsPerVitalityFactor(HeroClass, HeroLevel) * GetHeroVitality();
                    }
                    else
                    {
                        hitPoints = 36 + 4 * HeroLevel + GetHitpointsPerVitalityFactor(HeroClass, HeroLevel) * GetHeroVitality();
                    }
                    break;
                case HeroClass.EnchantressFollower:
                case HeroClass.ScoundrelFollower:
                    // Missing leveling
                    // 60: hitpoints = 6219 + GetHitpointsPerVitalityFactor(HeroClass, HeroLevel) * GetHeroVitality();
                    hitPoints = 54685 + GetHitpointsPerVitalityFactor(HeroClass, HeroLevel) * GetHeroVitality();
                    break;
                case HeroClass.TemplarFollower:
                    // Missing leveling
                    // 60: hitpoints = 7752 + GetHitpointsPerVitalityFactor(HeroClass, HeroLevel) * GetHeroVitality();
                    hitPoints = 68346 + GetHitpointsPerVitalityFactor(HeroClass, HeroLevel) * GetHeroVitality();
                    break;
                default:
                    hitPoints = ItemValueRange.Zero;
                    break;
            }

            // Update with +% Life bonus
            if (HeroStatsItem.AttributesRaw.hitpointsMaxPercentBonusItem != null)
            {
                hitPoints *= 1 + HeroStatsItem.AttributesRaw.hitpointsMaxPercentBonusItem.Min;
            }

            return hitPoints;
        }

        public ItemValueRange getHeroResistance_All()
        {
            var resist = ItemValueRange.Zero;

            resist += HeroStatsItem.GetResistance("All");

            // Update with intelligence bonus
            resist += GetHeroIntelligence() / 10;

            return resist;
        }

        public ItemValueRange GetHeroResistance(string resist)
        {
            var resistance = getHeroResistance_All();

            resistance += HeroStatsItem.GetResistance(resist);

            return resistance;
        }

        public ItemValueRange GetHeroDexterity()
        {
            if (HeroStatsItem.AttributesRaw.dexterityItem != null)
            {
                return HeroStatsItem.AttributesRaw.dexterityItem;
            }
            return ItemValueRange.Zero;
        }

        public ItemValueRange GetHeroIntelligence()
        {
            if (HeroStatsItem.AttributesRaw.intelligenceItem != null)
            {
                return HeroStatsItem.AttributesRaw.intelligenceItem;
            }
            return ItemValueRange.Zero;
        }

        public ItemValueRange GetHeroStrength()
        {
            if (HeroStatsItem.AttributesRaw.strengthItem != null)
            {
                return HeroStatsItem.AttributesRaw.strengthItem;
            }
            return ItemValueRange.Zero;
        }

        public ItemValueRange GetHeroVitality()
        {
            if (HeroStatsItem.AttributesRaw.vitalityItem != null)
            {
                return HeroStatsItem.AttributesRaw.vitalityItem;
            }
            return ItemValueRange.Zero;
        }

        public ItemValueRange GetMainCharacteristic()
        {
            var result = ItemValueRange.Zero;

            switch (HeroClass)
            {
                case HeroClass.Monk:
                case HeroClass.DemonHunter:
                case HeroClass.ScoundrelFollower:
                    return GetHeroDexterity();

                case HeroClass.WitchDoctor:
                case HeroClass.Wizard:
                case HeroClass.EnchantressFollower:
                    return GetHeroIntelligence();

                case HeroClass.Barbarian:
                case HeroClass.Crusader:
                case HeroClass.TemplarFollower:
                    return GetHeroStrength();
            }

            return result;
        }

        public void Update()
        {
            HeroStatsItem.Update();
        }
    }
}
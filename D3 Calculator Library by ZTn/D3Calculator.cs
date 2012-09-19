using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    public class D3Calculator
    {
        #region >> Fields

        Item[] items;
        Item mainHand;
        Item offHand;

        Item uniqueItem;

        #endregion

        #region >> Constructors

        public D3Calculator(Item mainHand, Item offHand, Item[] items)
        {
            this.mainHand = mainHand;
            this.offHand = offHand;
            this.items = items;
        }

        #endregion

        public Item getUniqueItem()
        {
            // Build a list of all items with attributes
            List<Item> stuff = new List<Item>(items);

            // Add weapons
            stuff.Add(mainHand);
            stuff.Add(offHand);

            // Add gems on items
            foreach (Item item in items)
            {
                if (item.gems != null)
                    stuff.AddRange(item.gems);
            }

            // Add gems on weapons
            if (mainHand.gems != null)
                stuff.AddRange(mainHand.gems);
            if (offHand.gems != null)
                stuff.AddRange(offHand.gems);

            uniqueItem = new Item();
            uniqueItem.attributesRaw = new ItemAttributes();

            foreach (Item item in stuff)
            {
                Type type = item.attributesRaw.GetType();

                foreach (FieldInfo fieldInfo in type.GetFields())
                {
                    if (fieldInfo.GetValue(item.attributesRaw) != null)
                    {
                        ItemValueRange itemValueRange = (ItemValueRange)fieldInfo.GetValue(item.attributesRaw);
                        ItemValueRange uniqueItemValueRange = (ItemValueRange)fieldInfo.GetValue(uniqueItem.attributesRaw);
                        if (uniqueItemValueRange == null)
                            uniqueItemValueRange = new ItemValueRange();
                        uniqueItemValueRange.min += itemValueRange.min;
                        uniqueItemValueRange.max += itemValueRange.max;
                        fieldInfo.SetValue(uniqueItem.attributesRaw, uniqueItemValueRange);
                    }
                }
            }

            return uniqueItem;
        }

        public Boolean isAmbidextry()
        {
            return (offHand.attributesRaw.attacksPerSecondItem != null);
        }

        #region >> getWeaponResistDamage *

        /// <summary>
        /// Computes the specific damage for a resist done by a weapon
        /// </summary>
        /// <param name="item"></param>
        /// <param name="resist">Must be one of "Arcane", "Cold", "Fire", "Lightning", "Physical", "Poison"</param>
        /// <returns></returns>
        public double getWeaponResistDamage(Item item, String resist)
        {
            return (getWeaponResistDamageMin(item, resist) + getWeaponResistDamageMax(item, resist)) / 2;
        }

        /// <summary>
        /// Computes the specific maximum damage for a resist done by a weapon
        /// </summary>
        /// <param name="item"></param>
        /// <param name="resist">Must be one of "Arcane", "Cold", "Fire", "Lightning", "Physical", "Poison"</param>
        /// <returns></returns>
        public double getWeaponResistDamageMax(Item item, String resist)
        {
            Type type = item.attributesRaw.GetType();

            ItemValueRange damageWeaponMin = (ItemValueRange)type.GetField("damageWeaponMin_" + resist).GetValue(item.attributesRaw);
            ItemValueRange damageWeaponDelta = (ItemValueRange)type.GetField("damageWeaponDelta_" + resist).GetValue(item.attributesRaw);
            ItemValueRange damageWeaponBonusDelta = (ItemValueRange)type.GetField("damageWeaponBonusDelta_" + resist).GetValue(item.attributesRaw);
            ItemValueRange damageWeaponPercentBonus = (ItemValueRange)type.GetField("damageWeaponPercentBonus_" + resist).GetValue(item.attributesRaw);

            double min = (damageWeaponMin == null ? 0 : damageWeaponMin.min);
            double delta = (damageWeaponDelta == null ? 0 : damageWeaponDelta.min);
            double bonusDelta = (damageWeaponBonusDelta == null ? 0 : damageWeaponBonusDelta.min);
            double percentBonus = (damageWeaponPercentBonus == null ? 0 : damageWeaponPercentBonus.min);
            double damage = (min + delta + bonusDelta) * (1 + percentBonus);

            return damage;
        }

        /// <summary>
        /// Computes the specific minimum damage for a resist done by a weapon
        /// </summary>
        /// <param name="item"></param>
        /// <param name="resist">Must be one of "Arcane", "Cold", "Fire", "Lightning", "Physical", "Poison"</param>
        /// <returns></returns>
        public double getWeaponResistDamageMin(Item item, String resist)
        {
            Type type = item.attributesRaw.GetType();

            ItemValueRange damageWeaponMin = (ItemValueRange)type.GetField("damageWeaponMin_" + resist).GetValue(item.attributesRaw);
            ItemValueRange damageWeaponDelta = (ItemValueRange)type.GetField("damageWeaponDelta_" + resist).GetValue(item.attributesRaw);
            ItemValueRange damageWeaponBonusMin = (ItemValueRange)type.GetField("damageWeaponBonusMin_" + resist).GetValue(item.attributesRaw);
            ItemValueRange damageWeaponBonusDelta = (ItemValueRange)type.GetField("damageWeaponBonusDelta_" + resist).GetValue(item.attributesRaw);
            ItemValueRange damageWeaponPercentBonus = (ItemValueRange)type.GetField("damageWeaponPercentBonus_" + resist).GetValue(item.attributesRaw);

            double min = (damageWeaponMin == null ? 0 : damageWeaponMin.min);
            double bonusMin = (damageWeaponBonusMin == null ? 0 : damageWeaponBonusMin.min);
            double percentBonus = (damageWeaponPercentBonus == null ? 0 : damageWeaponPercentBonus.min);
            double damage = (min + bonusMin) * (1 + percentBonus);

            return damage;
        }

        #endregion

        #region >> getResistDamage *

        /// <summary>
        /// Computes the specific damage for a resist done by an item other than a weapon
        /// </summary>
        /// <param name="item"></param>
        /// <param name="resist">Must be one of "Arcane", "Cold", "Fire", "Lightning", "Physical", "Poison"</param>
        /// <returns></returns>
        public double getResistDamage(Item item, String resist)
        {
            return (getResistDamageMin(item, resist) + getResistDamageMax(item, resist)) / 2;
        }

        /// <summary>
        /// Computes the specific maximum damage for a resist done by an item other than a weapon
        /// </summary>
        /// <param name="item"></param>
        /// <param name="resist">Must be one of "Arcane", "Cold", "Fire", "Lightning", "Physical", "Poison"</param>
        /// <returns></returns>
        public double getResistDamageMax(Item item, String resist)
        {
            Type type = item.attributesRaw.GetType();

            ItemValueRange damageMin = (ItemValueRange)type.GetField("damageMin_" + resist).GetValue(item.attributesRaw);
            ItemValueRange damageDelta = (ItemValueRange)type.GetField("damageDelta_" + resist).GetValue(item.attributesRaw);

            double min = (damageMin == null ? 0 : damageMin.min);
            double delta = (damageDelta == null ? 0 : damageDelta.min);
            double damage = min + delta;

            return damage;
        }

        /// <summary>
        /// Computes the specific minimum damage for a resist done by an item other than a weapon
        /// </summary>
        /// <param name="item"></param>
        /// <param name="resist">Must be one of "Arcane", "Cold", "Fire", "Lightning", "Physical", "Poison"</param>
        /// <returns></returns>
        public double getResistDamageMin(Item item, String resist)
        {
            Type type = item.attributesRaw.GetType();

            ItemValueRange damageMin = (ItemValueRange)type.GetField("damageMin_" + resist).GetValue(item.attributesRaw);
            ItemValueRange damageBonusMin = (ItemValueRange)type.GetField("damageBonusMin_" + resist).GetValue(item.attributesRaw);

            double min = (damageMin == null ? 0 : damageMin.min);
            double bonusMin = (damageBonusMin == null ? 0 : damageBonusMin.min);
            double damage = min + bonusMin;

            return damage;
        }

        #endregion

        #region >> getWeaponDamage *

        public double getWeaponDamage()
        {
            // Compute weapon damage
            double damage = getWeaponDamage(mainHand) + getBonusDamage();
            // Ambidextry
            if (isAmbidextry())
            {
                double attackSpeedMainHand = getWeaponAttackSpeed(mainHand);
                double attackSpeedOffHand = getWeaponAttackSpeed(offHand);
                double attackSpeedAverage = getWeaponAttackSpeed();
                double mainHandDamage = getWeaponDamage(mainHand) + getBonusDamage();
                double offHandDamage = getWeaponDamage(offHand) + getBonusDamage();
                damage = (damage + offHandDamage) / 2;
            }
            return damage;
        }

        /// <summary>
        /// Calculate weapon damage
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public double getWeaponDamage(Item item)
        {
            double damage = getWeaponResistDamage(item, "Arcane")
                + getWeaponResistDamage(item, "Cold")
                + getWeaponResistDamage(item, "Fire")
                + getWeaponResistDamage(item, "Lightning")
                + getWeaponResistDamage(item, "Physical")
                + getWeaponResistDamage(item, "Poison");

            return damage;
        }

        /// <summary>
        /// Calculate maximum weapon damage
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public double getWeaponDamageMax(Item item)
        {
            double damage = getWeaponResistDamageMax(item, "Arcane")
                + getWeaponResistDamageMax(item, "Cold")
                + getWeaponResistDamageMax(item, "Fire")
                + getWeaponResistDamageMax(item, "Lightning")
                + getWeaponResistDamageMax(item, "Physical")
                + getWeaponResistDamageMax(item, "Poison");

            return damage;
        }

        /// <summary>
        /// Calculate minimum weapon damage
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public double getWeaponDamageMin(Item item)
        {
            double damage = getWeaponResistDamageMin(item, "Arcane")
                + getWeaponResistDamageMin(item, "Cold")
                + getWeaponResistDamageMin(item, "Fire")
                + getWeaponResistDamageMin(item, "Lightning")
                + getWeaponResistDamageMin(item, "Physical")
                + getWeaponResistDamageMin(item, "Poison");

            return damage;
        }

        #endregion

        /// <summary>
        /// Calculate weapon damage bonuses on stuff
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public double getBonusDamage()
        {
            double damage = getResistDamage(uniqueItem, "Arcane")
                + getResistDamage(uniqueItem, "Cold")
                + getResistDamage(uniqueItem, "Fire")
                + getResistDamage(uniqueItem, "Lightning")
                + getResistDamage(uniqueItem, "Physical")
                + getResistDamage(uniqueItem, "Poison");

            return damage;
        }

        #region >> getWeaponDPS

        public double getWeaponDPS()
        {
            return getWeaponDamage() * getWeaponAttackSpeed();
        }

        public double getWeaponDPS(Item item)
        {
            return getWeaponDamage(item) * getWeaponAttackSpeed(item);
        }

        #endregion

        public double getWeaponBonusDPS(Item item)
        {
            return getBonusDamage() * getWeaponAttackSpeed(item);
        }

        #region >> getWeaponAttackSpeed

        public double getWeaponAttackSpeed()
        {
            double weaponAttackSpeed;

            if (!isAmbidextry())
            {
                weaponAttackSpeed = getWeaponAttackSpeed(mainHand);
            }
            else
            {
                // Right formula: 2 * 1 / ( 1 / main + 1 / off ) [found by ZTn]
                weaponAttackSpeed = 2 * 1 / (1 / getWeaponAttackSpeed(mainHand) + 1 / getWeaponAttackSpeed(offHand));
                // Ambidextry gets a 15% bonus
                weaponAttackSpeed *= 1.15;
            }

            return weaponAttackSpeed;
        }

        public double getWeaponAttackSpeed(Item item)
        {
            double weaponAttackSpeed = item.attributesRaw.attacksPerSecondItem.min;

            if (item.attributesRaw.attacksPerSecondItemPercent != null)
                weaponAttackSpeed *= (1 + item.attributesRaw.attacksPerSecondItemPercent.min);

            return weaponAttackSpeed;
        }

        #endregion

        public double getIncreasedAttackSpeed()
        {
            double attackSpeed = 0;

            if (uniqueItem.attributesRaw.attacksPerSecondPercent != null)
                attackSpeed = uniqueItem.attributesRaw.attacksPerSecondPercent.min;

            return attackSpeed;
        }

        public double getHeroDPS(int level, int paragonLevel)
        {
            if (uniqueItem == null) uniqueItem = getUniqueItem();

            double dps = getWeaponDamage();

            // Update dps with Weapon Attack Speed
            dps *= getWeaponAttackSpeed();

            // Update dps with Attack Speed
            dps *= (1 + getIncreasedAttackSpeed());

            // Update dps with Critic
            double critPercentBonusCapped = 0.05;
            if (uniqueItem.attributesRaw.critPercentBonusCapped != null)
                critPercentBonusCapped += uniqueItem.attributesRaw.critPercentBonusCapped.min;
            double critDamagePercent = 0.5;
            if (uniqueItem.attributesRaw.critDamagePercent != null)
                critDamagePercent += uniqueItem.attributesRaw.critDamagePercent.min;
            dps *= 1 + critPercentBonusCapped * critDamagePercent;

            // Update dps with main statistic
            dps *= 1 + (uniqueItem.attributesRaw.dexterityItem.min + (7 + 3 * level) + (paragonLevel * 3)) / 100;

            return dps;
        }
    }
}

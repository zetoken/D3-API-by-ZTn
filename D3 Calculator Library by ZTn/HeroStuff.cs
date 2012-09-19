using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    public class HeroStuff : Item
    {
        #region >> Fields

        Item[] items;
        public Weapon mainHand;
        public Weapon offHand;

        #endregion

        #region >> Constructor

        public HeroStuff(Item mainHand, Item offHand, Item[] items)
            : base()
        {
            this.mainHand = new Weapon(mainHand);
            this.offHand = new Weapon(offHand);
            this.items = items;
        }

        #endregion

        public void buildUniqueItem()
        {
            attributesRaw = new ItemAttributes();

            // Build a list of all items with attributes
            List<Item> stuff = new List<Item>(items);

            // Add weapons
            stuff.Add(mainHand.item);
            stuff.Add(offHand.item);

            // Add gems on items
            foreach (Item item in items)
            {
                if (item.gems != null)
                    stuff.AddRange(item.gems);
            }

            // Add gems on weapons
            if (mainHand.item.gems != null)
                stuff.AddRange(mainHand.item.gems);
            if (offHand.item.gems != null)
                stuff.AddRange(offHand.item.gems);

            foreach (Item item in stuff)
            {
                Type type = item.attributesRaw.GetType();

                foreach (FieldInfo fieldInfo in type.GetFields())
                {
                    if (fieldInfo.GetValue(item.attributesRaw) != null)
                    {
                        ItemValueRange itemValueRange = (ItemValueRange)fieldInfo.GetValue(item.attributesRaw);
                        ItemValueRange uniqueItemValueRange = (ItemValueRange)fieldInfo.GetValue(this.attributesRaw);
                        if (uniqueItemValueRange == null)
                            uniqueItemValueRange = new ItemValueRange();
                        uniqueItemValueRange.min += itemValueRange.min;
                        uniqueItemValueRange.max += itemValueRange.max;
                        fieldInfo.SetValue(this.attributesRaw, uniqueItemValueRange);
                    }
                }
            }
        }

        /// <summary>
        /// Calculate weapon damage bonuses on stuff
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public double getBonusDamage()
        {
            double damage = getResistDamage("Arcane")
                + getResistDamage("Cold")
                + getResistDamage("Fire")
                + getResistDamage("Lightning")
                + getResistDamage("Physical")
                + getResistDamage("Poison");

            return damage;
        }

        #region >> getResistDamage *

        /// <summary>
        /// Computes the specific damage for a resist done by an weapon other than a weapon
        /// </summary>
        /// <param name="weapon"></param>
        /// <param name="resist">Must be one of "Arcane", "Cold", "Fire", "Lightning", "Physical", "Poison"</param>
        /// <returns></returns>
        public double getResistDamage(String resist)
        {
            return (getResistDamageMin(resist) + getResistDamageMax(resist)) / 2;
        }

        /// <summary>
        /// Computes the specific maximum damage for a resist done by an weapon other than a weapon
        /// </summary>
        /// <param name="weapon"></param>
        /// <param name="resist">Must be one of "Arcane", "Cold", "Fire", "Lightning", "Physical", "Poison"</param>
        /// <returns></returns>
        public double getResistDamageMax(String resist)
        {
            Type type = this.attributesRaw.GetType();

            ItemValueRange damageMin = (ItemValueRange)type.GetField("damageMin_" + resist).GetValue(this.attributesRaw);
            ItemValueRange damageDelta = (ItemValueRange)type.GetField("damageDelta_" + resist).GetValue(this.attributesRaw);

            double min = (damageMin == null ? 0 : damageMin.min);
            double delta = (damageDelta == null ? 0 : damageDelta.min);
            double damage = min + delta;

            return damage;
        }

        /// <summary>
        /// Computes the specific minimum damage for a resist done by an weapon other than a weapon
        /// </summary>
        /// <param name="weapon"></param>
        /// <param name="resist">Must be one of "Arcane", "Cold", "Fire", "Lightning", "Physical", "Poison"</param>
        /// <returns></returns>
        public double getResistDamageMin(String resist)
        {
            Type type = this.attributesRaw.GetType();

            ItemValueRange damageMin = (ItemValueRange)type.GetField("damageMin_" + resist).GetValue(this.attributesRaw);
            ItemValueRange damageBonusMin = (ItemValueRange)type.GetField("damageBonusMin_" + resist).GetValue(this.attributesRaw);

            double min = (damageMin == null ? 0 : damageMin.min);
            double bonusMin = (damageBonusMin == null ? 0 : damageBonusMin.min);
            double damage = min + bonusMin;

            return damage;
        }

        #endregion

        public Boolean isAmbidextry()
        {
            return (offHand.isWeapon());
        }

    }
}

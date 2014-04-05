using System;
using System.Collections.Generic;
using System.Linq;

using ZTn.BNet.D3.Calculator.Helpers;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    public class StatsItem : Item
    {
        #region >> Fields

        private readonly List<Item> items;
        public Item MainHand;
        private readonly Item offHand;

        private Item ambidexterityWeapon;

        private ItemAttributes levelAttr;
        private ItemAttributes attrParagonLevel;

        private ItemAttributes addedBonus;

        #endregion

        #region >> Constructor

        /// <summary>
        /// Creates a new <see cref="StatsItem"/> instance using existing items.
        /// </summary>
        /// <param name="mainHand"></param>
        /// <param name="offHand"></param>
        /// <param name="items"></param>
        public StatsItem(Item mainHand, Item offHand, IEnumerable<Item> items)
        {
            if (mainHand != null && mainHand.IsWeapon())
            {
                mainHand.CheckAndUpdateWeaponDelta();
            }
            if (offHand != null && offHand.IsWeapon())
            {
                offHand.CheckAndUpdateWeaponDelta();
            }

            // If no mainHand is used, then use default "naked hand" weapon
            MainHand = mainHand ?? D3Calculator.NakedHandWeapon;

            // If no offHand is used, then use default "blank" weapon
            this.offHand = offHand ?? D3Calculator.BlankWeapon;

            this.items = new List<Item>(items);
        }

        #endregion

        private ItemValueRange ComputeWeaponAttackPerSecondForAmbidextry()
        {
            // Right formula: 2 * 1 / ( 1 / main + 1 / off ) [found by ZTn, nowhere else at that time]
            var weaponAttackSpeed = 2 * 1 / (1 / MainHand.GetRawWeaponAttackPerSecond() + 1 / offHand.GetRawWeaponAttackPerSecond());

            return weaponAttackSpeed;
        }

        protected ItemAttributes ComputeAmbidexterityWeaponAttributes()
        {
            var resists = new List<string> { "Arcane", "Cold", "Fire", "Holy", "Lightning", "Physical", "Poison" };
            var fields = new List<string> { "damageWeaponBonusDelta_", "damageWeaponBonusMin_", "damageWeaponDelta_", "damageWeaponMin_", "damageWeaponBonusMinX1_" };

            var attr = MainHand.AttributesRaw + offHand.AttributesRaw;

            // Calculate attack per second
            attr.attacksPerSecondItem = ComputeWeaponAttackPerSecondForAmbidextry();
            attr.attacksPerSecondItemPercent = null;

            // Calculate damages of weapon
            foreach (var resist in resists)
            {
                var mainHandWeaponPercentBonus = MainHand.GetAttributeByName("damageWeaponPercentBonus_" + resist);
                var offHandWeaponPercentBonus = offHand.GetAttributeByName("damageWeaponPercentBonus_" + resist);
                foreach (var field in fields)
                {
                    var mainHandField = MainHand.GetAttributeByName(field + resist);
                    var offHandField = offHand.GetAttributeByName(field + resist);
                    var newValue = 0.5 *
                        (
                            mainHandField * (ItemValueRange.One + mainHandWeaponPercentBonus)
                            + offHandField * (ItemValueRange.One + offHandWeaponPercentBonus)
                        );
                    if (newValue.Min == 0)
                        newValue = null;
                    attr.SetAttributeByName(field + resist, newValue);
                }
            }

            // Remove % damage bonus as they are taken into account in previous step
            attr.damageWeaponPercentBonus_Arcane = null;
            attr.damageWeaponPercentBonus_Cold = null;
            attr.damageWeaponPercentBonus_Fire = null;
            attr.damageWeaponPercentBonus_Holy = null;
            attr.damageWeaponPercentBonus_Lightning = null;
            attr.damageWeaponPercentBonus_Physical = null;
            attr.damageWeaponPercentBonus_Poison = null;

            return attr;
        }

        public ItemValueRange GetWeaponAttackPerSecond()
        {
            var weapon = IsAmbidexterity() ? ambidexterityWeapon : MainHand;

            // Initialize with weapon attack speed
            var weaponAttackSpeed = weapon.GetWeaponAttackPerSecond(AttributesRaw.attacksPerSecondItem);

            weaponAttackSpeed *= ItemValueRange.One + AttributesRaw.attacksPerSecondPercent;

            return weaponAttackSpeed;
        }

        public ItemValueRange GetWeaponDamage()
        {
            return this.GetRawAverageWeaponDamage() + this.GetRawAverageBonusDamage();
        }

        public ItemValueRange GetWeaponDamageMin()
        {
            return this.GetRawWeaponDamageMin() + this.GetRawBonusDamageMin();
        }

        public ItemValueRange GetWeaponDamageMax()
        {
            return MainHand.GetRawWeaponDamageMax() + this.GetRawWeaponDamageMax() + this.GetRawBonusDamageMax();
        }

        public Boolean IsAmbidexterity()
        {
            return offHand.IsWeapon();
        }

        public void Update()
        {
            AttributesRaw = new ItemAttributes();

            // Add bonus from level and paragon
            if (levelAttr != null)
                AttributesRaw += levelAttr;
            if (attrParagonLevel != null)
                AttributesRaw += attrParagonLevel;

            // Build a list of all items with fields
            var stuff = new List<Item>(items);

            // Add bonus (skills, buffs)
            if (addedBonus != null)
            {
                AttributesRaw += addedBonus;
            }

            // Merge gems with their items
            foreach (var item in items.Where(item => item.Gems != null))
            {
                item.MergeSocketedGems();
            }
            if (MainHand.Gems != null)
            {
                MainHand.MergeSocketedGems();
            }
            if (offHand.Gems != null)
            {
                offHand.MergeSocketedGems();
            }

            // Add items
            foreach (var item in stuff)
            {
                AttributesRaw += item.AttributesRaw;
            }

            // Add weapons - Note: we don't want attackPerSecondItem to include weapon's value, only stuff or skills bonuses
            var attackPerSecondItem = AttributesRaw.attacksPerSecondItem;
            if (IsAmbidexterity())
            {
                ambidexterityWeapon = new Item(ComputeAmbidexterityWeaponAttributes());
                AttributesRaw += ambidexterityWeapon.AttributesRaw;
                // Ambidextry gets a 15% attack speed bonus
                AttributesRaw += new ItemAttributes { attacksPerSecondPercent = new ItemValueRange(0.15) };
            }
            else
            {
                AttributesRaw += MainHand.AttributesRaw;
                AttributesRaw += offHand.AttributesRaw;
            }
            AttributesRaw.attacksPerSecondItem = attackPerSecondItem;
        }

        public void SetLevelBonus(ItemAttributes levelAttr)
        {
            this.levelAttr = levelAttr;
        }

        public void SetParagonLevelBonus(ItemAttributes itemParagonLevel)
        {
            attrParagonLevel = itemParagonLevel;
        }

        public void SetSkillsBonus(ItemAttributes addedBonus)
        {
            this.addedBonus = addedBonus;
        }

        public List<Set> GetActivatedSets()
        {
            var allItems = new List<Item>();
            allItems.AddRange(items);
            allItems.Add(MainHand);
            allItems.Add(offHand);

            return allItems.GetActivatedSets();
        }

        public ItemAttributes GetActivatedSetBonus()
        {
            var allItems = new List<Item>();
            allItems.AddRange(items);
            allItems.Add(MainHand);
            allItems.Add(offHand);

            return allItems.GetActivatedSetBonus();
        }
    }
}

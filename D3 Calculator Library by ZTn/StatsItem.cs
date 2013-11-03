using System;
using System.Collections.Generic;
using System.Linq;

using ZTn.BNet.D3.Calculator.Helpers;
using ZTn.BNet.D3.Calculator.Sets;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    public class StatsItem : Item
    {
        #region >> Fields

        List<Item> items;
        public Item mainHand;
        Item offHand;

        Item ambidextryWeapon;

        ItemAttributes attrLevel;
        ItemAttributes attrParagonLevel;

        ItemAttributes addedBonus;

        #endregion

        #region >> Constructor

        public StatsItem(Item mainHand, Item offHand, IEnumerable<Item> items)
            : base()
        {
            if (mainHand != null && mainHand.isWeapon())
                mainHand.checkAndUpdateWeaponDelta();
            if (offHand != null && offHand.isWeapon())
                offHand.checkAndUpdateWeaponDelta();

            // If no mainHand is used, then use default "naked hand" weapon
            if (mainHand != null)
                this.mainHand = mainHand;
            else
                this.mainHand = D3Calculator.nakedHandWeapon;

            // If no offHand is used, then use default "blank" weapon
            if (offHand != null)
                this.offHand = offHand;
            else
                this.offHand = D3Calculator.blankWeapon;

            this.items = new List<Item>(items);
        }

        #endregion

        protected ItemValueRange computeWeaponAttackPerSecondForAmbidextry()
        {
            ItemValueRange weaponAttackSpeed;
            // Right formula: 2 * 1 / ( 1 / main + 1 / off ) [found by ZTn, nowhere else at that time]
            weaponAttackSpeed = 2 * 1 / (1 / mainHand.getRawWeaponAttackPerSecond() + 1 / offHand.getRawWeaponAttackPerSecond());

            return weaponAttackSpeed;
        }

        protected ItemAttributes computeAmbidextryWeaponAttributes()
        {
            List<String> resists = new List<string>() { "Arcane", "Cold", "Fire", "Holy", "Lightning", "Physical", "Poison" };
            List<String> fields = new List<string>() { "damageWeaponBonusDelta_", "damageWeaponBonusMin_", "damageWeaponDelta_", "damageWeaponMin_", "damageWeaponBonusMinX1_" };

            ItemAttributes attr = mainHand.attributesRaw + offHand.attributesRaw;
            ItemAttributes mattr = mainHand.attributesRaw;
            ItemAttributes oattr = offHand.attributesRaw;

            // Calculate attack per second
            attr.attacksPerSecondItem = computeWeaponAttackPerSecondForAmbidextry();
            attr.attacksPerSecondItemPercent = null;

            // Calculate damages of weapon
            foreach (String resist in resists)
            {
                ItemValueRange mainHandWeaponPercentBonus = mainHand.getAttributeByName("damageWeaponPercentBonus_" + resist);
                ItemValueRange offHandWeaponPercentBonus = offHand.getAttributeByName("damageWeaponPercentBonus_" + resist);
                foreach (String field in fields)
                {
                    ItemValueRange mainHandField = mainHand.getAttributeByName(field + resist);
                    ItemValueRange offHandField = offHand.getAttributeByName(field + resist);
                    ItemValueRange newValue = 0.5 *
                        (
                            mainHandField * (ItemValueRange.One + mainHandWeaponPercentBonus)
                            + offHandField * (ItemValueRange.One + offHandWeaponPercentBonus)
                        );
                    if (newValue.min == 0)
                        newValue = null;
                    attr.setAttributeByName(field + resist, newValue);
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

        public ItemValueRange getWeaponAttackPerSecond()
        {
            ItemValueRange weaponAttackSpeed = ItemValueRange.Zero;
            Item weapon;

            if (isAmbidextry())
                weapon = ambidextryWeapon;
            else
                weapon = mainHand;

            // Initialize with weapon attack speed
            weaponAttackSpeed = weapon.getWeaponAttackPerSecond(attributesRaw.attacksPerSecondItem);

            weaponAttackSpeed *= ItemValueRange.One + attributesRaw.attacksPerSecondPercent;

            return weaponAttackSpeed;
        }

        public ItemValueRange getWeaponDamage()
        {
            return this.getRawAverageWeaponDamage() + this.getRawAverageBonusDamage();
        }

        public ItemValueRange getWeaponDamageMin()
        {
            return this.getRawWeaponDamageMin() + this.getRawBonusDamageMin();
        }

        public ItemValueRange getWeaponDamageMax()
        {
            return mainHand.getRawWeaponDamageMax() + this.getRawWeaponDamageMax() + this.getRawBonusDamageMax();
        }

        public Boolean isAmbidextry()
        {
            return offHand.isWeapon();
        }

        public void update()
        {
            attributesRaw = new ItemAttributes();

            // Add bonus from level and paragon
            if (attrLevel != null)
                attributesRaw += attrLevel;
            if (attrParagonLevel != null)
                attributesRaw += attrParagonLevel;

            // Build a list of all items with fields
            List<Item> stuff = new List<Item>(items);

            // Add bonus (skills, buffs)
            if (addedBonus != null)
            {
                attributesRaw += addedBonus;
            }

            // Merge gems with their items
            foreach (Item item in items.Where(item => item.gems != null))
            {
                item.mergeSocketedGems();
            }
            if (mainHand.gems != null)
            {
                mainHand.mergeSocketedGems();
            }
            if (offHand.gems != null)
            {
                offHand.mergeSocketedGems();
            }

            // Add items
            foreach (Item item in stuff)
            {
                attributesRaw += item.attributesRaw;
            }

            // Add weapons - Note: we don't want attackPerSecondItem to include weapon's value, only stuff or skills bonuses
            ItemValueRange attackPerSecondItem = attributesRaw.attacksPerSecondItem;
            if (isAmbidextry())
            {
                ambidextryWeapon = new Item(computeAmbidextryWeaponAttributes());
                attributesRaw += ambidextryWeapon.attributesRaw;
                // Ambidextry gets a 15% attack speed bonus
                attributesRaw += new ItemAttributes() { attacksPerSecondPercent = new ItemValueRange(0.15) };
            }
            else
            {
                attributesRaw += mainHand.attributesRaw;
                attributesRaw += offHand.attributesRaw;
            }
            attributesRaw.attacksPerSecondItem = attackPerSecondItem;
        }

        public void setLevelBonus(ItemAttributes itemLevel)
        {
            this.attrLevel = itemLevel;
        }

        public void setParagonLevelBonus(ItemAttributes itemParagonLevel)
        {
            this.attrParagonLevel = itemParagonLevel;
        }

        public void setSkillsBonus(ItemAttributes addedBonus)
        {
            this.addedBonus = addedBonus;
        }

        public List<Set> getActivatedSets()
        {
            List<Item> allItems = new List<Item>();
            allItems.AddRange(items);
            allItems.Add(mainHand);
            allItems.Add(offHand);

            return allItems.getActivatedSets();
        }

        public ItemAttributes getActivatedSetBonus()
        {
            List<Item> allItems = new List<Item>();
            allItems.AddRange(items);
            allItems.Add(mainHand);
            allItems.Add(offHand);

            return allItems.getActivatedSetBonus();
        }
    }
}

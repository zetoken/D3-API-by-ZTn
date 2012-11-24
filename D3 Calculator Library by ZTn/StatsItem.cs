using System;
using System.Collections.Generic;
using ZTn.BNet.D3.Calculator.Sets;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    public class StatsItem : Item
    {
        #region >> Fields

        List<Item> items;
        Item mainHand;
        Item offHand;

        ItemAttributes attrLevel;
        ItemAttributes attrParagonLevel;

        ItemAttributes addedBonus;

        #endregion

        #region >> Constructor

        public StatsItem(Item mainHand, Item offHand, Item[] items)
            : base()
        {
            this.mainHand = mainHand;
            this.offHand = offHand;
            this.items = new List<Item>(items);
        }

        #endregion

        public double getWeaponAttackPerSecond()
        {
            double weaponAttackSpeed;

            if (!isAmbidextry())
            {
                weaponAttackSpeed = mainHand.getRawWeaponAttackPerSecond().min;
            }
            else
            {
                // Right formula: 2 * 1 / ( 1 / main + 1 / off ) [found by ZTn]
                weaponAttackSpeed = 2 * 1 / (1 / mainHand.getRawWeaponAttackPerSecond().min + 1 / offHand.getRawWeaponAttackPerSecond().min);
                // Ambidextry gets a 15% bonus
                weaponAttackSpeed *= 1.15;
            }

            return weaponAttackSpeed;
        }

        public double getWeaponDamage()
        {
            // Compute weapon thorns
            double damage = this.getRawWeaponDamage().min + this.getRawBonusDamage().min;
            // Ambidextry
            if (isAmbidextry())
            {
                damage = this.getRawWeaponDamage().min / 2 + this.getRawBonusDamage().min;
            }
            return damage;
        }

        public double getWeaponDamageMin()
        {
            // Compute weapon damage
            double damage = this.getRawWeaponDamageMin().min + this.getRawBonusDamageMin().min;
            // Ambidextry
            if (isAmbidextry())
            {
                damage = this.getRawWeaponDamageMin().min / 2 + this.getRawBonusDamageMin().min;
            }
            return damage;
        }

        public double getWeaponDamageMax()
        {
            // Compute weapon damage
            double damage = mainHand.getRawWeaponDamageMax().min + this.getRawWeaponDamageMax().min + this.getRawBonusDamageMax().min;
            // Ambidextry
            if (isAmbidextry())
            {
                damage = this.getRawWeaponDamageMax().min / 2 + this.getRawBonusDamageMax().min;
            }
            return damage;
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

            // Build a list of all items with attributes
            List<Item> stuff = new List<Item>(items);

            // Add bonus (skills, buffs)
            if (addedBonus != null)
            {
                if (addedBonus.attacksPerSecondItem != null)
                {
                    mainHand.attributesRaw.attacksPerSecondItem += addedBonus.attacksPerSecondItem;
                    if (offHand.isWeapon())
                        offHand.attributesRaw.attacksPerSecondItem += addedBonus.attacksPerSecondItem;
                    addedBonus.attacksPerSecondItem = null;
                }
                attributesRaw += addedBonus;
            }

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

            // Add items
            foreach (Item item in stuff)
            {
                attributesRaw += item.attributesRaw;
            }
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

        public ItemAttributes getActivatedSetBonus(KnownSets knownSets)
        {
            return knownSets.getActivatedSetBonus(items);
        }
    }
}

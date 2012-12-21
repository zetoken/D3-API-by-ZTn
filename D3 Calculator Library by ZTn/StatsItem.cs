using System;
using System.Collections.Generic;
using ZTn.BNet.D3.Calculator.Sets;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    public class StatsItem : Item
    {
        #region >> Fields

        private static readonly Type typeOfItemAttributes = typeof(ItemAttributes);

        List<Item> items;
        public Item mainHand;
        Item offHand;

        Item ambidextryWeapon;

        ItemAttributes attrLevel;
        ItemAttributes attrParagonLevel;

        ItemAttributes addedBonus;

        #endregion

        #region >> Constructor

        public StatsItem(Item mainHand, Item offHand, Item[] items)
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

        protected double computeWeaponAttackPerSecondForAmbidextry()
        {
            double weaponAttackSpeed;
            // Right formula: 2 * 1 / ( 1 / main + 1 / off ) [found by ZTn, nowhere else at that time]
            weaponAttackSpeed = 2 * 1 / (1 / mainHand.getRawWeaponAttackPerSecond().min + 1 / offHand.getRawWeaponAttackPerSecond().min);

            return weaponAttackSpeed;
        }

        protected ItemAttributes computeAmbidextryWeaponAttributes()
        {
            List<String> resists = new List<string>() { "Arcane", "Cold", "Fire", "Holy", "Lightning", "Physical", "Poison" };
            List<String> fields = new List<string>() { "damageWeaponBonusDelta_", "damageWeaponBonusMin_", "damageWeaponDelta_", "damageWeaponMin_" };

            ItemAttributes attr = mainHand.attributesRaw + offHand.attributesRaw;
            ItemAttributes mattr = mainHand.attributesRaw;
            ItemAttributes oattr = offHand.attributesRaw;

            // Calculate attack per second
            attr.attacksPerSecondItem = new ItemValueRange(computeWeaponAttackPerSecondForAmbidextry());
            attr.attacksPerSecondItemPercent = null;

            // Calculate damages of ambidextryWeapon
            ItemValueRange half = new ItemValueRange(0.5);

            foreach (String resist in resists)
            {
                ItemValueRange mainHandWeaponPercentBonus = (ItemValueRange)typeOfItemAttributes.GetField("damageWeaponPercentBonus_" + resist).GetValue(mainHand.attributesRaw);
                ItemValueRange offHandWeaponPercentBonus = (ItemValueRange)typeOfItemAttributes.GetField("damageWeaponPercentBonus_" + resist).GetValue(offHand.attributesRaw);
                foreach (String field in fields)
                {
                    ItemValueRange mainHandField = (ItemValueRange)typeOfItemAttributes.GetField(field + resist).GetValue(mainHand.attributesRaw);
                    ItemValueRange offHandField = (ItemValueRange)typeOfItemAttributes.GetField(field + resist).GetValue(offHand.attributesRaw);
                    ItemValueRange newValue =
                        (
                            mainHandField * (ItemValueRange.One + mainHandWeaponPercentBonus)
                            + offHandField * (ItemValueRange.One + offHandWeaponPercentBonus)
                        )
                        * half;
                    if (newValue.min == 0)
                        newValue = null;
                    typeOfItemAttributes.GetField(field + resist).SetValue(attr, newValue);
                }
            }

            attr.damageWeaponPercentBonus_Arcane = null;
            attr.damageWeaponPercentBonus_Cold = null;
            attr.damageWeaponPercentBonus_Fire = null;
            attr.damageWeaponPercentBonus_Holy = null;
            attr.damageWeaponPercentBonus_Lightning = null;
            attr.damageWeaponPercentBonus_Physical = null;
            attr.damageWeaponPercentBonus_Poison = null;

            return attr;
        }

        public double getWeaponAttackPerSecond()
        {
            double weaponAttackSpeed;
            double increasedAttackSpeed;

            if (isAmbidextry())
            {
                weaponAttackSpeed = ambidextryWeapon.getRawWeaponAttackPerSecond().min;
            }
            else
            {
                weaponAttackSpeed = mainHand.getRawWeaponAttackPerSecond().min;
            }
            weaponAttackSpeed += (attributesRaw.attacksPerSecondItemPercent != null ? attributesRaw.attacksPerSecondItemPercent.min : 0);

            increasedAttackSpeed = (attributesRaw.attacksPerSecondPercent != null ? attributesRaw.attacksPerSecondPercent.min : 0);
            weaponAttackSpeed *= 1 + increasedAttackSpeed;

            return weaponAttackSpeed;
        }

        public double getWeaponDamage()
        {
            return this.getRawWeaponDamage().min + this.getRawBonusDamage().min;
        }

        public double getWeaponDamageMin()
        {
            return this.getRawWeaponDamageMin().min + this.getRawBonusDamageMin().min;
        }

        public double getWeaponDamageMax()
        {
            return mainHand.getRawWeaponDamageMax().min + this.getRawWeaponDamageMax().min + this.getRawBonusDamageMax().min;
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

            // Add gems on items
            foreach (Item item in items)
            {
                if (item.gems != null)
                {
                    foreach (SocketedGem gem in item.gems)
                        attributesRaw += gem.attributesRaw;
                }
            }

            // Add gems on weapons
            if (mainHand.gems != null)
            {
                foreach (SocketedGem gem in mainHand.gems)
                    attributesRaw += gem.attributesRaw;
            }
            if (offHand.gems != null)
            {
                foreach (SocketedGem gem in offHand.gems)
                    attributesRaw += gem.attributesRaw;
            }

            // Add items
            foreach (Item item in stuff)
            {
                attributesRaw += item.attributesRaw;
            }

            // Add weapons
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
            List<ItemSummary> allItems = new List<ItemSummary>();
            foreach (ItemSummary item in items)
                allItems.Add(item);
            allItems.Add(mainHand);
            allItems.Add(offHand);
            return knownSets.getActivatedSetBonus(allItems);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    public class HeroStuff : Item
    {
        #region >> Fields

        List<Item> items;
        public Item mainHand;
        public Item offHand;

        #endregion

        #region >> Constructor

        public HeroStuff(Item mainHand, Item offHand, Item[] items)
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
            // Compute weapon damage
            double damage = mainHand.getRawWeaponDamage().min + this.getRawBonusDamage().min;
            // Ambidextry
            if (isAmbidextry())
            {
                double mainHandDamage = mainHand.getRawWeaponDamage().min + this.getRawBonusDamage().min;
                double offHandDamage = offHand.getRawWeaponDamage().min + this.getRawBonusDamage().min;
                damage = (damage + offHandDamage) / 2;
            }
            return damage;
        }

        public double getWeaponDamageMin()
        {
            // Compute weapon damage
            double damage = mainHand.getRawWeaponDamageMin().min + this.getRawBonusDamageMin().min;
            // Ambidextry
            if (isAmbidextry())
            {
                double mainHandDamage = mainHand.getRawWeaponDamageMin().min + this.getRawBonusDamageMin().min;
                double offHandDamage = offHand.getRawWeaponDamageMin().min + this.getRawBonusDamageMin().min;
                damage = (damage + offHandDamage) / 2;
            }
            return damage;
        }

        public double getWeaponDamageMax()
        {
            // Compute weapon damage
            double damage = mainHand.getRawWeaponDamageMax().min + this.getRawBonusDamageMax().min;
            // Ambidextry
            if (isAmbidextry())
            {
                double mainHandDamage = mainHand.getRawWeaponDamageMax().min + this.getRawBonusDamageMax().min;
                double offHandDamage = offHand.getRawWeaponDamageMax().min + this.getRawBonusDamageMax().min;
                damage = (damage + offHandDamage) / 2;
            }
            return damage;
        }

        public Boolean isAmbidextry()
        {
            return (offHand.isWeapon());
        }

        public void update()
        {
            attributesRaw = new ItemAttributes();

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

            foreach (Item item in stuff)
            {
                attributesRaw += item.attributesRaw;
            }

            this.updateFromRawAttributes();
        }

        public void updateWithTalents(Item addedBonus, Item multipliedBonus)
        {
            update();
            this.attributesRaw = (this.attributesRaw + addedBonus.attributesRaw) * multipliedBonus.attributesRaw;
        }
    }
}

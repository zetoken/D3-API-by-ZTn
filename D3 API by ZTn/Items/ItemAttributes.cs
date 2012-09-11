using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class ItemAttributes
    {
        #region >> Fields

        [DataMember(Name = "Attacks_Per_Second_Item")]
        public ItemValueRange attacksPerSecondItem;
        [DataMember(Name = "Attacks_Per_Second_Item_Percent")]
        public ItemValueRange attacksPerSecondItemPercent;

        [DataMember(Name = "Dexterity_Item")]
        public ItemValueRange dexterityItem;
        [DataMember(Name = "Intelligence_Item")]
        public ItemValueRange intelligenceItem;
        [DataMember(Name = "Strength_Item")]
        public ItemValueRange strengthItem;
        [DataMember(Name = "Vitality_Item")]
        public ItemValueRange vitalityItem;

        [DataMember(Name = "Crit_Damage_Percent")]
        public ItemValueRange critDamagePercent;
        [DataMember(Name = "Crit_Percent_Bonus_Capped")]
        public ItemValueRange critPercentBonusCapped;

        [DataMember(Name = "Hitpoints_On_Hit")]
        public ItemValueRange hitpointsOnHit;

        [DataMember(Name = "Hitpoints_Regen_Per_Second")]
        public ItemValueRange hitpointsRegenPerSecond;

        [DataMember(Name = "Armor_Item")]
        public ItemValueRange armorItem;

        [DataMember(Name = "Resistance#Arcane")]
        public ItemValueRange resistance_Arcane;
        [DataMember(Name = "Resistance#Cold")]
        public ItemValueRange resistance_Cold;
        [DataMember(Name = "Resistance#Fire")]
        public ItemValueRange resistance_Fire;
        [DataMember(Name = "Resistance#Lightning")]
        public ItemValueRange resistance_Lightning;
        [DataMember(Name = "Resistance#Physical")]
        public ItemValueRange resistance_Physical;
        [DataMember(Name = "Resistance#Poison")]
        public ItemValueRange resistance_Poison;
        [DataMember(Name = "Resistance_All")]
        public ItemValueRange resistanceAll;

        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Arcane")]
        public ItemValueRange damageWeaponBonusDelta_Arcane;
        [DataMember(Name = "Damage_Weapon_Bonus_Min#Arcane")]
        public ItemValueRange damageWeaponBonusMin_Arcane;
        [DataMember(Name = "Damage_Weapon_Delta#Arcane")]
        public ItemValueRange damageWeaponDelta_Arcane;
        [DataMember(Name = "Damage_Weapon_Min#Arcane")]
        public ItemValueRange damageWeaponMin_Arcane;
        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Arcane")]
        public ItemValueRange damageWeaponPercentBonus_Arcane;

        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Cold")]
        public ItemValueRange damageWeaponBonusDelta_Cold;
        [DataMember(Name = "Damage_Weapon_Bonus_Min#Cold")]
        public ItemValueRange damageWeaponBonusMin_Cold;
        [DataMember(Name = "Damage_Weapon_Delta#Cold")]
        public ItemValueRange damageWeaponDelta_Cold;
        [DataMember(Name = "Damage_Weapon_Min#Cold")]
        public ItemValueRange damageWeaponMin_Cold;
        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Cold")]
        public ItemValueRange damageWeaponPercentBonus_Cold;

        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Fire")]
        public ItemValueRange damageWeaponBonusDelta_Fire;
        [DataMember(Name = "Damage_Weapon_Bonus_Min#Fire")]
        public ItemValueRange damageWeaponBonusMin_Fire;
        [DataMember(Name = "Damage_Weapon_Delta#Fire")]
        public ItemValueRange damageWeaponDelta_Fire;
        [DataMember(Name = "Damage_Weapon_Min#Fire")]
        public ItemValueRange damageWeaponMin_Fire;
        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Fire")]
        public ItemValueRange damageWeaponPercentBonus_Fire;

        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Lightning")]
        public ItemValueRange damageWeaponBonusDelta_Lightning;
        [DataMember(Name = "Damage_Weapon_Bonus_Min#Lightning")]
        public ItemValueRange damageWeaponBonusMin_Lightning;
        [DataMember(Name = "Damage_Weapon_Delta#Lightning")]
        public ItemValueRange damageWeaponDelta_Lightning;
        [DataMember(Name = "Damage_Weapon_Min#Lightning")]
        public ItemValueRange damageWeaponMin_Lightning;
        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Lightning")]
        public ItemValueRange damageWeaponPercentBonus_Lightning;

        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Physical")]
        public ItemValueRange damageWeaponBonusDelta_Physical;
        [DataMember(Name = "Damage_Weapon_Bonus_Min#Physical")]
        public ItemValueRange damageWeaponBonusMin_Physical;
        [DataMember(Name = "Damage_Weapon_Delta#Physical")]
        public ItemValueRange damageWeaponDelta_Physical;
        [DataMember(Name = "Damage_Weapon_Min#Physical")]
        public ItemValueRange damageWeaponMin_Physical;
        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Physical")]
        public ItemValueRange damageWeaponPercentBonus_Physical;

        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Poison")]
        public ItemValueRange damageWeaponBonusDelta_Poison;
        [DataMember(Name = "Damage_Weapon_Bonus_Min#Poison")]
        public ItemValueRange damageWeaponBonusMin_Poison;
        [DataMember(Name = "Damage_Weapon_Delta#Poison")]
        public ItemValueRange damageWeaponDelta_Poison;
        [DataMember(Name = "Damage_Weapon_Min#Poison")]
        public ItemValueRange damageWeaponMin_Poison;
        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Poison")]
        public ItemValueRange damageWeaponPercentBonus_Poison;

        [DataMember(Name = "Durability_Cur")]
        public ItemValueRange durabilityCur;
        [DataMember(Name = "Durability_Max")]
        public ItemValueRange durability_Max;

        [DataMember(Name = "Magic_Find")]
        public ItemValueRange magicFind;
        [DataMember(Name = "Gold_Find")]
        public ItemValueRange goldFind;

        [DataMember(Name = "Sockets")]
        public ItemValueRange sockets;

        #endregion
    }
}

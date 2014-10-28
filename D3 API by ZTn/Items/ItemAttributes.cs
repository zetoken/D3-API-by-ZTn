using System.Reflection;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class ItemAttributes : D3Object
    {
        #region >> Fields

        // Find how it's used ?
        [DataMember(Name = "Amplify_Damage_Type_Percent", EmitDefaultValue = false)]
        public ItemValueRange amplifyDamageTypePercent;

        [DataMember(Name = "Armor_Item", EmitDefaultValue = false)]
        public ItemValueRange armorItem;

        [DataMember(Name = "Armor_Bonus_Item", EmitDefaultValue = false)]
        public ItemValueRange armorBonusItem;

        // Find how it's used ?
        [DataMember(Name = "Attack", EmitDefaultValue = false)]
        public ItemValueRange attack;

        // Attack Per Second (weapon only)
        [DataMember(Name = "Attacks_Per_Second_Item", EmitDefaultValue = false)]
        public ItemValueRange attacksPerSecondItem;

        // Attack Speed bonus only for the item (weapon only)
        [DataMember(Name = "Attacks_Per_Second_Item_Percent", EmitDefaultValue = false)]
        public ItemValueRange attacksPerSecondItemPercent;

        // Attack Speed bonus
        [DataMember(Name = "Attacks_Per_Second_Percent", EmitDefaultValue = false)]
        public ItemValueRange attacksPerSecondPercent;

        // "Ring of Royal Grandeur" like (+1 to bonus set with a minimum of 2)
        [DataMember(Name = "Attribute_Set_Item_Discount", EmitDefaultValue = false)]
        public ItemValueRange AttributeSetItemDiscount;

        [DataMember(Name = "Block_Amount_Item_Delta", EmitDefaultValue = false)]
        public ItemValueRange blockAmountItemDelta;

        [DataMember(Name = "Block_Amount_Item_Min", EmitDefaultValue = false)]
        public ItemValueRange blockAmountItemMin;

        [DataMember(Name = "Block_Chance_Bonus_Item", EmitDefaultValue = false)]
        public ItemValueRange blockChanceBonusItem;

        [DataMember(Name = "Block_Chance_Item", EmitDefaultValue = false)]
        public ItemValueRange blockChanceItem;

        [DataMember(Name = "Bow", EmitDefaultValue = false)]
        public ItemValueRange bow;

        [DataMember(Name = "Crit_Damage_Percent", EmitDefaultValue = false)]
        public ItemValueRange critDamagePercent;

        [DataMember(Name = "Crit_Percent_Bonus_Capped", EmitDefaultValue = false)]
        public ItemValueRange critPercentBonusCapped;

        // Find how it's used ?
        [DataMember(Name = "Crit_Percent_Bonus_Uncapped", EmitDefaultValue = false)]
        public ItemValueRange critPercentBonusUncapped;

        [DataMember(Name = "Crossbow", EmitDefaultValue = false)]
        public ItemValueRange crossbow;

        [DataMember(Name = "CrowdControl_Reduction", EmitDefaultValue = false)]
        public ItemValueRange crowdControlReduction;

        #region >> Damage_Bonus_Min

        [DataMember(Name = "Damage_Bonus_Min#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageBonusMin_Arcane;

        [DataMember(Name = "Damage_Bonus_Min#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageBonusMin_Cold;

        [DataMember(Name = "Damage_Bonus_Min#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageBonusMin_Fire;

        [DataMember(Name = "Damage_Bonus_Min#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageBonusMin_Holy;

        [DataMember(Name = "Damage_Bonus_Min#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageBonusMin_Lightning;

        [DataMember(Name = "Damage_Bonus_Min#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageBonusMin_Physical;

        [DataMember(Name = "Damage_Bonus_Min#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageBonusMin_Poison;

        #endregion

        #region >> Damage_Dealt_Percent_Bonus

        [DataMember(Name = "Damage_Dealt_Percent_Bonus#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageDealtPercentBonusArcane;

        [DataMember(Name = "Damage_Dealt_Percent_Bonus#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageDealtPercentBonusCold;

        [DataMember(Name = "Damage_Dealt_Percent_Bonus#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageDealtPercentBonusFire;

        [DataMember(Name = "Damage_Dealt_Percent_Bonus#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageDealtPercentBonusHoly;

        [DataMember(Name = "Damage_Dealt_Percent_Bonus#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageDealtPercentBonusLightning;

        [DataMember(Name = "Damage_Dealt_Percent_Bonus#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageDealtPercentBonusPhysical;

        [DataMember(Name = "Damage_Dealt_Percent_Bonus#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageDealtPercentBonusPoison;

        #endregion

        #region >> Damage_Delta

        [DataMember(Name = "Damage_Delta#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageDelta_Arcane;

        [DataMember(Name = "Damage_Delta#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageDelta_Cold;

        [DataMember(Name = "Damage_Delta#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageDelta_Fire;

        [DataMember(Name = "Damage_Delta#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageDelta_Holy;

        [DataMember(Name = "Damage_Delta#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageDelta_Lightning;

        [DataMember(Name = "Damage_Delta#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageDelta_Physical;

        [DataMember(Name = "Damage_Delta#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageDelta_Poison;

        #endregion

        #region >> Damage_Min

        [DataMember(Name = "Damage_Min#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageMin_Arcane;

        [DataMember(Name = "Damage_Min#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageMin_Cold;

        [DataMember(Name = "Damage_Min#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageMin_Fire;

        [DataMember(Name = "Damage_Min#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageMin_Holy;

        [DataMember(Name = "Damage_Min#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageMin_Lightning;

        [DataMember(Name = "Damage_Min#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageMin_Physical;

        [DataMember(Name = "Damage_Min#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageMin_Poison;

        #endregion

        [DataMember(Name = "Damage_Percent_Bonus_Vs_Elites", EmitDefaultValue = false)]
        public ItemValueRange damagePercentBonusVsElites;

        [DataMember(Name = "Damage_Percent_Bonus_Vs_Monster_Type", EmitDefaultValue = false)]
        public ItemValueRange damagePercentBonusVsMonsterType;

        [DataMember(Name = "Damage_Percent_Reduction_From_Elites", EmitDefaultValue = false)]
        public ItemValueRange damagePercentReductionFromElites;

        [DataMember(Name = "Damage_Percent_Reduction_From_Melee", EmitDefaultValue = false)]
        public ItemValueRange damagePercentReductionFromMelee;

        [DataMember(Name = "Damage_Percent_Reduction_From_Ranged", EmitDefaultValue = false)]
        public ItemValueRange damagePercentReductionFromRanged;

        [DataMember(Name = "Damage_Percent_Reduction_From_Type", EmitDefaultValue = false)]
        public ItemValueRange damagePercentReductionFromType;

        [DataMember(Name = "Damage_Percent_Reduction_Turns_Into_Heal", EmitDefaultValue = false)]
        public ItemValueRange damagePercentReductionTurnsIntoHeal;

        #region >> Damage_Type_Percent_Bonus

        [DataMember(Name = "Damage_Type_Percent_Bonus#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageTypePercentBonus_Arcane;

        [DataMember(Name = "Damage_Type_Percent_Bonus#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageTypePercentBonus_Cold;

        [DataMember(Name = "Damage_Type_Percent_Bonus#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageTypePercentBonus_Fire;

        [DataMember(Name = "Damage_Type_Percent_Bonus#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageTypePercentBonus_Holy;

        [DataMember(Name = "Damage_Type_Percent_Bonus#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageTypePercentBonus_Lightning;

        [DataMember(Name = "Damage_Type_Percent_Bonus#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageTypePercentBonus_Physical;

        [DataMember(Name = "Damage_Type_Percent_Bonus#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageTypePercentBonus_Poison;

        #endregion

        #region >> Damage_Weapon_Bonus_Delta

        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDelta_Arcane;

        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDelta_Cold;

        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDelta_Fire;

        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDelta_Holy;

        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDelta_Lightning;

        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDelta_Physical;

        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDelta_Poison;

        #endregion

        #region >> Damage_Weapon_Bonus_Delta_X1

        [DataMember(Name = "Damage_Weapon_Bonus_Delta_X1#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDeltaX1_Arcane;

        [DataMember(Name = "Damage_Weapon_Bonus_Delta_X1#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDeltaX1_Cold;

        [DataMember(Name = "Damage_Weapon_Bonus_Delta_X1#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDeltaX1_Fire;

        [DataMember(Name = "Damage_Weapon_Bonus_Delta_X1#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDeltaX1_Holy;

        [DataMember(Name = "Damage_Weapon_Bonus_Delta_X1#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDeltaX1_Lightning;

        [DataMember(Name = "Damage_Weapon_Bonus_Delta_X1#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDeltaX1_Physical;

        [DataMember(Name = "Damage_Weapon_Bonus_Delta_X1#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusDeltaX1_Poison;

        #endregion

        #region >> Damage_Weapon_Bonus_Min

        [DataMember(Name = "Damage_Weapon_Bonus_Min#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMin_Arcane;

        [DataMember(Name = "Damage_Weapon_Bonus_Min#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMin_Cold;

        [DataMember(Name = "Damage_Weapon_Bonus_Min#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMin_Fire;

        [DataMember(Name = "Damage_Weapon_Bonus_Min#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMin_Holy;

        [DataMember(Name = "Damage_Weapon_Bonus_Min#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMin_Lightning;

        [DataMember(Name = "Damage_Weapon_Bonus_Min#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMin_Physical;

        [DataMember(Name = "Damage_Weapon_Bonus_Min#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMin_Poison;

        #endregion

        #region >> Damage_Weapon_Bonus_Min_X1

        [DataMember(Name = "Damage_Weapon_Bonus_Min_X1#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMinX1_Arcane;

        [DataMember(Name = "Damage_Weapon_Bonus_Min_X1#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMinX1_Cold;

        [DataMember(Name = "Damage_Weapon_Bonus_Min_X1#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMinX1_Fire;

        [DataMember(Name = "Damage_Weapon_Bonus_Min_X1#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMinX1_Holy;

        [DataMember(Name = "Damage_Weapon_Bonus_Min_X1#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMinX1_Lightning;

        [DataMember(Name = "Damage_Weapon_Bonus_Min_X1#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMinX1_Physical;

        [DataMember(Name = "Damage_Weapon_Bonus_Min_X1#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusMinX1_Poison;

        #endregion

        #region >> Damage_Weapon_Bonus_Flat

        [DataMember(Name = "Damage_Weapon_Bonus_Flat#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusFlat_Arcane;

        [DataMember(Name = "Damage_Weapon_Bonus_Flat#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusFlat_Cold;

        [DataMember(Name = "Damage_Weapon_Bonus_Flat#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusFlat_Fire;

        [DataMember(Name = "Damage_Weapon_Bonus_Flat#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusFlat_Holy;

        [DataMember(Name = "Damage_Weapon_Bonus_Flat#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusFlat_Lightning;

        [DataMember(Name = "Damage_Weapon_Bonus_Flat#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusFlat_Physical;

        [DataMember(Name = "Damage_Weapon_Bonus_Flat#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponBonusFlat_Poison;

        #endregion

        #region >> Damage_Weapon_Delta

        [DataMember(Name = "Damage_Weapon_Delta#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponDelta_Arcane;

        [DataMember(Name = "Damage_Weapon_Delta#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponDelta_Cold;

        [DataMember(Name = "Damage_Weapon_Delta#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponDelta_Fire;

        [DataMember(Name = "Damage_Weapon_Delta#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponDelta_Holy;

        [DataMember(Name = "Damage_Weapon_Delta#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponDelta_Lightning;

        [DataMember(Name = "Damage_Weapon_Delta#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponDelta_Physical;

        [DataMember(Name = "Damage_Weapon_Delta#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponDelta_Poison;

        #endregion

        #region >> Damage_Weapon_Min

        [DataMember(Name = "Damage_Weapon_Min#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponMin_Arcane;

        [DataMember(Name = "Damage_Weapon_Min#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponMin_Cold;

        [DataMember(Name = "Damage_Weapon_Min#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponMin_Fire;

        [DataMember(Name = "Damage_Weapon_Min#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponMin_Holy;

        [DataMember(Name = "Damage_Weapon_Min#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponMin_Lightning;

        [DataMember(Name = "Damage_Weapon_Min#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponMin_Physical;

        [DataMember(Name = "Damage_Weapon_Min#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponMin_Poison;

        #endregion

        #region >> Damage_Weapon_Percent_Bonus

        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Arcane", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponPercentBonus_Arcane;

        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Cold", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponPercentBonus_Cold;

        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Fire", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponPercentBonus_Fire;

        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Holy", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponPercentBonus_Holy;

        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Lightning", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponPercentBonus_Lightning;

        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Physical", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponPercentBonus_Physical;

        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Poison", EmitDefaultValue = false)]
        public ItemValueRange damageWeaponPercentBonus_Poison;

        #endregion

        // Find how it's used ?
        [DataMember(Name = "Defense", EmitDefaultValue = false)]
        public ItemValueRange defense;

        #region >> Dexterity

        // Blizzard workaround bug for some cases where Blizzard API uses Dexterity instead of Dexterity_Item attribute
        [DataMember(Name = "Dexterity", EmitDefaultValue = false),]
        private ItemValueRange Dexterity
        {
            set { dexterityItem = value; }
        }

        [DataMember(Name = "Dexterity_Item", EmitDefaultValue = false)]
        public ItemValueRange dexterityItem;

        #endregion

        //"DyeType"

        #region >> Experience_Bonus

        [DataMember(Name = "Experience_Bonus", EmitDefaultValue = false)]
        public ItemValueRange experienceBonus;

        [DataMember(Name = "Experience_Bonus_Percent", EmitDefaultValue = false)]
        public ItemValueRange experienceBonusPercent;

        #endregion

        //"GemQuality"

        #region >> Gold

        [DataMember(Name = "Gold_Find", EmitDefaultValue = false)]
        public ItemValueRange goldFind;

        [DataMember(Name = "Gold_PickUp_Radius", EmitDefaultValue = false)]
        public ItemValueRange goldPickUpRadius;

        #endregion

        #region >> Health_Globe

        [DataMember(Name = "Health_Globe_Bonus_Chance", EmitDefaultValue = false)]
        public ItemValueRange healthGlobeBonusChance;

        [DataMember(Name = "Health_Globe_Bonus_Health", EmitDefaultValue = false)]
        public ItemValueRange healthGlobeBonusHealth;

        #endregion

        #region >> Hitpoints

        [DataMember(Name = "Hitpoints_Granted", EmitDefaultValue = false)]
        public ItemValueRange hitpointsGranted;

        [DataMember(Name = "Hitpoints_Granted_Duration", EmitDefaultValue = false)]
        public ItemValueRange hitpointsGrantedDuration;

        [DataMember(Name = "Hitpoints_Max_Percent_Bonus_Item", EmitDefaultValue = false)]
        public ItemValueRange hitpointsMaxPercentBonusItem;

        [DataMember(Name = "Hitpoints_On_Hit", EmitDefaultValue = false)]
        public ItemValueRange hitpointsOnHit;

        [DataMember(Name = "Hitpoints_On_Kill", EmitDefaultValue = false)]
        public ItemValueRange hitpointsOnKill;

        [DataMember(Name = "Hitpoints_Percent", EmitDefaultValue = false)]
        public ItemValueRange hitpointsPercent;

        [DataMember(Name = "Hitpoints_Regen_Per_Second", EmitDefaultValue = false)]
        public ItemValueRange hitpointsRegenPerSecond;

        #endregion

        #region >> Intelligence

        // Blizzard workaround bug for some cases where Blizzard API uses Intelligence instead of Intelligence_Item attribute
        [DataMember(Name = "Intelligence", EmitDefaultValue = false),]
        private ItemValueRange Intelligence
        {
            set { intelligenceItem = value; }
        }

        [DataMember(Name = "Intelligence_Item", EmitDefaultValue = false)]
        public ItemValueRange intelligenceItem;

        #endregion

        [DataMember(Name = "Item_Indestructible", EmitDefaultValue = false)]
        public ItemValueRange itemIndestructible;

        [DataMember(Name = "Item_Level_Requirement_Reduction", EmitDefaultValue = false)]
        public ItemValueRange itemLevelRequirementReduction;

        //"Item_Power_Passive"

        [DataMember(Name = "Magic_Find", EmitDefaultValue = false)]
        public ItemValueRange magicFind;

        [DataMember(Name = "Movement_Scalar", EmitDefaultValue = false)]
        public ItemValueRange movementScalar;

        //"On_Hit_Blind_Proc_Chance"
        //"On_Hit_Chill_Proc_Chance"
        //"On_Hit_Fear_Proc_Chance"
        //"On_Hit_Freeze_Proc_Chance"
        //"On_Hit_Immobilize_Proc_Chance"
        //"On_Hit_Knockback_Proc_Chance"
        //"On_Hit_Slow_Proc_Chance"
        //"On_Hit_Stun_Proc_Chance"
        //"Power_Cooldown_Reduction"

        [DataMember(Name = "Power_Cooldown_Reduction_Percent_All", EmitDefaultValue = false)]
        public ItemValueRange powerCooldownReductionPercentAll;

        //"Power_Crit_Percent_Bonus"
        //"Power_Damage_Percent_Bonus"
        //"Power_Duration_Increase"

        [DataMember(Name = "Power_Resource_Reduction#Monk_SweepingWind", EmitDefaultValue = false)]
        public ItemValueRange PowerResourceReductionMonkSweepingWind;

        //"Power_Resource_Reduction"
        //"Precision"

        [DataMember(Name = "Quiver", EmitDefaultValue = false)]
        public ItemValueRange quiver;

        //Requirement_When_Equipped"

        [DataMember(Name = "Resistance_All", EmitDefaultValue = false)]
        public ItemValueRange resistance_All;

        #region >> Resistance

        [DataMember(Name = "Resistance#Arcane", EmitDefaultValue = false)]
        public ItemValueRange resistance_Arcane;

        [DataMember(Name = "Resistance#Cold", EmitDefaultValue = false)]
        public ItemValueRange resistance_Cold;

        [DataMember(Name = "Resistance#Fire", EmitDefaultValue = false)]
        public ItemValueRange resistance_Fire;

        [DataMember(Name = "Resistance#Lightning", EmitDefaultValue = false)]
        public ItemValueRange resistance_Lightning;

        [DataMember(Name = "Resistance#Physical", EmitDefaultValue = false)]
        public ItemValueRange resistance_Physical;

        [DataMember(Name = "Resistance#Poison", EmitDefaultValue = false)]
        public ItemValueRange resistance_Poison;

        #endregion

        //"Resistance_Freeze"
        //"Resistance_Root"
        //"Resistance_Stun"
        //"Resistance_StunRootFreeze"
        //"Resource_Max_Bonus"
        //"Resource_On_Crit"
        //"Resource_On_Hit"
        //"Resource_On_Kill#Mana"

        #region >> "Resource_Regen_Per_Second

        [DataMember(Name = "Resource_Regen_Per_Second#Mana", EmitDefaultValue = false)]
        public ItemValueRange Resource_Regen_Per_Second_Mana;

        [DataMember(Name = "Resource_Regen_Per_Second#Spirit", EmitDefaultValue = false)]
        public ItemValueRange Resource_Regen_Per_Second_Spirit;

        #endregion

        [DataMember(Name = "Season")]
        public ItemValueRange Season;

        //"Resource_Set_Point_Bonus"
        //"ScrollDuration"

        [DataMember(Name = "Sockets", EmitDefaultValue = false)]
        public ItemValueRange sockets;

        //"Spending_Resource_Heals_Percent#Spirit"
        //"Stats_All_Bonus"

        [DataMember(Name = "Steal_Health_Percent", EmitDefaultValue = false)]
        public ItemValueRange stealHealthPercent;

        #region >> Strength

        // Blizzard workaround bug for some cases where Blizzard API uses Strength instead of Strength_Item attribute
        [DataMember(Name = "Strength", EmitDefaultValue = false),]
        private ItemValueRange Strength
        {
            set { strengthItem = value; }
        }

        [DataMember(Name = "Strength_Item", EmitDefaultValue = false)]
        public ItemValueRange strengthItem;

        #endregion

        #region >> Thorns_Fixed

        [DataMember(Name = "Thorns_Fixed#Arcane", EmitDefaultValue = false)]
        public ItemValueRange thornsFixed_Arcane;

        [DataMember(Name = "Thorns_Fixed#Cold", EmitDefaultValue = false)]
        public ItemValueRange thornsFixed_Cold;

        [DataMember(Name = "Thorns_Fixed#Fire", EmitDefaultValue = false)]
        public ItemValueRange thornsFixed_Fire;

        [DataMember(Name = "Thorns_Fixed#Holy", EmitDefaultValue = false)]
        public ItemValueRange thornsFixed_Holy;

        [DataMember(Name = "Thorns_Fixed#Lightning", EmitDefaultValue = false)]
        public ItemValueRange thornsFixed_Lightning;

        [DataMember(Name = "Thorns_Fixed#Physical", EmitDefaultValue = false)]
        public ItemValueRange thornsFixed_Physical;

        [DataMember(Name = "Thorns_Fixed#Poison", EmitDefaultValue = false)]
        public ItemValueRange thornsFixed_Poison;

        #endregion

        #region >> Vitality

        // Blizzard workaround bug for some cases where Blizzard API uses Vitality instead of Vitality_Item attribute
        [DataMember(Name = "Vitality", EmitDefaultValue = false)]
        private ItemValueRange Vitality
        {
            set { vitalityItem = value; }
        }

        [DataMember(Name = "Vitality_Item", EmitDefaultValue = false)]
        public ItemValueRange vitalityItem;

        #endregion

        //"Weapon_On_Hit_Bleed_Proc_Chance"
        //"Weapon_On_Hit_Bleed_Proc_Damage_Base"
        //"Weapon_On_Hit_Bleed_Proc_Damage_Delta"
        //"Weapon_On_Hit_Blind_Proc_Chance"
        //"Weapon_On_Hit_Chill_Proc_Chance"
        //"Weapon_On_Hit_Fear_Proc_Chance"
        //"Weapon_On_Hit_Freeze_Proc_Chance"
        //"Weapon_On_Hit_Immobilize_Proc_Chance"
        //"Weapon_On_Hit_Knockback_Proc_Chance"
        //"Weapon_On_Hit_Slow_Proc_Chance"
        //"Weapon_On_Hit_Stun_Proc_Chance"

        #endregion

        #region >> Constructors

        public ItemAttributes()
        {
        }

        /// <summary>
        /// Creates a new instance by copying fields of <paramref name="itemAttributes"/> (deep copy).
        /// Note: Only fields of type <see cref="ItemValueRange"/> are copied.
        /// </summary>
        /// <param name="itemAttributes"></param>
        public ItemAttributes(ItemAttributes itemAttributes)
        {
            if (itemAttributes == null)
            {
                return;
            }

            var type = GetType();

            foreach (var fieldInfo in type.GetTypeInfo().DeclaredFields)
            {
                var valueRange = fieldInfo.GetValue(itemAttributes) as ItemValueRange;
                if (valueRange != null)
                {
                    fieldInfo.SetValue(this, new ItemValueRange(valueRange));
                }
            }
        }

        #endregion

        #region >> Operators

        public static ItemAttributes operator +(ItemAttributes left, ItemAttributes right)
        {
            if (left == null)
            {
                return new ItemAttributes(right);
            }

            var target = new ItemAttributes(left);

            SumIntoLeftOperand(target, right);

            return target;
        }

        public static ItemAttributes operator -(ItemAttributes left, ItemAttributes right)
        {
            var target = new ItemAttributes(left);

            var type = target.GetType();

            foreach (var fieldInfo in type.GetTypeInfo().DeclaredFields)
            {
                if (fieldInfo.Name != "UnmanagedAttributes" && fieldInfo.GetValue(right) != null)
                {
                    var targetValueRange = (ItemValueRange)fieldInfo.GetValue(target);
                    var rightValueRange = (ItemValueRange)fieldInfo.GetValue(right);
                    if (targetValueRange == null)
                    {
                        targetValueRange = new ItemValueRange();
                    }
                    targetValueRange -= rightValueRange;
                    if (targetValueRange.Min == 0 && targetValueRange.Max == 0)
                    {
                        targetValueRange = null;
                    }
                    fieldInfo.SetValue(target, targetValueRange - rightValueRange);
                }
            }

            return target;
        }

        public static ItemAttributes operator *(ItemAttributes left, ItemAttributes right)
        {
            var target = new ItemAttributes(left);

            var type = target.GetType();

            foreach (var fieldInfo in type.GetTypeInfo().DeclaredFields)
            {
                if (fieldInfo.Name != "UnmanagedAttributes" && fieldInfo.GetValue(right) != null)
                {
                    var targetValueRange = (ItemValueRange)fieldInfo.GetValue(target);
                    var rightValueRange = (ItemValueRange)fieldInfo.GetValue(right);
                    if (targetValueRange == null)
                    {
                        targetValueRange = new ItemValueRange(1);
                    }
                    fieldInfo.SetValue(target, targetValueRange * rightValueRange);
                }
            }

            return target;
        }

        #endregion

        /// <summary>
        /// Sums up <paramref name="right"/> operand into <paramref name="left"/> operand.
        /// <paramref name="left"/> is updated by this method (used as a memory and speed optimization of <c>left = left + right</c>).
        /// </summary>
        /// <param name="left">Left operand of the addition, can't be <c>null</c>.</param>
        /// <param name="right">Right operand of the addition, can be <c>null</c>.</param>
        public static void SumIntoLeftOperand(ItemAttributes left, ItemAttributes right)
        {
            if (right == null)
            {
                return;
            }

            var typeInfo = left.GetType().GetTypeInfo();
            var targetType = typeof(ItemValueRange);

            // TODO: find a better way to handle this particular case...
            var powerCooldownReductionPercentAll = left.powerCooldownReductionPercentAll;

            foreach (var fieldInfo in typeInfo.DeclaredFields)
            {
                if (fieldInfo.FieldType == targetType)
                {
                    var rightValue = fieldInfo.GetValue(right);
                    if (rightValue != null)
                    {
                        var leftValueRange = (ItemValueRange)fieldInfo.GetValue(left);
                        var rightValueRange = (ItemValueRange)rightValue;
                        if (leftValueRange == null)
                        {
                            fieldInfo.SetValue(left, new ItemValueRange(rightValueRange));
                        }
                        else
                        {
                            fieldInfo.SetValue(left, leftValueRange + rightValueRange);
                        }
                    }
                }
            }

            // TODO: find a better way to handle this particular case...
            if (powerCooldownReductionPercentAll != null)
            {
                left.powerCooldownReductionPercentAll = powerCooldownReductionPercentAll;
                ItemValueRange.SumAsPercentOnRemainingIntoLeftOperand(left.powerCooldownReductionPercentAll, right.powerCooldownReductionPercentAll);
            }
        }
    }
}
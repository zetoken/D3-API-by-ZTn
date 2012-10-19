using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class ItemAttributes
    {
        #region >> Fields

        // Find how it's used ?
        [DataMember(Name = "Amplify_Damage_Type_Percent")]
        public ItemValueRange amplifyDamageTypePercent;

        [DataMember(Name = "Armor_Item")]
        public ItemValueRange armorItem;
        [DataMember(Name = "Armor_Bonus_Item")]
        public ItemValueRange armorBonusItem;

        // Find how it's used ?
        [DataMember(Name = "Attack")]
        public ItemValueRange attack;

        // Attack Per Second (weapon only)
        [DataMember(Name = "Attacks_Per_Second_Item")]
        public ItemValueRange attacksPerSecondItem;

        // Attack Speed bonus only for the item (weapon only)
        [DataMember(Name = "Attacks_Per_Second_Item_Percent")]
        public ItemValueRange attacksPerSecondItemPercent;

        // Attack Speed bonus
        [DataMember(Name = "Attacks_Per_Second_Percent")]
        public ItemValueRange attacksPerSecondPercent;

        [DataMember(Name = "Block_Amount_Item_Delta")]
        public ItemValueRange blockAmountItemDelta;
        [DataMember(Name = "Block_Amount_Item_Min")]
        public ItemValueRange blockAmountItemMin;
        [DataMember(Name = "Block_Chance_Bonus_Item")]
        public ItemValueRange blockChanceBonusItem;
        [DataMember(Name = "Block_Chance_Item")]
        public ItemValueRange blockChanceItem;

        [DataMember(Name = "Bow")]
        public ItemValueRange bow;

        [DataMember(Name = "Crit_Damage_Percent")]
        public ItemValueRange critDamagePercent;
        [DataMember(Name = "Crit_Percent_Bonus_Capped")]
        public ItemValueRange critPercentBonusCapped;
        // Find how it's used ?
        [DataMember(Name = "Crit_Percent_Bonus_Uncapped")]
        public ItemValueRange critPercentBonusUncapped;

        [DataMember(Name = "Crossbow")]
        public ItemValueRange crossbow;

        [DataMember(Name = "CrowdControl_Reduction")]
        public ItemValueRange crowdControlReduction;

        #region >> Damage_Bonus_Min

        [DataMember(Name = "Damage_Bonus_Min#Arcane")]
        public ItemValueRange damageBonusMin_Arcane;
        [DataMember(Name = "Damage_Bonus_Min#Cold")]
        public ItemValueRange damageBonusMin_Cold;
        [DataMember(Name = "Damage_Bonus_Min#Fire")]
        public ItemValueRange damageBonusMin_Fire;
        [DataMember(Name = "Damage_Bonus_Min#Holy")]
        public ItemValueRange damageBonusMin_Holy;
        [DataMember(Name = "Damage_Bonus_Min#Lightning")]
        public ItemValueRange damageBonusMin_Lightning;
        [DataMember(Name = "Damage_Bonus_Min#Physical")]
        public ItemValueRange damageBonusMin_Physical;
        [DataMember(Name = "Damage_Bonus_Min#Poison")]
        public ItemValueRange damageBonusMin_Poison;

        #endregion

        // Find how it's used ?
        [DataMember(Name = "Damage_Dealt_Percent_Bonus")]
        public ItemValueRange damageDealtPercentBonus;

        #region >> Damage_Delta

        [DataMember(Name = "Damage_Delta#Arcane")]
        public ItemValueRange damageDelta_Arcane;
        [DataMember(Name = "Damage_Delta#Cold")]
        public ItemValueRange damageDelta_Cold;
        [DataMember(Name = "Damage_Delta#Fire")]
        public ItemValueRange damageDelta_Fire;
        [DataMember(Name = "Damage_Delta#Holy")]
        public ItemValueRange damageDelta_Holy;
        [DataMember(Name = "Damage_Delta#Lightning")]
        public ItemValueRange damageDelta_Lightning;
        [DataMember(Name = "Damage_Delta#Physical")]
        public ItemValueRange damageDelta_Physical;
        [DataMember(Name = "Damage_Delta#Poison")]
        public ItemValueRange damageDelta_Poison;

        #endregion

        #region >> Damage_Min

        [DataMember(Name = "Damage_Min#Arcane")]
        public ItemValueRange damageMin_Arcane;
        [DataMember(Name = "Damage_Min#Cold")]
        public ItemValueRange damageMin_Cold;
        [DataMember(Name = "Damage_Min#Fire")]
        public ItemValueRange damageMin_Fire;
        [DataMember(Name = "Damage_Min#Holy")]
        public ItemValueRange damageMin_Holy;
        [DataMember(Name = "Damage_Min#Lightning")]
        public ItemValueRange damageMin_Lightning;
        [DataMember(Name = "Damage_Min#Physical")]
        public ItemValueRange damageMin_Physical;
        [DataMember(Name = "Damage_Min#Poison")]
        public ItemValueRange damageMin_Poison;

        #endregion

        // Find how it's used ?
        [DataMember(Name = "Damage_Percent_Bonus_Vs_Elites")]
        public ItemValueRange damagePercentBonusVsElites;
        [DataMember(Name = "Damage_Percent_Bonus_Vs_Monster_Type")]
        public ItemValueRange damagePercentBonusVsMonsterType;
        [DataMember(Name = "Damage_Percent_Reduction_From_Elites")]
        public ItemValueRange damagePercentReductionFromElites;
        [DataMember(Name = "Damage_Percent_Reduction_From_Melee")]
        public ItemValueRange damagePercentReductionFromMelee;
        [DataMember(Name = "Damage_Percent_Reduction_From_Ranged")]
        public ItemValueRange damagePercentReductionFromRanged;
        [DataMember(Name = "Damage_Percent_Reduction_From_Type")]
        public ItemValueRange damagePercentReductionFromType;
        [DataMember(Name = "Damage_Percent_Reduction_Turns_Into_Heal")]
        public ItemValueRange damagePercentReductionTurnsIntoHeal;

        #region >> Damage_Type_Percent_Bonus

        [DataMember(Name = "Damage_Type_Percent_Bonus#Arcane")]
        public ItemValueRange damageTypePercentBonus_Arcane;
        [DataMember(Name = "Damage_Type_Percent_Bonus#Cold")]
        public ItemValueRange damageTypePercentBonus_Cold;
        [DataMember(Name = "Damage_Type_Percent_Bonus#Fire")]
        public ItemValueRange damageTypePercentBonus_Fire;
        [DataMember(Name = "Damage_Type_Percent_Bonus#Holy")]
        public ItemValueRange damageTypePercentBonus_Holy;
        [DataMember(Name = "Damage_Type_Percent_Bonus#Lightning")]
        public ItemValueRange damageTypePercentBonus_Lightning;
        [DataMember(Name = "Damage_Type_Percent_Bonus#Physical")]
        public ItemValueRange damageTypePercentBonus_Physical;
        [DataMember(Name = "Damage_Type_Percent_Bonus#Poison")]
        public ItemValueRange damageTypePercentBonus_Poison;

        #endregion

        #region >> Damage_Weapon_Bonus_Delta

        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Arcane")]
        public ItemValueRange damageWeaponBonusDelta_Arcane;
        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Cold")]
        public ItemValueRange damageWeaponBonusDelta_Cold;
        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Fire")]
        public ItemValueRange damageWeaponBonusDelta_Fire;
        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Holy")]
        public ItemValueRange damageWeaponBonusDelta_Holy;
        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Lightning")]
        public ItemValueRange damageWeaponBonusDelta_Lightning;
        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Physical")]
        public ItemValueRange damageWeaponBonusDelta_Physical;
        [DataMember(Name = "Damage_Weapon_Bonus_Delta#Poison")]
        public ItemValueRange damageWeaponBonusDelta_Poison;

        #endregion

        #region >> Damage_Weapon_Bonus_Min

        [DataMember(Name = "Damage_Weapon_Bonus_Min#Arcane")]
        public ItemValueRange damageWeaponBonusMin_Arcane;
        [DataMember(Name = "Damage_Weapon_Bonus_Min#Cold")]
        public ItemValueRange damageWeaponBonusMin_Cold;
        [DataMember(Name = "Damage_Weapon_Bonus_Min#Fire")]
        public ItemValueRange damageWeaponBonusMin_Fire;
        [DataMember(Name = "Damage_Weapon_Bonus_Min#Holy")]
        public ItemValueRange damageWeaponBonusMin_Holy;
        [DataMember(Name = "Damage_Weapon_Bonus_Min#Lightning")]
        public ItemValueRange damageWeaponBonusMin_Lightning;
        [DataMember(Name = "Damage_Weapon_Bonus_Min#Physical")]
        public ItemValueRange damageWeaponBonusMin_Physical;
        [DataMember(Name = "Damage_Weapon_Bonus_Min#Poison")]
        public ItemValueRange damageWeaponBonusMin_Poison;

        #endregion

        #region >> Damage_Weapon_Delta

        [DataMember(Name = "Damage_Weapon_Delta#Arcane")]
        public ItemValueRange damageWeaponDelta_Arcane;
        [DataMember(Name = "Damage_Weapon_Delta#Cold")]
        public ItemValueRange damageWeaponDelta_Cold;
        [DataMember(Name = "Damage_Weapon_Delta#Fire")]
        public ItemValueRange damageWeaponDelta_Fire;
        [DataMember(Name = "Damage_Weapon_Delta#Holy")]
        public ItemValueRange damageWeaponDelta_Holy;
        [DataMember(Name = "Damage_Weapon_Delta#Lightning")]
        public ItemValueRange damageWeaponDelta_Lightning;
        [DataMember(Name = "Damage_Weapon_Delta#Physical")]
        public ItemValueRange damageWeaponDelta_Physical;
        [DataMember(Name = "Damage_Weapon_Delta#Poison")]
        public ItemValueRange damageWeaponDelta_Poison;

        #endregion

        #region >> Damage_Weapon_Min

        [DataMember(Name = "Damage_Weapon_Min#Arcane")]
        public ItemValueRange damageWeaponMin_Arcane;
        [DataMember(Name = "Damage_Weapon_Min#Cold")]
        public ItemValueRange damageWeaponMin_Cold;
        [DataMember(Name = "Damage_Weapon_Min#Fire")]
        public ItemValueRange damageWeaponMin_Fire;
        [DataMember(Name = "Damage_Weapon_Min#Holy")]
        public ItemValueRange damageWeaponMin_Holy;
        [DataMember(Name = "Damage_Weapon_Min#Lightning")]
        public ItemValueRange damageWeaponMin_Lightning;
        [DataMember(Name = "Damage_Weapon_Min#Physical")]
        public ItemValueRange damageWeaponMin_Physical;
        [DataMember(Name = "Damage_Weapon_Min#Poison")]
        public ItemValueRange damageWeaponMin_Poison;

        #endregion

        #region >> Damage_Weapon_Percent_Bonus

        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Arcane")]
        public ItemValueRange damageWeaponPercentBonus_Arcane;
        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Cold")]
        public ItemValueRange damageWeaponPercentBonus_Cold;
        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Fire")]
        public ItemValueRange damageWeaponPercentBonus_Fire;
        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Holy")]
        public ItemValueRange damageWeaponPercentBonus_Holy;
        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Lightning")]
        public ItemValueRange damageWeaponPercentBonus_Lightning;
        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Physical")]
        public ItemValueRange damageWeaponPercentBonus_Physical;
        [DataMember(Name = "Damage_Weapon_Percent_Bonus#Poison")]
        public ItemValueRange damageWeaponPercentBonus_Poison;

        #endregion

        // Find how it's used ?
        [DataMember(Name = "Defense")]
        public ItemValueRange defense;

        [DataMember(Name = "Dexterity_Item")]
        public ItemValueRange dexterityItem;

        [DataMember(Name = "Durability_Cur")]
        public ItemValueRange durabilityCur;
        [DataMember(Name = "Durability_Max")]
        public ItemValueRange durability_Max;

        //"DyeType"

        [DataMember(Name = "Experience_Bonus")]
        public ItemValueRange experienceBonus;
        [DataMember(Name = "Experience_Bonus_Percent")]
        public ItemValueRange experienceBonusPercent;

        //"GemQuality"

        [DataMember(Name = "Gold_Find")]
        public ItemValueRange goldFind;
        [DataMember(Name = "Gold_PickUp_Radius")]
        public ItemValueRange goldPickUpRadius;

        [DataMember(Name = "Health_Globe_Bonus_Chance")]
        public ItemValueRange healthGlobeBonusChance;
        [DataMember(Name = "Health_Globe_Bonus_Health")]
        public ItemValueRange healthGlobeBonusHealth;

        [DataMember(Name = "Hitpoints_Granted")]
        public ItemValueRange hitpointsGranted;
        [DataMember(Name = "Hitpoints_Granted_Duration")]
        public ItemValueRange hitpointsGrantedDuration;

        [DataMember(Name = "Hitpoints_Max_Percent_Bonus_Item")]
        public ItemValueRange hitpointsMaxPercentBonusItem;

        [DataMember(Name = "Hitpoints_On_Hit")]
        public ItemValueRange hitpointsOnHit;
        [DataMember(Name = "Hitpoints_On_Kill")]
        public ItemValueRange hitpointsOnKill;

        [DataMember(Name = "Hitpoints_Percent")]
        public ItemValueRange hitpointsPercent;

        [DataMember(Name = "Hitpoints_Regen_Per_Second")]
        public ItemValueRange hitpointsRegenPerSecond;


        //"Intelligence"

        [DataMember(Name = "Intelligence_Item")]
        public ItemValueRange intelligenceItem;

        [DataMember(Name = "Item_Indestructible")]
        public ItemValueRange itemIndestructible;

        [DataMember(Name = "Item_Level_Requirement_Reduction")]
        public ItemValueRange itemLevelRequirementReduction;

        // Find how it's used
        [DataMember(Name = "Item_Power_Passive")]
        public ItemValueRange itemPowerPassive;

        [DataMember(Name = "Magic_Find")]
        public ItemValueRange magicFind;

        [DataMember(Name = "Movement_Scalar")]
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
        //"Power_Crit_Percent_Bonus"
        //"Power_Damage_Percent_Bonus"
        //"Power_Duration_Increase"
        //"Power_Resource_Reduction"
        //"Precision"

        [DataMember(Name = "Quiver")]
        public ItemValueRange quiver;

        [DataMember(Name = "Requirement_When_Equipped")]
        public ItemValueRange requirementWhenEquipped;

        [DataMember(Name = "Resistance_All")]
        public ItemValueRange resistance_All;

        #region >> Resistance

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

        #endregion

        //"Resistance_Freeze"
        //"Resistance_Root"
        //"Resistance_Stun"
        //"Resistance_StunRootFreeze"
        //"Resource_Max_Bonus"
        //"Resource_On_Crit"
        //"Resource_On_Hit"
        //"Resource_On_Kill"
        //"Resource_Regen_Per_Second"
        //"Resource_Set_Point_Bonus"
        //"ScrollDuration"

        [DataMember(Name = "Sockets")]
        public ItemValueRange sockets;


        //"Spending_Resource_Heals_Percent"
        //"Stats_All_Bonus"

        [DataMember(Name = "Steal_Health_Percent")]
        public ItemValueRange stealHealthPercent;

        [DataMember(Name = "Strength_Item")]
        public ItemValueRange strengthItem;

        #region >> Thorns_Fixed

        [DataMember(Name = "Thorns_Fixed#Arcane")]
        public ItemValueRange thornsFixed_Arcane;
        [DataMember(Name = "Thorns_Fixed#Cold")]
        public ItemValueRange thornsFixed_Cold;
        [DataMember(Name = "Thorns_Fixed#Fire")]
        public ItemValueRange thornsFixed_Fire;
        [DataMember(Name = "Thorns_Fixed#Holy")]
        public ItemValueRange thornsFixed_Holy;
        [DataMember(Name = "Thorns_Fixed#Lightning")]
        public ItemValueRange thornsFixed_Lightning;
        [DataMember(Name = "Thorns_Fixed#Physical")]
        public ItemValueRange thornsFixed_Physical;
        [DataMember(Name = "Thorns_Fixed#Poison")]
        public ItemValueRange thornsFixed_Poison;

        #endregion

        //"Vitality"

        [DataMember(Name = "Vitality_Item")]
        public ItemValueRange vitalityItem;

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
        /// Copy constructor.
        /// Ensures all fields are properly copied by value.
        /// </summary>
        /// <param name="itemAttributes"></param>
        public ItemAttributes(ItemAttributes itemAttributes)
        {
            Type type = this.GetType();

            foreach (FieldInfo fieldInfo in type.GetFields())
            {
                if (fieldInfo.GetValue(itemAttributes) != null)
                {
                    ItemValueRange rightValueRange = (ItemValueRange)fieldInfo.GetValue(itemAttributes);
                    ItemValueRange valueRange = new ItemValueRange();
                    valueRange.min += rightValueRange.min;
                    valueRange.max += rightValueRange.max;
                    fieldInfo.SetValue(this, valueRange);
                }
            }
        }

        #endregion

        #region >> Operators

        public static ItemAttributes operator +(ItemAttributes left, ItemAttributes right)
        {
            ItemAttributes target = new ItemAttributes(left);

            Type type = target.GetType();

            foreach (FieldInfo fieldInfo in type.GetFields())
            {
                if (fieldInfo.GetValue(right) != null)
                {
                    ItemValueRange targetValueRange = (ItemValueRange)fieldInfo.GetValue(target);
                    ItemValueRange rightValueRange = (ItemValueRange)fieldInfo.GetValue(right);
                    if (targetValueRange == null)
                        targetValueRange = new ItemValueRange();
                    fieldInfo.SetValue(target, targetValueRange + rightValueRange);
                }
            }

            return target;
        }

        public static ItemAttributes operator -(ItemAttributes left, ItemAttributes right)
        {
            ItemAttributes target = new ItemAttributes(left);

            Type type = target.GetType();

            foreach (FieldInfo fieldInfo in type.GetFields())
            {
                if (fieldInfo.GetValue(right) != null)
                {
                    ItemValueRange targetValueRange = (ItemValueRange)fieldInfo.GetValue(target);
                    ItemValueRange rightValueRange = (ItemValueRange)fieldInfo.GetValue(right);
                    if (targetValueRange == null)
                        targetValueRange = new ItemValueRange();
                    targetValueRange -= rightValueRange;
                    if ((targetValueRange.min) == 0 && (targetValueRange.max == 0))
                        targetValueRange = null;
                    fieldInfo.SetValue(target, targetValueRange - rightValueRange);
                }
            }

            return target;
        }

        public static ItemAttributes operator *(ItemAttributes left, ItemAttributes right)
        {
            ItemAttributes target = new ItemAttributes(left);

            Type type = target.GetType();

            foreach (FieldInfo fieldInfo in type.GetFields())
            {
                if (fieldInfo.GetValue(right) != null)
                {
                    ItemValueRange targetValueRange = (ItemValueRange)fieldInfo.GetValue(target);
                    ItemValueRange rightValueRange = (ItemValueRange)fieldInfo.GetValue(right);
                    if (targetValueRange == null)
                        targetValueRange = new ItemValueRange(1);
                    fieldInfo.SetValue(target, targetValueRange * rightValueRange);
                }
            }

            return target;
        }

        #endregion
    }
}

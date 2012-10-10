using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    public class GemHelper
    {
        public static List<Item> dexterity = new List<Item>()
        {
            new Item(new ItemAttributes() { dexterityItem = new ItemValueRange(6) }) { name = "+6 Dexterity" },
            new Item(new ItemAttributes() { dexterityItem = new ItemValueRange(10) }) { name = "+10 Dexterity" },
            new Item(new ItemAttributes() { dexterityItem = new ItemValueRange(14) }) { name = "+14 Dexterity" },
            new Item(new ItemAttributes() { dexterityItem = new ItemValueRange(18) }) { name = "+18 Dexterity" },
            new Item(new ItemAttributes() { dexterityItem = new ItemValueRange(22) }) { name = "+22 Dexterity" },
            new Item(new ItemAttributes() { dexterityItem = new ItemValueRange(26) }) { name = "+26 Dexterity" },
            new Item(new ItemAttributes() { dexterityItem = new ItemValueRange(30) }) { name = "+30 Dexterity" },
            new Item(new ItemAttributes() { dexterityItem = new ItemValueRange(34) }) { name = "+34 Dexterity" },
            new Item(new ItemAttributes() { dexterityItem = new ItemValueRange(38) }) { name = "+38 Dexterity" },
            new Item(new ItemAttributes() { dexterityItem = new ItemValueRange(42) }) { name = "+42 Dexterity" },
            new Item(new ItemAttributes() { dexterityItem = new ItemValueRange(46) }) { name = "+46 Dexterity" },
            new Item(new ItemAttributes() { dexterityItem = new ItemValueRange(50) }) { name = "+50 Dexterity" },
            new Item(new ItemAttributes() { dexterityItem = new ItemValueRange(54) }) { name = "+54 Dexterity" },
            new Item(new ItemAttributes() { dexterityItem = new ItemValueRange(58) }) { name = "+58 Dexterity" }
        };

        public static List<Item> intelligence = new List<Item>()
        {
            new Item(new ItemAttributes() { intelligenceItem = new ItemValueRange(6) }) { name = "+6 Intelligence" },
            new Item(new ItemAttributes() { intelligenceItem = new ItemValueRange(10) }) { name = "+10 Intelligence" },
            new Item(new ItemAttributes() { intelligenceItem = new ItemValueRange(14) }) { name = "+14 Intelligence" },
            new Item(new ItemAttributes() { intelligenceItem = new ItemValueRange(18) }) { name = "+18 Intelligence" },
            new Item(new ItemAttributes() { intelligenceItem = new ItemValueRange(22) }) { name = "+22 Intelligence" },
            new Item(new ItemAttributes() { intelligenceItem = new ItemValueRange(26) }) { name = "+26 Intelligence" },
            new Item(new ItemAttributes() { intelligenceItem = new ItemValueRange(30) }) { name = "+30 Intelligence" },
            new Item(new ItemAttributes() { intelligenceItem = new ItemValueRange(34) }) { name = "+34 Intelligence" },
            new Item(new ItemAttributes() { intelligenceItem = new ItemValueRange(38) }) { name = "+38 Intelligence" },
            new Item(new ItemAttributes() { intelligenceItem = new ItemValueRange(42) }) { name = "+42 Intelligence" },
            new Item(new ItemAttributes() { intelligenceItem = new ItemValueRange(46) }) { name = "+46 Intelligence" },
            new Item(new ItemAttributes() { intelligenceItem = new ItemValueRange(50) }) { name = "+50 Intelligence" },
            new Item(new ItemAttributes() { intelligenceItem = new ItemValueRange(54) }) { name = "+54 Intelligence" },
            new Item(new ItemAttributes() { intelligenceItem = new ItemValueRange(58) }) { name = "+58 Intelligence" }
        };

        public static List<Item> strength = new List<Item>()
        {
            new Item(new ItemAttributes() { strengthItem = new ItemValueRange(6) }) { name = "+6 Strength" },
            new Item(new ItemAttributes() { strengthItem = new ItemValueRange(10) }) { name = "+10 Strength" },
            new Item(new ItemAttributes() { strengthItem = new ItemValueRange(14) }) { name = "+14 Strength" },
            new Item(new ItemAttributes() { strengthItem = new ItemValueRange(18) }) { name = "+18 Strength" },
            new Item(new ItemAttributes() { strengthItem = new ItemValueRange(22) }) { name = "+22 Strength" },
            new Item(new ItemAttributes() { strengthItem = new ItemValueRange(26) }) { name = "+26 Strength" },
            new Item(new ItemAttributes() { strengthItem = new ItemValueRange(30) }) { name = "+30 Strength" },
            new Item(new ItemAttributes() { strengthItem = new ItemValueRange(34) }) { name = "+34 Strength" },
            new Item(new ItemAttributes() { strengthItem = new ItemValueRange(38) }) { name = "+38 Strength" },
            new Item(new ItemAttributes() { strengthItem = new ItemValueRange(42) }) { name = "+42 Strength" },
            new Item(new ItemAttributes() { strengthItem = new ItemValueRange(46) }) { name = "+46 Strength" },
            new Item(new ItemAttributes() { strengthItem = new ItemValueRange(50) }) { name = "+50 Strength" },
            new Item(new ItemAttributes() { strengthItem = new ItemValueRange(54) }) { name = "+54 Strength" },
            new Item(new ItemAttributes() { strengthItem = new ItemValueRange(58) }) { name = "+58 Strength" }
        };

        public static List<Item> vitality = new List<Item>()
        {
            new Item(new ItemAttributes() { vitalityItem = new ItemValueRange(6) }) { name = "+6 Vitality" },
            new Item(new ItemAttributes() { vitalityItem = new ItemValueRange(10) }) { name = "+10 Vitality" },
            new Item(new ItemAttributes() { vitalityItem = new ItemValueRange(14) }) { name = "+14 Vitality" },
            new Item(new ItemAttributes() { vitalityItem = new ItemValueRange(18) }) { name = "+18 Vitality" },
            new Item(new ItemAttributes() { vitalityItem = new ItemValueRange(22) }) { name = "+22 Vitality" },
            new Item(new ItemAttributes() { vitalityItem = new ItemValueRange(26) }) { name = "+26 Vitality" },
            new Item(new ItemAttributes() { vitalityItem = new ItemValueRange(30) }) { name = "+30 Vitality" },
            new Item(new ItemAttributes() { vitalityItem = new ItemValueRange(34) }) { name = "+34 Vitality" },
            new Item(new ItemAttributes() { vitalityItem = new ItemValueRange(38) }) { name = "+38 Vitality" },
            new Item(new ItemAttributes() { vitalityItem = new ItemValueRange(42) }) { name = "+42 Vitality" },
            new Item(new ItemAttributes() { vitalityItem = new ItemValueRange(46) }) { name = "+46 Vitality" },
            new Item(new ItemAttributes() { vitalityItem = new ItemValueRange(50) }) { name = "+50 Vitality" },
            new Item(new ItemAttributes() { vitalityItem = new ItemValueRange(54) }) { name = "+54 Vitality" },
            new Item(new ItemAttributes() { vitalityItem = new ItemValueRange(58) }) { name = "+58 Vitality" }
        };

        public static List<Item> damage = new List<Item>()
        {
            new Item(new ItemAttributes() { damageWeaponBonusMin_Physical = new ItemValueRange(2), damageWeaponBonusDelta_Physical = new ItemValueRange(2) }) { name = "[2-4]" },
            new Item(new ItemAttributes() { damageWeaponBonusMin_Physical = new ItemValueRange(4), damageWeaponBonusDelta_Physical = new ItemValueRange(4) }) { name = "[4-8]" },
            new Item(new ItemAttributes() { damageWeaponBonusMin_Physical = new ItemValueRange(8), damageWeaponBonusDelta_Physical = new ItemValueRange(8) }) { name = "[8-16]" },
            new Item(new ItemAttributes() { damageWeaponBonusMin_Physical = new ItemValueRange(10), damageWeaponBonusDelta_Physical = new ItemValueRange(10) }) { name = "[10-20]" },
            new Item(new ItemAttributes() { damageWeaponBonusMin_Physical = new ItemValueRange(11), damageWeaponBonusDelta_Physical = new ItemValueRange(11) }) { name = "[11-22]" },
            new Item(new ItemAttributes() { damageWeaponBonusMin_Physical = new ItemValueRange(12), damageWeaponBonusDelta_Physical = new ItemValueRange(12) }) { name = "[12-24]" },
            new Item(new ItemAttributes() { damageWeaponBonusMin_Physical = new ItemValueRange(13), damageWeaponBonusDelta_Physical = new ItemValueRange(13) }) { name = "[13-26]" },
            new Item(new ItemAttributes() { damageWeaponBonusMin_Physical = new ItemValueRange(14), damageWeaponBonusDelta_Physical = new ItemValueRange(14) }) { name = "[14-28]" },
            new Item(new ItemAttributes() { damageWeaponBonusMin_Physical = new ItemValueRange(15), damageWeaponBonusDelta_Physical = new ItemValueRange(15) }) { name = "[15-30]" },
            new Item(new ItemAttributes() { damageWeaponBonusMin_Physical = new ItemValueRange(16), damageWeaponBonusDelta_Physical = new ItemValueRange(16) }) { name = "[16-32]" },
            new Item(new ItemAttributes() { damageWeaponBonusMin_Physical = new ItemValueRange(17), damageWeaponBonusDelta_Physical = new ItemValueRange(17) }) { name = "[17-34]" },
            new Item(new ItemAttributes() { damageWeaponBonusMin_Physical = new ItemValueRange(18), damageWeaponBonusDelta_Physical = new ItemValueRange(18) }) { name = "[18-36]" },
            new Item(new ItemAttributes() { damageWeaponBonusMin_Physical = new ItemValueRange(19), damageWeaponBonusDelta_Physical = new ItemValueRange(19) }) { name = "[19-38]" },
            new Item(new ItemAttributes() { damageWeaponBonusMin_Physical = new ItemValueRange(20), damageWeaponBonusDelta_Physical = new ItemValueRange(20) }) { name = "[20-40]" }
        };

        public static List<Item> criticDamage = new List<Item>()
        {
            new Item(new ItemAttributes() { critDamagePercent = new ItemValueRange(0.5) }) { name = "+ 5% Critic Damage" },
            new Item(new ItemAttributes() { critDamagePercent = new ItemValueRange(0.10) }) { name = "+ 10% Critic Damage" },
            new Item(new ItemAttributes() { critDamagePercent = new ItemValueRange(0.15) }) { name = "+ 15% Critic Damage" },
            new Item(new ItemAttributes() { critDamagePercent = new ItemValueRange(0.20) }) { name = "+ 20% Critic Damage" },
            new Item(new ItemAttributes() { critDamagePercent = new ItemValueRange(0.25) }) { name = "+ 25% Critic Damage" },
            new Item(new ItemAttributes() { critDamagePercent = new ItemValueRange(0.30) }) { name = "+ 30% Critic Damage" },
            new Item(new ItemAttributes() { critDamagePercent = new ItemValueRange(0.35) }) { name = "+ 35% Critic Damage" },
            new Item(new ItemAttributes() { critDamagePercent = new ItemValueRange(0.40) }) { name = "+ 40% Critic Damage" },
            new Item(new ItemAttributes() { critDamagePercent = new ItemValueRange(0.45) }) { name = "+ 45% Critic Damage" },
            new Item(new ItemAttributes() { critDamagePercent = new ItemValueRange(0.50) }) { name = "+ 50% Critic Damage" },
            new Item(new ItemAttributes() { critDamagePercent = new ItemValueRange(0.70) }) { name = "+ 70% Critic Damage" },
            new Item(new ItemAttributes() { critDamagePercent = new ItemValueRange(0.80) }) { name = "+ 80% Critic Damage" },
            new Item(new ItemAttributes() { critDamagePercent = new ItemValueRange(0.90) }) { name = "+ 90% Critic Damage" },
            new Item(new ItemAttributes() { critDamagePercent = new ItemValueRange(1.00) }) { name = "+ 100% Critic Damage" }
        };

        public static List<Item> lifePercent = new List<Item>()
        {
            new Item(new ItemAttributes() { hitpointsMaxPercentBonusItem = new ItemValueRange(0.05) }) { name = "+ 5% Life" },
            new Item(new ItemAttributes() { hitpointsMaxPercentBonusItem = new ItemValueRange(0.06) }) { name = "+ 6% Life" },
            new Item(new ItemAttributes() { hitpointsMaxPercentBonusItem = new ItemValueRange(0.07) }) { name = "+ 7% Life" },
            new Item(new ItemAttributes() { hitpointsMaxPercentBonusItem = new ItemValueRange(0.08) }) { name = "+ 8% Life" },
            new Item(new ItemAttributes() { hitpointsMaxPercentBonusItem = new ItemValueRange(0.09) }) { name = "+ 9% Life" },
            new Item(new ItemAttributes() { hitpointsMaxPercentBonusItem = new ItemValueRange(0.10) }) { name = "+ 10% Life" },
            new Item(new ItemAttributes() { hitpointsMaxPercentBonusItem = new ItemValueRange(0.11) }) { name = "+ 11% Life" },
            new Item(new ItemAttributes() { hitpointsMaxPercentBonusItem = new ItemValueRange(0.12) }) { name = "+ 12% Life" },
            new Item(new ItemAttributes() { hitpointsMaxPercentBonusItem = new ItemValueRange(0.13) }) { name = "+ 13% Life" },
            new Item(new ItemAttributes() { hitpointsMaxPercentBonusItem = new ItemValueRange(0.14) }) { name = "+ 14% Life" },
            new Item(new ItemAttributes() { hitpointsMaxPercentBonusItem = new ItemValueRange(0.15) }) { name = "+ 15% Life" },
            new Item(new ItemAttributes() { hitpointsMaxPercentBonusItem = new ItemValueRange(0.16) }) { name = "+ 16% Life" },
            new Item(new ItemAttributes() { hitpointsMaxPercentBonusItem = new ItemValueRange(0.17) }) { name = "+ 17% Life" },
            new Item(new ItemAttributes() { hitpointsMaxPercentBonusItem = new ItemValueRange(0.18) }) { name = "+ 18% Life" }
        };
    }
}

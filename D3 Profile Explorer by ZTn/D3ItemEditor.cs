﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ZTn.BNet.D3.Calculator.Gems;
using ZTn.BNet.D3.Calculator.Helpers;
using ZTn.BNet.D3.Items;
using ZTn.BNet.D3.Properties;

namespace ZTn.BNet.D3ProfileExplorer
{
    public partial class D3ItemEditor : UserControl
    {
        private List<GemsListViewItem> gems1;
        private List<GemsListViewItem> gems2;
        private List<GemsListViewItem> gems3;

        public KnownGems KnownGems { get; set; }

        public D3ItemEditor()
        {
            InitializeComponent();

            var typeIdSource = new List<String> { "", "Generic Armor" };
            typeIdSource.AddRange(Constants.WeaponTypeIds);
            typeIdSource.AddRange(Constants.HelmTypeIds);
            guiItemTypeId.Items.AddRange(typeIdSource.ToArray());
        }

        #region >> Inner Classes

        private class GemsListViewItem
        {
            public readonly Item Item;
            public string Label { [UsedImplicitly] get; private set; }

            public GemsListViewItem(Item item)
            {
                Item = item;
                Label = item.Name;
            }
        }

        #endregion

        private static void PopulateData(Control textBox, ItemValueRange itemValueRange)
        {
            if (itemValueRange != null && itemValueRange.Min != 0)
            {
                textBox.Text = itemValueRange.Min.ToString();
            }
            else
            {
                textBox.Text = String.Empty;
            }
        }

        private static void PopulateDataPercent(Control textBox, ItemValueRange itemValueRange)
        {
            if (itemValueRange != null && itemValueRange.Min != 0)
            {
                textBox.Text = (100 * itemValueRange.Min).ToString("N1");
            }
            else
            {
                textBox.Text = String.Empty;
            }
        }

        private static ItemValueRange GetData(Control textBox)
        {
            return String.IsNullOrEmpty(textBox.Text) ? null : new ItemValueRange(Double.Parse(textBox.Text));
        }

        private static ItemValueRange GetDataPercent(Control textBox)
        {
            return String.IsNullOrEmpty(textBox.Text) ? null : new ItemValueRange(Double.Parse(textBox.Text) / 100);
        }

        private static void SelectActiveGem(ComboBox comboBox, IEnumerable<GemsListViewItem> refGems, ItemSummary equippedGem)
        {
            if (equippedGem != null)
            {
                comboBox.SelectedItem = refGems.FirstOrDefault(g => equippedGem.Id == g.Item.Id);
            }
        }

        public void SetEditedItem(Item item)
        {
            Tag = item;

            if (item == null)
            {
                return;
            }

            guiItemName.Text = item.Name;
            guiItemId.Text = item.Id;
            guiItemTypeId.Text = (item.Type != null ? item.Type.Id : "");

            item.Simplify();

            var attr = item.AttributesRaw;

            // Characteristics
            PopulateData(guiDexterity, attr.dexterityItem);
            PopulateData(guiIntelligence, attr.intelligenceItem);
            PopulateData(guiStrength, attr.strengthItem);
            PopulateData(guiVitality, attr.vitalityItem);
            PopulateDataPercent(guiAttackSpeed, attr.attacksPerSecondPercent);
            PopulateDataPercent(guiCriticDamage, attr.critDamagePercent);
            PopulateDataPercent(guiCriticChance, attr.critPercentBonusCapped);
            PopulateDataPercent(guiHitpointsMaxPercent, attr.hitpointsMaxPercentBonusItem);
            PopulateData(guiArmor, attr.armorItem);

            // Weapon characterics
            PopulateData(guiWeaponAttackPerSecond, attr.attacksPerSecondItem);
            PopulateData(guiWeaponDamageMinArcane, attr.damageWeaponMin_Arcane);
            PopulateData(guiWeaponDamageMinCold, attr.damageWeaponMin_Cold);
            PopulateData(guiWeaponDamageMinFire, attr.damageWeaponMin_Fire);
            PopulateData(guiWeaponDamageMinHoly, attr.damageWeaponMin_Holy);
            PopulateData(guiWeaponDamageMinLightning, attr.damageWeaponMin_Lightning);
            PopulateData(guiWeaponDamageMinPhysical, attr.damageWeaponMin_Physical * (1 + attr.damageWeaponPercentBonus_Physical));
            PopulateData(guiWeaponDamageMinPoison, attr.damageWeaponMin_Poison);

            PopulateData(guiWeaponDamageMaxArcane, attr.damageWeaponMin_Arcane + attr.damageWeaponDelta_Arcane);
            PopulateData(guiWeaponDamageMaxCold, attr.damageWeaponMin_Cold + attr.damageWeaponDelta_Cold);
            PopulateData(guiWeaponDamageMaxFire, attr.damageWeaponMin_Fire + attr.damageWeaponDelta_Fire);
            PopulateData(guiWeaponDamageMaxHoly, attr.damageWeaponMin_Holy + attr.damageWeaponDelta_Holy);
            PopulateData(guiWeaponDamageMaxLightning, attr.damageWeaponMin_Lightning + attr.damageWeaponDelta_Lightning);
            PopulateData(guiWeaponDamageMaxPhysical, (attr.damageWeaponMin_Physical + attr.damageWeaponDelta_Physical) * (1 + attr.damageWeaponPercentBonus_Physical));
            PopulateData(guiWeaponDamageMaxPoison, attr.damageWeaponMin_Poison + attr.damageWeaponDelta_Poison);

            PopulateDataPercent(guiWeaponDamagePercentBonus, attr.damageWeaponPercentBonus_Physical);

            // Item damage bonuses
            PopulateData(guiBonusDamageMinArcane, attr.damageMin_Arcane);
            PopulateData(guiBonusDamageMinCold, attr.damageMin_Cold);
            PopulateData(guiBonusDamageMinFire, attr.damageMin_Fire);
            PopulateData(guiBonusDamageMinHoly, attr.damageMin_Holy);
            PopulateData(guiBonusDamageMinLightning, attr.damageMin_Lightning);
            PopulateData(guiBonusDamageMinPhysical, attr.damageMin_Physical);
            PopulateData(guiBonusDamageMinPoison, attr.damageMin_Poison);

            PopulateData(guiBonusDamageMaxArcane, attr.damageMin_Arcane + attr.damageDelta_Arcane);
            PopulateData(guiBonusDamageMaxCold, attr.damageMin_Cold + attr.damageDelta_Cold);
            PopulateData(guiBonusDamageMaxFire, attr.damageMin_Fire + attr.damageDelta_Fire);
            PopulateData(guiBonusDamageMaxHoly, attr.damageMin_Holy + attr.damageDelta_Holy);
            PopulateData(guiBonusDamageMaxLightning, attr.damageMin_Lightning + attr.damageDelta_Lightning);
            PopulateData(guiBonusDamageMaxPhysical, attr.damageMin_Physical + attr.damageDelta_Physical);
            PopulateData(guiBonusDamageMaxPoison, attr.damageMin_Poison + attr.damageDelta_Poison);

            PopulateDataPercent(guiBonusDamagePercentArcane, attr.damageTypePercentBonus_Arcane);
            PopulateDataPercent(guiBonusDamagePercentCold, attr.damageTypePercentBonus_Cold);
            PopulateDataPercent(guiBonusDamagePercentFire, attr.damageTypePercentBonus_Fire);
            PopulateDataPercent(guiBonusDamagePercentHoly, attr.damageTypePercentBonus_Holy);
            PopulateDataPercent(guiBonusDamagePercentLightning, attr.damageTypePercentBonus_Lightning);
            PopulateDataPercent(guiBonusDamagePercentPhysical, attr.damageTypePercentBonus_Physical);
            PopulateDataPercent(guiBonusDamagePercentPoison, attr.damageTypePercentBonus_Poison);

            // Skill bonus
            PopulateDataPercent(guiSkillBonusPercentArcane, attr.damageDealtPercentBonusArcane);
            PopulateDataPercent(guiSkillBonusPercentCold, attr.damageDealtPercentBonusCold);
            PopulateDataPercent(guiSkillBonusPercentFire, attr.damageDealtPercentBonusFire);
            PopulateDataPercent(guiSkillBonusPercentHoly, attr.damageDealtPercentBonusHoly);
            PopulateDataPercent(guiSkillBonusPercentLightning, attr.damageDealtPercentBonusLightning);
            PopulateDataPercent(guiSkillBonusPercentPhysical, attr.damageDealtPercentBonusPhysical);
            PopulateDataPercent(guiSkillBonusPercentPoison, attr.damageDealtPercentBonusPoison);

            PopulateDataPercent(guiSkillCooldownReductionAll, attr.powerCooldownReductionPercentAll);

            PopulateDataPercent(guiBonusEliteDamagePercent, attr.damagePercentBonusVsElites);

            // Resistances
            PopulateData(guiResistance_All, attr.resistance_All);
            PopulateData(guiResistance_Arcane, attr.resistance_Arcane);
            PopulateData(guiResistance_Cold, attr.resistance_Cold);
            PopulateData(guiResistance_Fire, attr.resistance_Fire);
            PopulateData(guiResistance_Lightning, attr.resistance_Lightning);
            PopulateData(guiResistance_Physical, attr.resistance_Physical);
            PopulateData(guiResistance_Poison, attr.resistance_Poison);

            // Shield
            PopulateDataPercent(guiShieldBlockPercent, attr.blockChanceItem + attr.blockChanceBonusItem);
            PopulateData(guiShieldBlockMin, attr.blockAmountItemMin);
            PopulateData(guiShieldBlockMax, attr.blockAmountItemMin + attr.blockAmountItemDelta);

            PopulateData(guiHitpointsOnHit, attr.hitpointsOnHit);
            PopulateData(guiHitpointsRegenPerSecond, attr.hitpointsRegenPerSecond);
            PopulateDataPercent(guiLifeSteal, attr.stealHealthPercent);

            PopulateDataPercent(guiReductionFromElitesPercent, attr.damagePercentReductionFromElites);
            PopulateDataPercent(guiReductionFromMeleePercent, attr.damagePercentReductionFromMelee);
            PopulateDataPercent(guiReductionFromRangedPercent, attr.damagePercentReductionFromRanged);

            // Gems
            gems1 = new List<GemsListViewItem>();
            gems1.Add(new GemsListViewItem(new Item(new ItemAttributes()) { Attributes = new ItemTextAttributes { Primary = new[] { new ItemTextAttribute { Text = "( no gem )" } } } }));
            if (item.Type != null)
            {
                gems1.AddRange(KnownGems.GetGemsForItem(item).Select(g => new GemsListViewItem(g)));
            }
            gems2 = new List<GemsListViewItem>(gems1);
            gems3 = new List<GemsListViewItem>(gems1);

            guiGem1.DataSource = gems1;
            guiGem1.DisplayMember = "Label";
            guiGem2.DataSource = gems2;
            guiGem2.DisplayMember = "Label";
            guiGem3.DataSource = gems3;
            guiGem3.DisplayMember = "Label";

            guiGem1.SelectedIndex = 0;
            guiGem2.SelectedIndex = 0;
            guiGem3.SelectedIndex = 0;
            if (item.Gems != null)
            {
                if (item.Gems.Length >= 1)
                {
                    SelectActiveGem(guiGem1, gems1, item.Gems[0].Item);
                }
                if (item.Gems.Length >= 2)
                {
                    SelectActiveGem(guiGem2, gems2, item.Gems[1].Item);
                }
                if (item.Gems.Length >= 3)
                {
                    SelectActiveGem(guiGem3, gems3, item.Gems[2].Item);
                }
            }
        }

        public Item GetEditedItem()
        {
            var item = new Item();
            var attr = new ItemAttributes();

            item.Name = guiItemName.Text;
            item.Id = guiItemId.Text;
            item.Type = new ItemType(guiItemTypeId.Text, false);

            attr.dexterityItem = GetData(guiDexterity);
            attr.intelligenceItem = GetData(guiIntelligence);
            attr.strengthItem = GetData(guiStrength);
            attr.vitalityItem = GetData(guiVitality);
            attr.attacksPerSecondPercent = GetDataPercent(guiAttackSpeed);
            attr.critDamagePercent = GetDataPercent(guiCriticDamage);
            attr.critPercentBonusCapped = GetDataPercent(guiCriticChance);
            attr.hitpointsMaxPercentBonusItem = GetDataPercent(guiHitpointsMaxPercent);
            attr.armorItem = GetData(guiArmor);

            attr.attacksPerSecondItem = GetData(guiWeaponAttackPerSecond);

            attr.damageWeaponPercentBonus_Physical = GetDataPercent(guiWeaponDamagePercentBonus);
            var damageWeaponPercentBonus_Physical = (attr.damageWeaponPercentBonus_Physical == null ? 0 : attr.damageWeaponPercentBonus_Physical.Min);

            attr.damageWeaponMin_Arcane = GetData(guiWeaponDamageMinArcane);
            attr.damageWeaponMin_Cold = GetData(guiWeaponDamageMinCold);
            attr.damageWeaponMin_Fire = GetData(guiWeaponDamageMinFire);
            attr.damageWeaponMin_Holy = GetData(guiWeaponDamageMinHoly);
            attr.damageWeaponMin_Lightning = GetData(guiWeaponDamageMinLightning);
            attr.damageWeaponMin_Physical = GetData(guiWeaponDamageMinPhysical) / (1 + damageWeaponPercentBonus_Physical);
            attr.damageWeaponMin_Poison = GetData(guiWeaponDamageMinPoison);

            attr.damageWeaponDelta_Arcane = GetData(guiWeaponDamageMaxArcane) - attr.damageWeaponMin_Arcane;
            attr.damageWeaponDelta_Cold = GetData(guiWeaponDamageMaxCold) - attr.damageWeaponMin_Cold;
            attr.damageWeaponDelta_Fire = GetData(guiWeaponDamageMaxFire) - attr.damageWeaponMin_Fire;
            attr.damageWeaponDelta_Holy = GetData(guiWeaponDamageMaxHoly) - attr.damageWeaponMin_Holy;
            attr.damageWeaponDelta_Lightning = GetData(guiWeaponDamageMaxLightning) - attr.damageWeaponMin_Lightning;
            attr.damageWeaponDelta_Physical = GetData(guiWeaponDamageMaxPhysical) / (1 + damageWeaponPercentBonus_Physical) - attr.damageWeaponMin_Physical;
            attr.damageWeaponDelta_Poison = GetData(guiWeaponDamageMaxPoison) - attr.damageWeaponMin_Poison;

            attr.damageMin_Arcane = GetData(guiBonusDamageMinArcane);
            attr.damageMin_Cold = GetData(guiBonusDamageMinCold);
            attr.damageMin_Fire = GetData(guiBonusDamageMinFire);
            attr.damageMin_Holy = GetData(guiBonusDamageMinHoly);
            attr.damageMin_Lightning = GetData(guiBonusDamageMinLightning);
            attr.damageMin_Physical = GetData(guiBonusDamageMinPhysical);
            attr.damageMin_Poison = GetData(guiBonusDamageMinPoison);

            attr.damageDelta_Arcane = GetData(guiBonusDamageMaxArcane) - attr.damageMin_Arcane;
            attr.damageDelta_Cold = GetData(guiBonusDamageMaxCold) - attr.damageMin_Cold;
            attr.damageDelta_Fire = GetData(guiBonusDamageMaxFire) - attr.damageMin_Fire;
            attr.damageDelta_Holy = GetData(guiBonusDamageMaxHoly) - attr.damageMin_Holy;
            attr.damageDelta_Lightning = GetData(guiBonusDamageMaxLightning) - attr.damageMin_Lightning;
            attr.damageDelta_Physical = GetData(guiBonusDamageMaxPhysical) - attr.damageMin_Physical;
            attr.damageDelta_Poison = GetData(guiBonusDamageMaxPoison) - attr.damageMin_Poison;

            attr.damageTypePercentBonus_Arcane = GetDataPercent(guiBonusDamagePercentArcane);
            attr.damageTypePercentBonus_Cold = GetDataPercent(guiBonusDamagePercentCold);
            attr.damageTypePercentBonus_Fire = GetDataPercent(guiBonusDamagePercentFire);
            attr.damageTypePercentBonus_Holy = GetDataPercent(guiBonusDamagePercentHoly);
            attr.damageTypePercentBonus_Lightning = GetDataPercent(guiBonusDamagePercentLightning);
            attr.damageTypePercentBonus_Physical = GetDataPercent(guiBonusDamagePercentPhysical);
            attr.damageTypePercentBonus_Poison = GetDataPercent(guiBonusDamagePercentPoison);

            attr.damageDealtPercentBonusArcane = GetDataPercent(guiSkillBonusPercentArcane);
            attr.damageDealtPercentBonusCold = GetDataPercent(guiSkillBonusPercentCold);
            attr.damageDealtPercentBonusFire = GetDataPercent(guiSkillBonusPercentFire);
            attr.damageDealtPercentBonusHoly = GetDataPercent(guiSkillBonusPercentHoly);
            attr.damageDealtPercentBonusLightning = GetDataPercent(guiSkillBonusPercentLightning);
            attr.damageDealtPercentBonusPhysical = GetDataPercent(guiSkillBonusPercentPhysical);
            attr.damageDealtPercentBonusPoison = GetDataPercent(guiSkillBonusPercentPoison);

            attr.powerCooldownReductionPercentAll = GetDataPercent(guiSkillCooldownReductionAll);

            attr.damagePercentBonusVsElites = GetDataPercent(guiBonusEliteDamagePercent);

            attr.resistance_All = GetData(guiResistance_All);
            attr.resistance_Arcane = GetData(guiResistance_Arcane);
            attr.resistance_Cold = GetData(guiResistance_Cold);
            attr.resistance_Fire = GetData(guiResistance_Fire);
            attr.resistance_Lightning = GetData(guiResistance_Lightning);
            attr.resistance_Physical = GetData(guiResistance_Physical);
            attr.resistance_Poison = GetData(guiResistance_Poison);

            // Shield
            attr.blockChanceItem = GetData(guiShieldBlockPercent);
            attr.blockAmountItemMin = GetData(guiShieldBlockMin);
            attr.blockAmountItemDelta = GetData(guiShieldBlockMax) - attr.blockAmountItemMin;

            attr.hitpointsOnHit = GetData(guiHitpointsOnHit);
            attr.hitpointsRegenPerSecond = GetData(guiHitpointsRegenPerSecond);
            attr.stealHealthPercent = GetDataPercent(guiLifeSteal);

            attr.damagePercentReductionFromElites = GetDataPercent(guiReductionFromElitesPercent);
            attr.damagePercentReductionFromMelee = GetDataPercent(guiReductionFromMeleePercent);
            attr.damagePercentReductionFromRanged = GetDataPercent(guiReductionFromRangedPercent);

            item.AttributesRaw = attr;
            var gems = new List<SocketedGem>();

            if (guiGem1.SelectedIndex > 0)
            {
                var gem = new SocketedGem(new Item(((GemsListViewItem)guiGem1.SelectedItem).Item));
                gems.Add(gem);
            }
            if (guiGem2.SelectedIndex > 0)
            {
                var gem = new SocketedGem(new Item(((GemsListViewItem)guiGem2.SelectedItem).Item));
                gems.Add(gem);
            }
            if (guiGem3.SelectedIndex > 0)
            {
                var gem = new SocketedGem(new Item(((GemsListViewItem)guiGem3.SelectedItem).Item));
                gems.Add(gem);
            }

            item.Gems = gems.ToArray();

            return item;
        }

        private void GuiReset_Click(object sender, EventArgs e)
        {
            SetEditedItem((Item)Tag);
        }

        private void guiItemTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            // re-generates data
            gems1 = new List<GemsListViewItem>();
            gems1.Add(new GemsListViewItem(new Item(new ItemAttributes()) { Attributes = new ItemTextAttributes { Primary = new[] { new ItemTextAttribute { Text = "( no gem )" } } } }));
            gems1.AddRange(KnownGems.GetGemsForItemTypeId(guiItemTypeId.Text).Select(g => new GemsListViewItem(g)));
            gems2 = new List<GemsListViewItem>(gems1);
            gems3 = new List<GemsListViewItem>(gems1);

            var index = guiGem1.SelectedIndex;
            guiGem1.DataSource = gems1;
            guiGem1.SelectedIndex = index;
            index = guiGem2.SelectedIndex;
            guiGem2.DataSource = gems2;
            guiGem2.SelectedIndex = index;
            index = guiGem3.SelectedIndex;
            guiGem3.DataSource = gems3;
            guiGem3.SelectedIndex = index;
        }
    }
}
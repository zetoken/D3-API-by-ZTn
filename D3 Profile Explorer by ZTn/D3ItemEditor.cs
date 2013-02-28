using System;
using System.Collections.Generic;
using System.Windows.Forms;

using ZTn.BNet.D3.Calculator.Gems;
using ZTn.BNet.D3.Calculator.Helpers;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    public partial class D3ItemEditor : UserControl
    {
        List<Item> gems1;
        List<Item> gems2;
        List<Item> gems3;

        List<String> weaponTypeIdList = new List<String>() { "Axe", "Axe2H", "Bow", "Crossbow", "Dagger", "Daibo", "FistWeapon", "HandCrossbow", "Mace", "Mace2H", "Polearm", "Spear", "Sword", "Sword2H" };
        List<String> helmTypeIdList = new List<String>() { "Hat", "Helm", "Mask", "SpiritStone" };

        public D3ItemEditor()
        {
            InitializeComponent();

            List<String> typeIdSource = new List<String>() { "", "Generic Armor" };
            typeIdSource.AddRange(weaponTypeIdList);
            typeIdSource.AddRange(helmTypeIdList);
            guiItemTypeId.Items.AddRange(typeIdSource.ToArray());
        }

        private void populateData(TextBox textBox, ItemValueRange itemValueRange)
        {
            if (itemValueRange != null && itemValueRange.min != 0)
                textBox.Text = itemValueRange.min.ToString();
            else
                textBox.Text = String.Empty;
        }

        private void populateDataPercent(TextBox textBox, ItemValueRange itemValueRange)
        {
            if (itemValueRange != null && itemValueRange.min != 0)
                textBox.Text = (100 * itemValueRange.min).ToString();
            else
                textBox.Text = String.Empty;
        }

        private ItemValueRange getData(TextBox textBox)
        {
            ItemValueRange data;

            if (String.IsNullOrEmpty(textBox.Text))
                data = null;
            else
                data = new ItemValueRange(Double.Parse(textBox.Text));
            return data;
        }

        private ItemValueRange getDataPercent(TextBox textBox)
        {
            ItemValueRange data;

            if (String.IsNullOrEmpty(textBox.Text))
                data = null;
            else
                data = new ItemValueRange(Double.Parse(textBox.Text) / 100);
            return data;
        }

        private void selectActiveGem(ComboBox comboBox, List<Item> refGems, ItemSummary equippedGem)
        {
            if (equippedGem != null)
            {
                foreach (Item gem in refGems)
                {
                    if (equippedGem.id == gem.id)
                    {
                        comboBox.SelectedItem = gem;
                        break;
                    }
                }
            }
        }

        public void setEditedItem(Item item)
        {
            Tag = item;
            if (item != null)
            {
                guiItemName.Text = item.name;
                guiItemId.Text = item.id;
                guiItemTypeId.Text = (item.type != null ? item.type.id : "");

                ItemAttributes attr = item.attributesRaw;

                // Characteristics
                populateData(guiDexterity, attr.dexterityItem);
                populateData(guiIntelligence, attr.intelligenceItem);
                populateData(guiStrength, attr.strengthItem);
                populateData(guiVitality, attr.vitalityItem);
                populateDataPercent(guiAttackSpeed, attr.attacksPerSecondPercent);
                populateDataPercent(guiCriticDamage, attr.critDamagePercent);
                populateDataPercent(guiCriticChance, attr.critPercentBonusCapped);
                populateDataPercent(guiHitpointsMaxPercent, attr.hitpointsMaxPercentBonusItem);
                populateData(guiArmor, item.getArmor());
                populateData(guiHitpointsOnHit, attr.hitpointsOnHit);
                populateData(guiHitpointsRegenPerSecond, attr.hitpointsRegenPerSecond);
                populateDataPercent(guiLifeSteal, attr.stealHealthPercent);

                // Weapon characterics
                populateData(guiWeaponAttackPerSecond, item.getRawWeaponAttackPerSecond());
                populateData(guiWeaponDamageMinArcane, item.getRawWeaponDamageMin("Arcane"));
                populateData(guiWeaponDamageMinCold, item.getRawWeaponDamageMin("Cold"));
                populateData(guiWeaponDamageMinFire, item.getRawWeaponDamageMin("Fire"));
                populateData(guiWeaponDamageMinHoly, item.getRawWeaponDamageMin("Holy"));
                populateData(guiWeaponDamageMinLightning, item.getRawWeaponDamageMin("Lightning"));
                populateData(guiWeaponDamageMinPhysical, item.getRawWeaponDamageMin("Physical"));
                populateData(guiWeaponDamageMinPoison, item.getRawWeaponDamageMin("Poison"));

                item.checkAndUpdateWeaponDelta();

                populateData(guiWeaponDamageMaxArcane, item.getRawWeaponDamageMax("Arcane"));
                populateData(guiWeaponDamageMaxCold, item.getRawWeaponDamageMax("Cold"));
                populateData(guiWeaponDamageMaxFire, item.getRawWeaponDamageMax("Fire"));
                populateData(guiWeaponDamageMaxHoly, item.getRawWeaponDamageMax("Holy"));
                populateData(guiWeaponDamageMaxLightning, item.getRawWeaponDamageMax("Lightning"));
                populateData(guiWeaponDamageMaxPhysical, item.getRawWeaponDamageMax("Physical"));
                populateData(guiWeaponDamageMaxPoison, item.getRawWeaponDamageMax("Poison"));

                // Item damage bonuses
                populateData(guiBonusDamageMinArcane, item.getRawBonusDamageMin("Arcane"));
                populateData(guiBonusDamageMinCold, item.getRawBonusDamageMin("Cold"));
                populateData(guiBonusDamageMinFire, item.getRawBonusDamageMin("Fire"));
                populateData(guiBonusDamageMinHoly, item.getRawBonusDamageMin("Holy"));
                populateData(guiBonusDamageMinLightning, item.getRawBonusDamageMin("Lightning"));
                populateData(guiBonusDamageMinPhysical, item.getRawBonusDamageMin("Physical"));
                populateData(guiBonusDamageMinPoison, item.getRawBonusDamageMin("Poison"));

                populateData(guiBonusDamageMaxArcane, item.getRawBonusDamageMax("Arcane"));
                populateData(guiBonusDamageMaxCold, item.getRawBonusDamageMax("Cold"));
                populateData(guiBonusDamageMaxFire, item.getRawBonusDamageMax("Fire"));
                populateData(guiBonusDamageMaxHoly, item.getRawBonusDamageMax("Holy"));
                populateData(guiBonusDamageMaxLightning, item.getRawBonusDamageMax("Lightning"));
                populateData(guiBonusDamageMaxPhysical, item.getRawBonusDamageMax("Physical"));
                populateData(guiBonusDamageMaxPoison, item.getRawBonusDamageMax("Poison"));

                populateDataPercent(guiBonusDamagePercentArcane, attr.damageTypePercentBonus_Arcane);
                populateDataPercent(guiBonusDamagePercentCold, attr.damageTypePercentBonus_Cold);
                populateDataPercent(guiBonusDamagePercentFire, attr.damageTypePercentBonus_Fire);
                populateDataPercent(guiBonusDamagePercentHoly, attr.damageTypePercentBonus_Holy);
                populateDataPercent(guiBonusDamagePercentLightning, attr.damageTypePercentBonus_Lightning);
                populateDataPercent(guiBonusDamagePercentPhysical, attr.damageTypePercentBonus_Physical);
                populateDataPercent(guiBonusDamagePercentPoison, attr.damageTypePercentBonus_Poison);

                // Resistances
                populateData(guiResistance_All, attr.resistance_All);
                populateData(guiResistance_Arcane, attr.resistance_Arcane);
                populateData(guiResistance_Cold, attr.resistance_Cold);
                populateData(guiResistance_Fire, attr.resistance_Fire);
                populateData(guiResistance_Lightning, attr.resistance_Lightning);
                populateData(guiResistance_Physical, attr.resistance_Physical);
                populateData(guiResistance_Poison, attr.resistance_Poison);

                // Shield
                populateDataPercent(guiShieldBlockPercent, attr.blockChanceItem + attr.blockChanceBonusItem);
                populateData(guiShieldBlockMin, attr.blockAmountItemMin);
                populateData(guiShieldBlockMax, attr.blockAmountItemMin + attr.blockAmountItemDelta);

                // Gems
                gems1 = new List<Item>();
                gems1.Add(new Item(new ItemAttributes()) { name = "( no gem )" });
                if (item.type != null)
                {
                    if (weaponTypeIdList.IndexOf(item.type.id) >= 0)
                        gems1.AddRange(GemHelper.weaponSocketedGems);
                    else if (item.type.id.Contains("Helm") || item.type.id.Contains("SpiritStone") || item.type.id.Contains("Mask") || item.type.id.Contains("Hat"))
                        gems1.AddRange(GemHelper.helmSocketedGems);
                    else
                        gems1.AddRange(GemHelper.otherSocketedGems);
                }
                gems2 = new List<Item>(gems1);
                gems3 = new List<Item>(gems1);

                guiGem1.DataSource = gems1;
                guiGem1.DisplayMember = "name";
                guiGem2.DataSource = gems2;
                guiGem2.DisplayMember = "name";
                guiGem3.DataSource = gems3;
                guiGem3.DisplayMember = "name";

                guiGem1.SelectedIndex = 0;
                guiGem2.SelectedIndex = 0;
                guiGem3.SelectedIndex = 0;
                if (item.gems != null)
                {
                    if (item.gems.Length >= 1)
                    {
                        selectActiveGem(guiGem1, gems1, item.gems[0].item);
                    }
                    if (item.gems.Length >= 2)
                    {
                        selectActiveGem(guiGem2, gems2, item.gems[1].item);
                    }
                    if (item.gems.Length >= 3)
                    {
                        selectActiveGem(guiGem3, gems3, item.gems[2].item);
                    }
                }
            }
        }

        public Item getEditedItem()
        {
            Item item = new Item();
            ItemAttributes attr = new ItemAttributes();

            item.name = guiItemName.Text;
            item.id = guiItemId.Text;
            item.type = new ItemType(guiItemTypeId.Text, false);

            attr.dexterityItem = getData(guiDexterity);
            attr.intelligenceItem = getData(guiIntelligence);
            attr.strengthItem = getData(guiStrength);
            attr.vitalityItem = getData(guiVitality);
            attr.attacksPerSecondPercent = getDataPercent(guiAttackSpeed);
            attr.critDamagePercent = getDataPercent(guiCriticDamage);
            attr.critPercentBonusCapped = getDataPercent(guiCriticChance);
            attr.hitpointsMaxPercentBonusItem = getDataPercent(guiHitpointsMaxPercent);
            attr.armorItem = getData(guiArmor);
            attr.hitpointsOnHit = getData(guiHitpointsOnHit);
            attr.hitpointsRegenPerSecond = getData(guiHitpointsRegenPerSecond);
            attr.stealHealthPercent = getDataPercent(guiLifeSteal);

            attr.attacksPerSecondItem = getData(guiWeaponAttackPerSecond);

            attr.damageWeaponMin_Arcane = getData(guiWeaponDamageMinArcane);
            attr.damageWeaponMin_Cold = getData(guiWeaponDamageMinCold);
            attr.damageWeaponMin_Fire = getData(guiWeaponDamageMinFire);
            attr.damageWeaponMin_Holy = getData(guiWeaponDamageMinHoly);
            attr.damageWeaponMin_Lightning = getData(guiWeaponDamageMinLightning);
            attr.damageWeaponMin_Physical = getData(guiWeaponDamageMinPhysical);
            attr.damageWeaponMin_Poison = getData(guiWeaponDamageMinPoison);

            attr.damageWeaponDelta_Arcane = getData(guiWeaponDamageMaxArcane) - attr.damageWeaponMin_Arcane;
            attr.damageWeaponDelta_Cold = getData(guiWeaponDamageMaxCold) - attr.damageWeaponMin_Cold;
            attr.damageWeaponDelta_Fire = getData(guiWeaponDamageMaxFire) - attr.damageWeaponMin_Fire;
            attr.damageWeaponDelta_Holy = getData(guiWeaponDamageMaxHoly) - attr.damageWeaponMin_Holy;
            attr.damageWeaponDelta_Lightning = getData(guiWeaponDamageMaxLightning) - attr.damageWeaponMin_Lightning;
            attr.damageWeaponDelta_Physical = getData(guiWeaponDamageMaxPhysical) - attr.damageWeaponMin_Physical;
            attr.damageWeaponDelta_Poison = getData(guiWeaponDamageMaxPoison) - attr.damageWeaponMin_Poison;

            attr.damageMin_Arcane = getData(guiBonusDamageMinArcane);
            attr.damageMin_Cold = getData(guiBonusDamageMinCold);
            attr.damageMin_Fire = getData(guiBonusDamageMinFire);
            attr.damageMin_Holy = getData(guiBonusDamageMinHoly);
            attr.damageMin_Lightning = getData(guiBonusDamageMinLightning);
            attr.damageMin_Physical = getData(guiBonusDamageMinPhysical);
            attr.damageMin_Poison = getData(guiBonusDamageMinPoison);

            attr.damageDelta_Arcane = getData(guiBonusDamageMaxArcane) - attr.damageMin_Arcane;
            attr.damageDelta_Cold = getData(guiBonusDamageMaxCold) - attr.damageMin_Cold;
            attr.damageDelta_Fire = getData(guiBonusDamageMaxFire) - attr.damageMin_Fire;
            attr.damageDelta_Holy = getData(guiBonusDamageMaxHoly) - attr.damageMin_Holy;
            attr.damageDelta_Lightning = getData(guiBonusDamageMaxLightning) - attr.damageMin_Lightning;
            attr.damageDelta_Physical = getData(guiBonusDamageMaxPhysical) - attr.damageMin_Physical;
            attr.damageDelta_Poison = getData(guiBonusDamageMaxPoison) - attr.damageMin_Poison;

            attr.damageTypePercentBonus_Arcane = getDataPercent(guiBonusDamagePercentArcane);
            attr.damageTypePercentBonus_Cold = getDataPercent(guiBonusDamagePercentCold);
            attr.damageTypePercentBonus_Fire = getDataPercent(guiBonusDamagePercentFire);
            attr.damageTypePercentBonus_Holy = getDataPercent(guiBonusDamagePercentHoly);
            attr.damageTypePercentBonus_Lightning = getDataPercent(guiBonusDamagePercentLightning);
            attr.damageTypePercentBonus_Physical = getDataPercent(guiBonusDamagePercentPhysical);
            attr.damageTypePercentBonus_Poison = getDataPercent(guiBonusDamagePercentPoison);

            attr.resistance_All = getData(guiResistance_All);
            attr.resistance_Arcane = getData(guiResistance_Arcane);
            attr.resistance_Cold = getData(guiResistance_Cold);
            attr.resistance_Fire = getData(guiResistance_Fire);
            attr.resistance_Lightning = getData(guiResistance_Lightning);
            attr.resistance_Physical = getData(guiResistance_Physical);
            attr.resistance_Poison = getData(guiResistance_Poison);

            // Shield
            attr.blockChanceItem = getData(guiShieldBlockPercent);
            attr.blockAmountItemMin = getData(guiShieldBlockMin);
            attr.blockAmountItemDelta = getData(guiShieldBlockMax) - attr.blockAmountItemMin;

            item.attributesRaw = attr;
            List<SocketedGem> gems = new List<SocketedGem>();

            if (guiGem1.SelectedIndex > 0)
            {
                gems.Add(new SocketedGem((Item)guiGem1.SelectedItem));
            }
            if (guiGem2.SelectedIndex > 0)
            {
                gems.Add(new SocketedGem((Item)guiGem2.SelectedItem));
            }
            if (guiGem3.SelectedIndex > 0)
            {
                gems.Add(new SocketedGem((Item)guiGem3.SelectedItem));
            }

            item.gems = gems.ToArray();

            return item;
        }

        private void GuiReset_Click(object sender, EventArgs e)
        {
            setEditedItem((Item)Tag);
        }

        private void guiItemTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            // re-generates data
            gems1 = new List<Item>();
            gems1.Add(new Item(new ItemAttributes()) { name = "( no gem )" });
            if (weaponTypeIdList.IndexOf(guiItemTypeId.Text) >= 0)
                gems1.AddRange(GemHelper.weaponSocketedGems);
            else if (guiItemTypeId.Text.Contains("Helm") || guiItemTypeId.Text.Contains("SpiritStone") || guiItemTypeId.Text.Contains("Mask") || guiItemTypeId.Text.Contains("Hat"))
                gems1.AddRange(GemHelper.helmSocketedGems);
            else
                gems1.AddRange(GemHelper.otherSocketedGems);
            gems2 = new List<Item>(gems1);
            gems3 = new List<Item>(gems1);

            int index = guiGem1.SelectedIndex;
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

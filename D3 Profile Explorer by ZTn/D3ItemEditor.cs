using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    public partial class D3ItemEditor : UserControl
    {
        List<Item> gems1;
        List<Item> gems2;
        List<Item> gems3;

        public D3ItemEditor()
        {
            InitializeComponent();

            gems1 = new List<Item>();
            gems1.Add(new Item(new ItemAttributes()) { name = "( no gem )" });
            gems1.AddRange(GemHelper.dexterity);
            gems1.AddRange(GemHelper.intelligence);
            gems1.AddRange(GemHelper.strength);
            gems1.AddRange(GemHelper.vitality);
            gems1.AddRange(GemHelper.damage);
            gems1.AddRange(GemHelper.criticDamage);
            gems1.AddRange(GemHelper.lifePercent);
            gems2 = new List<Item>(gems1);
            gems3 = new List<Item>(gems1);

            guiGem1.DataSource = gems1;
            guiGem1.DisplayMember = "name";
            guiGem2.DataSource = gems2;
            guiGem2.DisplayMember = "name";
            guiGem3.DataSource = gems3;
            guiGem3.DisplayMember = "name";
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

        private void selectActiveGem(ComboBox comboBox, List<Item> refGems, Item equippedGem)
        {
            if (equippedGem.attributesRaw.dexterityItem != null)
            {
                foreach (Item gem in gems2)
                {
                    if ((gem.attributesRaw.dexterityItem != null) && (gem.attributesRaw.dexterityItem.min == equippedGem.attributesRaw.dexterityItem.min))
                    {
                        comboBox.SelectedItem = gem;
                        break;
                    }
                }
            }
            else if (equippedGem.attributesRaw.intelligenceItem != null)
            {
                foreach (Item gem in gems1)
                {
                    if ((gem.attributesRaw.intelligenceItem != null) && (gem.attributesRaw.intelligenceItem.min == equippedGem.attributesRaw.intelligenceItem.min))
                    {
                        comboBox.SelectedItem = gem;
                        break;
                    }
                }
            }
            else if (equippedGem.attributesRaw.strengthItem != null)
            {
                foreach (Item gem in gems1)
                {
                    if ((gem.attributesRaw.strengthItem != null) && (gem.attributesRaw.strengthItem.min == equippedGem.attributesRaw.strengthItem.min))
                    {
                        comboBox.SelectedItem = gem;
                        break;
                    }
                }
            }
            else if (equippedGem.attributesRaw.vitalityItem != null)
            {
                foreach (Item gem in gems1)
                {
                    if ((gem.attributesRaw.vitalityItem != null) && (gem.attributesRaw.vitalityItem.min == equippedGem.attributesRaw.vitalityItem.min))
                    {
                        comboBox.SelectedItem = gem;
                        break;
                    }
                }
            }
            else if (equippedGem.attributesRaw.damageWeaponBonusMin_Physical != null)
            {
                foreach (Item gem in gems1)
                {
                    if ((gem.attributesRaw.damageWeaponBonusMin_Physical != null) && (gem.attributesRaw.damageWeaponBonusMin_Physical.min == equippedGem.attributesRaw.damageWeaponBonusMin_Physical.min))
                    {
                        comboBox.SelectedItem = gem;
                        break;
                    }
                }
            }
            else if (equippedGem.attributesRaw.critDamagePercent != null)
            {
                foreach (Item gem in gems1)
                {
                    if ((gem.attributesRaw.critDamagePercent != null) && (gem.attributesRaw.critDamagePercent.min == equippedGem.attributesRaw.critDamagePercent.min))
                    {
                        comboBox.SelectedItem = gem;
                        break;
                    }
                }
            }
            else if (equippedGem.attributesRaw.hitpointsMaxPercentBonusItem != null)
            {
                foreach (Item gem in gems1)
                {
                    if ((gem.attributesRaw.hitpointsMaxPercentBonusItem != null) && (gem.attributesRaw.hitpointsMaxPercentBonusItem.min == equippedGem.attributesRaw.hitpointsMaxPercentBonusItem.min))
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
                populateData(guiArmor, attr.armorItem + attr.armorBonusItem);
                populateData(guiHitpointsOnHit, attr.hitpointsOnHit);
                populateData(guiHitpointsRegenPerSecond, attr.hitpointsRegenPerSecond);

                // Weapon characterics
                if (attr.attacksPerSecondItemPercent == null)
                {
                    populateData(guiWeaponAttackPerSecond, attr.attacksPerSecondItem);
                }
                else
                {
                    populateData(guiWeaponAttackPerSecond, attr.attacksPerSecondItem * (ItemValueRange.One + attr.attacksPerSecondItemPercent));
                }
                populateData(guiWeaponDamageMinArcane, (attr.damageWeaponMin_Arcane + attr.damageWeaponBonusMin_Arcane) * (ItemValueRange.One + attr.damageWeaponPercentBonus_Arcane));
                populateData(guiWeaponDamageMinCold, (attr.damageWeaponMin_Cold + attr.damageWeaponBonusMin_Cold) * (ItemValueRange.One + attr.damageWeaponPercentBonus_Cold));
                populateData(guiWeaponDamageMinFire, (attr.damageWeaponMin_Fire + attr.damageWeaponBonusMin_Fire) * (ItemValueRange.One + attr.damageWeaponPercentBonus_Fire));
                populateData(guiWeaponDamageMinHoly, (attr.damageWeaponMin_Holy + attr.damageWeaponBonusMin_Holy) * (ItemValueRange.One + attr.damageWeaponPercentBonus_Holy));
                populateData(guiWeaponDamageMinLightning, (attr.damageWeaponMin_Lightning + attr.damageWeaponBonusMin_Lightning) * (ItemValueRange.One + attr.damageWeaponPercentBonus_Lightning));
                populateData(guiWeaponDamageMinPhysical, (attr.damageWeaponMin_Physical + attr.damageWeaponBonusMin_Physical) * (ItemValueRange.One + attr.damageWeaponPercentBonus_Physical));
                populateData(guiWeaponDamageMinPoison, (attr.damageWeaponMin_Poison + attr.damageWeaponBonusMin_Poison) * (ItemValueRange.One + attr.damageWeaponPercentBonus_Poison));

                populateData(guiWeaponDamageMaxArcane, (attr.damageWeaponMin_Arcane + attr.damageWeaponDelta_Arcane + attr.damageWeaponBonusDelta_Arcane) * (ItemValueRange.One + attr.damageWeaponPercentBonus_Arcane));
                populateData(guiWeaponDamageMaxCold, (attr.damageWeaponMin_Cold + attr.damageWeaponDelta_Cold + attr.damageWeaponBonusDelta_Cold) * (ItemValueRange.One + attr.damageWeaponPercentBonus_Cold));
                populateData(guiWeaponDamageMaxFire, (attr.damageWeaponMin_Fire + attr.damageWeaponDelta_Fire + attr.damageWeaponBonusDelta_Fire) * (ItemValueRange.One + attr.damageWeaponPercentBonus_Fire));
                populateData(guiWeaponDamageMaxHoly, (attr.damageWeaponMin_Holy + attr.damageWeaponDelta_Holy + attr.damageWeaponBonusDelta_Holy) * (ItemValueRange.One + attr.damageWeaponPercentBonus_Holy));
                populateData(guiWeaponDamageMaxLightning, (attr.damageWeaponMin_Lightning + attr.damageWeaponDelta_Lightning + attr.damageWeaponBonusDelta_Lightning) * (ItemValueRange.One + attr.damageWeaponPercentBonus_Lightning));
                populateData(guiWeaponDamageMaxPhysical, (attr.damageWeaponMin_Physical + attr.damageWeaponDelta_Physical + attr.damageWeaponBonusDelta_Physical) * (ItemValueRange.One + attr.damageWeaponPercentBonus_Physical));
                populateData(guiWeaponDamageMaxPoison, (attr.damageWeaponMin_Poison + attr.damageWeaponDelta_Poison + attr.damageWeaponBonusDelta_Poison) * (ItemValueRange.One + attr.damageWeaponPercentBonus_Poison));

                // Item damage bonuses
                populateData(guiBonusDamageMinArcane, attr.damageMin_Arcane + attr.damageBonusMin_Arcane);
                populateData(guiBonusDamageMinCold, attr.damageMin_Cold + attr.damageBonusMin_Cold);
                populateData(guiBonusDamageMinFire, attr.damageMin_Fire + attr.damageBonusMin_Fire);
                populateData(guiBonusDamageMinHoly, attr.damageMin_Holy + attr.damageBonusMin_Holy);
                populateData(guiBonusDamageMinLightning, attr.damageMin_Lightning + attr.damageBonusMin_Lightning);
                populateData(guiBonusDamageMinPhysical, attr.damageMin_Physical + attr.damageBonusMin_Physical);
                populateData(guiBonusDamageMinPoison, attr.damageMin_Poison + attr.damageBonusMin_Poison);

                populateData(guiBonusDamageMaxArcane, attr.damageMin_Arcane + attr.damageDelta_Arcane);
                populateData(guiBonusDamageMaxCold, attr.damageMin_Cold + attr.damageDelta_Cold);
                populateData(guiBonusDamageMaxFire, attr.damageMin_Fire + attr.damageDelta_Fire);
                populateData(guiBonusDamageMaxHoly, attr.damageMin_Holy + attr.damageDelta_Holy);
                populateData(guiBonusDamageMaxLightning, attr.damageMin_Lightning + attr.damageDelta_Lightning);
                populateData(guiBonusDamageMaxPhysical, attr.damageMin_Physical + attr.damageDelta_Physical);
                populateData(guiBonusDamageMaxPoison, attr.damageMin_Poison + attr.damageDelta_Poison);

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

                // GemHelper
                if (item.gems != null)
                {
                    if (item.gems.Length >= 1)
                    {
                        selectActiveGem(guiGem1, gems1, item.gems[0]);
                    }
                    if (item.gems.Length >= 2)
                    {
                        selectActiveGem(guiGem2, gems2, item.gems[1]);
                    }
                    if (item.gems.Length >= 3)
                    {
                        selectActiveGem(guiGem3, gems3, item.gems[2]);
                    }
                }
            }
        }

        public Item getEditedItem()
        {
            Item item = new Item();
            ItemAttributes attr = new ItemAttributes();

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
            List<Item> gems = new List<Item>();

            if (guiGem1.SelectedIndex != 0)
            {
                gems.Add((Item)guiGem1.SelectedItem);
            }
            if (guiGem2.SelectedIndex != 0)
            {
                gems.Add((Item)guiGem2.SelectedItem);
            }
            if (guiGem3.SelectedIndex != 0)
            {
                gems.Add((Item)guiGem3.SelectedItem);
            }

            item.gems = gems.ToArray();

            return item;
        }

        private void GuiReset_Click(object sender, EventArgs e)
        {
            setEditedItem((Item)Tag);
        }
    }
}

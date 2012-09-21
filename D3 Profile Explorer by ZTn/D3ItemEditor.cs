using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator
{
    public partial class D3ItemEditor : UserControl
    {
        public D3ItemEditor()
        {
            InitializeComponent();
        }

        private void populateData(TextBox textBox, ItemValueRange itemValueRange)
        {
            if (itemValueRange != null)
                textBox.Text = itemValueRange.min.ToString();
        }

        public void setEditedItem(Item item)
        {
            Tag = item;

            ItemAttributes attr = item.attributesRaw;

            // Characteristics
            populateData(guiDexterity, attr.dexterityItem);
            populateData(guiStrength, attr.strengthItem);
            populateData(guiIntelligence, attr.intelligenceItem);
            populateData(guiVitality, attr.vitalityItem);
            populateData(guiAttackSpeed, attr.attacksPerSecondPercent);
            populateData(guiCriticChance, attr.critDamagePercent);
            populateData(guiCriticDamage, attr.critPercentBonusCapped);

            // Weapon Characterics
            populateData(guiWeaponAttackPerSecond, attr.attacksPerSecondItem);

            populateData(guiWeaponDamageMinArcane, attr.damageWeaponMin_Arcane + attr.damageWeaponBonusMin_Arcane);
            populateData(guiWeaponDamageMinCold, attr.damageWeaponMin_Cold + attr.damageWeaponBonusMin_Cold);
            populateData(guiWeaponDamageMinFire, attr.damageWeaponMin_Fire + attr.damageWeaponBonusMin_Fire);
            populateData(guiWeaponDamageMinLightning, attr.damageWeaponMin_Lightning + attr.damageWeaponBonusMin_Lightning);
            populateData(guiWeaponDamageMinPhysical, attr.damageWeaponMin_Physical + attr.damageWeaponBonusMin_Physical);
            populateData(guiWeaponDamageMinPoison, attr.damageWeaponMin_Poison + attr.damageWeaponBonusMin_Poison);

            populateData(guiWeaponDamageMaxArcane, attr.damageWeaponMin_Arcane + attr.damageWeaponDelta_Arcane + attr.damageWeaponBonusDelta_Arcane);
            populateData(guiWeaponDamageMaxCold, attr.damageWeaponMin_Cold + attr.damageWeaponDelta_Cold + attr.damageWeaponBonusDelta_Cold);
            populateData(guiWeaponDamageMaxFire, attr.damageWeaponMin_Fire + attr.damageWeaponDelta_Fire + attr.damageWeaponBonusDelta_Fire);
            populateData(guiWeaponDamageMaxLightning, attr.damageWeaponMin_Lightning + attr.damageWeaponDelta_Lightning + attr.damageWeaponBonusDelta_Lightning);
            populateData(guiWeaponDamageMaxPhysical, attr.damageWeaponMin_Physical + attr.damageWeaponDelta_Physical + attr.damageWeaponBonusDelta_Physical);
            populateData(guiWeaponDamageMaxPoison, attr.damageWeaponMin_Poison + attr.damageWeaponDelta_Poison + attr.damageWeaponBonusDelta_Poison);

            // Bonus characteristics
            populateData(guiBonusDamageMaxArcane, attr.damageMin_Arcane + attr.damageBonusMin_Arcane);
            populateData(guiBonusDamageMaxCold, attr.damageMin_Cold + attr.damageBonusMin_Cold);
            populateData(guiBonusDamageMaxFire, attr.damageMin_Fire + attr.damageBonusMin_Fire);
            populateData(guiBonusDamageMaxLightning, attr.damageMin_Lightning + attr.damageBonusMin_Lightning);
            populateData(guiBonusDamageMaxPhysical, attr.damageMin_Physical + attr.damageBonusMin_Physical);
            populateData(guiBonusDamageMaxPoison, attr.damageMin_Poison + attr.damageBonusMin_Poison);
        }
    }
}

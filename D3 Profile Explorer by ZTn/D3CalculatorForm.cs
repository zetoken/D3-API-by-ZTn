using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZTn.BNet.D3.Calculator;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3ProfileExplorer
{
    public partial class D3CalculatorForm : Form
    {
        #region >> Fields

        Hero hero;

        Item bracers;
        Item feet;
        Item hands;
        Item head;
        Item leftFinger;
        Item legs;
        Item neck;
        Item rightFinger;
        Item shoulders;
        Item torso;
        Item waist;

        #endregion

        #region >> Constructors

        public D3CalculatorForm()
        {
            InitializeComponent();

            guiHeroClass.DataSource = new List<String>() { "barbarian", "demon-hunter", "monk", "witch-doctor", "wizard" };
        }

        public D3CalculatorForm(Hero hero)
            : this()
        {
            this.hero = hero;

            guiHeroClass.SelectedItem = hero.heroClass;
            guiHeroLevel.Text = hero.level.ToString();
            guiHeroParagonLevel.Text = hero.paragonLevel.ToString();

            if (hero.items.bracers != null)
                bracers = Item.getItemFromTooltipParams(hero.items.bracers.tooltipParams);
            if (hero.items.feet != null)
                feet = Item.getItemFromTooltipParams(hero.items.feet.tooltipParams);
            if (hero.items.hands != null)
                hands = Item.getItemFromTooltipParams(hero.items.hands.tooltipParams);
            if (hero.items.head != null)
                head = Item.getItemFromTooltipParams(hero.items.head.tooltipParams);
            if (hero.items.leftFinger != null)
                leftFinger = Item.getItemFromTooltipParams(hero.items.leftFinger.tooltipParams);
            if (hero.items.legs != null)
                legs = Item.getItemFromTooltipParams(hero.items.legs.tooltipParams);
            if (hero.items.neck != null)
                neck = Item.getItemFromTooltipParams(hero.items.neck.tooltipParams);
            if (hero.items.rightFinger != null)
                rightFinger = Item.getItemFromTooltipParams(hero.items.rightFinger.tooltipParams);
            if (hero.items.shoulders != null)
                shoulders = Item.getItemFromTooltipParams(hero.items.shoulders.tooltipParams);
            if (hero.items.torso != null)
                torso = Item.getItemFromTooltipParams(hero.items.torso.tooltipParams);
            if (hero.items.waist != null)
                waist = Item.getItemFromTooltipParams(hero.items.waist.tooltipParams);

            Item mainHand = Item.getItemFromTooltipParams(hero.items.mainHand.tooltipParams);

            Item offHand;
            if (hero.items.offHand != null)
                offHand = Item.getItemFromTooltipParams(hero.items.offHand.tooltipParams);
            else
                offHand = new Item(new ItemAttributes());

            guiMainHandEditor.setEditedItem(mainHand);
            guiOffHandEditor.setEditedItem(offHand);
            guiBracersEditor.setEditedItem(bracers);
            guiFeetEditor.setEditedItem(feet);
            guiHandsEditor.setEditedItem(hands);
            guiHeadEditor.setEditedItem(head);
            guiLeftFingerEditor.setEditedItem(leftFinger);
            guiLegsEditor.setEditedItem(legs);
            guiNeckEditor.setEditedItem(neck);
            guiRightFingerEditor.setEditedItem(rightFinger);
            guiShouldersEditor.setEditedItem(shoulders);
            guiTorsoEditor.setEditedItem(torso);
            guiWaistEditor.setEditedItem(waist);
        }

        #endregion

        private Hero getEditedHero()
        {
            Hero hero = new Hero();
            hero.heroClass = (String)guiHeroClass.SelectedItem;

            if (String.IsNullOrEmpty(guiHeroLevel.Text))
                hero.level = 60;
            else
                hero.level = Int32.Parse(guiHeroLevel.Text);

            if (String.IsNullOrEmpty(guiHeroParagonLevel.Text))
                hero.paragonLevel = 0;
            else
                hero.paragonLevel = Int32.Parse(guiHeroParagonLevel.Text);

            return hero;
        }

        private void guiDoCalculations_Click(object sender, EventArgs e)
        {
            hero = getEditedHero();

            List<Item> items = new List<Item>();
            items.Add(guiBracersEditor.getEditedItem());
            items.Add(guiFeetEditor.getEditedItem());
            items.Add(guiHandsEditor.getEditedItem());
            items.Add(guiHeadEditor.getEditedItem());
            items.Add(guiLeftFingerEditor.getEditedItem());
            items.Add(guiLegsEditor.getEditedItem());
            items.Add(guiNeckEditor.getEditedItem());
            items.Add(guiRightFingerEditor.getEditedItem());
            items.Add(guiShouldersEditor.getEditedItem());
            items.Add(guiTorsoEditor.getEditedItem());
            items.Add(guiWaistEditor.getEditedItem());

            Item mainHand = guiMainHandEditor.getEditedItem();

            Item offHand = guiOffHandEditor.getEditedItem();

            Item multipliedBonus = new Item();
            multipliedBonus.attributesRaw = new ItemAttributes();

            Item addedBonus = new Item();
            addedBonus.attributesRaw = new ItemAttributes();
            if (guiSkillCriticDamage50Percent.Checked)
                addedBonus.attributesRaw += new ItemAttributes() { critDamagePercent = new ItemValueRange(0.5) };
            if (guiSkillCriticChance3Percent.Checked)
                addedBonus.attributesRaw += new ItemAttributes() { critPercentBonusCapped = new ItemValueRange(0.03) };
            if (guiSkillCriticChance10Percent.Checked)
                addedBonus.attributesRaw += new ItemAttributes() { critPercentBonusCapped = new ItemValueRange(0.10) };
            if (guiSkillAttackSpeed3Percent.Checked)
                addedBonus.attributesRaw += new ItemAttributes() { attacksPerSecondItem = new ItemValueRange(0.03) };

            double skillBonus = 0;
            if (guiSkillDamage15Percent.Checked)
                skillBonus += 0.15;
            if (guiSkillDamage20Percent.Checked)
                skillBonus += 0.20;

            D3Calculator d3Calculator = new D3Calculator(hero, mainHand, offHand, items.ToArray());
            Item globalItem = d3Calculator.heroStuff;

            guiCalculatedDPS.Text = d3Calculator.getHeroDPS().ToString();
            guiCalculatedAttackPerSecond.Text = d3Calculator.getActualAttackSpeed().ToString();
            guiCalcultatedDamageMin.Text = (d3Calculator.heroStuff.getWeaponDamageMin() * d3Calculator.getDamageMultiplierNormal()).ToString();
            guiCalcultatedDamageMax.Text = (d3Calculator.heroStuff.getWeaponDamageMax() * d3Calculator.getDamageMultiplierNormal()).ToString();
            guiCalcultatedDamageCriticMin.Text = (d3Calculator.heroStuff.getWeaponDamageMin() * d3Calculator.getDamageMultiplierCritic()).ToString();
            guiCalcultatedDamageCriticMax.Text = (d3Calculator.heroStuff.getWeaponDamageMax() * d3Calculator.getDamageMultiplierCritic()).ToString();
            guiCalculatedHitpoints.Text = d3Calculator.getHeroHitpoints().ToString();
            guiCalculatedArmor.Text = d3Calculator.getHeroArmor().ToString();
            guiCalculatedResistance_Arcane.Text = d3Calculator.getHeroResistance_Arcane().ToString();
            guiCalculatedResistance_Cold.Text = d3Calculator.getHeroResistance_Cold().ToString();
            guiCalculatedResistance_Fire.Text = d3Calculator.getHeroResistance_Fire().ToString();
            guiCalculatedResistance_Lightning.Text = d3Calculator.getHeroResistance_Lightning().ToString();
            guiCalculatedResistance_Physical.Text = d3Calculator.getHeroResistance_Physical().ToString();
            guiCalculatedResistance_Poison.Text = d3Calculator.getHeroResistance_Poison().ToString();
            guiCalculatedResistance_All.Text = d3Calculator.getHeroResistance_All().ToString();

            guiCalculatedDPSWithBuffs.Text = d3Calculator.getHeroDPS(addedBonus, multipliedBonus, skillBonus).ToString();
            guiCalculatedAttackPerSecondWithBuffs.Text = d3Calculator.getActualAttackSpeed().ToString();
            guiCalcultatedDamageMinWithBuffs.Text = (d3Calculator.heroStuff.getWeaponDamageMin() * d3Calculator.getDamageMultiplierNormal()).ToString();
            guiCalcultatedDamageMaxWithBuffs.Text = (d3Calculator.heroStuff.getWeaponDamageMax() * d3Calculator.getDamageMultiplierNormal()).ToString();
            guiCalcultatedDamageCriticMinWithBuffs.Text = (d3Calculator.heroStuff.getWeaponDamageMin() * d3Calculator.getDamageMultiplierCritic()).ToString();
            guiCalcultatedDamageCriticMaxWithBuffs.Text = (d3Calculator.heroStuff.getWeaponDamageMax() * d3Calculator.getDamageMultiplierCritic()).ToString();

            populateCalculatedData(guiItemsDexterity, d3Calculator.heroStuff.attributesRaw.dexterityItem);
            populateCalculatedData(guiItemsIntelligence, d3Calculator.heroStuff.attributesRaw.intelligenceItem);
            populateCalculatedData(guiItemsStrength, d3Calculator.heroStuff.attributesRaw.strengthItem);
            populateCalculatedData(guiItemsVitality, d3Calculator.heroStuff.attributesRaw.vitalityItem);
            populateCalculatedDataPercent(guiItemsCriticChance, d3Calculator.heroStuff.attributesRaw.critPercentBonusCapped);
            populateCalculatedDataPercent(guiItemsSpeedAttack, d3Calculator.heroStuff.attributesRaw.attacksPerSecondPercent);
            populateCalculatedDataPercent(guiItemsCriticDamage, d3Calculator.heroStuff.attributesRaw.critDamagePercent);
            populateCalculatedDataPercent(guiItemsLifePercent, d3Calculator.heroStuff.attributesRaw.hitpointsMaxPercentBonusItem);
            populateCalculatedData(guiItemsResistance_All, d3Calculator.heroStuff.attributesRaw.resistanceAll);
            populateCalculatedData(guiItemsResistance_Arcane, d3Calculator.heroStuff.attributesRaw.resistance_Arcane);
            populateCalculatedData(guiItemsResistance_Cold, d3Calculator.heroStuff.attributesRaw.resistance_Cold);
            populateCalculatedData(guiItemsResistance_Fire, d3Calculator.heroStuff.attributesRaw.resistance_Fire);
            populateCalculatedData(guiItemsResistance_Lightning, d3Calculator.heroStuff.attributesRaw.resistance_Lightning);
            populateCalculatedData(guiItemsResistance_Physical, d3Calculator.heroStuff.attributesRaw.resistance_Physical);
            populateCalculatedData(guiItemsResistance_Poison, d3Calculator.heroStuff.attributesRaw.resistance_Poison);
        }

        private void populateCalculatedData(TextBox textBox, ItemValueRange itemValueRange)
        {
            if (itemValueRange != null)
                textBox.Text = itemValueRange.min.ToString();
        }

        private void populateCalculatedDataPercent(TextBox textBox, ItemValueRange itemValueRange)
        {
            if (itemValueRange != null)
                textBox.Text = (100 * itemValueRange.min).ToString();
        }
    }
}

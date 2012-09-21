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

        public D3CalculatorForm()
        {
            InitializeComponent();
        }

        public D3CalculatorForm(Hero hero)
            : this()
        {
            this.hero = hero;

            bracers = Item.getItemFromTooltipParams(hero.items.bracers.tooltipParams);
            feet = Item.getItemFromTooltipParams(hero.items.feet.tooltipParams);
            hands = Item.getItemFromTooltipParams(hero.items.hands.tooltipParams);
            head = Item.getItemFromTooltipParams(hero.items.head.tooltipParams);
            leftFinger = Item.getItemFromTooltipParams(hero.items.leftFinger.tooltipParams);
            legs = Item.getItemFromTooltipParams(hero.items.legs.tooltipParams);
            neck = Item.getItemFromTooltipParams(hero.items.neck.tooltipParams);
            rightFinger = Item.getItemFromTooltipParams(hero.items.rightFinger.tooltipParams);
            shoulders = Item.getItemFromTooltipParams(hero.items.shoulders.tooltipParams);
            torso = Item.getItemFromTooltipParams(hero.items.torso.tooltipParams);
            waist = Item.getItemFromTooltipParams(hero.items.waist.tooltipParams);

            Item mainHand = Item.getItemFromTooltipParams(hero.items.mainHand.tooltipParams);

            Item offHand;
            if (hero.items.offHand != null)
                offHand = Item.getItemFromTooltipParams(hero.items.offHand.tooltipParams);
            else
            {
                offHand = new Item();
                offHand.attributesRaw = new ItemAttributes();
            }

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

        private void guiDoCalculations_Click(object sender, EventArgs e)
        {
            List<Item> items = new List<Item>();
            items.Add(bracers);
            items.Add(feet);
            items.Add(hands);
            items.Add(head);
            items.Add(leftFinger);
            items.Add(legs);
            items.Add(neck);
            items.Add(rightFinger);
            items.Add(shoulders);
            items.Add(torso);
            items.Add(waist);

            Item mainHand = Item.getItemFromTooltipParams(hero.items.mainHand.tooltipParams);

            Item offHand = null;
            if (hero.items.offHand != null)
                offHand = Item.getItemFromTooltipParams(hero.items.offHand.tooltipParams);
            else
            {
                offHand = new Item();
                offHand.attributesRaw = new ItemAttributes();
            }

            Item multipliedBonus = new Item();
            multipliedBonus.attributesRaw = new ItemAttributes();

            Item addedBonus = new Item();
            addedBonus.attributesRaw = new ItemAttributes();
            addedBonus.attributesRaw.critDamagePercent = new ItemValueRange(0.1); // TODO: AUTOMATE THAT +10% CRITIC DAMAGE and all

            double skillBonus = 0;

            D3Calculator d3Calculator = new D3Calculator(mainHand, offHand, items.ToArray());
            Item globalItem = d3Calculator.heroStuff;

            guiCalculatedDPS.Text = d3Calculator.getHeroDPS(hero.level, hero.paragonLevel).ToString();
            guiCalculatedAttackPerSecond.Text = d3Calculator.heroStuff.getWeaponAttackPerSecond().ToString();
            guiCalcultatedDamageMin.Text = (d3Calculator.heroStuff.getWeaponDamageMin() * d3Calculator.getDamageMultiplierNormal(hero.level, hero.paragonLevel)).ToString();
            guiCalcultatedDamageMax.Text = (d3Calculator.heroStuff.getWeaponDamageMax() * d3Calculator.getDamageMultiplierNormal(hero.level, hero.paragonLevel)).ToString();
            guiCalcultatedDamageCriticMin.Text = (d3Calculator.heroStuff.getWeaponDamageMin() * d3Calculator.getDamageMultiplierCritic(hero.level, hero.paragonLevel)).ToString();
            guiCalcultatedDamageCriticMax.Text = (d3Calculator.heroStuff.getWeaponDamageMax() * d3Calculator.getDamageMultiplierCritic(hero.level, hero.paragonLevel)).ToString();

            guiCalculatedDPSWithBuffs.Text = d3Calculator.getHeroDPS(hero.level, hero.paragonLevel, addedBonus, multipliedBonus, skillBonus).ToString();
            guiCalculatedAttackPerSecondWithBuffs.Text = d3Calculator.heroStuff.getWeaponAttackPerSecond().ToString();
            guiCalcultatedDamageMinWithBuffs.Text = (d3Calculator.heroStuff.getWeaponDamageMin() * d3Calculator.getDamageMultiplierNormal(hero.level, hero.paragonLevel)).ToString();
            guiCalcultatedDamageMaxWithBuffs.Text = (d3Calculator.heroStuff.getWeaponDamageMax() * d3Calculator.getDamageMultiplierNormal(hero.level, hero.paragonLevel)).ToString();
            guiCalcultatedDamageCriticMinWithBuffs.Text = (d3Calculator.heroStuff.getWeaponDamageMin() * d3Calculator.getDamageMultiplierCritic(hero.level, hero.paragonLevel)).ToString();
            guiCalcultatedDamageCriticMaxWithBuffs.Text = (d3Calculator.heroStuff.getWeaponDamageMax() * d3Calculator.getDamageMultiplierCritic(hero.level, hero.paragonLevel)).ToString();
        }

        private void populateItemEditorData(TextBox textBox, ItemValueRange itemValueRange)
        {
            if (itemValueRange != null)
                textBox.Text = itemValueRange.min.ToString();
        }
    }
}

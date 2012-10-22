using System;
using System.Collections.Generic;
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

            D3Calculator d3Calculator = new D3Calculator(hero, mainHand, offHand, items.ToArray());
            Item globalItem = d3Calculator.heroStuff;

            Item addedBonus = new Item();
            addedBonus.attributesRaw = new ItemAttributes();

            // Barbarian skills
            if (guiSkillNervesOfSteel.Checked)
                addedBonus.attributesRaw += (new D3.Calculator.Skills.Barbarian.NervesOfSteel()).getBonus(d3Calculator);
            if (guiSkillWeaponsMaster_MaceAxe.Checked)
                addedBonus.attributesRaw += (new D3.Calculator.Skills.Barbarian.WeaponsMaster_MaceAxe()).getBonus(d3Calculator);
            if (guiSkillWeaponsMaster_PolearmSpear.Checked)
                addedBonus.attributesRaw += (new D3.Calculator.Skills.Barbarian.WeaponsMaster_PolearmSpear()).getBonus(d3Calculator);
            if (guiSkillWeaponsMaster_SwordDagguer.Checked)
                addedBonus.attributesRaw += (new D3.Calculator.Skills.Barbarian.WeaponsMaster_SwordDagguer()).getBonus(d3Calculator);
            if (guiSkillToughAsNails.Checked)
                addedBonus.attributesRaw += (new D3.Calculator.Skills.Barbarian.ToughAsNails()).getBonus(d3Calculator);
            if (guiSkillRuthless.Checked)
                addedBonus.attributesRaw += (new D3.Calculator.Skills.Barbarian.Ruthless()).getBonus(d3Calculator);

            // Demon Hunter skills
            if (guiSkillArchery_Bow.Checked)
                addedBonus.attributesRaw += (new D3.Calculator.Skills.DemonHunter.Archery_Bow()).getBonus(d3Calculator);
            if (guiSkillArchery_Crossbow.Checked)
                addedBonus.attributesRaw += (new D3.Calculator.Skills.DemonHunter.Archery_Crossbow()).getBonus(d3Calculator);
            if (guiSkillArchery_HandCrossbow.Checked)
                addedBonus.attributesRaw += (new D3.Calculator.Skills.DemonHunter.Archery_HandCrossbow()).getBonus(d3Calculator);
            if (guiSkillSteadyAim.Checked)
                addedBonus.attributesRaw += (new D3.Calculator.Skills.DemonHunter.SteadyAim()).getBonus(d3Calculator);
            if (guiSkillSharpShooter.Checked)
                addedBonus.attributesRaw += (new D3.Calculator.Skills.DemonHunter.SharpShooter()).getBonus(d3Calculator);
            if (guiSkillPerfectionnist.Checked)
                addedBonus.attributesRaw += (new D3.Calculator.Skills.DemonHunter.Perfectionnist()).getBonus(d3Calculator);

            // Monk skills
            if (guiSkillSeizeTheInitiative.Checked)
                addedBonus.attributesRaw += (new D3.Calculator.Skills.Monk.SeizeTheInitiative()).getBonus(d3Calculator);
            if (guiSkillOneWithEverything.Checked)
                addedBonus.attributesRaw += (new D3.Calculator.Skills.Monk.OneWithEverything()).getBonus(d3Calculator);
            if (guiSkillMantraOfHealing_TimeOfNeed.Checked)
                addedBonus.attributesRaw += (new D3.Calculator.Skills.Monk.MantraOfHealing_TimeOfNeed()).getBonus(d3Calculator);

            // Witch Doctor skills
            if (guiSkillPierceTheVeil.Checked)
                addedBonus.attributesRaw += (new D3.Calculator.Skills.WitchDoctor.PierceTheVeil()).getBonus(d3Calculator);

            // Wizard skills
            if (guiSkillGlassCannon.Checked)
                addedBonus.attributesRaw += (new D3.Calculator.Skills.Wizard.GlassCannon()).getBonus(d3Calculator);
            if (guiSkillGalvanizingWard.Checked)
                addedBonus.attributesRaw += (new D3.Calculator.Skills.Wizard.GalvanizingWard()).getBonus(d3Calculator);

            // Followers buffs are applied after class skills
            d3Calculator.getHeroDPS(addedBonus);

            if (guiSkillAnatomy.Checked)
                addedBonus.attributesRaw += (new D3.Calculator.Skills.Followers.Anatomy()).getBonus(d3Calculator);
            if (guiSkillFocusedMind.Checked)
                addedBonus.attributesRaw += (new D3.Calculator.Skills.Followers.FocusedMind()).getBonus(d3Calculator);
            if (guiSkillPoweredArmor.Checked)
                addedBonus.attributesRaw += (new D3.Calculator.Skills.Followers.PoweredArmor()).getBonus(d3Calculator);

            guiCalculatedDPS.Text = d3Calculator.getHeroDPS(addedBonus).ToString();

            updateItemsSummary(d3Calculator);

            updateCalculationResults(d3Calculator);
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

        private void updateItemsSummary(D3Calculator d3Calculator)
        {
            ItemAttributes attr = d3Calculator.heroStuff.attributesRaw;

            populateCalculatedData(guiItemsDexterity, attr.dexterityItem);
            populateCalculatedData(guiItemsIntelligence, attr.intelligenceItem);
            populateCalculatedData(guiItemsStrength, attr.strengthItem);
            populateCalculatedData(guiItemsVitality, attr.vitalityItem);

            populateCalculatedDataPercent(guiItemsCriticChance, attr.critPercentBonusCapped);
            populateCalculatedDataPercent(guiItemsSpeedAttack, attr.attacksPerSecondPercent);
            populateCalculatedDataPercent(guiItemsCriticDamage, attr.critDamagePercent);
            populateCalculatedDataPercent(guiItemsLifePercent, attr.hitpointsMaxPercentBonusItem);
            populateCalculatedData(guiItemsLifeOnHit, attr.hitpointsOnHit);
            populateCalculatedData(guiItemsLifePerSecond, attr.hitpointsRegenPerSecond);

            populateCalculatedData(guiItemsResistance_All, attr.resistance_All);
            populateCalculatedData(guiItemsResistance_Arcane, attr.resistance_Arcane);
            populateCalculatedData(guiItemsResistance_Cold, attr.resistance_Cold);
            populateCalculatedData(guiItemsResistance_Fire, attr.resistance_Fire);
            populateCalculatedData(guiItemsResistance_Lightning, attr.resistance_Lightning);
            populateCalculatedData(guiItemsResistance_Physical, attr.resistance_Physical);
            populateCalculatedData(guiItemsResistance_Poison, attr.resistance_Poison);
        }

        private void updateCalculationResults(D3Calculator d3Calculator)
        {
            ItemAttributes attr = d3Calculator.heroStuff.attributesRaw;

            guiCalculatedAttackPerSecond.Text = d3Calculator.getActualAttackSpeed().ToString();
            guiCalcultatedDamageMin.Text = (d3Calculator.heroStuff.getWeaponDamageMin() * d3Calculator.getDamageMultiplierNormal()).ToString();
            guiCalcultatedDamageMax.Text = (d3Calculator.heroStuff.getWeaponDamageMax() * d3Calculator.getDamageMultiplierNormal()).ToString();
            guiCalcultatedDamageCriticMin.Text = (d3Calculator.heroStuff.getWeaponDamageMin() * d3Calculator.getDamageMultiplierCritic()).ToString();
            guiCalcultatedDamageCriticMax.Text = (d3Calculator.heroStuff.getWeaponDamageMax() * d3Calculator.getDamageMultiplierCritic()).ToString();
            guiCalculatedHitpoints.Text = d3Calculator.getHeroHitpoints().ToString();
            guiCalculatedDodge.Text = d3Calculator.getHeroDodge().ToString();

            guiCalculatedArmor.Text = d3Calculator.getHeroArmor().ToString();
            guiCalculatedResistance_Arcane.Text = d3Calculator.getHeroResistance_Arcane().ToString();
            guiCalculatedResistance_Cold.Text = d3Calculator.getHeroResistance_Cold().ToString();
            guiCalculatedResistance_Fire.Text = d3Calculator.getHeroResistance_Fire().ToString();
            guiCalculatedResistance_Lightning.Text = d3Calculator.getHeroResistance_Lightning().ToString();
            guiCalculatedResistance_Physical.Text = d3Calculator.getHeroResistance_Physical().ToString();
            guiCalculatedResistance_Poison.Text = d3Calculator.getHeroResistance_Poison().ToString();
            guiCalculatedResistance_All.Text = d3Calculator.getHeroResistance_All().ToString();

            guiCalculatedDamageReduction_Armor.Text = (100 * d3Calculator.getHeroDamageReduction_Armor(hero.level)).ToString();
            guiCalculatedDamageReduction_Arcane.Text = (100 * d3Calculator.getHeroDamageReduction_Arcane(hero.level)).ToString();
            guiCalculatedDamageReduction_Cold.Text = (100 * d3Calculator.getHeroDamageReduction_Cold(hero.level)).ToString();
            guiCalculatedDamageReduction_Fire.Text = (100 * d3Calculator.getHeroDamageReduction_Fire(hero.level)).ToString();
            guiCalculatedDamageReduction_Lightning.Text = (100 * d3Calculator.getHeroDamageReduction_Lightning(hero.level)).ToString();
            guiCalculatedDamageReduction_Physical.Text = (100 * d3Calculator.getHeroDamageReduction_Physical(hero.level)).ToString();
            guiCalculatedDamageReduction_Poison.Text = (100 * d3Calculator.getHeroDamageReduction_Poison(hero.level)).ToString();

            populateCalculatedData(guiCalculatedBlockChance, attr.blockChanceItem);
            populateCalculatedData(guiCalculatedBlockMin, attr.blockAmountItemMin);
            populateCalculatedData(guiCalculatedBlockMax, attr.blockAmountItemMin + attr.blockAmountItemDelta);

            guiCalculatedEffectiveHitpoints.Text = Math.Round(d3Calculator.getHeroEffectiveHitpoints(hero.level)).ToString();
            guiCalculatedDPSEHPRatio.Text = Math.Round(d3Calculator.getHeroDPS() * d3Calculator.getHeroEffectiveHitpoints(hero.level) / 1000000).ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ZTn.BNet.D3.Calculator;
using ZTn.BNet.D3.Calculator.Gems;
using ZTn.BNet.D3.Calculator.Helpers;
using ZTn.BNet.D3.Calculator.Skills;
using ZTn.BNet.D3.Calculator.Skills.Barbarian;
using ZTn.BNet.D3.Calculator.Skills.Followers;
using ZTn.BNet.D3.Calculator.Skills.Monk;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.HeroFollowers;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3ProfileExplorer
{
    public sealed partial class D3CalculatorForm : Form
    {
        #region >> Fields

        int heroLevel;

        readonly Item special;
        readonly Item bracers;
        readonly Item feet;
        readonly Item hands;
        readonly Item head;
        readonly Item leftFinger;
        readonly Item legs;
        readonly Item neck;
        readonly Item rightFinger;
        readonly Item shoulders;
        readonly Item torso;
        readonly Item waist;

        readonly List<CheckBox> passiveCheckBoxes;

        #endregion

        #region >> Constructors

        public D3CalculatorForm()
        {
            InitializeComponent();

            guiHeroClass.DataSource = new List<String> {
                HeroClass.Barbarian.ToString(),
                HeroClass.DemonHunter.ToString(),
                HeroClass.Monk.ToString(), 
                HeroClass.WitchDoctor.ToString(), 
                HeroClass.Wizard.ToString(),
                HeroClass.EnchantressFollower.ToString(),
                HeroClass.ScoundrelFollower.ToString(),
                HeroClass.TemplarFollower.ToString()
            };

            var knownGems = KnownGems.GetKnownGemsFromJsonFile("d3gem.json");

            List<D3ItemEditor> d3ItemEditors = new List<D3ItemEditor>
            {
                guiMainHandEditor,
                guiOffHandEditor,
                guiSpecialEditor,
                guiBracersEditor,
                guiFeetEditor,
                guiHandsEditor,
                guiHeadEditor,
                guiLeftFingerEditor,
                guiLegsEditor,
                guiNeckEditor,
                guiRightFingerEditor,
                guiShouldersEditor,
                guiTorsoEditor,
                guiWaistEditor,
                guiSetBonusEditor
            };

            passiveCheckBoxes = new List<CheckBox>
            {
                //  Barbarian passive skills
                guiSkillNervesOfSteel,
                guiSkillWeaponsMaster,
                guiSkillToughAsNails,
                guiSkillRuthless,

                // Demon Hunter passive skills
                guiSkillArchery,
                guiSkillSteadyAim,
                guiSkillSharpShooter,
                guiSkillPerfectionnist,

                // Monk passive skills
                guiSkillSeizeTheInitiative,
                guiSkillOneWithEverything,

                // Witch Doctor skills
                guiSkillPierceTheVeil,

                // Wizard skills
                guiSkillGlassCannon,
                guiSkillGalvanizingWard
            };

            foreach (var d3ItemEditor in d3ItemEditors)
            {
                d3ItemEditor.KnownGems = knownGems;
            }

        }

        public D3CalculatorForm(Hero hero)
            : this()
        {
            Item offHand;
            Item mainHand;
            Text += " [ " + hero.name + " ]";

            guiHeroClass.SelectedItem = hero.heroClass.ToString();
            guiHeroLevel.Text = hero.level.ToString();
            guiHeroParagonLevel.Text = hero.paragonLevel.ToString();

            if (hero.items.bracers != null)
                bracers = hero.items.bracers.GetFullItem();
            if (hero.items.feet != null)
                feet = hero.items.feet.GetFullItem();
            if (hero.items.hands != null)
                hands = hero.items.hands.GetFullItem();
            if (hero.items.head != null)
                head = hero.items.head.GetFullItem();
            if (hero.items.leftFinger != null)
                leftFinger = hero.items.leftFinger.GetFullItem();
            if (hero.items.legs != null)
                legs = hero.items.legs.GetFullItem();
            if (hero.items.neck != null)
                neck = hero.items.neck.GetFullItem();
            if (hero.items.rightFinger != null)
                rightFinger = hero.items.rightFinger.GetFullItem();
            if (hero.items.shoulders != null)
                shoulders = hero.items.shoulders.GetFullItem();
            if (hero.items.torso != null)
                torso = hero.items.torso.GetFullItem();
            if (hero.items.waist != null)
                waist = hero.items.waist.GetFullItem();

            // If no weapon is set in mainHand, use "naked hand" weapon
            if (hero.items.mainHand != null)
                mainHand = hero.items.mainHand.GetFullItem();
            else
                mainHand = D3Calculator.NakedHandWeapon;

            // If no item is set in offHand, use a blank item
            if (hero.items.offHand != null)
                offHand = hero.items.offHand.GetFullItem();
            else
                offHand = D3Calculator.BlankWeapon;

            var allRawItems = new List<Item> { bracers, feet, hands, head, leftFinger, legs, neck, rightFinger, shoulders, torso, waist, mainHand, offHand };

            guiMainHandEditor.SetEditedItem(mainHand);
            guiOffHandEditor.SetEditedItem(offHand);
            guiBracersEditor.SetEditedItem(bracers);
            guiFeetEditor.SetEditedItem(feet);
            guiHandsEditor.SetEditedItem(hands);
            guiHeadEditor.SetEditedItem(head);
            guiLeftFingerEditor.SetEditedItem(leftFinger);
            guiLegsEditor.SetEditedItem(legs);
            guiNeckEditor.SetEditedItem(neck);
            guiRightFingerEditor.SetEditedItem(rightFinger);
            guiShouldersEditor.SetEditedItem(shoulders);
            guiTorsoEditor.SetEditedItem(torso);
            guiWaistEditor.SetEditedItem(waist);

            guiSetBonusEditor.SetEditedItem(new Item(allRawItems.Where(i => i != null).ToList().GetActivatedSetBonus()));

            PopulatePassiveSkills(hero);
            PopulateActiveSkills(hero);
        }

        public D3CalculatorForm(Follower follower, HeroClass heroClass)
            : this()
        {
            Item offHand;
            Item mainHand;
            Text += " [ " + follower.slug + " ]";

            guiHeroClass.SelectedItem = heroClass.ToString();
            guiHeroLevel.Text = follower.level.ToString();
            guiHeroParagonLevel.Text = "0";

            if (follower.items.special != null)
                special = follower.items.special.GetFullItem();
            if (follower.items.leftFinger != null)
                leftFinger = follower.items.leftFinger.GetFullItem();
            if (follower.items.neck != null)
                neck = follower.items.neck.GetFullItem();
            if (follower.items.rightFinger != null)
                rightFinger = follower.items.rightFinger.GetFullItem();

            // If no weapon is set in mainHand, use "naked hand" weapon
            if (follower.items.mainHand != null)
                mainHand = follower.items.mainHand.GetFullItem();
            else
                mainHand = D3Calculator.NakedHandWeapon;

            // If no item is set in offHand, use a blank item
            if (follower.items.offHand != null)
                offHand = follower.items.offHand.GetFullItem();
            else
                offHand = D3Calculator.BlankWeapon;

            var allRawItems = new List<Item> { special, leftFinger, neck, rightFinger, mainHand, offHand };

            guiSpecialEditor.SetEditedItem(special);
            guiMainHandEditor.SetEditedItem(mainHand);
            guiOffHandEditor.SetEditedItem(offHand);
            guiLeftFingerEditor.SetEditedItem(leftFinger);
            guiNeckEditor.SetEditedItem(neck);
            guiRightFingerEditor.SetEditedItem(rightFinger);

            guiSetBonusEditor.SetEditedItem(new Item(allRawItems.Where(i => i != null).ToList().GetActivatedSetBonus()));

            //populatePassiveSkills();
            //populateActiveSkills();
        }

        #endregion

        private Hero GetEditedHero()
        {
            var hero = new Hero();
            hero.heroClass = (HeroClass)Enum.Parse(typeof(HeroClass), (String)(guiHeroClass.SelectedItem));

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

        private Follower GetEditedFollower()
        {
            var follower = new Follower();

            if (String.IsNullOrEmpty(guiHeroLevel.Text))
                follower.level = 60;
            else
                follower.level = Int32.Parse(guiHeroLevel.Text);

            return follower;
        }

        private void guiDoCalculations_Click(object sender, EventArgs e)
        {
            var heroClass = (HeroClass)Enum.Parse(typeof(HeroClass), (String)(guiHeroClass.SelectedItem));

            switch (heroClass)
            {
                case HeroClass.Barbarian:
                case HeroClass.DemonHunter:
                case HeroClass.Monk:
                case HeroClass.WitchDoctor:
                case HeroClass.Wizard:
                    GuiDoCalculationsForHero();
                    break;
                case HeroClass.EnchantressFollower:
                case HeroClass.ScoundrelFollower:
                case HeroClass.TemplarFollower:
                    GuiDoCalculationsForFollower();
                    break;
            }
        }

        private void GuiDoCalculationsForHero()
        {
            // Retrieve hero from the GUI
            var hero = GetEditedHero();
            heroLevel = hero.level;

            // Retrieve worn items from the GUI
            var items = new List<Item>
            {
                guiBracersEditor.GetEditedItem(),
                guiFeetEditor.GetEditedItem(),
                guiHandsEditor.GetEditedItem(),
                guiHeadEditor.GetEditedItem(),
                guiLeftFingerEditor.GetEditedItem(),
                guiLegsEditor.GetEditedItem(),
                guiNeckEditor.GetEditedItem(),
                guiRightFingerEditor.GetEditedItem(),
                guiShouldersEditor.GetEditedItem(),
                guiTorsoEditor.GetEditedItem(),
                guiWaistEditor.GetEditedItem(),
                guiSetBonusEditor.GetEditedItem()
            };

            var mainHand = guiMainHandEditor.GetEditedItem();

            var offHand = guiOffHandEditor.GetEditedItem();

            var d3Calculator = new D3Calculator(hero, mainHand, offHand, items.ToArray());

            // Retrieve used skills from the GUI
            var passiveSkills = passiveCheckBoxes
                .Where(p => p.Checked)
                .Select(checkBox => PassiveSkillModifierFactory.GetFromSlug(checkBox.Tag as string))
                .ToList();

            // Some buffs are applied after passives skills: followers skills and active skills
            var activeSkills = new List<ID3SkillModifier>();

            // Barbarian active skills
            if (guiSkillWarCry_Invigorate.Checked)
                activeSkills.Add(new WarCry_Invigorate());

            // Demon Hunter active skills

            // Monk active skills
            if (guiSkillMantraOfHealing_TimeOfNeed.Checked)
                activeSkills.Add(new MantraOfHealing_TimeOfNeed());
            if (guiSkillMantraOfEvasion_HardTarget.Checked)
                activeSkills.Add(new MantraOfEvasion_HardTarget());
            if (guiSkillMysticAlly_EarthAlly.Checked)
                activeSkills.Add(new MysticAlly_EarthAlly());

            // Witch Doctor active skills

            // Wizard skills

            // Followers
            if (guiSkillAnatomy.Checked)
                activeSkills.Add(new Anatomy());
            if (guiSkillFocusedMind.Checked)
                activeSkills.Add(new FocusedMind());
            if (guiSkillPoweredArmor.Checked)
                activeSkills.Add(new PoweredArmor());

            guiCalculatedDPS.Text = d3Calculator.GetHeroDps(passiveSkills, activeSkills).Min.ToString();

            UpdateItemsSummary(d3Calculator);

            UpdateCalculationResults(d3Calculator);
        }

        private void GuiDoCalculationsForFollower()
        {
            // Retrieve follower from the GUI
            var follower = GetEditedFollower();

            // Retrieve worn items from the GUI
            var items = new List<Item>
            {
                guiSpecialEditor.GetEditedItem(),
                guiLeftFingerEditor.GetEditedItem(),
                guiNeckEditor.GetEditedItem(),
                guiRightFingerEditor.GetEditedItem(),
                guiSetBonusEditor.GetEditedItem()
            };

            var mainHand = guiMainHandEditor.GetEditedItem();

            var offHand = guiOffHandEditor.GetEditedItem();

            var heroClass = (HeroClass)Enum.Parse(typeof(HeroClass), (String)(guiHeroClass.SelectedItem));

            var d3Calculator = new D3Calculator(follower, heroClass, mainHand, offHand, items.ToArray());

            // Retrieve used skills from the GUI
            var passiveSkills = new List<ID3SkillModifier>();

            // Some buffs are applied after passives skills: followers skills and active skills
            var activeSkills = new List<ID3SkillModifier>();

            // Followers
            if (guiSkillAnatomy.Checked)
                activeSkills.Add(new Anatomy());
            if (guiSkillFocusedMind.Checked)
                activeSkills.Add(new FocusedMind());
            if (guiSkillPoweredArmor.Checked)
                activeSkills.Add(new PoweredArmor());

            guiCalculatedDPS.Text = d3Calculator.GetHeroDps(passiveSkills, activeSkills).Min.ToString();

            UpdateItemsSummary(d3Calculator);

            UpdateCalculationResults(d3Calculator);
        }

        private static void PopulateActiveSkills(Hero hero)
        {
            if (hero.skills.active != null)
            {
                foreach (var activeSkill in hero.skills.active.Where(active => active.skill != null))
                {
                    switch (activeSkill.skill.slug)
                    {
                        // Monk
                        case "mantra-of-healing":
                            switch (activeSkill.rune.slug)
                            {
                                case "":
                                    break;
                            }
                            break;
                        case "mystic-ally":
                            switch (activeSkill.rune.slug)
                            {
                                case "":
                                    break;
                            }
                            break;
                        case "war-cry":
                            switch (activeSkill.rune.slug)
                            {
                                case "":
                                    break;
                            }
                            break;
                    }
                }
            }
        }

        private static void PopulateCalculatedData(Control textBox, ItemValueRange itemValueRange)
        {
            if (itemValueRange != null && itemValueRange.Min != 0)
                textBox.Text = itemValueRange.Min.ToString();
        }

        private static void PopulateCalculatedDataPercent(Control textBox, ItemValueRange itemValueRange)
        {
            if (itemValueRange != null && itemValueRange.Min != 0)
                textBox.Text = (100 * itemValueRange.Min).ToString();
        }

        private void PopulatePassiveSkills(Hero hero)
        {
            if (hero.skills.passive != null)
            {
                foreach (var passiveSkill in hero.skills.passive.Where(passive => passive.skill != null))
                {
                    var skillCheckBox = passiveCheckBoxes
                        .FirstOrDefault(cb => (cb.Tag as string) == passiveSkill.skill.slug);

                    if (skillCheckBox != null)
                        skillCheckBox.Checked = true;
                }
            }
        }

        private void UpdateItemsSummary(D3Calculator d3Calculator)
        {
            var attr = d3Calculator.HeroStatsItem.attributesRaw;

            PopulateCalculatedData(guiItemsDexterity, attr.dexterityItem);
            PopulateCalculatedData(guiItemsIntelligence, attr.intelligenceItem);
            PopulateCalculatedData(guiItemsStrength, attr.strengthItem);
            PopulateCalculatedData(guiItemsVitality, attr.vitalityItem);

            PopulateCalculatedDataPercent(guiItemsCriticChance, attr.critPercentBonusCapped);
            PopulateCalculatedDataPercent(guiItemsSpeedAttack, attr.attacksPerSecondPercent);
            PopulateCalculatedDataPercent(guiItemsCriticDamage, attr.critDamagePercent);
            PopulateCalculatedDataPercent(guiItemsLifePercent, attr.hitpointsMaxPercentBonusItem);
            PopulateCalculatedData(guiItemsLifeOnHit, attr.hitpointsOnHit);
            PopulateCalculatedData(guiItemsLifePerSecond, attr.hitpointsRegenPerSecond);
            PopulateCalculatedDataPercent(guiItemsLifeSteal, attr.stealHealthPercent);

            PopulateCalculatedData(guiItemsResistance_All, attr.resistance_All);
            PopulateCalculatedData(guiItemsResistance_Arcane, attr.resistance_Arcane);
            PopulateCalculatedData(guiItemsResistance_Cold, attr.resistance_Cold);
            PopulateCalculatedData(guiItemsResistance_Fire, attr.resistance_Fire);
            PopulateCalculatedData(guiItemsResistance_Lightning, attr.resistance_Lightning);
            PopulateCalculatedData(guiItemsResistance_Physical, attr.resistance_Physical);
            PopulateCalculatedData(guiItemsResistance_Poison, attr.resistance_Poison);
        }

        private void UpdateCalculationResults(D3Calculator d3Calculator)
        {
            var attr = d3Calculator.HeroStatsItem.attributesRaw;

            guiCalculatedAttackPerSecond.Text = d3Calculator.GetActualAttackSpeed().Min.ToString();
            PopulateCalculatedData(guiCalcultatedDamageMin, d3Calculator.HeroStatsItem.GetWeaponDamageMin() * d3Calculator.GetDamageMultiplierNormal());
            PopulateCalculatedData(guiCalcultatedDamageMax, d3Calculator.HeroStatsItem.GetWeaponDamageMax() * d3Calculator.GetDamageMultiplierNormal());
            PopulateCalculatedData(guiCalcultatedDamageCriticMin, d3Calculator.HeroStatsItem.GetWeaponDamageMin() * d3Calculator.GetDamageMultiplierCritic());
            PopulateCalculatedData(guiCalcultatedDamageCriticMax, d3Calculator.HeroStatsItem.GetWeaponDamageMax() * d3Calculator.GetDamageMultiplierCritic());
            PopulateCalculatedData(guiCalculatedHitpoints, d3Calculator.GetHeroHitpoints());
            guiCalculatedDodge.Text = d3Calculator.GetHeroDodge().ToString();

            PopulateCalculatedData(guiCalculatedArmor, d3Calculator.GetHeroArmor());
            PopulateCalculatedData(guiCalculatedResistance_Arcane, d3Calculator.GetHeroResistance("Arcane"));
            PopulateCalculatedData(guiCalculatedResistance_Cold, d3Calculator.GetHeroResistance("Cold"));
            PopulateCalculatedData(guiCalculatedResistance_Fire, d3Calculator.GetHeroResistance("Fire"));
            PopulateCalculatedData(guiCalculatedResistance_Lightning, d3Calculator.GetHeroResistance("Lightning"));
            PopulateCalculatedData(guiCalculatedResistance_Physical, d3Calculator.GetHeroResistance("Physical"));
            PopulateCalculatedData(guiCalculatedResistance_Poison, d3Calculator.GetHeroResistance("Poison"));
            PopulateCalculatedData(guiCalculatedResistance_All, d3Calculator.getHeroResistance_All());

            guiCalculatedDamageReduction_Armor.Text = (100 * d3Calculator.GetHeroDamageReduction_Armor(heroLevel)).ToString();
            guiCalculatedDamageReduction_Arcane.Text = (100 * d3Calculator.GetHeroDamageReduction(heroLevel, "Arcane")).ToString();
            guiCalculatedDamageReduction_Cold.Text = (100 * d3Calculator.GetHeroDamageReduction(heroLevel, "Cold")).ToString();
            guiCalculatedDamageReduction_Fire.Text = (100 * d3Calculator.GetHeroDamageReduction(heroLevel, "Fire")).ToString();
            guiCalculatedDamageReduction_Lightning.Text = (100 * d3Calculator.GetHeroDamageReduction(heroLevel, "Lightning")).ToString();
            guiCalculatedDamageReduction_Physical.Text = (100 * d3Calculator.GetHeroDamageReduction(heroLevel, "Physical")).ToString();
            guiCalculatedDamageReduction_Poison.Text = (100 * d3Calculator.GetHeroDamageReduction(heroLevel, "Poison")).ToString();

            PopulateCalculatedData(guiCalculatedBlockChance, attr.blockChanceItem);
            PopulateCalculatedData(guiCalculatedBlockMin, attr.blockAmountItemMin);
            PopulateCalculatedData(guiCalculatedBlockMax, attr.blockAmountItemMin + attr.blockAmountItemDelta);

            guiCalculatedEffectiveHitpoints.Text = Math.Round(d3Calculator.GetHeroEffectiveHitpoints(heroLevel)).ToString();
            guiCalculatedDPSEHPRatio.Text = Math.Round(d3Calculator.GetHeroDps().Min * d3Calculator.GetHeroEffectiveHitpoints(heroLevel) / 1000000).ToString();
        }

        private void guiHeroClass_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var heroClass = (HeroClass)Enum.Parse(typeof(HeroClass), guiHeroClass.SelectedItem as String);

            // TODO: hide useless tabs
            switch (heroClass)
            {
                case HeroClass.Barbarian:
                case HeroClass.DemonHunter:
                case HeroClass.Monk:
                case HeroClass.WitchDoctor:
                case HeroClass.Wizard:
                    break;
                case HeroClass.EnchantressFollower:
                case HeroClass.ScoundrelFollower:
                case HeroClass.TemplarFollower:
                    break;
            }
        }
    }
}

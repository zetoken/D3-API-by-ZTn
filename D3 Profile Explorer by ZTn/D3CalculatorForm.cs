using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZTn.BNet.D3.Calculator;
using ZTn.BNet.D3.Calculator.Gems;
using ZTn.BNet.D3.Calculator.Helpers;
using ZTn.BNet.D3.Calculator.Skills;
using ZTn.BNet.D3.Calculator.Skills.Barbarian;
using ZTn.BNet.D3.Calculator.Skills.DemonHunter;
using ZTn.BNet.D3.Calculator.Skills.Followers;
using ZTn.BNet.D3.Calculator.Skills.Monk;
using ZTn.BNet.D3.Helpers;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.HeroFollowers;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3ProfileExplorer
{
    public sealed partial class D3CalculatorForm : Form
    {
        #region >> Fields

        private int heroLevel;

        private readonly Item special;
        private readonly Item bracers;
        private readonly Item feet;
        private readonly Item hands;
        private readonly Item head;
        private readonly Item leftFinger;
        private readonly Item legs;
        private readonly Item neck;
        private readonly Item rightFinger;
        private readonly Item shoulders;
        private readonly Item torso;
        private readonly Item waist;

        private readonly List<CheckBox> passiveCheckBoxes;

        private ItemValueRange calculatedDps;

        private Button lastItemButton;
        private Button currentItemButton;

        #endregion

        #region >> Constructors

        public D3CalculatorForm()
        {
            InitializeComponent();

            guiHeroClass.DataSource = new List<String>
            {
                HeroClass.Barbarian.ToString(),
                HeroClass.Crusader.ToString(),
                HeroClass.DemonHunter.ToString(),
                HeroClass.Monk.ToString(),
                HeroClass.WitchDoctor.ToString(),
                HeroClass.Wizard.ToString(),
                HeroClass.EnchantressFollower.ToString(),
                HeroClass.ScoundrelFollower.ToString(),
                HeroClass.TemplarFollower.ToString()
            };

            var knownGems = KnownGems.GetKnownGemsFromJsonFile("d3gem.json");

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
                guiSkillUnity,

                // Witch Doctor skills
                guiSkillPierceTheVeil,

                // Wizard skills
                guiSkillGlassCannon,
                guiSkillGalvanizingWard
            };

            guiSetBonusEditor.KnownGems = knownGems;

            guiItemEditor.KnownGems = knownGems;
        }

        public D3CalculatorForm(Hero hero)
            : this()
        {
            Text += " [ " + hero.name + " ]";

            guiHeroClass.SelectedItem = hero.heroClass.ToString();
            guiHeroLevel.Text = hero.level.ToString();
            guiHeroParagonLevel.Text = hero.paragonLevel.ToString();

            if (hero.items.bracers != null)
            {
                bracers = hero.items.bracers.GetFullItem();
            }
            if (hero.items.feet != null)
            {
                feet = hero.items.feet.GetFullItem();
            }
            if (hero.items.hands != null)
            {
                hands = hero.items.hands.GetFullItem();
            }
            if (hero.items.head != null)
            {
                head = hero.items.head.GetFullItem();
            }
            if (hero.items.leftFinger != null)
            {
                leftFinger = hero.items.leftFinger.GetFullItem();
            }
            if (hero.items.legs != null)
            {
                legs = hero.items.legs.GetFullItem();
            }
            if (hero.items.neck != null)
            {
                neck = hero.items.neck.GetFullItem();
            }
            if (hero.items.rightFinger != null)
            {
                rightFinger = hero.items.rightFinger.GetFullItem();
            }
            if (hero.items.shoulders != null)
            {
                shoulders = hero.items.shoulders.GetFullItem();
            }
            if (hero.items.torso != null)
            {
                torso = hero.items.torso.GetFullItem();
            }
            if (hero.items.waist != null)
            {
                waist = hero.items.waist.GetFullItem();
            }

            // If no weapon is set in mainHand, use "naked hand" weapon
            var mainHand = (hero.items.mainHand != null ? hero.items.mainHand.GetFullItem() : D3Calculator.NakedHandWeapon);

            // If no item is set in offHand, use a blank item
            Item offHand;
            if (hero.items.offHand != null)
            {
                offHand = hero.items.offHand.GetFullItem();
            }
            else
            {
                offHand = D3Calculator.BlankWeapon;
            }

            var allRawItems = new List<Item> { bracers, feet, hands, head, leftFinger, legs, neck, rightFinger, shoulders, torso, waist, mainHand, offHand };

            guiItemChoiceMainHand.Tag = mainHand;
            guiItemChoiceOffHand.Tag = offHand;
            guiItemChoiceBracers.Tag = bracers;
            guiItemChoiceFeet.Tag = feet;
            guiItemChoiceHands.Tag = hands;
            guiItemChoiceHead.Tag = head;
            guiItemChoiceLeftFinger.Tag = leftFinger;
            guiItemChoiceLegs.Tag = legs;
            guiItemChoiceNeck.Tag = neck;
            guiItemChoiceRightFinger.Tag = rightFinger;
            guiItemChoiceShoulders.Tag = shoulders;
            guiItemChoiceTorso.Tag = torso;
            guiItemChoiceWaist.Tag = waist;

            guiSetBonusEditor.SetEditedItem(new Item(allRawItems.Where(i => i != null).ToList().GetActivatedSetBonus()));

            // Main hand item selected by default
            guiItemChoices_Click(guiItemChoiceMainHand, null);

            PopulatePassiveSkills(hero);
            PopulateActiveSkills(hero);

            DoCalculations();
            DoActionOnCalculatedControls(SetAsReferenceValue);
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
            {
                special = follower.items.special.GetFullItem();
            }
            if (follower.items.leftFinger != null)
            {
                leftFinger = follower.items.leftFinger.GetFullItem();
            }
            if (follower.items.neck != null)
            {
                neck = follower.items.neck.GetFullItem();
            }
            if (follower.items.rightFinger != null)
            {
                rightFinger = follower.items.rightFinger.GetFullItem();
            }

            // If no weapon is set in mainHand, use "naked hand" weapon
            if (follower.items.mainHand != null)
            {
                mainHand = follower.items.mainHand.GetFullItem();
            }
            else
            {
                mainHand = D3Calculator.NakedHandWeapon;
            }

            // If no item is set in offHand, use a blank item
            if (follower.items.offHand != null)
            {
                offHand = follower.items.offHand.GetFullItem();
            }
            else
            {
                offHand = D3Calculator.BlankWeapon;
            }

            var allRawItems = new List<Item> { special, leftFinger, neck, rightFinger, mainHand, offHand };

            guiItemChoiceSpecial.Tag = special;
            guiItemChoiceMainHand.Tag = mainHand;
            guiItemChoiceOffHand.Tag = offHand;
            guiItemChoiceLeftFinger.Tag = leftFinger;
            guiItemChoiceNeck.Tag = neck;
            guiItemChoiceRightFinger.Tag = rightFinger;

            guiSetBonusEditor.SetEditedItem(new Item(allRawItems.Where(i => i != null).ToList().GetActivatedSetBonus()));

            // Main hand item selected by default
            guiItemChoices_Click(guiItemChoiceMainHand, null);

            // Run initial calculations
            DoCalculations();
            DoActionOnCalculatedControls(UpdateResultControlColor);
        }

        #endregion

        private Hero GetEditedHero()
        {
            var hero = new Hero();
            hero.heroClass = (HeroClass)Enum.Parse(typeof(HeroClass), (String)(guiHeroClass.SelectedItem));

            if (String.IsNullOrEmpty(guiHeroLevel.Text))
            {
                hero.level = 60;
            }
            else
            {
                hero.level = Int32.Parse(guiHeroLevel.Text);
            }

            if (String.IsNullOrEmpty(guiHeroParagonLevel.Text))
            {
                hero.paragonLevel = 0;
            }
            else
            {
                hero.paragonLevel = Int32.Parse(guiHeroParagonLevel.Text);
            }

            return hero;
        }

        private Follower GetEditedFollower()
        {
            var follower = new Follower();

            if (String.IsNullOrEmpty(guiHeroLevel.Text))
            {
                follower.level = 70;
            }
            else
            {
                follower.level = Int32.Parse(guiHeroLevel.Text);
            }

            return follower;
        }

        private void guiDoCalculations_Click(object sender, EventArgs e)
        {
            // Force save of current editing item
            if (currentItemButton != null)
            {
                guiItemChoices_Click(currentItemButton, null);
            }

            DoCalculations();
        }

        private void DoCalculations()
        {
            var heroClass = (HeroClass)Enum.Parse(typeof(HeroClass), (String)(guiHeroClass.SelectedItem));

            switch (heroClass)
            {
                case HeroClass.Barbarian:
                case HeroClass.Crusader:
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
                guiItemChoiceBracers.Tag as Item,
                guiItemChoiceFeet.Tag as Item,
                guiItemChoiceHands.Tag as Item,
                guiItemChoiceHead.Tag as Item,
                guiItemChoiceLeftFinger.Tag as Item,
                guiItemChoiceLegs.Tag as Item,
                guiItemChoiceNeck.Tag as Item,
                guiItemChoiceRightFinger.Tag as Item,
                guiItemChoiceShoulders.Tag as Item,
                guiItemChoiceTorso.Tag as Item,
                guiItemChoiceWaist.Tag as Item,
                guiSetBonusEditor.GetEditedItem()
            };
            items = items.Where(i => i != null)
                .Select(i => i.DeepClone())
                .ToList();

            var mainHand = (guiItemChoiceMainHand.Tag as Item).DeepClone();

            var offHand = (guiItemChoiceOffHand.Tag as Item).DeepClone();

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
            {
                activeSkills.Add(new WarCry_Invigorate());
            }

            // Demon Hunter active skills
            if (guiSkillCompanion_BoarCompanion.Checked)
            {
                activeSkills.Add(new Companion_BoarCompanion());
            }

            // Monk active skills
            if (guiSkillMantraOfHealing_TimeOfNeed.Checked)
            {
                activeSkills.Add(new MantraOfHealing_TimeOfNeed());
            }
            if (guiSkillMantraOfEvasion_HardTarget.Checked)
            {
                activeSkills.Add(new MantraOfEvasion_HardTarget());
            }
            if (guiSkillMantraOfRetribution_Transgression.Checked)
            {
                activeSkills.Add(new MantraOfRetribution_Transgression());
            }
            if (guiSkillMysticAlly_EarthAlly.Checked)
            {
                activeSkills.Add(new MysticAlly_EarthAlly());
            }
            if (guiSkillMysticAlly_FireAlly.Checked)
            {
                activeSkills.Add(new MysticAlly_FireAlly());
            }

            // Witch Doctor active skills

            // Wizard skills

            // Followers
            if (guiSkillAnatomy.Checked)
            {
                activeSkills.Add(new Anatomy());
            }
            if (guiSkillFocusedMind.Checked)
            {
                activeSkills.Add(new FocusedMind());
            }
            if (guiSkillPoweredArmor.Checked)
            {
                activeSkills.Add(new PoweredArmor());
            }

            calculatedDps = d3Calculator.GetHeroDps(passiveSkills, activeSkills);

            UpdateItemsSummary(d3Calculator);

            UpdateCalculationResults(d3Calculator);

            DoActionOnCalculatedControls(UpdateResultControlColor);
        }

        private void GuiDoCalculationsForFollower()
        {
            // Retrieve follower from the GUI
            var follower = GetEditedFollower();

            // Retrieve worn items from the GUI
            var items = new List<Item>
            {
                guiItemChoiceSpecial.Tag as Item,
                guiItemChoiceLeftFinger.Tag as Item,
                guiItemChoiceNeck.Tag as Item,
                guiItemChoiceRightFinger.Tag as Item,
                guiSetBonusEditor.GetEditedItem()
            };
            items = items.Where(i => i != null)
                .Select(i => i.DeepClone())
                .ToList();

            var mainHand = (guiItemChoiceMainHand.Tag as Item).DeepClone();

            var offHand = (guiItemChoiceOffHand.Tag as Item).DeepClone();

            var heroClass = (HeroClass)Enum.Parse(typeof(HeroClass), (String)(guiHeroClass.SelectedItem));

            var d3Calculator = new D3Calculator(follower, heroClass, mainHand, offHand, items.ToArray());

            // Retrieve used skills from the GUI
            var passiveSkills = new List<ID3SkillModifier>();

            // Some buffs are applied after passives skills: followers skills and active skills
            var activeSkills = new List<ID3SkillModifier>();

            // Followers
            if (guiSkillAnatomy.Checked)
            {
                activeSkills.Add(new Anatomy());
            }
            if (guiSkillFocusedMind.Checked)
            {
                activeSkills.Add(new FocusedMind());
            }
            if (guiSkillPoweredArmor.Checked)
            {
                activeSkills.Add(new PoweredArmor());
            }

            calculatedDps = d3Calculator.GetHeroDps(passiveSkills, activeSkills);

            guiCalculatedDPS.Text = calculatedDps.Min.ToString();

            UpdateItemsSummary(d3Calculator);

            UpdateCalculationResults(d3Calculator);

            DoActionOnCalculatedControls(UpdateResultControlColor);
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
            if (itemValueRange != null && !itemValueRange.IsZero())
            {
                var round = Math.Round(itemValueRange.Min);
                if (Math.Abs(itemValueRange.Min - round) < 0.0001)
                {
                    textBox.Text = itemValueRange.Min.ToString("N0");
                }
                else
                {
                    textBox.Text = itemValueRange.Min.ToString("N2");
                }
            }
        }

        private static void PopulateCalculatedDataPercent(Control textBox, ItemValueRange itemValueRange)
        {
            if (itemValueRange != null && !itemValueRange.IsZero())
            {
                textBox.Text = (100 * itemValueRange.Min).ToString("N2");
            }
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
                    {
                        skillCheckBox.Checked = true;
                    }
                }
            }
        }

        private void UpdateItemsSummary(D3Calculator d3Calculator)
        {
            var attr = d3Calculator.HeroStatsItem.AttributesRaw;

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
        }

        private void UpdateCalculationResults(D3Calculator d3Calculator)
        {
            var attr = d3Calculator.HeroStatsItem.AttributesRaw;

            guiCalculatedDPS.Text = calculatedDps.Min.ToString("N");

            guiCalculatedAttackPerSecond.Text = d3Calculator.GetActualAttackSpeed().Min.ToString("N2");
            PopulateCalculatedData(guiCalcultatedDamageMin, d3Calculator.HeroStatsItem.GetWeaponDamageMin() * d3Calculator.GetDamageMultiplierNormal());
            PopulateCalculatedData(guiCalcultatedDamageMax, d3Calculator.HeroStatsItem.GetWeaponDamageMax() * d3Calculator.GetDamageMultiplierNormal());
            PopulateCalculatedData(guiCalcultatedDamageCriticMin, d3Calculator.HeroStatsItem.GetWeaponDamageMin() * d3Calculator.GetDamageMultiplierCritic());
            PopulateCalculatedData(guiCalcultatedDamageCriticMax, d3Calculator.HeroStatsItem.GetWeaponDamageMax() * d3Calculator.GetDamageMultiplierCritic());

            PopulateCalculatedDataPercent(guiCalculatedSkillBonusPercent_Arcane, attr.damageDealtPercentBonusArcane);
            PopulateCalculatedDataPercent(guiCalculatedSkillBonusPercent_Cold, attr.damageDealtPercentBonusCold);
            PopulateCalculatedDataPercent(guiCalculatedSkillBonusPercent_Fire, attr.damageDealtPercentBonusFire);
            PopulateCalculatedDataPercent(guiCalculatedSkillBonusPercent_Holy, attr.damageDealtPercentBonusHoly);
            PopulateCalculatedDataPercent(guiCalculatedSkillBonusPercent_Lightning, attr.damageDealtPercentBonusLightning);
            PopulateCalculatedDataPercent(guiCalculatedSkillBonusPercent_Physical, attr.damageDealtPercentBonusPhysical);
            PopulateCalculatedDataPercent(guiCalculatedSkillBonusPercent_Poison, attr.damageDealtPercentBonusPoison);

            PopulateCalculatedData(guiCalculatedSkillDamage_Arcane, calculatedDps * (1 + attr.damageDealtPercentBonusArcane));
            PopulateCalculatedData(guiCalculatedSkillDamage_Cold, calculatedDps * (1 + attr.damageDealtPercentBonusCold));
            PopulateCalculatedData(guiCalculatedSkillDamage_Fire, calculatedDps * (1 + attr.damageDealtPercentBonusFire));
            PopulateCalculatedData(guiCalculatedSkillDamage_Holy, calculatedDps * (1 + attr.damageDealtPercentBonusHoly));
            PopulateCalculatedData(guiCalculatedSkillDamage_Lightning, calculatedDps * (1 + attr.damageDealtPercentBonusLightning));
            PopulateCalculatedData(guiCalculatedSkillDamage_Physical, calculatedDps * (1 + attr.damageDealtPercentBonusPhysical));
            PopulateCalculatedData(guiCalculatedSkillDamage_Poison, calculatedDps * (1 + attr.damageDealtPercentBonusPoison));

            PopulateCalculatedData(guiCalculatedSkillDamageVsElites_Arcane, calculatedDps * (1 + attr.damageDealtPercentBonusArcane) * (1 + attr.damagePercentBonusVsElites));
            PopulateCalculatedData(guiCalculatedSkillDamageVsElites_Cold, calculatedDps * (1 + attr.damageDealtPercentBonusCold) * (1 + attr.damagePercentBonusVsElites));
            PopulateCalculatedData(guiCalculatedSkillDamageVsElites_Fire, calculatedDps * (1 + attr.damageDealtPercentBonusFire) * (1 + attr.damagePercentBonusVsElites));
            PopulateCalculatedData(guiCalculatedSkillDamageVsElites_Holy, calculatedDps * (1 + attr.damageDealtPercentBonusHoly) * (1 + attr.damagePercentBonusVsElites));
            PopulateCalculatedData(guiCalculatedSkillDamageVsElites_Lightning, calculatedDps * (1 + attr.damageDealtPercentBonusLightning) * (1 + attr.damagePercentBonusVsElites));
            PopulateCalculatedData(guiCalculatedSkillDamageVsElites_Physical, calculatedDps * (1 + attr.damageDealtPercentBonusPhysical) * (1 + attr.damagePercentBonusVsElites));
            PopulateCalculatedData(guiCalculatedSkillDamageVsElites_Poison, calculatedDps * (1 + attr.damageDealtPercentBonusPoison) * (1 + attr.damagePercentBonusVsElites));

            PopulateCalculatedDataPercent(guiSkillCooldownReductionAll, attr.powerCooldownReductionPercentAll);

            PopulateCalculatedDataPercent(guiCalculatedBonusEliteDamagePercent, attr.damagePercentBonusVsElites);
            PopulateCalculatedDataPercent(guiCalculatedReductionFromMeleePercent, attr.damagePercentReductionFromMelee);
            PopulateCalculatedDataPercent(guiCalculatedReductionFromRangedPercent, attr.damagePercentReductionFromRanged);

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

            guiCalculatedDamageReduction_Armor.Text = (100 * d3Calculator.GetHeroDamageReduction_Armor(heroLevel)).ToString("N2");
            guiCalculatedDamageReduction_Arcane.Text = (100 * d3Calculator.GetHeroDamageReduction(heroLevel, "Arcane")).ToString("N2");
            guiCalculatedDamageReduction_Cold.Text = (100 * d3Calculator.GetHeroDamageReduction(heroLevel, "Cold")).ToString("N2");
            guiCalculatedDamageReduction_Fire.Text = (100 * d3Calculator.GetHeroDamageReduction(heroLevel, "Fire")).ToString("N2");
            guiCalculatedDamageReduction_Lightning.Text = (100 * d3Calculator.GetHeroDamageReduction(heroLevel, "Lightning")).ToString("N2");
            guiCalculatedDamageReduction_Physical.Text = (100 * d3Calculator.GetHeroDamageReduction(heroLevel, "Physical")).ToString("N2");
            guiCalculatedDamageReduction_Poison.Text = (100 * d3Calculator.GetHeroDamageReduction(heroLevel, "Poison")).ToString("N2");

            PopulateCalculatedData(guiCalculatedBlockChance, attr.blockChanceItem);
            PopulateCalculatedData(guiCalculatedBlockMin, attr.blockAmountItemMin);
            PopulateCalculatedData(guiCalculatedBlockMax, attr.blockAmountItemMin + attr.blockAmountItemDelta);

            guiCalculatedEffectiveHitpoints.Text = Math.Round(d3Calculator.GetHeroEffectiveHitpoints(heroLevel)).ToString("N0");
            guiCalculatedDPSEHPRatio.Text = Math.Round(d3Calculator.GetHeroDps().Min * d3Calculator.GetHeroEffectiveHitpoints(heroLevel) / 1000000).ToString("N0");
        }

        private void guiHeroClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            var heroClass = (HeroClass)Enum.Parse(typeof(HeroClass), (string)guiHeroClass.SelectedItem);

            var isHero = false;

            switch (heroClass)
            {
                case HeroClass.Barbarian:
                case HeroClass.Crusader:
                case HeroClass.DemonHunter:
                case HeroClass.Monk:
                case HeroClass.WitchDoctor:
                case HeroClass.Wizard:
                    isHero = true;
                    break;
            }

            guiItemChoiceSpecial.Visible = !isHero;
            guiItemChoiceBracers.Visible = isHero;
            guiItemChoiceBracers.Visible = isHero;
            guiItemChoiceFeet.Visible = isHero;
            guiItemChoiceHands.Visible = isHero;
            guiItemChoiceHead.Visible = isHero;
            guiItemChoiceLegs.Visible = isHero;
            guiItemChoiceShoulders.Visible = isHero;
            guiItemChoiceTorso.Visible = isHero;
            guiItemChoiceWaist.Visible = isHero;
        }

        private void guiItemChoices_Click(object sender, EventArgs e)
        {
            currentItemButton = sender as Button;
            if (currentItemButton == null)
            {
                return;
            }

            if (lastItemButton != null)
            {
                lastItemButton.BackColor = Color.Transparent;
                lastItemButton.Tag = guiItemEditor.GetEditedItem();
            }

            currentItemButton.FlatAppearance.MouseOverBackColor = Color.PaleGreen;
            currentItemButton.BackColor = Color.LimeGreen;
            var currentItem = currentItemButton.Tag as Item;
            if (currentItem == null)
            {
                currentItem = new Item(new ItemAttributes());
            }
            guiItemEditor.SetEditedItem(currentItem);

            lastItemButton = currentItemButton;
        }

        private void guiSetAsReference_Click(object sender, EventArgs e)
        {
            DoActionOnCalculatedControls(SetAsReferenceValue);
        }

        private void DoActionOnCalculatedControls(Action<Control> action)
        {
            foreach (var control in tabResults.Controls)
            {
                var groupBox = control as GroupBox;
                if (groupBox != null)
                {
                    UpdateControlsOnCalculationDone(groupBox, action);
                }
            }
        }

        private static void SetAsReferenceValue(Control textBox)
        {
            textBox.Tag = textBox.Text;
            textBox.BackColor = SystemColors.Control;
        }

        private static void UpdateResultControlColor(Control textBox)
        {
            var tag = textBox.Tag as string;
            if (!String.IsNullOrWhiteSpace(tag))
            {
                var previousValue = Double.Parse((string)textBox.Tag);
                var currentValue = Double.Parse(textBox.Text);
                if (currentValue > previousValue)
                {
                    textBox.BackColor = Color.PaleGreen;
                }
                else if (currentValue < previousValue)
                {
                    textBox.BackColor = Color.LightSalmon;
                }
                else
                {
                    textBox.BackColor = SystemColors.Control;
                }
            }
        }

        private static void UpdateControlsOnCalculationDone(Control control, Action<Control> action)
        {
            foreach (var innerControl in control.Controls)
            {
                var textBox = innerControl as TextBox;
                if (textBox != null)
                {
                    action(textBox);
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ZTn.BNet.D3.Calculator;
using ZTn.BNet.D3.Calculator.Gems;
using ZTn.BNet.D3.Calculator.Helpers;
using ZTn.BNet.D3.Calculator.Sets;
using ZTn.BNet.D3.Calculator.Skills;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;
using ZTn.BNet.D3.Skills;

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

        Item mainHand;
        Item offHand;

        List<CheckBox> passiveCheckBoxes;

        #endregion

        #region >> Constructors

        public D3CalculatorForm()
        {
            InitializeComponent();

            guiHeroClass.DataSource = new List<String>() {
                HeroClass.Barbarian.ToString(),
                HeroClass.DemonHunter.ToString(),
                HeroClass.Monk.ToString(), 
                HeroClass.WitchDoctor.ToString(), 
                HeroClass.Wizard.ToString()
            };

            KnownGems knownGems = KnownGems.getKnownGemsFromJsonFile("d3gem.json");

            guiMainHandEditor.knownGems = knownGems;
            guiOffHandEditor.knownGems = knownGems;
            guiBracersEditor.knownGems = knownGems;
            guiFeetEditor.knownGems = knownGems;
            guiHandsEditor.knownGems = knownGems;
            guiHeadEditor.knownGems = knownGems;
            guiLeftFingerEditor.knownGems = knownGems;
            guiLegsEditor.knownGems = knownGems;
            guiNeckEditor.knownGems = knownGems;
            guiRightFingerEditor.knownGems = knownGems;
            guiShouldersEditor.knownGems = knownGems;
            guiTorsoEditor.knownGems = knownGems;
            guiWaistEditor.knownGems = knownGems;
            guiSetBonusEditor.knownGems = knownGems;

            passiveCheckBoxes = new List<CheckBox>()
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

        }

        public D3CalculatorForm(Hero hero)
            : this()
        {
            this.hero = hero;
            this.Text += " [ " + hero.name + " ]";

            guiHeroClass.SelectedItem = hero.heroClass.ToString();
            guiHeroLevel.Text = hero.level.ToString();
            guiHeroParagonLevel.Text = hero.paragonLevel.ToString();

            if (hero.items.bracers != null)
                bracers = hero.items.bracers.getFullItem();
            if (hero.items.feet != null)
                feet = hero.items.feet.getFullItem();
            if (hero.items.hands != null)
                hands = hero.items.hands.getFullItem();
            if (hero.items.head != null)
                head = hero.items.head.getFullItem();
            if (hero.items.leftFinger != null)
                leftFinger = hero.items.leftFinger.getFullItem();
            if (hero.items.legs != null)
                legs = hero.items.legs.getFullItem();
            if (hero.items.neck != null)
                neck = hero.items.neck.getFullItem();
            if (hero.items.rightFinger != null)
                rightFinger = hero.items.rightFinger.getFullItem();
            if (hero.items.shoulders != null)
                shoulders = hero.items.shoulders.getFullItem();
            if (hero.items.torso != null)
                torso = hero.items.torso.getFullItem();
            if (hero.items.waist != null)
                waist = hero.items.waist.getFullItem();

            // If no weapon is set in mainHand, use "naked hand" weapon
            if (hero.items.mainHand != null)
                mainHand = hero.items.mainHand.getFullItem();
            else
                mainHand = D3Calculator.nakedHandWeapon;

            // If no item is set in offHand, use a blank item
            if (hero.items.offHand != null)
                offHand = hero.items.offHand.getFullItem();
            else
                offHand = D3Calculator.blankWeapon;

            List<Item> allRawItems = new List<Item>() { bracers, feet, hands, head, leftFinger, legs, neck, rightFinger, shoulders, torso, waist, mainHand, offHand };

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

            List<Item> items = new List<Item>()
            {
                guiBracersEditor.getEditedItem(),
                guiFeetEditor.getEditedItem(),
                guiHandsEditor.getEditedItem(),
                guiHeadEditor.getEditedItem(),
                guiLeftFingerEditor.getEditedItem(),
                guiLegsEditor.getEditedItem(),
                guiNeckEditor.getEditedItem(),
                guiRightFingerEditor.getEditedItem(),
                guiShouldersEditor.getEditedItem(),
                guiTorsoEditor.getEditedItem(),
                guiWaistEditor.getEditedItem()
            };

            guiSetBonusEditor.setEditedItem(new Item(allRawItems.Where(i => i != null).ToList().getActivatedSetBonus()));

            populatePassiveSkills();
            populateActiveSkills();
        }

        #endregion

        private Hero getEditedHero()
        {
            Hero hero = new Hero();
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

        private void guiDoCalculations_Click(object sender, EventArgs e)
        {
            // Retrieve hero from the GUI
            hero = getEditedHero();

            // Retrieve weared items from the GUI
            List<Item> items = new List<Item>()
            {
                guiBracersEditor.getEditedItem(),
                guiFeetEditor.getEditedItem(),
                guiHandsEditor.getEditedItem(),
                guiHeadEditor.getEditedItem(),
                guiLeftFingerEditor.getEditedItem(),
                guiLegsEditor.getEditedItem(),
                guiNeckEditor.getEditedItem(),
                guiRightFingerEditor.getEditedItem(),
                guiShouldersEditor.getEditedItem(),
                guiTorsoEditor.getEditedItem(),
                guiWaistEditor.getEditedItem(),
                guiSetBonusEditor.getEditedItem()
            };

            Item mainHand = guiMainHandEditor.getEditedItem();

            Item offHand = guiOffHandEditor.getEditedItem();

            D3Calculator d3Calculator = new D3Calculator(hero, mainHand, offHand, items.ToArray());

            // Retrieve used skills from the GUI
            List<ID3SkillModifier> passiveSkills = new List<ID3SkillModifier>();

            foreach (CheckBox checkBox in passiveCheckBoxes.Where(p => p.Checked))
                passiveSkills.Add(PassiveSkillModifierFactory.getFromSlug(checkBox.Tag as string));

            // Some buffs are applied after passives skills: followers skills and active skills
            List<ID3SkillModifier> activeSkills = new List<ID3SkillModifier>();

            // Barbarian active skills
            if (guiSkillWarCry_Invigorate.Checked)
                activeSkills.Add(new D3.Calculator.Skills.Barbarian.WarCry_Invigorate());

            // Demon Hunter active skills

            // Monk active skills
            if (guiSkillMantraOfHealing_TimeOfNeed.Checked)
                activeSkills.Add(new D3.Calculator.Skills.Monk.MantraOfHealing_TimeOfNeed());
            if (guiSkillMantraOfEvasion_HardTarget.Checked)
                activeSkills.Add(new D3.Calculator.Skills.Monk.MantraOfEvasion_HardTarget());
            if (guiSkillMysticAlly_EarthAlly.Checked)
                activeSkills.Add(new D3.Calculator.Skills.Monk.MysticAlly_EarthAlly());

            // Witch Doctor active skills

            // Wizard skills

            // Followers
            if (guiSkillAnatomy.Checked)
                activeSkills.Add(new D3.Calculator.Skills.Followers.Anatomy());
            if (guiSkillFocusedMind.Checked)
                activeSkills.Add(new D3.Calculator.Skills.Followers.FocusedMind());
            if (guiSkillPoweredArmor.Checked)
                activeSkills.Add(new D3.Calculator.Skills.Followers.PoweredArmor());

            guiCalculatedDPS.Text = d3Calculator.getHeroDPS(passiveSkills, activeSkills).min.ToString();

            updateItemsSummary(d3Calculator);

            updateCalculationResults(d3Calculator);
        }

        private void populateActiveSkills()
        {
            if (hero.skills.active != null)
            {
                foreach (ActiveSkill activeSkill in hero.skills.active.Where(active => active.skill != null))
                {
                    switch (activeSkill.skill.slug)
                    {
                        // Monk
                        case "mantra-of-healing":
                            switch (activeSkill.rune.slug)
                            {
                                case "":
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "mystic-ally":
                            switch (activeSkill.rune.slug)
                            {
                                case "":
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "war-cry":
                            switch (activeSkill.rune.slug)
                            {
                                case "":
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void populateCalculatedData(TextBox textBox, ItemValueRange itemValueRange)
        {
            if (itemValueRange != null && itemValueRange.min != 0)
                textBox.Text = itemValueRange.min.ToString();
        }

        private void populateCalculatedDataPercent(TextBox textBox, ItemValueRange itemValueRange)
        {
            if (itemValueRange != null && itemValueRange.min != 0)
                textBox.Text = (100 * itemValueRange.min).ToString();
        }

        private void populatePassiveSkills()
        {
            if (hero.skills.passive != null)
            {
                foreach (PassiveSkill passiveSkill in hero.skills.passive.Where(passive => passive.skill != null))
                {
                    CheckBox skillCheckBox = passiveCheckBoxes
                        .FirstOrDefault(cb => (cb.Tag as string) == passiveSkill.skill.slug);

                    if (skillCheckBox != null)
                        skillCheckBox.Checked = true;
                }
            }
        }

        private void updateItemsSummary(D3Calculator d3Calculator)
        {
            ItemAttributes attr = d3Calculator.heroStatsItem.attributesRaw;

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
            populateCalculatedDataPercent(guiItemsLifeSteal, attr.stealHealthPercent);

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
            ItemAttributes attr = d3Calculator.heroStatsItem.attributesRaw;

            guiCalculatedAttackPerSecond.Text = d3Calculator.getActualAttackSpeed().min.ToString();
            populateCalculatedData(guiCalcultatedDamageMin, d3Calculator.heroStatsItem.getWeaponDamageMin() * d3Calculator.getDamageMultiplierNormal());
            populateCalculatedData(guiCalcultatedDamageMax, d3Calculator.heroStatsItem.getWeaponDamageMax() * d3Calculator.getDamageMultiplierNormal());
            populateCalculatedData(guiCalcultatedDamageCriticMin, d3Calculator.heroStatsItem.getWeaponDamageMin() * d3Calculator.getDamageMultiplierCritic());
            populateCalculatedData(guiCalcultatedDamageCriticMax, d3Calculator.heroStatsItem.getWeaponDamageMax() * d3Calculator.getDamageMultiplierCritic());
            populateCalculatedData(guiCalculatedHitpoints, d3Calculator.getHeroHitpoints());
            guiCalculatedDodge.Text = d3Calculator.getHeroDodge().ToString();

            populateCalculatedData(guiCalculatedArmor, d3Calculator.getHeroArmor());
            populateCalculatedData(guiCalculatedResistance_Arcane, d3Calculator.getHeroResistance("Arcane"));
            populateCalculatedData(guiCalculatedResistance_Cold, d3Calculator.getHeroResistance("Cold"));
            populateCalculatedData(guiCalculatedResistance_Fire, d3Calculator.getHeroResistance("Fire"));
            populateCalculatedData(guiCalculatedResistance_Lightning, d3Calculator.getHeroResistance("Lightning"));
            populateCalculatedData(guiCalculatedResistance_Physical, d3Calculator.getHeroResistance("Physical"));
            populateCalculatedData(guiCalculatedResistance_Poison, d3Calculator.getHeroResistance("Poison"));
            populateCalculatedData(guiCalculatedResistance_All, d3Calculator.getHeroResistance_All());

            guiCalculatedDamageReduction_Armor.Text = (100 * d3Calculator.getHeroDamageReduction_Armor(hero.level)).ToString();
            guiCalculatedDamageReduction_Arcane.Text = (100 * d3Calculator.getHeroDamageReduction(hero.level, "Arcane")).ToString();
            guiCalculatedDamageReduction_Cold.Text = (100 * d3Calculator.getHeroDamageReduction(hero.level, "Cold")).ToString();
            guiCalculatedDamageReduction_Fire.Text = (100 * d3Calculator.getHeroDamageReduction(hero.level, "Fire")).ToString();
            guiCalculatedDamageReduction_Lightning.Text = (100 * d3Calculator.getHeroDamageReduction(hero.level, "Lightning")).ToString();
            guiCalculatedDamageReduction_Physical.Text = (100 * d3Calculator.getHeroDamageReduction(hero.level, "Physical")).ToString();
            guiCalculatedDamageReduction_Poison.Text = (100 * d3Calculator.getHeroDamageReduction(hero.level, "Poison")).ToString();

            populateCalculatedData(guiCalculatedBlockChance, attr.blockChanceItem);
            populateCalculatedData(guiCalculatedBlockMin, attr.blockAmountItemMin);
            populateCalculatedData(guiCalculatedBlockMax, attr.blockAmountItemMin + attr.blockAmountItemDelta);

            guiCalculatedEffectiveHitpoints.Text = Math.Round(d3Calculator.getHeroEffectiveHitpoints(hero.level)).ToString();
            guiCalculatedDPSEHPRatio.Text = Math.Round(d3Calculator.getHeroDPS().min * d3Calculator.getHeroEffectiveHitpoints(hero.level) / 1000000).ToString();
        }
    }
}

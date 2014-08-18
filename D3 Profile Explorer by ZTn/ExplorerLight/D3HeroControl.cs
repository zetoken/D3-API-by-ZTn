using System;
using System.Drawing;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3ProfileExplorer.Properties;

namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    partial class D3HeroControl : D3SelectableControl
    {
        public HeroSummary HeroSummary
        {
            set
            {
                UpdateHeroInfo(value);
                UpdateHeroPicture(value.heroClass, value.gender);
            }
        }

        public D3HeroControl()
        {
            InitializeComponent();

            InitializeControl();
        }

        public D3HeroControl(HeroSummary heroSummary)
            : this()
        {
            HeroSummary = heroSummary;
        }

        private void UpdateHeroInfo(HeroSummary value)
        {
            guiHeroName.Text = value.name;

            guiHeroClass.Text = value.heroClass.ToString();

            guiHeroLevel.Text = String.Format("{0}", value.level);
            guiHeroParangonLevel.Text = String.Format("+{0}", value.paragonLevel);

            guiHeroHardcore.Visible = value.hardcore;
        }

        private void UpdateHeroPicture(HeroClass heroClass, HeroGender gender)
        {
            Image picture;
            switch (heroClass)
            {
                case HeroClass.Barbarian:
                    picture = (gender == HeroGender.Female ? Resources.barbarian_female : Resources.barbarian_male);
                    break;
                case HeroClass.Crusader:
                    picture = (gender == HeroGender.Female ? Resources.crusader_female : Resources.crusader_male);
                    break;
                case HeroClass.DemonHunter:
                    picture = (gender == HeroGender.Female ? Resources.demonhunter_female : Resources.demonhunter_male);
                    break;
                case HeroClass.Monk:
                    picture = (gender == HeroGender.Female ? Resources.monk_female : Resources.monk_male);
                    break;
                case HeroClass.WitchDoctor:
                    picture = (gender == HeroGender.Female ? Resources.witchdoctor_female : Resources.witchdoctor_male);
                    break;
                case HeroClass.Wizard:
                    picture = (gender == HeroGender.Female ? Resources.wizard_female : Resources.wizard_male);
                    break;
                default:
                    return;
            }

            if (picture == null)
            {
                return;
            }

            guiHeroPicture.Image = picture;
        }
    }
}
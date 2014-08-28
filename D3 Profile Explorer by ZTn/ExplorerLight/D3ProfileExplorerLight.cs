using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ZTn.BNet.BattleNet;
using ZTn.BNet.D3;
using ZTn.BNet.D3.Careers;
using ZTn.BNet.D3.DataProviders;
using ZTn.BNet.D3.Helpers;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    public partial class D3ProfileExplorerLight : Form
    {
        private const string D3ProfilesFileName = "D3Profiles.json";

        private readonly D3ProfileExplorerLightConfig config;

        private BNetProfileControl activeProfileControl;
        private D3HeroControl activeHeroControl;

        public D3ProfileExplorerLight()
        {
            InitializeComponent();

            var cacheableDataProvider = new CacheableDataProvider(new HttpRequestDataProvider()) { FetchMode = FetchMode.OnlineIfMissing };
            D3Api.DataProvider = cacheableDataProvider;
            D3Api.ApiKey = "zrxxcy3qzp8jcbgrce2es4yq52ew2k7r";

            var hosts = "hosts.json".CreateFromJsonFile<List<Host>>();
            guiBattleNetHostList.DataSource = hosts;
            guiBattleNetHostList.DisplayMember = "name";

            var langs = "languages.json".CreateFromJsonFile<List<Language>>();
            guiBattleNetLanguageList.DataSource = langs;
            guiBattleNetLanguageList.DisplayMember = "name";

            config = File.Exists(D3ProfilesFileName)
                ? D3ProfilesFileName.CreateFromJsonFile<D3ProfileExplorerLightConfig>()
                : new D3ProfileExplorerLightConfig();

            guiProfilePanel.Controls.Clear();
            foreach (var profile in config.Profiles)
            {
                AddProfile(profile);
            }

            guiRefreshCareer.Visible = false;
            guiRefreshHero.Visible = false;
            guiRunCalculator.Visible = false;
        }

        private void guiShowFullExplorer_Click(object sender, EventArgs e)
        {
            var fullExplorer = new GuiD3ProfileExplorer();
            fullExplorer.Show();
        }

        private void guiAddProfile_Click(object sender, EventArgs e)
        {
            BattleTag battleTag;

            try
            {
                battleTag = new BattleTag(guiBattleTag.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Battle Tag syntax is invalid: verify the battle tag.");
                return;
            }

            var host = (Host)guiBattleNetHostList.SelectedItem;

            var profileExists = config.Profiles.Any(p => p.BattleTag.Id.ToLower() == battleTag.Id.ToLower() && p.Host.Url == host.Url);
            if (profileExists)
            {
                MessageBox.Show("The profile already exists.");
                return;
            }

            FetchCareer(battleTag, host);

            var profileContainer = new D3ProfileContainer(battleTag, host);
            config.Profiles.Add(profileContainer);

            AddProfile(profileContainer);
        }

        private void D3ProfileExplorerLight_FormClosing(object sender, FormClosingEventArgs e)
        {
            config.WriteToJsonFile(D3ProfilesFileName, true);
        }

        private void AddItem(ItemSummary itemSummary)
        {
            if (itemSummary == null)
            {
                return;
            }

            var item = itemSummary.GetFullItem();
            if (item == null)
            {
                return;
            }

            var control = new D3ItemControl(item);

            guiItemsPanel.Controls.Add(control);
        }

        private void AddProfile(D3ProfileContainer profileContainer)
        {
            var control = new BNetProfileControl(profileContainer.BattleTag, profileContainer.Host) { Tag = profileContainer };

            control.Click += bNetProfileControl_Click;

            guiProfilePanel.Controls.Add(control);
        }

        private void ShowCareer(Career career, BattleTag battleTag, Host host)
        {
            if (career == null)
            {
                return;
            }

            guiHeroesPanel.Controls.Clear();
            foreach (var hero in career.Heroes)
            {
                var control = new D3HeroControl(hero);
                control.Click += d3HeroControl_Click;
                control.Tag = new D3HeroContainer(hero, battleTag, host);
                guiHeroesPanel.Controls.Add(control);
            }

            guiRefreshCareer.Visible = true;
        }

        private void ShowHero(Hero hero)
        {
            if (hero == null)
            {
                return;
            }

            guiItemsPanel.Controls.Clear();
            AddItem(hero.Items.bracers);
            AddItem(hero.Items.feet);
            AddItem(hero.Items.hands);
            AddItem(hero.Items.head);
            AddItem(hero.Items.leftFinger);
            AddItem(hero.Items.legs);
            AddItem(hero.Items.mainHand);
            AddItem(hero.Items.neck);
            AddItem(hero.Items.offHand);
            AddItem(hero.Items.rightFinger);
            AddItem(hero.Items.shoulders);
            AddItem(hero.Items.torso);
            AddItem(hero.Items.waist);

            guiRefreshHero.Visible = true;
            guiRunCalculator.Visible = true;
        }

        private void bNetProfileControl_Click(object sender, EventArgs e)
        {
            var control = sender as BNetProfileControl;

            if (control == null)
            {
                return;
            }

            SuspendLayout();

            if (activeProfileControl != null)
            {
                activeProfileControl.IsHighlighted = false;
            }

            control.IsHighlighted = true;

            var profileContainer = (D3ProfileContainer)control.Tag;
            var career = FetchCareer(profileContainer.BattleTag, profileContainer.Host);
            ShowCareer(career, profileContainer.BattleTag, profileContainer.Host);

            activeProfileControl = control;

            ResumeLayout();
        }

        private void d3HeroControl_Click(object sender, EventArgs e)
        {
            var control = sender as D3HeroControl;

            if (control == null)
            {
                return;
            }

            SuspendLayout();

            if (activeHeroControl != null)
            {
                activeHeroControl.IsHighlighted = false;
            }

            control.IsHighlighted = true;

            var container = (D3HeroContainer)control.Tag;
            var hero = FetchHero(container.HeroSummary, container.BattleTag, container.Host);
            ShowHero(hero);

            activeHeroControl = control;

            ResumeLayout();
        }

        private static Career FetchCareer(BattleTag battleTag, Host host)
        {
            D3Api.Host = host.Url;

            Career career;
            try
            {
                career = Career.CreateFromBattleTag(battleTag);
            }
            catch (FileNotInCacheException)
            {
                MessageBox.Show("Career was not found in cache: go online to retrieve it.");
                return null;
            }
            catch (BNetResponseFailedException)
            {
                MessageBox.Show("Battle.net sent an http error: try again later.");
                return null;
            }
            catch (BNetFailureObjectReturnedException)
            {
                MessageBox.Show("Battle.net sent an error: verify the battle tag.");
                return null;
            }

            return career;
        }

        private static Hero FetchHero(HeroSummary heroSummary, BattleTag battleTag, Host host)
        {
            D3Api.Host = host.Url;

            Hero hero;
            try
            {
                hero = heroSummary.GetHeroFromBattleTag(battleTag);
            }
            catch (FileNotInCacheException)
            {
                MessageBox.Show("Hero was not found in cache: go online to retrieve it.");
                return null;
            }
            catch (BNetResponseFailedException)
            {
                MessageBox.Show("Battle.net sent an http error: try again later.");
                return null;
            }
            catch (BNetFailureObjectReturnedException)
            {
                MessageBox.Show("Battle.net sent an error: verify the battle tag.");
                return null;
            }

            return hero;
        }

        private void guiRunCalculator_Click(object sender, EventArgs e)
        {
            if (activeHeroControl == null)
            {
                return;
            }

            var container = (D3HeroContainer)activeHeroControl.Tag;
            var hero = container.HeroSummary.GetHeroFromBattleTag(container.BattleTag);

            if (hero == null)
            {
                return;
            }

            var form = new D3CalculatorForm(hero);
            form.Show();
        }

        private void guiRefreshCareer_Click(object sender, EventArgs e)
        {
            var container = (D3ProfileContainer)activeProfileControl.Tag;

            var dataProvider = (CacheableDataProvider)D3Api.DataProvider;

            dataProvider.FetchMode = FetchMode.Online;
            var career = FetchCareer(container.BattleTag, container.Host);
            dataProvider.FetchMode = FetchMode.OnlineIfMissing;

            ShowCareer(career, container.BattleTag, container.Host);

            guiItemsPanel.Controls.Clear();

            MessageBox.Show("Career updated.");
        }

        private void guiRefreshHero_Click(object sender, EventArgs e)
        {
            var container = (D3HeroContainer)activeHeroControl.Tag;

            var dataProvider = (CacheableDataProvider)D3Api.DataProvider;

            dataProvider.FetchMode = FetchMode.Online;
            var hero = FetchHero(container.HeroSummary, container.BattleTag, container.Host);
            dataProvider.FetchMode = FetchMode.OnlineIfMissing;

            ShowHero(hero);

            MessageBox.Show("Hero updated.");
        }
    }
}
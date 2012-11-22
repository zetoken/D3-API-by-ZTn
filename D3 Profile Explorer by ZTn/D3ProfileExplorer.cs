using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

using ZTn.BNet.BattleNet;
using ZTn.BNet.D3.Careers;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;
using ZTn.BNet.D3.Artisans;
using ZTn.BNet.D3.DataProviders;
using ZTn.BNet.D3.Calculator;
using ZTn.BNet.D3.Skills;
using ZTn.BNet.D3.Medias;
using System.IO;

namespace ZTn.BNet.D3ProfileExplorer
{
    public partial class guiD3ProfileExplorer : Form
    {
        public guiD3ProfileExplorer()
        {
            InitializeComponent();

            D3.D3Api.dataProvider = new CacheableDataProvider(new HttpRequestDataProvider());

            List<Host> hosts = new List<Host>
            {
                new Host("Europe", "eu.battle.net"),
                new Host("America","us.battle.net"),
                new Host("Korea", "kr.battle.net"),
                new Host("Taiwan","tw.battle.net")
            };
            guiBattleNetHostList.DataSource = hosts;
            guiBattleNetHostList.DisplayMember = "name";

            List<Language> langs = new List<Language>
            {
                new Language("English", "en"),
                new Language("French","fr"),
                new Language("German", "de"),
                new Language("Italian","it"),
                new Language("Spanish", "es"),
                new Language("Polish","pl"),
                new Language("Portuguese","pt"),
                new Language("Russian","ru"),
                new Language("Turkish","tr"),
                new Language("Korean","ko"),
                new Language("Chinese","zh")
            };
            guiBattleNetLanguageList.DataSource = langs;
            guiBattleNetLanguageList.DisplayMember = "name";

            guiD3ProfileExplorerDllName.Text = Assembly.GetExecutingAssembly().GetName().Name;
            guiD3ProfileExplorerVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            guiBattleNetDllName.Text = typeof(BattleNet.BattleTag).Assembly.GetName().Name;
            guiBattleNetVersion.Text = typeof(BattleNet.BattleTag).Assembly.GetName().Version.ToString();
            guiD3APIDllName.Text = typeof(D3.D3Api).Assembly.GetName().Name;
            guiD3APIVersion.Text = typeof(D3.D3Api).Assembly.GetName().Version.ToString();
        }

        private void guiProfileLookup_Click(object sender, EventArgs e)
        {
            BattleTag battleTag = new BattleTag(guiBattleTag.Text);

            TreeNode node = new TreeNode("Career of " + battleTag.ToString() + " on " + D3.D3Api.host);

            Career career;
            try
            {
                career = Career.getCareerFromBattleTag(battleTag);
            }
            catch (FileNotInCacheException)
            {
                MessageBox.Show("Career was not found in cache: go online to retrieve it.");
                return;
            }
            catch (BNetResponseFailed)
            {
                MessageBox.Show("Battle.net sent an http error: try again later.");
                return;
            }
            catch (BNetFailureObjectReturned)
            {
                MessageBox.Show("Battle.net sent an error: verify the battle tag.");
                return;
            }

            node.Nodes.AddRange(createNodeFromD3Object(career).ToArray());

            guiD3ProfileTreeView.Nodes.Add(node);
        }

        private List<TreeNode> createNodeFromD3Object(Object d3Object)
        {
            List<TreeNode> newNodes = new List<TreeNode>();

            Type type = d3Object.GetType();

            if (type.IsArray)
            {
                Object[] array = (Object[])d3Object;
                foreach (Object o in array)
                {
                    TreeNode newNode = new TreeNode(String.Format("[{0}]", o.GetType().Name));
                    newNode.Nodes.AddRange(createNodeFromD3Object(o).ToArray());
                    insertContextMenu(newNode, o);
                    newNodes.Add(newNode);
                }
            }
            else if (type.IsEnum)
            {
                TreeNode newNode = new TreeNode(d3Object.ToString());
                newNodes.Add(newNode);
            }
            else
            {
                if (type.FullName.Contains("ZTn.BNet.D3"))
                {
                    PropertyInfo[] propertyInfos = type.GetProperties();
                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        Object d3ObjectValue = propertyInfo.GetValue(d3Object, null);
                        if ((d3ObjectValue != null))
                        {
                            TreeNode newNode = new TreeNode(propertyInfo.Name);
                            newNode.Nodes.AddRange(createNodeFromD3Object(d3ObjectValue).ToArray());
                            insertContextMenu(newNode, d3ObjectValue);
                            newNodes.Add(newNode);
                        }
                    }
                    FieldInfo[] fieldInfos = type.GetFields();
                    foreach (FieldInfo fieldInfo in fieldInfos)
                    {
                        Object d3ObjectValue = fieldInfo.GetValue(d3Object);
                        if ((!fieldInfo.IsStatic) && (d3ObjectValue != null))
                        {
                            TreeNode newNode = new TreeNode(fieldInfo.Name);
                            newNode.Nodes.AddRange(createNodeFromD3Object(d3ObjectValue).ToArray());
                            insertContextMenu(newNode, d3ObjectValue);
                            newNodes.Add(newNode);
                        }
                    }
                }
                else
                {
                    TreeNode newNode = new TreeNode(d3Object.ToString());
                    newNodes.Add(newNode);
                }
            }
            return newNodes;
        }

        private void insertContextMenu(TreeNode node, Object d3Object)
        {
            if (d3Object is Hero)
            {
                node.Tag = d3Object;
                node.ContextMenuStrip = guiHeroContextMenu;
                node.NodeFont = new Font(guiD3ProfileTreeView.Font, FontStyle.Underline);
            }
            else if (d3Object is HeroSummary)
            {
                node.Tag = new HeroSummaryInformation(D3.D3Api.host, new BattleTag(guiBattleTag.Text), (HeroSummary)d3Object);
                node.ContextMenuStrip = guiHeroSummaryContextMenu;
                node.NodeFont = new Font(guiD3ProfileTreeView.Font, FontStyle.Underline);
            }
            else if (d3Object is ItemSummary)
            {
                node.Tag = d3Object;
                node.ContextMenuStrip = guiItemSummaryContextMenu;
                node.NodeFont = new Font(guiD3ProfileTreeView.Font, FontStyle.Underline);
            }
            else if (d3Object is CareerArtisan)
            {
                node.Tag = d3Object;
                node.ContextMenuStrip = guiCareerArtisanContextMenu;
                node.NodeFont = new Font(guiD3ProfileTreeView.Font, FontStyle.Underline);
            }
            else if (d3Object is Skill)
            {
                node.Tag = d3Object;
                node.ContextMenuStrip = guiSkillContextMenu;
                node.NodeFont = new Font(guiD3ProfileTreeView.Font, FontStyle.Underline);
            }
        }

        private void guiD3ProfileTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                guiD3ProfileTreeView.SelectedNode = e.Node;
        }

        private void exploreHeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HeroSummaryInformation heroSummaryInformation = (HeroSummaryInformation)guiD3ProfileTreeView.SelectedNode.Tag;

            TreeNode node = new TreeNode("Hero " + heroSummaryInformation.battleTag + " / " + heroSummaryInformation.heroSummary.id);

            Hero hero;
            try
            {
                hero = Hero.getHeroFromHeroId(heroSummaryInformation.battleTag, heroSummaryInformation.heroSummary.id);
            }
            catch (FileNotInCacheException)
            {
                MessageBox.Show("Hero was not found in cache: go online to retrieve it.");
                return;
            }

            node.Nodes.AddRange(createNodeFromD3Object(hero).ToArray());
            insertContextMenu(node, hero);

            guiD3ProfileTreeView.Nodes.Add(node);
        }

        private void exploreItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemSummary itemSummary = (ItemSummary)guiD3ProfileTreeView.SelectedNode.Tag;

            if (itemSummary.tooltipParams != null)
            {

                TreeNode node = new TreeNode("Item " + itemSummary.tooltipParams);

                Item item;
                try
                {
                    item = Item.getItemFromTooltipParams(itemSummary.tooltipParams);
                }
                catch (FileNotInCacheException)
                {
                    MessageBox.Show("Item was not found in cache: go online to retrieve it.");
                    return;
                }

                node.Nodes.AddRange(createNodeFromD3Object(item).ToArray());

                guiD3ProfileTreeView.Nodes.Add(node);
            }
        }

        private void exploreCareerArtisanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CareerArtisan careerArtisan = (CareerArtisan)guiD3ProfileTreeView.SelectedNode.Tag;

            TreeNode node = new TreeNode("Artisan " + careerArtisan.slug);

            Artisan artisan = Artisan.getArtisanFromSlug(careerArtisan.slug);

            node.Nodes.AddRange(createNodeFromD3Object(artisan).ToArray());

            guiD3ProfileTreeView.Nodes.Add(node);
        }

        private void guiBattleNetHostList_TextChanged(object sender, EventArgs e)
        {
            D3.D3Api.host = ((Host)guiBattleNetHostList.SelectedItem).url;
        }

        private void guiBattleNetLanguageList_TextChanged(object sender, EventArgs e)
        {
            D3.D3Api.locale = ((Language)guiBattleNetLanguageList.SelectedItem).code;
        }

        private void guiOfflineMode_CheckStateChanged(object sender, EventArgs e)
        {
            if (D3.D3Api.dataProvider is CacheableDataProvider)
            {
                CacheableDataProvider dataProvider = (CacheableDataProvider)D3.D3Api.dataProvider;
                dataProvider.online = !guiOfflineMode.Checked;
            }
        }

        private void d3CalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hero hero = (Hero)guiD3ProfileTreeView.SelectedNode.Tag;

            new D3CalculatorForm(hero).Show();
        }

        private void buildUniqueItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hero hero = (Hero)guiD3ProfileTreeView.SelectedNode.Tag;
            List<Item> items = new List<Item>{
                Item.getItemFromTooltipParams(hero.items.bracers.tooltipParams),
                Item.getItemFromTooltipParams(hero.items.feet.tooltipParams),
                Item.getItemFromTooltipParams(hero.items.hands.tooltipParams),
                Item.getItemFromTooltipParams(hero.items.head.tooltipParams),
                Item.getItemFromTooltipParams(hero.items.leftFinger.tooltipParams),
                Item.getItemFromTooltipParams(hero.items.legs.tooltipParams),
                Item.getItemFromTooltipParams(hero.items.neck.tooltipParams),
                Item.getItemFromTooltipParams(hero.items.rightFinger.tooltipParams),
                Item.getItemFromTooltipParams(hero.items.shoulders.tooltipParams),
                Item.getItemFromTooltipParams(hero.items.torso.tooltipParams),
                Item.getItemFromTooltipParams(hero.items.waist.tooltipParams)
            };

            Item mainHand = Item.getItemFromTooltipParams(hero.items.mainHand.tooltipParams);

            Item offHand = null;
            if (hero.items.offHand != null)
                offHand = Item.getItemFromTooltipParams(hero.items.offHand.tooltipParams);
            else
            {
                offHand = new Item();
                offHand.attributesRaw = new ItemAttributes();
            }

            StatsItem heroStuff = new StatsItem(mainHand, offHand, items.ToArray());
            heroStuff.update();

            TreeNode node = new TreeNode("Unique Item for " + hero.name);
            node.Nodes.AddRange(createNodeFromD3Object(heroStuff).ToArray());

            guiD3ProfileTreeView.Nodes.Add(node);

        }

        private void d3CalculatorHeroSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HeroSummaryInformation heroSummaryInformation = (HeroSummaryInformation)guiD3ProfileTreeView.SelectedNode.Tag;

            Hero hero;
            try
            {
                hero = Hero.getHeroFromHeroId(heroSummaryInformation.battleTag, heroSummaryInformation.heroSummary.id);
            }
            catch (FileNotInCacheException)
            {
                MessageBox.Show("Hero was not found in cache: go online to retrieve it.");
                return;
            }

            new D3CalculatorForm(hero).Show();
        }

        private void getItemLargeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemSummary itemSummary = (ItemSummary)guiD3ProfileTreeView.SelectedNode.Tag;
            if (itemSummary.icon != null)
            {
                D3Picture picture = D3.D3Api.getItemIcon(itemSummary.icon, "large");
                using (var imageStream = new MemoryStream(picture.bytes))
                {
                    guiD3Icon.Image = Image.FromStream(imageStream);
                }
            }
        }

        private void getItemSmallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemSummary itemSummary = (ItemSummary)guiD3ProfileTreeView.SelectedNode.Tag;
            if (itemSummary.icon != null)
            {
                D3Picture picture = D3.D3Api.getItemIcon(itemSummary.icon);
                using (var imageStream = new MemoryStream(picture.bytes))
                {
                    guiD3Icon.Image = Image.FromStream(imageStream);
                }
            }
        }

        private void getSkillIcon42ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Skill skill = (Skill)guiD3ProfileTreeView.SelectedNode.Tag;
            if (skill.icon != null)
            {
                D3Picture picture = D3.D3Api.getSkillIcon(skill.icon);
                using (var imageStream = new MemoryStream(picture.bytes))
                {
                    guiD3Icon.Image = Image.FromStream(imageStream);
                }
            }
        }

        private void getSkillIcon64ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Skill skill = (Skill)guiD3ProfileTreeView.SelectedNode.Tag;
            if (skill.icon != null)
            {
                D3Picture picture = D3.D3Api.getSkillIcon(skill.icon, "64");
                using (var imageStream = new MemoryStream(picture.bytes))
                {
                    guiD3Icon.Image = Image.FromStream(imageStream);
                }
            }
        }
    }
}

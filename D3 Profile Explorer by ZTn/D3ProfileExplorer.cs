﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using ZTn.BNet.BattleNet;
using ZTn.BNet.D3;
using ZTn.BNet.D3.Careers;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;
using ZTn.BNet.D3.Artisans;
using ZTn.BNet.D3.DataProviders;
using ZTn.BNet.D3.Calculator;
using ZTn.BNet.D3.Skills;
using System.IO;
using ZTn.BNet.D3.Calculator.Helpers;
using ZTn.BNet.D3.Calculator.Sets;
using System.Collections;
using ZTn.BNet.D3.Calculator.Gems;
using ZTn.BNet.D3.Helpers;
using ZTn.BNet.D3.Progresses;
using ZTn.BNet.D3.HeroFollowers;

namespace ZTn.BNet.D3ProfileExplorer
{
    public partial class GuiD3ProfileExplorer : Form
    {
        public GuiD3ProfileExplorer()
        {
            InitializeComponent();

            D3Api.DataProvider = new CacheableDataProvider(new HttpRequestDataProvider());

            var hosts = "hosts.json".CreateFromJsonFile<List<Host>>();
            guiBattleNetHostList.DataSource = hosts;
            guiBattleNetHostList.DisplayMember = "name";

            var langs = "languages.json".CreateFromJsonFile<List<Language>>();
            guiBattleNetLanguageList.DataSource = langs;
            guiBattleNetLanguageList.DisplayMember = "name";

            guiD3ProfileExplorerDllName.Text = Assembly.GetExecutingAssembly().GetName().Name;
            guiD3ProfileExplorerVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            guiBattleNetDllName.Text = typeof(BattleTag).Assembly.GetName().Name;
            guiBattleNetVersion.Text = typeof(BattleTag).Assembly.GetName().Version.ToString();
            guiD3APIDllName.Text = typeof(D3Api).Assembly.GetName().Name;
            guiD3APIVersion.Text = typeof(D3Api).Assembly.GetName().Version.ToString();
        }

        private void guiProfileLookup_Click(object sender, EventArgs e)
        {
            var battleTag = new BattleTag(guiBattleTag.Text);

            var node = new TreeNode("Career of " + battleTag + " on " + D3Api.Host);

            Career career;
            try
            {
                career = Career.CreateFromBattleTag(battleTag);
            }
            catch (FileNotInCacheException)
            {
                MessageBox.Show("Career was not found in cache: go online to retrieve it.");
                return;
            }
            catch (BNetResponseFailedException)
            {
                MessageBox.Show("Battle.net sent an http error: try again later.");
                return;
            }
            catch (BNetFailureObjectReturnedException)
            {
                MessageBox.Show("Battle.net sent an error: verify the battle tag.");
                return;
            }

            node.Nodes.AddRange(CreateNodeFromD3Object(career).ToArray());

            guiD3ProfileTreeView.Nodes.Add(node);
        }

        private List<TreeNode> CreateNodeFromD3Object(Object d3Object)
        {
            var newNodes = new List<TreeNode>();

            if (d3Object == null)
            {
                return newNodes;
            }

            var type = d3Object.GetType();

            if (type.IsArray)
            {
                var array = (Object[])d3Object;
                foreach (var o in array)
                {
                    var newNode = new TreeNode(String.Format("[{0}]", o.GetType().Name));
                    newNode.Nodes.AddRange(CreateNodeFromD3Object(o).ToArray());
                    InsertContextMenu(newNode, (dynamic)o);
                    UpdateNodeText(newNode, (dynamic)o);
                    newNodes.Add(newNode);
                }
            }
            else if (type.IsEnum)
            {
                var newNode = new TreeNode(d3Object.ToString());
                newNodes.Add(newNode);
            }
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                foreach (var o in (IList)d3Object)
                {
                    var newNode = new TreeNode(String.Format("[{0}]", o.GetType().Name));
                    newNode.Nodes.AddRange(CreateNodeFromD3Object(o).ToArray());
                    InsertContextMenu(newNode, (dynamic)o);
                    UpdateNodeText(newNode, (dynamic)o);
                    newNodes.Add(newNode);
                }
            }
            else
            {
                if (type.FullName.Contains("ZTn.BNet.D3"))
                {
                    var propertyInfos = type.GetProperties();
                    foreach (var propertyInfo in propertyInfos)
                    {
                        var d3ObjectValue = propertyInfo.GetValue(d3Object, null);
                        if ((d3ObjectValue != null))
                        {
                            var newNode = new TreeNode(propertyInfo.Name);
                            newNode.Nodes.AddRange(CreateNodeFromD3Object(d3ObjectValue).ToArray());
                            InsertContextMenu(newNode, (dynamic)d3ObjectValue);
                            UpdateNodeText(newNode, (dynamic)d3ObjectValue);
                            newNodes.Add(newNode);
                        }
                    }
                    var fieldInfos = type.GetFields();
                    foreach (var fieldInfo in fieldInfos.Where(info => !info.IsStatic))
                    {
                        var d3ObjectValue = fieldInfo.GetValue(d3Object);
                        if (d3ObjectValue != null)
                        {
                            var newNode = new TreeNode(fieldInfo.Name);
                            newNode.Nodes.AddRange(CreateNodeFromD3Object(d3ObjectValue).ToArray());
                            InsertContextMenu(newNode, (dynamic)d3ObjectValue);
                            UpdateNodeText(newNode, (dynamic)d3ObjectValue);
                            newNodes.Add(newNode);
                        }
                    }
                }
                else
                {
                    var newNode = new TreeNode(d3Object.ToString());
                    newNodes.Add(newNode);
                }
            }
            return newNodes;
        }

        #region >> InsertContextMenu Overloads

        private void InsertContextMenu(TreeNode node, Object d3Object)
        {
            // Catch "all": no context menu
        }

        private void InsertContextMenu(TreeNode node, Hero d3Object)
        {
            node.Tag = d3Object;
            node.ContextMenuStrip = guiHeroContextMenu;
            node.NodeFont = new Font(guiD3ProfileTreeView.Font, FontStyle.Underline);
        }

        private void InsertContextMenu(TreeNode node, HeroSummary d3Object)
        {
            node.Tag = new HeroSummaryInformation(D3Api.Host, new BattleTag(guiBattleTag.Text), d3Object);
            node.ContextMenuStrip = guiHeroSummaryContextMenu;
            node.NodeFont = new Font(guiD3ProfileTreeView.Font, FontStyle.Underline);
        }

        private void InsertContextMenu(TreeNode node, Item d3Object)
        {
            node.Tag = d3Object;
            node.ContextMenuStrip = guiItemContextMenu;
            node.NodeFont = new Font(guiD3ProfileTreeView.Font, FontStyle.Underline);
        }

        private void InsertContextMenu(TreeNode node, ItemSummary d3Object)
        {
            node.Tag = d3Object;
            node.ContextMenuStrip = guiItemSummaryContextMenu;
            node.NodeFont = new Font(guiD3ProfileTreeView.Font, FontStyle.Underline);
        }

        private void InsertContextMenu(TreeNode node, CareerArtisan d3Object)
        {
            node.Tag = d3Object;
            node.ContextMenuStrip = guiCareerArtisanContextMenu;
            node.NodeFont = new Font(guiD3ProfileTreeView.Font, FontStyle.Underline);
        }

        private void InsertContextMenu(TreeNode node, Skill d3Object)
        {
            node.Tag = d3Object;
            node.ContextMenuStrip = guiSkillContextMenu;
            node.NodeFont = new Font(guiD3ProfileTreeView.Font, FontStyle.Underline);
        }

        private void InsertContextMenu(TreeNode node, Follower d3Object)
        {
            node.Tag = d3Object;
            node.ContextMenuStrip = guiFollowerContextMenu;
            node.NodeFont = new Font(guiD3ProfileTreeView.Font, FontStyle.Underline);
        }

        #endregion

        #region >> UpdateNodeText Overloads

        private static void UpdateNodeText(TreeNode node, Object d3Object)
        {
        }

        private static void UpdateNodeText(TreeNode node, ActProgress d3Object)
        {
            node.Text += " >> " + d3Object.completed;
        }

        private static void UpdateNodeText(TreeNode node, CareerArtisan d3Object)
        {
            node.Text += " >> " + d3Object.slug;
        }

        private static void UpdateNodeText(TreeNode node, float d3Object)
        {
            node.Text += " >> " + d3Object;
        }

        private static void UpdateNodeText(TreeNode node, HeroSummary d3Object)
        {
            node.Text += String.Format(" >> L:{1:D2} P:{2:D2} - {0}", d3Object.name, d3Object.level, d3Object.paragonLevel);
        }

        private static void UpdateNodeText(TreeNode node, int d3Object)
        {
            node.Text += " >> " + d3Object;
        }

        private static void UpdateNodeText(TreeNode node, ItemSummary d3Object)
        {
            node.Text += " >> " + d3Object.name;
        }

        private static void UpdateNodeText(TreeNode node, Set d3Object)
        {
            node.Text += " >> " + d3Object.name;
        }

        private static void UpdateNodeText(TreeNode node, Skill d3Object)
        {
            node.Text += " >> " + d3Object.name;
        }

        private static void UpdateNodeText(TreeNode node, Quest d3Object)
        {
            node.Text += " >> " + d3Object.name;
        }

        private static void UpdateNodeText(TreeNode node, Recipe d3Object)
        {
            node.Text += " >> " + d3Object.name;
        }

        private static void UpdateNodeText(TreeNode node, String d3Object)
        {
            node.Text += " >> " + d3Object;
        }

        #endregion

        private void guiD3ProfileTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                guiD3ProfileTreeView.SelectedNode = e.Node;
        }

        private void exploreHeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var heroSummaryInformation = (HeroSummaryInformation)guiD3ProfileTreeView.SelectedNode.Tag;

            var node = new TreeNode("Hero " + heroSummaryInformation.battleTag + " / " + heroSummaryInformation.heroSummary.id + " (" + heroSummaryInformation.heroSummary.name + ")");

            Hero hero;
            try
            {
                hero = Hero.CreateFromHeroId(heroSummaryInformation.battleTag, heroSummaryInformation.heroSummary.id);
            }
            catch (FileNotInCacheException)
            {
                MessageBox.Show("Hero was not found in cache: go online to retrieve it.");
                return;
            }

            node.Nodes.AddRange(CreateNodeFromD3Object(hero).ToArray());
            InsertContextMenu(node, hero);

            guiD3ProfileTreeView.Nodes.Add(node);
        }

        private void exploreItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var itemSummary = (ItemSummary)guiD3ProfileTreeView.SelectedNode.Tag;

            if (itemSummary.tooltipParams != null)
            {

                var node = new TreeNode("Item [ " + itemSummary.name + " ]");

                Item item;
                try
                {
                    item = Item.CreateFromTooltipParams(itemSummary.tooltipParams);
                }
                catch (FileNotInCacheException)
                {
                    MessageBox.Show("Item was not found in cache: go online to retrieve it.");
                    return;
                }

                InsertContextMenu(node, item);

                node.Nodes.AddRange(CreateNodeFromD3Object(item).ToArray());

                guiD3ProfileTreeView.Nodes.Add(node);
            }
        }

        private void exploreCareerArtisanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var careerArtisan = (CareerArtisan)guiD3ProfileTreeView.SelectedNode.Tag;

            var node = new TreeNode("Artisan " + careerArtisan.slug);

            var artisan = Artisan.CreateFromSlug(careerArtisan.slug);

            node.Nodes.AddRange(CreateNodeFromD3Object(artisan).ToArray());

            guiD3ProfileTreeView.Nodes.Add(node);
        }

        private void guiBattleNetHostList_TextChanged(object sender, EventArgs e)
        {
            D3Api.Host = ((Host)guiBattleNetHostList.SelectedItem).Url;
        }

        private void guiBattleNetLanguageList_TextChanged(object sender, EventArgs e)
        {
            D3Api.Locale = ((Language)guiBattleNetLanguageList.SelectedItem).Code;
        }

        private void guiOfflineMode_CheckStateChanged(object sender, EventArgs e)
        {
            if (D3Api.DataProvider is CacheableDataProvider)
            {
                var dataProvider = (CacheableDataProvider)D3Api.DataProvider;
                dataProvider.onlineMode = (guiOfflineMode.Checked ? OnlineMode.Offline : OnlineMode.Online);
            }
        }

        private void d3CalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hero = (Hero)guiD3ProfileTreeView.SelectedNode.Tag;

            new D3CalculatorForm(hero).Show();
        }

        private void d3CalculatorFollowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var follower = (Follower)guiD3ProfileTreeView.SelectedNode.Tag;

            var slugToHeroClass = new Dictionary<string, HeroClass>
            {
                { "enchantress", HeroClass.EnchantressFollower },
                { "scoundrel", HeroClass.ScoundrelFollower },
                { "templar", HeroClass.TemplarFollower }
            };

            new D3CalculatorForm(follower, slugToHeroClass[follower.slug]).Show();
        }

        private void buildUniqueItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hero = (Hero)guiD3ProfileTreeView.SelectedNode.Tag;

            var items = new List<Item>();
            if (hero.items.bracers != null)
                items.Add(Item.CreateFromTooltipParams(hero.items.bracers.tooltipParams));
            if (hero.items.feet != null)
                items.Add(Item.CreateFromTooltipParams(hero.items.feet.tooltipParams));
            if (hero.items.hands != null)
                items.Add(Item.CreateFromTooltipParams(hero.items.hands.tooltipParams));
            if (hero.items.head != null)
                items.Add(Item.CreateFromTooltipParams(hero.items.head.tooltipParams));
            if (hero.items.leftFinger != null)
                items.Add(Item.CreateFromTooltipParams(hero.items.leftFinger.tooltipParams));
            if (hero.items.legs != null)
                items.Add(Item.CreateFromTooltipParams(hero.items.legs.tooltipParams));
            if (hero.items.neck != null)
                items.Add(Item.CreateFromTooltipParams(hero.items.neck.tooltipParams));
            if (hero.items.rightFinger != null)
                items.Add(Item.CreateFromTooltipParams(hero.items.rightFinger.tooltipParams));
            if (hero.items.shoulders != null)
                items.Add(Item.CreateFromTooltipParams(hero.items.shoulders.tooltipParams));
            if (hero.items.torso != null)
                items.Add(Item.CreateFromTooltipParams(hero.items.torso.tooltipParams));
            if (hero.items.waist != null)
                items.Add(Item.CreateFromTooltipParams(hero.items.waist.tooltipParams));

            var mainHand = Item.CreateFromTooltipParams(hero.items.mainHand.tooltipParams);

            Item offHand;
            if (hero.items.offHand != null)
            {
                offHand = Item.CreateFromTooltipParams(hero.items.offHand.tooltipParams);
            }
            else
            {
                offHand = new Item { attributesRaw = new ItemAttributes() };
            }

            var heroStuff = new StatsItem(mainHand, offHand, items.ToArray());
            heroStuff.Update();

            var node = new TreeNode("Unique Item for " + hero.name);
            node.Nodes.AddRange(CreateNodeFromD3Object(heroStuff).ToArray());

            guiD3ProfileTreeView.Nodes.Add(node);
        }

        private void buildUniqueItemFollowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var follower = (Follower)guiD3ProfileTreeView.SelectedNode.Tag;

            var items = new List<Item>();
            if (follower.items.special != null)
                items.Add(Item.CreateFromTooltipParams(follower.items.special.tooltipParams));
            if (follower.items.leftFinger != null)
                items.Add(Item.CreateFromTooltipParams(follower.items.leftFinger.tooltipParams));
            if (follower.items.neck != null)
                items.Add(Item.CreateFromTooltipParams(follower.items.neck.tooltipParams));
            if (follower.items.rightFinger != null)
                items.Add(Item.CreateFromTooltipParams(follower.items.rightFinger.tooltipParams));

            var mainHand = Item.CreateFromTooltipParams(follower.items.mainHand.tooltipParams);

            Item offHand;
            if (follower.items.offHand != null)
            {
                offHand = Item.CreateFromTooltipParams(follower.items.offHand.tooltipParams);
            }
            else
            {
                offHand = new Item(new ItemAttributes());
            }

            var heroStuff = new StatsItem(mainHand, offHand, items.ToArray());
            heroStuff.Update();

            var node = new TreeNode("Unique Item for " + follower.slug + " follower");
            node.Nodes.AddRange(CreateNodeFromD3Object(heroStuff).ToArray());

            guiD3ProfileTreeView.Nodes.Add(node);
        }

        private void d3CalculatorHeroSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var heroSummaryInformation = (HeroSummaryInformation)guiD3ProfileTreeView.SelectedNode.Tag;

            Hero hero;
            try
            {
                hero = Hero.CreateFromHeroId(heroSummaryInformation.battleTag, heroSummaryInformation.heroSummary.id);
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
            var itemSummary = (ItemSummary)guiD3ProfileTreeView.SelectedNode.Tag;
            if (itemSummary.icon != null)
            {
                var picture = D3Api.GetItemIcon(itemSummary.icon, "large");
                using (var imageStream = new MemoryStream(picture.Bytes))
                {
                    guiD3Icon.Image = Image.FromStream(imageStream);
                }
            }
        }

        private void getItemSmallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var itemSummary = (ItemSummary)guiD3ProfileTreeView.SelectedNode.Tag;
            if (itemSummary.icon != null)
            {
                var picture = D3Api.GetItemIcon(itemSummary.icon);
                using (var imageStream = new MemoryStream(picture.Bytes))
                {
                    guiD3Icon.Image = Image.FromStream(imageStream);
                }
            }
        }

        private void getSkillIcon42ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var skill = (Skill)guiD3ProfileTreeView.SelectedNode.Tag;
            if (skill.icon != null)
            {
                var picture = D3Api.GetSkillIcon(skill.icon);
                using (var imageStream = new MemoryStream(picture.Bytes))
                {
                    guiD3Icon.Image = Image.FromStream(imageStream);
                }
            }
        }

        private void getSkillIcon64ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var skill = (Skill)guiD3ProfileTreeView.SelectedNode.Tag;
            if (skill.icon != null)
            {
                var picture = D3Api.GetSkillIcon(skill.icon, "64");
                using (var imageStream = new MemoryStream(picture.Bytes))
                {
                    guiD3Icon.Image = Image.FromStream(imageStream);
                }
            }
        }

        private void guiLoadKnownSets_Click(object sender, EventArgs e)
        {
            var node = new TreeNode("Known Sets (loaded from d3set.json)");

            KnownSets knownSets;
            try
            {
                knownSets = KnownSets.CreateFromJsonFile("d3set.json");
            }
            catch (FileNotInCacheException)
            {
                MessageBox.Show("Known sets file was not found");
                return;
            }

            node.Nodes.AddRange(CreateNodeFromD3Object(knownSets).ToArray());

            guiD3ProfileTreeView.Nodes.Add(node);
        }

        private void guiLoadKnownGems_Click(object sender, EventArgs e)
        {
            var node = new TreeNode("Known Gems (loaded from d3gem.json)");

            KnownGems knownGems;
            try
            {
                knownGems = KnownGems.GetKnownGemsFromJsonFile("d3gem.json");
            }
            catch (FileNotInCacheException)
            {
                MessageBox.Show("Known gems file was not found");
                return;
            }

            node.Nodes.AddRange(CreateNodeFromD3Object(knownGems).ToArray());

            guiD3ProfileTreeView.Nodes.Add(node);
        }

        private void getMetaItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var itemSummary = (ItemSummary)guiD3ProfileTreeView.SelectedNode.Tag;

            if (itemSummary.id != null)
            {

                var node = new TreeNode("Item (meta) [ " + itemSummary.name + " ]");

                Item item;
                try
                {
                    item = Item.CreateFromTooltipParams("item/" + itemSummary.id);
                }
                catch (FileNotInCacheException)
                {
                    MessageBox.Show("Item was not found in cache: go online to retrieve it.");
                    return;
                }

                node.Nodes.AddRange(CreateNodeFromD3Object(item).ToArray());

                guiD3ProfileTreeView.Nodes.Add(node);
            }
        }

        private void simplifyItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var simplifiedItem = ((Item)guiD3ProfileTreeView.SelectedNode.Tag).Simplify();

            var node = new TreeNode("Item (simplified) [ " + simplifiedItem.name + " ]");

            InsertContextMenu(node, simplifiedItem);

            node.Nodes.AddRange(CreateNodeFromD3Object(simplifiedItem).ToArray());

            guiD3ProfileTreeView.Nodes.Add(node);
        }

        private void guiUpdateKnownGems_Click(object sender, EventArgs e)
        {
            var socketColors = new List<string> { "Amethyst", "Emerald", "Ruby", "Topaz" };

            var sockets = new List<Item>();

            foreach (var gemColor in socketColors)
            {
                for (var index = 1; index < 16; index++)
                {
                    var id = String.Format("{0}_{1:00}", gemColor, index);
                    sockets.Add(Item.CreateFromTooltipParams("item/" + id));
                }
            }

            sockets.WriteToJsonFile("d3gem.json");

            var node = new TreeNode("Updated Gems from battle.net (saved from d3gem.json)");

            var knownSets = KnownGems.GetKnownGemsFromJsonFile("d3gem.json");

            node.Nodes.AddRange(CreateNodeFromD3Object(knownSets).ToArray());

            guiD3ProfileTreeView.Nodes.Add(node);
        }

        private void guiBattleTag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guiProfileLookup_Click(sender, e);
            }
        }
    }
}

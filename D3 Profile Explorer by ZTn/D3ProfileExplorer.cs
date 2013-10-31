using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
using ZTn.BNet.D3.Calculator.Helpers;
using ZTn.BNet.D3.Calculator.Sets;
using System.Collections;
using ZTn.BNet.D3.Calculator.Gems;
using ZTn.BNet.D3.Helpers;
using ZTn.BNet.D3.Progresses;

namespace ZTn.BNet.D3ProfileExplorer
{
    public partial class guiD3ProfileExplorer : Form
    {
        public guiD3ProfileExplorer()
        {
            InitializeComponent();

            D3.D3Api.dataProvider = new CacheableDataProvider(new HttpRequestDataProvider());

            List<Host> hosts = JsonHelpers.getFromJsonFile<List<Host>>("hosts.json");
            guiBattleNetHostList.DataSource = hosts;
            guiBattleNetHostList.DisplayMember = "name";

            List<Language> langs = JsonHelpers.getFromJsonFile<List<Language>>("languages.json");
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
                    insertContextMenu(newNode, (dynamic)o);
                    updateNodeText(newNode, (dynamic)o);
                    newNodes.Add(newNode);
                }
            }
            else if (type.IsEnum)
            {
                TreeNode newNode = new TreeNode(d3Object.ToString());
                newNodes.Add(newNode);
            }
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                if (d3Object != null)
                {
                    foreach (Object o in (IList)d3Object)
                    {
                        TreeNode newNode = new TreeNode(String.Format("[{0}]", o.GetType().Name));
                        newNode.Nodes.AddRange(createNodeFromD3Object(o).ToArray());
                        insertContextMenu(newNode, (dynamic)o);
                        updateNodeText(newNode, (dynamic)o);
                        newNodes.Add(newNode);
                    }
                }
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
                            insertContextMenu(newNode, (dynamic)d3ObjectValue);
                            updateNodeText(newNode, (dynamic)d3ObjectValue);
                            newNodes.Add(newNode);
                        }
                    }
                    FieldInfo[] fieldInfos = type.GetFields();
                    foreach (FieldInfo fieldInfo in fieldInfos.Where(info => !info.IsStatic))
                    {
                        Object d3ObjectValue = fieldInfo.GetValue(d3Object);
                        if (d3ObjectValue != null)
                        {
                            TreeNode newNode = new TreeNode(fieldInfo.Name);
                            newNode.Nodes.AddRange(createNodeFromD3Object(d3ObjectValue).ToArray());
                            insertContextMenu(newNode, (dynamic)d3ObjectValue);
                            updateNodeText(newNode, (dynamic)d3ObjectValue);
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

        #region >> insertContextMenu Overloads

        private void insertContextMenu(TreeNode node, Object d3Object)
        {
            // Catch "all": no context menu
        }

        private void insertContextMenu(TreeNode node, Hero d3Object)
        {
            node.Tag = d3Object;
            node.ContextMenuStrip = guiHeroContextMenu;
            node.NodeFont = new Font(guiD3ProfileTreeView.Font, FontStyle.Underline);
        }

        private void insertContextMenu(TreeNode node, HeroSummary d3Object)
        {
            node.Tag = new HeroSummaryInformation(D3.D3Api.host, new BattleTag(guiBattleTag.Text), (HeroSummary)d3Object);
            node.ContextMenuStrip = guiHeroSummaryContextMenu;
            node.NodeFont = new Font(guiD3ProfileTreeView.Font, FontStyle.Underline);
        }

        private void insertContextMenu(TreeNode node, Item d3Object)
        {
            node.Tag = d3Object;
            node.ContextMenuStrip = guiItemContextMenu;
            node.NodeFont = new Font(guiD3ProfileTreeView.Font, FontStyle.Underline);
        }

        private void insertContextMenu(TreeNode node, ItemSummary d3Object)
        {
            node.Tag = d3Object;
            node.ContextMenuStrip = guiItemSummaryContextMenu;
            node.NodeFont = new Font(guiD3ProfileTreeView.Font, FontStyle.Underline);
        }

        private void insertContextMenu(TreeNode node, CareerArtisan d3Object)
        {
            node.Tag = d3Object;
            node.ContextMenuStrip = guiCareerArtisanContextMenu;
            node.NodeFont = new Font(guiD3ProfileTreeView.Font, FontStyle.Underline);
        }

        private void insertContextMenu(TreeNode node, Skill d3Object)
        {
            node.Tag = d3Object;
            node.ContextMenuStrip = guiSkillContextMenu;
            node.NodeFont = new Font(guiD3ProfileTreeView.Font, FontStyle.Underline);
        }

        #endregion

        #region >> updateNodeText Overloads

        private void updateNodeText(TreeNode node, Object d3Object)
        {
        }

        private void updateNodeText(TreeNode node, ActProgress d3Object)
        {
            node.Text += " >> " + d3Object.completed;
        }

        private void updateNodeText(TreeNode node, CareerArtisan d3Object)
        {
            node.Text += " >> " + d3Object.slug;
        }

        private void updateNodeText(TreeNode node, float d3Object)
        {
            node.Text += " >> " + d3Object;
        }

        private void updateNodeText(TreeNode node, HeroSummary d3Object)
        {
            node.Text += String.Format(" >> L:{1:D2} P:{2:D2} - {0}", d3Object.name, d3Object.level, d3Object.paragonLevel);
        }

        private void updateNodeText(TreeNode node, int d3Object)
        {
            node.Text += " >> " + d3Object;
        }

        private void updateNodeText(TreeNode node, ItemSummary d3Object)
        {
            node.Text += " >> " + d3Object.name;
        }

        private void updateNodeText(TreeNode node, Set d3Object)
        {
            node.Text += " >> " + d3Object.name;
        }

        private void updateNodeText(TreeNode node, Skill d3Object)
        {
            node.Text += " >> " + d3Object.name;
        }

        private void updateNodeText(TreeNode node, Quest d3Object)
        {
            node.Text += " >> " + d3Object.name;
        }

        private void updateNodeText(TreeNode node, Recipe d3Object)
        {
            node.Text += " >> " + d3Object.name;
        }

        private void updateNodeText(TreeNode node, String d3Object)
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
            HeroSummaryInformation heroSummaryInformation = (HeroSummaryInformation)guiD3ProfileTreeView.SelectedNode.Tag;

            TreeNode node = new TreeNode("Hero " + heroSummaryInformation.battleTag + " / " + heroSummaryInformation.heroSummary.id + " (" + heroSummaryInformation.heroSummary.name + ")");

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

                TreeNode node = new TreeNode("Item [ " + itemSummary.name + " ]");

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

                insertContextMenu(node, item);

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
                dataProvider.onlineMode = (guiOfflineMode.Checked ? OnlineMode.Offline : OnlineMode.Online);
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
            List<Item> items = new List<Item>();
            if (hero.items.bracers != null)
                items.Add(Item.getItemFromTooltipParams(hero.items.bracers.tooltipParams));
            if (hero.items.feet != null)
                items.Add(Item.getItemFromTooltipParams(hero.items.feet.tooltipParams));
            if (hero.items.hands != null)
                items.Add(Item.getItemFromTooltipParams(hero.items.hands.tooltipParams));
            if (hero.items.head != null)
                items.Add(Item.getItemFromTooltipParams(hero.items.head.tooltipParams));
            if (hero.items.leftFinger != null)
                items.Add(Item.getItemFromTooltipParams(hero.items.leftFinger.tooltipParams));
            if (hero.items.legs != null)
                items.Add(Item.getItemFromTooltipParams(hero.items.legs.tooltipParams));
            if (hero.items.neck != null)
                items.Add(Item.getItemFromTooltipParams(hero.items.neck.tooltipParams));
            if (hero.items.rightFinger != null)
                items.Add(Item.getItemFromTooltipParams(hero.items.rightFinger.tooltipParams));
            if (hero.items.shoulders != null)
                items.Add(Item.getItemFromTooltipParams(hero.items.shoulders.tooltipParams));
            if (hero.items.torso != null)
                items.Add(Item.getItemFromTooltipParams(hero.items.torso.tooltipParams));
            if (hero.items.waist != null)
                items.Add(Item.getItemFromTooltipParams(hero.items.waist.tooltipParams));

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

        private void guiLoadKnownSets_Click(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode("Known Sets (loaded from d3set.json)");

            KnownSets knownSets;
            try
            {
                knownSets = KnownSets.getKnownSetsFromJsonFile("d3set.json");
            }
            catch (FileNotInCacheException)
            {
                MessageBox.Show("Known sets file was not found");
                return;
            }

            node.Nodes.AddRange(createNodeFromD3Object(knownSets).ToArray());

            guiD3ProfileTreeView.Nodes.Add(node);
        }

        private void guiLoadKnownGems_Click(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode("Known Gems (loaded from d3gem.json)");

            KnownGems knownGems;
            try
            {
                knownGems = KnownGems.getKnownGemsFromJsonFile("d3gem.json");
            }
            catch (FileNotInCacheException)
            {
                MessageBox.Show("Known gems file was not found");
                return;
            }

            node.Nodes.AddRange(createNodeFromD3Object(knownGems).ToArray());

            guiD3ProfileTreeView.Nodes.Add(node);
        }

        private void getMetaItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemSummary itemSummary = (ItemSummary)guiD3ProfileTreeView.SelectedNode.Tag;

            if (itemSummary.id != null)
            {

                TreeNode node = new TreeNode("Item (meta) [ " + itemSummary.name + " ]");

                Item item;
                try
                {
                    item = Item.getItemFromTooltipParams("item/" + itemSummary.id);
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

        private void simplifyItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Item simplifiedItem = ((Item)guiD3ProfileTreeView.SelectedNode.Tag).simplify();

            TreeNode node = new TreeNode("Item (simplified) [ " + simplifiedItem.name + " ]");

            insertContextMenu(node, simplifiedItem);

            node.Nodes.AddRange(createNodeFromD3Object(simplifiedItem).ToArray());

            guiD3ProfileTreeView.Nodes.Add(node);
        }

        private void guiUpdateKnownGems_Click(object sender, EventArgs e)
        {
            List<String> socketColors = new List<string>() { "Amethyst", "Emerald", "Ruby", "Topaz" };

            List<Item> sockets = new List<Item>();

            foreach (String gemColor in socketColors)
            {
                for (int index = 1; index < 16; index++)
                {
                    String id = String.Format("{0}_{1:00}", gemColor, index);
                    sockets.Add(Item.getItemFromTooltipParams("item/" + id));
                }
            }

            JsonHelpers.writeToJsonFile(sockets, "d3gem.json");

            TreeNode node = new TreeNode("Updated Gems from battle.net (saved from d3gem.json)");

            KnownGems knownSets = KnownGems.getKnownGemsFromJsonFile("d3gem.json");

            node.Nodes.AddRange(createNodeFromD3Object(knownSets).ToArray());

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

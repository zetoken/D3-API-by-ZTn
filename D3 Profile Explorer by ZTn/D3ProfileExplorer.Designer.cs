namespace ZTn.BNet.D3ProfileExplorer
{
    partial class guiD3ProfileExplorer
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label guiLabel1;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiD3ProfileExplorer));
            this.guiD3ProfileTreeView = new System.Windows.Forms.TreeView();
            this.guiProfileLookup = new System.Windows.Forms.Button();
            this.guiBattleTag = new System.Windows.Forms.TextBox();
            this.guiHeroSummaryContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exploreHeroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.d3CalculatorHeroSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guiItemSummaryContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exploreItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getItemSmallIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getItemLargeIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guiBattleNetHostList = new System.Windows.Forms.ComboBox();
            this.guiBattleNetLanguageList = new System.Windows.Forms.ComboBox();
            this.guiBattleNetDllName = new System.Windows.Forms.Label();
            this.guiD3APIDllName = new System.Windows.Forms.Label();
            this.guiBattleNetVersion = new System.Windows.Forms.Label();
            this.guiD3APIVersion = new System.Windows.Forms.Label();
            this.guiD3ProfileExplorerVersion = new System.Windows.Forms.Label();
            this.guiD3ProfileExplorerDllName = new System.Windows.Forms.Label();
            this.guiCareerArtisanContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exploreCareerArtisanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guiOfflineMode = new System.Windows.Forms.CheckBox();
            this.guiHeroContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.d3CalculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildUniqueItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guiSkillContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.getSkillIcon42ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getSkillIcon64ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guiD3Icon = new System.Windows.Forms.PictureBox();
            this.guiLoadKnownSets = new System.Windows.Forms.Button();
            guiLabel1 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.guiHeroSummaryContextMenu.SuspendLayout();
            this.guiItemSummaryContextMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.guiCareerArtisanContextMenu.SuspendLayout();
            this.guiHeroContextMenu.SuspendLayout();
            this.guiSkillContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guiD3Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // guiLabel1
            // 
            guiLabel1.AutoSize = true;
            guiLabel1.Location = new System.Drawing.Point(14, 32);
            guiLabel1.Name = "guiLabel1";
            guiLabel1.Size = new System.Drawing.Size(59, 13);
            guiLabel1.TabIndex = 4;
            guiLabel1.Text = "Battle Tag:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(14, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(32, 13);
            label1.TabIndex = 0;
            label1.Text = "Host:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(185, 6);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(58, 13);
            label2.TabIndex = 2;
            label2.Text = "Language:";
            // 
            // guiD3ProfileTreeView
            // 
            this.guiD3ProfileTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guiD3ProfileTreeView.Location = new System.Drawing.Point(12, 71);
            this.guiD3ProfileTreeView.Name = "guiD3ProfileTreeView";
            this.guiD3ProfileTreeView.Size = new System.Drawing.Size(604, 479);
            this.guiD3ProfileTreeView.TabIndex = 1;
            this.guiD3ProfileTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.guiD3ProfileTreeView_NodeMouseClick);
            // 
            // guiProfileLookup
            // 
            this.guiProfileLookup.Location = new System.Drawing.Point(185, 27);
            this.guiProfileLookup.Name = "guiProfileLookup";
            this.guiProfileLookup.Size = new System.Drawing.Size(150, 23);
            this.guiProfileLookup.TabIndex = 6;
            this.guiProfileLookup.Text = "Profile lookup";
            this.guiProfileLookup.UseVisualStyleBackColor = true;
            this.guiProfileLookup.Click += new System.EventHandler(this.guiProfileLookup_Click);
            // 
            // guiBattleTag
            // 
            this.guiBattleTag.Location = new System.Drawing.Point(79, 29);
            this.guiBattleTag.Name = "guiBattleTag";
            this.guiBattleTag.Size = new System.Drawing.Size(100, 20);
            this.guiBattleTag.TabIndex = 5;
            // 
            // guiHeroSummaryContextMenu
            // 
            this.guiHeroSummaryContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exploreHeroToolStripMenuItem,
            this.d3CalculatorHeroSummaryToolStripMenuItem});
            this.guiHeroSummaryContextMenu.Name = "guiHeroSummaryContextMenu";
            this.guiHeroSummaryContextMenu.Size = new System.Drawing.Size(146, 48);
            // 
            // exploreHeroToolStripMenuItem
            // 
            this.exploreHeroToolStripMenuItem.Name = "exploreHeroToolStripMenuItem";
            this.exploreHeroToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.exploreHeroToolStripMenuItem.Text = "Explore Hero";
            this.exploreHeroToolStripMenuItem.Click += new System.EventHandler(this.exploreHeroToolStripMenuItem_Click);
            // 
            // d3CalculatorHeroSummaryToolStripMenuItem
            // 
            this.d3CalculatorHeroSummaryToolStripMenuItem.Name = "d3CalculatorHeroSummaryToolStripMenuItem";
            this.d3CalculatorHeroSummaryToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.d3CalculatorHeroSummaryToolStripMenuItem.Text = "D3 Calculator";
            this.d3CalculatorHeroSummaryToolStripMenuItem.Click += new System.EventHandler(this.d3CalculatorHeroSummaryToolStripMenuItem_Click);
            // 
            // guiItemSummaryContextMenu
            // 
            this.guiItemSummaryContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exploreItemToolStripMenuItem,
            this.getItemSmallIconToolStripMenuItem,
            this.getItemLargeIconToolStripMenuItem});
            this.guiItemSummaryContextMenu.Name = "guiHeroSummaryContextMenu";
            this.guiItemSummaryContextMenu.Size = new System.Drawing.Size(178, 70);
            // 
            // exploreItemToolStripMenuItem
            // 
            this.exploreItemToolStripMenuItem.Name = "exploreItemToolStripMenuItem";
            this.exploreItemToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.exploreItemToolStripMenuItem.Text = "Explore Item";
            this.exploreItemToolStripMenuItem.Click += new System.EventHandler(this.exploreItemToolStripMenuItem_Click);
            // 
            // getItemSmallIconToolStripMenuItem
            // 
            this.getItemSmallIconToolStripMenuItem.Name = "getItemSmallIconToolStripMenuItem";
            this.getItemSmallIconToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.getItemSmallIconToolStripMenuItem.Text = "Get Item Small Icon";
            this.getItemSmallIconToolStripMenuItem.Click += new System.EventHandler(this.getItemSmallIconToolStripMenuItem_Click);
            // 
            // getItemLargeIconToolStripMenuItem
            // 
            this.getItemLargeIconToolStripMenuItem.Name = "getItemLargeIconToolStripMenuItem";
            this.getItemLargeIconToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.getItemLargeIconToolStripMenuItem.Text = "Get Item Large Icon";
            this.getItemLargeIconToolStripMenuItem.Click += new System.EventHandler(this.getItemLargeIconToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.guiBattleNetHostList);
            this.panel1.Controls.Add(label2);
            this.panel1.Controls.Add(this.guiBattleNetLanguageList);
            this.panel1.Controls.Add(label1);
            this.panel1.Controls.Add(guiLabel1);
            this.panel1.Controls.Add(this.guiProfileLookup);
            this.panel1.Controls.Add(this.guiBattleTag);
            this.panel1.Location = new System.Drawing.Point(434, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 53);
            this.panel1.TabIndex = 0;
            // 
            // guiBattleNetHostList
            // 
            this.guiBattleNetHostList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guiBattleNetHostList.FormattingEnabled = true;
            this.guiBattleNetHostList.Location = new System.Drawing.Point(79, 3);
            this.guiBattleNetHostList.Name = "guiBattleNetHostList";
            this.guiBattleNetHostList.Size = new System.Drawing.Size(100, 21);
            this.guiBattleNetHostList.TabIndex = 1;
            this.guiBattleNetHostList.TextChanged += new System.EventHandler(this.guiBattleNetHostList_TextChanged);
            // 
            // guiBattleNetLanguageList
            // 
            this.guiBattleNetLanguageList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guiBattleNetLanguageList.FormattingEnabled = true;
            this.guiBattleNetLanguageList.Location = new System.Drawing.Point(266, 3);
            this.guiBattleNetLanguageList.Name = "guiBattleNetLanguageList";
            this.guiBattleNetLanguageList.Size = new System.Drawing.Size(69, 21);
            this.guiBattleNetLanguageList.TabIndex = 3;
            this.guiBattleNetLanguageList.TextChanged += new System.EventHandler(this.guiBattleNetLanguageList_TextChanged);
            // 
            // guiBattleNetDllName
            // 
            this.guiBattleNetDllName.AutoSize = true;
            this.guiBattleNetDllName.Location = new System.Drawing.Point(15, 27);
            this.guiBattleNetDllName.Name = "guiBattleNetDllName";
            this.guiBattleNetDllName.Size = new System.Drawing.Size(88, 13);
            this.guiBattleNetDllName.TabIndex = 3;
            this.guiBattleNetDllName.Text = "BNet API by ZTn";
            // 
            // guiD3APIDllName
            // 
            this.guiD3APIDllName.AutoSize = true;
            this.guiD3APIDllName.Location = new System.Drawing.Point(15, 45);
            this.guiD3APIDllName.Name = "guiD3APIDllName";
            this.guiD3APIDllName.Size = new System.Drawing.Size(78, 13);
            this.guiD3APIDllName.TabIndex = 5;
            this.guiD3APIDllName.Text = "D3 API by ZTn";
            // 
            // guiBattleNetVersion
            // 
            this.guiBattleNetVersion.AutoSize = true;
            this.guiBattleNetVersion.Location = new System.Drawing.Point(152, 27);
            this.guiBattleNetVersion.Name = "guiBattleNetVersion";
            this.guiBattleNetVersion.Size = new System.Drawing.Size(40, 13);
            this.guiBattleNetVersion.TabIndex = 4;
            this.guiBattleNetVersion.Text = "0.0.0.0";
            // 
            // guiD3APIVersion
            // 
            this.guiD3APIVersion.AutoSize = true;
            this.guiD3APIVersion.Location = new System.Drawing.Point(152, 45);
            this.guiD3APIVersion.Name = "guiD3APIVersion";
            this.guiD3APIVersion.Size = new System.Drawing.Size(40, 13);
            this.guiD3APIVersion.TabIndex = 6;
            this.guiD3APIVersion.Text = "0.0.0.0";
            // 
            // guiD3ProfileExplorerVersion
            // 
            this.guiD3ProfileExplorerVersion.AutoSize = true;
            this.guiD3ProfileExplorerVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guiD3ProfileExplorerVersion.Location = new System.Drawing.Point(152, 9);
            this.guiD3ProfileExplorerVersion.Name = "guiD3ProfileExplorerVersion";
            this.guiD3ProfileExplorerVersion.Size = new System.Drawing.Size(40, 13);
            this.guiD3ProfileExplorerVersion.TabIndex = 2;
            this.guiD3ProfileExplorerVersion.Text = "0.0.0.0";
            // 
            // guiD3ProfileExplorerDllName
            // 
            this.guiD3ProfileExplorerDllName.AutoSize = true;
            this.guiD3ProfileExplorerDllName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guiD3ProfileExplorerDllName.Location = new System.Drawing.Point(15, 9);
            this.guiD3ProfileExplorerDllName.Name = "guiD3ProfileExplorerDllName";
            this.guiD3ProfileExplorerDllName.Size = new System.Drawing.Size(131, 13);
            this.guiD3ProfileExplorerDllName.TabIndex = 1;
            this.guiD3ProfileExplorerDllName.Text = "D3 Profile Explorer by ZTn";
            // 
            // guiCareerArtisanContextMenu
            // 
            this.guiCareerArtisanContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exploreCareerArtisanToolStripMenuItem});
            this.guiCareerArtisanContextMenu.Name = "guiHeroSummaryContextMenu";
            this.guiCareerArtisanContextMenu.Size = new System.Drawing.Size(153, 26);
            // 
            // exploreCareerArtisanToolStripMenuItem
            // 
            this.exploreCareerArtisanToolStripMenuItem.Name = "exploreCareerArtisanToolStripMenuItem";
            this.exploreCareerArtisanToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exploreCareerArtisanToolStripMenuItem.Text = "Explore Artisan";
            this.exploreCareerArtisanToolStripMenuItem.Click += new System.EventHandler(this.exploreCareerArtisanToolStripMenuItem_Click);
            // 
            // guiOfflineMode
            // 
            this.guiOfflineMode.AutoSize = true;
            this.guiOfflineMode.Location = new System.Drawing.Point(303, 17);
            this.guiOfflineMode.Name = "guiOfflineMode";
            this.guiOfflineMode.Size = new System.Drawing.Size(125, 17);
            this.guiOfflineMode.TabIndex = 8;
            this.guiOfflineMode.Text = "Offline Mode (cache)";
            this.guiOfflineMode.UseVisualStyleBackColor = true;
            this.guiOfflineMode.CheckStateChanged += new System.EventHandler(this.guiOfflineMode_CheckStateChanged);
            // 
            // guiHeroContextMenu
            // 
            this.guiHeroContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.d3CalculatorToolStripMenuItem,
            this.buildUniqueItemToolStripMenuItem});
            this.guiHeroContextMenu.Name = "guiHeroSummaryContextMenu";
            this.guiHeroContextMenu.Size = new System.Drawing.Size(170, 48);
            // 
            // d3CalculatorToolStripMenuItem
            // 
            this.d3CalculatorToolStripMenuItem.Name = "d3CalculatorToolStripMenuItem";
            this.d3CalculatorToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.d3CalculatorToolStripMenuItem.Text = "D3 Calculator";
            this.d3CalculatorToolStripMenuItem.Click += new System.EventHandler(this.d3CalculatorToolStripMenuItem_Click);
            // 
            // buildUniqueItemToolStripMenuItem
            // 
            this.buildUniqueItemToolStripMenuItem.Name = "buildUniqueItemToolStripMenuItem";
            this.buildUniqueItemToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.buildUniqueItemToolStripMenuItem.Text = "Build Unique Item";
            this.buildUniqueItemToolStripMenuItem.Click += new System.EventHandler(this.buildUniqueItemToolStripMenuItem_Click);
            // 
            // guiSkillContextMenu
            // 
            this.guiSkillContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getSkillIcon42ToolStripMenuItem,
            this.getSkillIcon64ToolStripMenuItem});
            this.guiSkillContextMenu.Name = "guiHeroSummaryContextMenu";
            this.guiSkillContextMenu.Size = new System.Drawing.Size(166, 48);
            // 
            // getSkillIcon42ToolStripMenuItem
            // 
            this.getSkillIcon42ToolStripMenuItem.Name = "getSkillIcon42ToolStripMenuItem";
            this.getSkillIcon42ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.getSkillIcon42ToolStripMenuItem.Text = "Get Skill Icon (42)";
            this.getSkillIcon42ToolStripMenuItem.Click += new System.EventHandler(this.getSkillIcon42ToolStripMenuItem_Click);
            // 
            // getSkillIcon64ToolStripMenuItem
            // 
            this.getSkillIcon64ToolStripMenuItem.Name = "getSkillIcon64ToolStripMenuItem";
            this.getSkillIcon64ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.getSkillIcon64ToolStripMenuItem.Text = "Get Skill Icon (64)";
            this.getSkillIcon64ToolStripMenuItem.Click += new System.EventHandler(this.getSkillIcon64ToolStripMenuItem_Click);
            // 
            // guiD3Icon
            // 
            this.guiD3Icon.Location = new System.Drawing.Point(622, 350);
            this.guiD3Icon.Name = "guiD3Icon";
            this.guiD3Icon.Size = new System.Drawing.Size(150, 200);
            this.guiD3Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.guiD3Icon.TabIndex = 9;
            this.guiD3Icon.TabStop = false;
            // 
            // guiLoadKnownSets
            // 
            this.guiLoadKnownSets.Location = new System.Drawing.Point(623, 72);
            this.guiLoadKnownSets.Name = "guiLoadKnownSets";
            this.guiLoadKnownSets.Size = new System.Drawing.Size(149, 23);
            this.guiLoadKnownSets.TabIndex = 10;
            this.guiLoadKnownSets.Text = "Load known sets";
            this.guiLoadKnownSets.UseVisualStyleBackColor = true;
            this.guiLoadKnownSets.Click += new System.EventHandler(this.guiLoadKnownSets_Click);
            // 
            // guiD3ProfileExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.guiLoadKnownSets);
            this.Controls.Add(this.guiD3Icon);
            this.Controls.Add(this.guiOfflineMode);
            this.Controls.Add(this.guiD3ProfileExplorerVersion);
            this.Controls.Add(this.guiD3ProfileExplorerDllName);
            this.Controls.Add(this.guiD3APIVersion);
            this.Controls.Add(this.guiBattleNetVersion);
            this.Controls.Add(this.guiD3APIDllName);
            this.Controls.Add(this.guiBattleNetDllName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.guiD3ProfileTreeView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiD3ProfileExplorer";
            this.Text = "D3 Profile Explorer by ZTn";
            this.guiHeroSummaryContextMenu.ResumeLayout(false);
            this.guiItemSummaryContextMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.guiCareerArtisanContextMenu.ResumeLayout(false);
            this.guiHeroContextMenu.ResumeLayout(false);
            this.guiSkillContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guiD3Icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView guiD3ProfileTreeView;
        private System.Windows.Forms.Button guiProfileLookup;
        private System.Windows.Forms.TextBox guiBattleTag;
        private System.Windows.Forms.ContextMenuStrip guiHeroSummaryContextMenu;
        private System.Windows.Forms.ToolStripMenuItem exploreHeroToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip guiItemSummaryContextMenu;
        private System.Windows.Forms.ToolStripMenuItem exploreItemToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label guiBattleNetVersion;
        private System.Windows.Forms.Label guiD3APIVersion;
        private System.Windows.Forms.Label guiBattleNetDllName;
        private System.Windows.Forms.Label guiD3APIDllName;
        private System.Windows.Forms.Label guiD3ProfileExplorerVersion;
        private System.Windows.Forms.Label guiD3ProfileExplorerDllName;
        private System.Windows.Forms.ContextMenuStrip guiCareerArtisanContextMenu;
        private System.Windows.Forms.ToolStripMenuItem exploreCareerArtisanToolStripMenuItem;
        private System.Windows.Forms.ComboBox guiBattleNetHostList;
        private System.Windows.Forms.ComboBox guiBattleNetLanguageList;
        private System.Windows.Forms.CheckBox guiOfflineMode;
        private System.Windows.Forms.ContextMenuStrip guiHeroContextMenu;
        private System.Windows.Forms.ToolStripMenuItem d3CalculatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildUniqueItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem d3CalculatorHeroSummaryToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip guiSkillContextMenu;
        private System.Windows.Forms.ToolStripMenuItem getSkillIcon42ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getItemSmallIconToolStripMenuItem;
        private System.Windows.Forms.PictureBox guiD3Icon;
        private System.Windows.Forms.ToolStripMenuItem getItemLargeIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getSkillIcon64ToolStripMenuItem;
        private System.Windows.Forms.Button guiLoadKnownSets;
    }
}


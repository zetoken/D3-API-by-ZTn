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
            this.guiItemSummaryContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exploreItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guiBattleNetLanguage = new System.Windows.Forms.TextBox();
            this.guiBattleNetHost = new System.Windows.Forms.TextBox();
            this.guiBattleNetDllName = new System.Windows.Forms.Label();
            this.guiD3APIDllName = new System.Windows.Forms.Label();
            this.guiBattleNetVersion = new System.Windows.Forms.Label();
            this.guiD3APIVersion = new System.Windows.Forms.Label();
            this.guiD3ProfileExplorerVersion = new System.Windows.Forms.Label();
            this.guiD3ProfileExplorerDllName = new System.Windows.Forms.Label();
            this.guiCareerArtisanContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exploreICareerArtisanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            guiLabel1 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.guiHeroSummaryContextMenu.SuspendLayout();
            this.guiItemSummaryContextMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.guiCareerArtisanContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // guiLabel1
            // 
            guiLabel1.AutoSize = true;
            guiLabel1.Location = new System.Drawing.Point(14, 32);
            guiLabel1.Name = "guiLabel1";
            guiLabel1.Size = new System.Drawing.Size(59, 13);
            guiLabel1.TabIndex = 0;
            guiLabel1.Text = "Battle Tag:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(14, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(32, 13);
            label1.TabIndex = 3;
            label1.Text = "Host:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(185, 6);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(58, 13);
            label2.TabIndex = 5;
            label2.Text = "Language:";
            // 
            // guiD3ProfileTreeView
            // 
            this.guiD3ProfileTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guiD3ProfileTreeView.Location = new System.Drawing.Point(12, 71);
            this.guiD3ProfileTreeView.Name = "guiD3ProfileTreeView";
            this.guiD3ProfileTreeView.Size = new System.Drawing.Size(760, 479);
            this.guiD3ProfileTreeView.TabIndex = 1;
            this.guiD3ProfileTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.guiD3ProfileTreeView_NodeMouseClick);
            // 
            // guiProfileLookup
            // 
            this.guiProfileLookup.Location = new System.Drawing.Point(185, 27);
            this.guiProfileLookup.Name = "guiProfileLookup";
            this.guiProfileLookup.Size = new System.Drawing.Size(150, 23);
            this.guiProfileLookup.TabIndex = 2;
            this.guiProfileLookup.Text = "Profile lookup";
            this.guiProfileLookup.UseVisualStyleBackColor = true;
            this.guiProfileLookup.Click += new System.EventHandler(this.guiProfileLookup_Click);
            // 
            // guiBattleTag
            // 
            this.guiBattleTag.Location = new System.Drawing.Point(79, 29);
            this.guiBattleTag.Name = "guiBattleTag";
            this.guiBattleTag.Size = new System.Drawing.Size(100, 20);
            this.guiBattleTag.TabIndex = 1;
            // 
            // guiHeroSummaryContextMenu
            // 
            this.guiHeroSummaryContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exploreHeroToolStripMenuItem});
            this.guiHeroSummaryContextMenu.Name = "guiHeroSummaryContextMenu";
            this.guiHeroSummaryContextMenu.Size = new System.Drawing.Size(142, 26);
            // 
            // exploreHeroToolStripMenuItem
            // 
            this.exploreHeroToolStripMenuItem.Name = "exploreHeroToolStripMenuItem";
            this.exploreHeroToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.exploreHeroToolStripMenuItem.Text = "Explore Hero";
            this.exploreHeroToolStripMenuItem.Click += new System.EventHandler(this.exploreHeroToolStripMenuItem_Click);
            // 
            // guiItemSummaryContextMenu
            // 
            this.guiItemSummaryContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exploreItemToolStripMenuItem});
            this.guiItemSummaryContextMenu.Name = "guiHeroSummaryContextMenu";
            this.guiItemSummaryContextMenu.Size = new System.Drawing.Size(140, 26);
            // 
            // exploreItemToolStripMenuItem
            // 
            this.exploreItemToolStripMenuItem.Name = "exploreItemToolStripMenuItem";
            this.exploreItemToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.exploreItemToolStripMenuItem.Text = "Explore Item";
            this.exploreItemToolStripMenuItem.Click += new System.EventHandler(this.exploreItemToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(label2);
            this.panel1.Controls.Add(this.guiBattleNetLanguage);
            this.panel1.Controls.Add(label1);
            this.panel1.Controls.Add(this.guiBattleNetHost);
            this.panel1.Controls.Add(guiLabel1);
            this.panel1.Controls.Add(this.guiProfileLookup);
            this.panel1.Controls.Add(this.guiBattleTag);
            this.panel1.Location = new System.Drawing.Point(434, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 53);
            this.panel1.TabIndex = 0;
            // 
            // guiBattleNetLanguage
            // 
            this.guiBattleNetLanguage.Location = new System.Drawing.Point(266, 3);
            this.guiBattleNetLanguage.Name = "guiBattleNetLanguage";
            this.guiBattleNetLanguage.Size = new System.Drawing.Size(69, 20);
            this.guiBattleNetLanguage.TabIndex = 6;
            this.guiBattleNetLanguage.TextChanged += new System.EventHandler(this.guiBattleNetLanguage_TextChanged);
            // 
            // guiBattleNetHost
            // 
            this.guiBattleNetHost.Location = new System.Drawing.Point(79, 3);
            this.guiBattleNetHost.Name = "guiBattleNetHost";
            this.guiBattleNetHost.Size = new System.Drawing.Size(100, 20);
            this.guiBattleNetHost.TabIndex = 4;
            // 
            // guiBattleNetDllName
            // 
            this.guiBattleNetDllName.AutoSize = true;
            this.guiBattleNetDllName.Location = new System.Drawing.Point(15, 27);
            this.guiBattleNetDllName.Name = "guiBattleNetDllName";
            this.guiBattleNetDllName.Size = new System.Drawing.Size(88, 13);
            this.guiBattleNetDllName.TabIndex = 4;
            this.guiBattleNetDllName.Text = "BNet API by ZTn";
            // 
            // guiD3APIDllName
            // 
            this.guiD3APIDllName.AutoSize = true;
            this.guiD3APIDllName.Location = new System.Drawing.Point(15, 45);
            this.guiD3APIDllName.Name = "guiD3APIDllName";
            this.guiD3APIDllName.Size = new System.Drawing.Size(78, 13);
            this.guiD3APIDllName.TabIndex = 6;
            this.guiD3APIDllName.Text = "D3 API by ZTn";
            // 
            // guiBattleNetVersion
            // 
            this.guiBattleNetVersion.AutoSize = true;
            this.guiBattleNetVersion.Location = new System.Drawing.Point(152, 27);
            this.guiBattleNetVersion.Name = "guiBattleNetVersion";
            this.guiBattleNetVersion.Size = new System.Drawing.Size(40, 13);
            this.guiBattleNetVersion.TabIndex = 5;
            this.guiBattleNetVersion.Text = "0.0.0.0";
            // 
            // guiD3APIVersion
            // 
            this.guiD3APIVersion.AutoSize = true;
            this.guiD3APIVersion.Location = new System.Drawing.Point(152, 45);
            this.guiD3APIVersion.Name = "guiD3APIVersion";
            this.guiD3APIVersion.Size = new System.Drawing.Size(40, 13);
            this.guiD3APIVersion.TabIndex = 7;
            this.guiD3APIVersion.Text = "0.0.0.0";
            // 
            // guiD3ProfileExplorerVersion
            // 
            this.guiD3ProfileExplorerVersion.AutoSize = true;
            this.guiD3ProfileExplorerVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guiD3ProfileExplorerVersion.Location = new System.Drawing.Point(152, 9);
            this.guiD3ProfileExplorerVersion.Name = "guiD3ProfileExplorerVersion";
            this.guiD3ProfileExplorerVersion.Size = new System.Drawing.Size(40, 13);
            this.guiD3ProfileExplorerVersion.TabIndex = 3;
            this.guiD3ProfileExplorerVersion.Text = "0.0.0.0";
            // 
            // guiD3ProfileExplorerDllName
            // 
            this.guiD3ProfileExplorerDllName.AutoSize = true;
            this.guiD3ProfileExplorerDllName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guiD3ProfileExplorerDllName.Location = new System.Drawing.Point(15, 9);
            this.guiD3ProfileExplorerDllName.Name = "guiD3ProfileExplorerDllName";
            this.guiD3ProfileExplorerDllName.Size = new System.Drawing.Size(131, 13);
            this.guiD3ProfileExplorerDllName.TabIndex = 2;
            this.guiD3ProfileExplorerDllName.Text = "D3 Profile Explorer by ZTn";
            // 
            // guiCareerArtisanContextMenu
            // 
            this.guiCareerArtisanContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exploreICareerArtisanToolStripMenuItem});
            this.guiCareerArtisanContextMenu.Name = "guiHeroSummaryContextMenu";
            this.guiCareerArtisanContextMenu.Size = new System.Drawing.Size(153, 48);
            // 
            // exploreICareerArtisanToolStripMenuItem
            // 
            this.exploreICareerArtisanToolStripMenuItem.Name = "exploreICareerArtisanToolStripMenuItem";
            this.exploreICareerArtisanToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exploreICareerArtisanToolStripMenuItem.Text = "Explore Artisan";
            this.exploreICareerArtisanToolStripMenuItem.Click += new System.EventHandler(this.exploreICareerArtisanToolStripMenuItem_Click);
            // 
            // guiD3ProfileExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
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
        private System.Windows.Forms.TextBox guiBattleNetHost;
        private System.Windows.Forms.TextBox guiBattleNetLanguage;
        private System.Windows.Forms.ContextMenuStrip guiCareerArtisanContextMenu;
        private System.Windows.Forms.ToolStripMenuItem exploreICareerArtisanToolStripMenuItem;
    }
}


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
            this.guiD3ProfileTreeView = new System.Windows.Forms.TreeView();
            this.guiProfileLookup = new System.Windows.Forms.Button();
            this.guiBattleTag = new System.Windows.Forms.TextBox();
            this.guiHeroSummaryContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exploreHeroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guiItemSummaryContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exploreItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guiBattleNetDllName = new System.Windows.Forms.Label();
            this.guiD3APIDllName = new System.Windows.Forms.Label();
            this.guiBattleNetVersion = new System.Windows.Forms.Label();
            this.guiD3APIVersion = new System.Windows.Forms.Label();
            this.guiD3ProfileExplorerVersion = new System.Windows.Forms.Label();
            this.guiD3ProfileExplorerDllName = new System.Windows.Forms.Label();
            guiLabel1 = new System.Windows.Forms.Label();
            this.guiHeroSummaryContextMenu.SuspendLayout();
            this.guiItemSummaryContextMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guiLabel1
            // 
            guiLabel1.AutoSize = true;
            guiLabel1.Location = new System.Drawing.Point(14, 8);
            guiLabel1.Name = "guiLabel1";
            guiLabel1.Size = new System.Drawing.Size(59, 13);
            guiLabel1.TabIndex = 3;
            guiLabel1.Text = "Battle Tag:";
            // 
            // guiD3ProfileTreeView
            // 
            this.guiD3ProfileTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guiD3ProfileTreeView.Location = new System.Drawing.Point(12, 47);
            this.guiD3ProfileTreeView.Name = "guiD3ProfileTreeView";
            this.guiD3ProfileTreeView.Size = new System.Drawing.Size(760, 503);
            this.guiD3ProfileTreeView.TabIndex = 0;
            this.guiD3ProfileTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.guiD3ProfileTreeView_NodeMouseClick);
            // 
            // guiProfileLookup
            // 
            this.guiProfileLookup.Location = new System.Drawing.Point(185, 3);
            this.guiProfileLookup.Name = "guiProfileLookup";
            this.guiProfileLookup.Size = new System.Drawing.Size(150, 23);
            this.guiProfileLookup.TabIndex = 1;
            this.guiProfileLookup.Text = "Profile lookup";
            this.guiProfileLookup.UseVisualStyleBackColor = true;
            this.guiProfileLookup.Click += new System.EventHandler(this.guiProfileLookup_Click);
            // 
            // guiBattleTag
            // 
            this.guiBattleTag.Location = new System.Drawing.Point(79, 5);
            this.guiBattleTag.Name = "guiBattleTag";
            this.guiBattleTag.Size = new System.Drawing.Size(100, 20);
            this.guiBattleTag.TabIndex = 2;
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
            this.panel1.Controls.Add(guiLabel1);
            this.panel1.Controls.Add(this.guiProfileLookup);
            this.panel1.Controls.Add(this.guiBattleTag);
            this.panel1.Location = new System.Drawing.Point(434, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 29);
            this.panel1.TabIndex = 5;
            // 
            // guiBattleNetDllName
            // 
            this.guiBattleNetDllName.AutoSize = true;
            this.guiBattleNetDllName.Location = new System.Drawing.Point(12, 9);
            this.guiBattleNetDllName.Name = "guiBattleNetDllName";
            this.guiBattleNetDllName.Size = new System.Drawing.Size(88, 13);
            this.guiBattleNetDllName.TabIndex = 6;
            this.guiBattleNetDllName.Text = "BNet API by ZTn";
            // 
            // guiD3APIDllName
            // 
            this.guiD3APIDllName.AutoSize = true;
            this.guiD3APIDllName.Location = new System.Drawing.Point(12, 27);
            this.guiD3APIDllName.Name = "guiD3APIDllName";
            this.guiD3APIDllName.Size = new System.Drawing.Size(78, 13);
            this.guiD3APIDllName.TabIndex = 7;
            this.guiD3APIDllName.Text = "D3 API by ZTn";
            // 
            // guiBattleNetVersion
            // 
            this.guiBattleNetVersion.AutoSize = true;
            this.guiBattleNetVersion.Location = new System.Drawing.Point(106, 9);
            this.guiBattleNetVersion.Name = "guiBattleNetVersion";
            this.guiBattleNetVersion.Size = new System.Drawing.Size(40, 13);
            this.guiBattleNetVersion.TabIndex = 8;
            this.guiBattleNetVersion.Text = "0.0.0.0";
            // 
            // guiD3APIVersion
            // 
            this.guiD3APIVersion.AutoSize = true;
            this.guiD3APIVersion.Location = new System.Drawing.Point(106, 27);
            this.guiD3APIVersion.Name = "guiD3APIVersion";
            this.guiD3APIVersion.Size = new System.Drawing.Size(40, 13);
            this.guiD3APIVersion.TabIndex = 9;
            this.guiD3APIVersion.Text = "0.0.0.0";
            // 
            // guiD3ProfileExplorerVersion
            // 
            this.guiD3ProfileExplorerVersion.AutoSize = true;
            this.guiD3ProfileExplorerVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guiD3ProfileExplorerVersion.Location = new System.Drawing.Point(312, 9);
            this.guiD3ProfileExplorerVersion.Name = "guiD3ProfileExplorerVersion";
            this.guiD3ProfileExplorerVersion.Size = new System.Drawing.Size(40, 13);
            this.guiD3ProfileExplorerVersion.TabIndex = 11;
            this.guiD3ProfileExplorerVersion.Text = "0.0.0.0";
            // 
            // guiD3ProfileExplorerDllName
            // 
            this.guiD3ProfileExplorerDllName.AutoSize = true;
            this.guiD3ProfileExplorerDllName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guiD3ProfileExplorerDllName.Location = new System.Drawing.Point(175, 9);
            this.guiD3ProfileExplorerDllName.Name = "guiD3ProfileExplorerDllName";
            this.guiD3ProfileExplorerDllName.Size = new System.Drawing.Size(131, 13);
            this.guiD3ProfileExplorerDllName.TabIndex = 10;
            this.guiD3ProfileExplorerDllName.Text = "D3 Profile Explorer by ZTn";
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
            this.Name = "guiD3ProfileExplorer";
            this.Text = "D3 Profile Explorer by ZTn";
            this.guiHeroSummaryContextMenu.ResumeLayout(false);
            this.guiItemSummaryContextMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
    }
}


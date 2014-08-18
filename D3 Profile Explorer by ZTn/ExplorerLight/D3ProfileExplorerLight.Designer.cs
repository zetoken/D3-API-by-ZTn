namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    partial class D3ProfileExplorerLight
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Panel guiBottomDock;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label guiLabel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(D3ProfileExplorerLight));
            System.Windows.Forms.ToolStrip toolStrip1;
            this.guiBattleNetHostList = new System.Windows.Forms.ComboBox();
            this.guiBattleNetLanguageList = new System.Windows.Forms.ComboBox();
            this.guiAddProfile = new System.Windows.Forms.Button();
            this.guiBattleTag = new System.Windows.Forms.TextBox();
            this.guiShowFullExplorer = new System.Windows.Forms.ToolStripButton();
            this.guiProfilePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.guiHeroesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.guiItemsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.guiRefreshCareer = new System.Windows.Forms.Button();
            this.guiRefreshHero = new System.Windows.Forms.Button();
            this.guiRunCalculator = new System.Windows.Forms.Button();
            guiBottomDock = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            guiLabel1 = new System.Windows.Forms.Label();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            guiBottomDock.SuspendLayout();
            toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guiBottomDock
            // 
            guiBottomDock.AutoSize = true;
            guiBottomDock.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            guiBottomDock.Controls.Add(this.guiBattleNetHostList);
            guiBottomDock.Controls.Add(label2);
            guiBottomDock.Controls.Add(this.guiBattleNetLanguageList);
            guiBottomDock.Controls.Add(label1);
            guiBottomDock.Controls.Add(guiLabel1);
            guiBottomDock.Controls.Add(this.guiAddProfile);
            guiBottomDock.Controls.Add(this.guiBattleTag);
            guiBottomDock.Dock = System.Windows.Forms.DockStyle.Bottom;
            guiBottomDock.Location = new System.Drawing.Point(0, 531);
            guiBottomDock.Name = "guiBottomDock";
            guiBottomDock.Size = new System.Drawing.Size(1008, 30);
            guiBottomDock.TabIndex = 3;
            // 
            // guiBattleNetHostList
            // 
            this.guiBattleNetHostList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guiBattleNetHostList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guiBattleNetHostList.FormattingEnabled = true;
            this.guiBattleNetHostList.Location = new System.Drawing.Point(41, 6);
            this.guiBattleNetHostList.Name = "guiBattleNetHostList";
            this.guiBattleNetHostList.Size = new System.Drawing.Size(100, 21);
            this.guiBattleNetHostList.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(147, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(58, 13);
            label2.TabIndex = 2;
            label2.Text = "Language:";
            // 
            // guiBattleNetLanguageList
            // 
            this.guiBattleNetLanguageList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guiBattleNetLanguageList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guiBattleNetLanguageList.FormattingEnabled = true;
            this.guiBattleNetLanguageList.Location = new System.Drawing.Point(211, 6);
            this.guiBattleNetLanguageList.Name = "guiBattleNetLanguageList";
            this.guiBattleNetLanguageList.Size = new System.Drawing.Size(69, 21);
            this.guiBattleNetLanguageList.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(32, 13);
            label1.TabIndex = 0;
            label1.Text = "Host:";
            // 
            // guiLabel1
            // 
            guiLabel1.AutoSize = true;
            guiLabel1.Location = new System.Drawing.Point(286, 9);
            guiLabel1.Name = "guiLabel1";
            guiLabel1.Size = new System.Drawing.Size(59, 13);
            guiLabel1.TabIndex = 4;
            guiLabel1.Text = "Battle Tag:";
            // 
            // guiAddProfile
            // 
            this.guiAddProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.guiAddProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guiAddProfile.Image = ((System.Drawing.Image)(resources.GetObject("guiAddProfile.Image")));
            this.guiAddProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.guiAddProfile.Location = new System.Drawing.Point(457, 4);
            this.guiAddProfile.Name = "guiAddProfile";
            this.guiAddProfile.Size = new System.Drawing.Size(100, 23);
            this.guiAddProfile.TabIndex = 6;
            this.guiAddProfile.Text = "Add Profile";
            this.guiAddProfile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.guiAddProfile.UseVisualStyleBackColor = true;
            this.guiAddProfile.Click += new System.EventHandler(this.guiAddProfile_Click);
            // 
            // guiBattleTag
            // 
            this.guiBattleTag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.guiBattleTag.Location = new System.Drawing.Point(351, 7);
            this.guiBattleTag.Name = "guiBattleTag";
            this.guiBattleTag.Size = new System.Drawing.Size(100, 20);
            this.guiBattleTag.TabIndex = 5;
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guiShowFullExplorer});
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(1008, 25);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // guiShowFullExplorer
            // 
            this.guiShowFullExplorer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.guiShowFullExplorer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.guiShowFullExplorer.Image = ((System.Drawing.Image)(resources.GetObject("guiShowFullExplorer.Image")));
            this.guiShowFullExplorer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.guiShowFullExplorer.Name = "guiShowFullExplorer";
            this.guiShowFullExplorer.Size = new System.Drawing.Size(23, 22);
            this.guiShowFullExplorer.Text = "Show Full Explorer";
            this.guiShowFullExplorer.Click += new System.EventHandler(this.guiShowFullExplorer_Click);
            // 
            // guiProfilePanel
            // 
            this.guiProfilePanel.AutoScroll = true;
            this.guiProfilePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.guiProfilePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.guiProfilePanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.guiProfilePanel.Location = new System.Drawing.Point(0, 25);
            this.guiProfilePanel.Name = "guiProfilePanel";
            this.guiProfilePanel.Padding = new System.Windows.Forms.Padding(3);
            this.guiProfilePanel.Size = new System.Drawing.Size(214, 506);
            this.guiProfilePanel.TabIndex = 0;
            // 
            // guiHeroesPanel
            // 
            this.guiHeroesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.guiHeroesPanel.AutoScroll = true;
            this.guiHeroesPanel.Location = new System.Drawing.Point(220, 57);
            this.guiHeroesPanel.Name = "guiHeroesPanel";
            this.guiHeroesPanel.Size = new System.Drawing.Size(281, 474);
            this.guiHeroesPanel.TabIndex = 1;
            // 
            // guiItemsPanel
            // 
            this.guiItemsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guiItemsPanel.AutoScroll = true;
            this.guiItemsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.guiItemsPanel.Location = new System.Drawing.Point(507, 57);
            this.guiItemsPanel.Name = "guiItemsPanel";
            this.guiItemsPanel.Size = new System.Drawing.Size(498, 474);
            this.guiItemsPanel.TabIndex = 2;
            // 
            // guiRefreshCareer
            // 
            this.guiRefreshCareer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.guiRefreshCareer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guiRefreshCareer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.guiRefreshCareer.Location = new System.Drawing.Point(223, 28);
            this.guiRefreshCareer.Name = "guiRefreshCareer";
            this.guiRefreshCareer.Size = new System.Drawing.Size(250, 23);
            this.guiRefreshCareer.TabIndex = 7;
            this.guiRefreshCareer.Text = "Refresh Career";
            this.guiRefreshCareer.UseVisualStyleBackColor = true;
            this.guiRefreshCareer.Click += new System.EventHandler(this.guiRefreshCareer_Click);
            // 
            // guiRefreshHero
            // 
            this.guiRefreshHero.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.guiRefreshHero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guiRefreshHero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.guiRefreshHero.Location = new System.Drawing.Point(510, 28);
            this.guiRefreshHero.Name = "guiRefreshHero";
            this.guiRefreshHero.Size = new System.Drawing.Size(198, 23);
            this.guiRefreshHero.TabIndex = 8;
            this.guiRefreshHero.Text = "Refresh Hero";
            this.guiRefreshHero.UseVisualStyleBackColor = true;
            this.guiRefreshHero.Click += new System.EventHandler(this.guiRefreshHero_Click);
            // 
            // guiRunCalculator
            // 
            this.guiRunCalculator.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.guiRunCalculator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guiRunCalculator.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.guiRunCalculator.Location = new System.Drawing.Point(714, 28);
            this.guiRunCalculator.Name = "guiRunCalculator";
            this.guiRunCalculator.Size = new System.Drawing.Size(196, 23);
            this.guiRunCalculator.TabIndex = 9;
            this.guiRunCalculator.Text = "Run Calculator";
            this.guiRunCalculator.UseVisualStyleBackColor = true;
            this.guiRunCalculator.Click += new System.EventHandler(this.guiRunCalculator_Click);
            // 
            // D3ProfileExplorerLight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.guiRunCalculator);
            this.Controls.Add(this.guiRefreshHero);
            this.Controls.Add(this.guiRefreshCareer);
            this.Controls.Add(this.guiItemsPanel);
            this.Controls.Add(this.guiProfilePanel);
            this.Controls.Add(this.guiHeroesPanel);
            this.Controls.Add(toolStrip1);
            this.Controls.Add(guiBottomDock);
            this.Name = "D3ProfileExplorerLight";
            this.Text = "D3 Profile Explorer Light by ZTn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.D3ProfileExplorerLight_FormClosing);
            guiBottomDock.ResumeLayout(false);
            guiBottomDock.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox guiBattleNetHostList;
        private System.Windows.Forms.ComboBox guiBattleNetLanguageList;
        private System.Windows.Forms.Button guiAddProfile;
        private System.Windows.Forms.TextBox guiBattleTag;
        private System.Windows.Forms.FlowLayoutPanel guiProfilePanel;
        private System.Windows.Forms.FlowLayoutPanel guiHeroesPanel;
        private System.Windows.Forms.FlowLayoutPanel guiItemsPanel;
        private System.Windows.Forms.ToolStripButton guiShowFullExplorer;
        private System.Windows.Forms.Button guiRefreshCareer;
        private System.Windows.Forms.Button guiRefreshHero;
        private System.Windows.Forms.Button guiRunCalculator;
    }
}
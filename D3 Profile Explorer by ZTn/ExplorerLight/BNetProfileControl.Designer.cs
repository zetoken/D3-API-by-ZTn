namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    partial class BNetProfileControl
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.GuiProfileHost = new System.Windows.Forms.Label();
            this.guiBattleTagName = new System.Windows.Forms.Label();
            this.guiBattleTagCode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GuiProfileHost
            // 
            this.GuiProfileHost.AutoSize = true;
            this.GuiProfileHost.BackColor = System.Drawing.Color.Transparent;
            this.GuiProfileHost.ForeColor = System.Drawing.Color.White;
            this.GuiProfileHost.Location = new System.Drawing.Point(3, 35);
            this.GuiProfileHost.Name = "GuiProfileHost";
            this.GuiProfileHost.Size = new System.Drawing.Size(64, 13);
            this.GuiProfileHost.TabIndex = 0;
            this.GuiProfileHost.Text = "xx.battle.net";
            // 
            // guiBattleTagName
            // 
            this.guiBattleTagName.AutoSize = true;
            this.guiBattleTagName.BackColor = System.Drawing.Color.Transparent;
            this.guiBattleTagName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.guiBattleTagName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(100)))), ((int)(((byte)(47)))));
            this.guiBattleTagName.Location = new System.Drawing.Point(3, 3);
            this.guiBattleTagName.Name = "guiBattleTagName";
            this.guiBattleTagName.Size = new System.Drawing.Size(42, 24);
            this.guiBattleTagName.TabIndex = 1;
            this.guiBattleTagName.Text = "Tok";
            // 
            // guiBattleTagCode
            // 
            this.guiBattleTagCode.AutoSize = true;
            this.guiBattleTagCode.BackColor = System.Drawing.Color.Transparent;
            this.guiBattleTagCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.guiBattleTagCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(100)))), ((int)(((byte)(47)))));
            this.guiBattleTagCode.Location = new System.Drawing.Point(117, 27);
            this.guiBattleTagCode.Name = "guiBattleTagCode";
            this.guiBattleTagCode.Size = new System.Drawing.Size(60, 24);
            this.guiBattleTagCode.TabIndex = 2;
            this.guiBattleTagCode.Text = "#2360";
            // 
            // BNetProfileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.guiBattleTagCode);
            this.Controls.Add(this.guiBattleTagName);
            this.Controls.Add(this.GuiProfileHost);
            this.Name = "BNetProfileControl";
            this.Size = new System.Drawing.Size(183, 51);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GuiProfileHost;
        private System.Windows.Forms.Label guiBattleTagName;
        private System.Windows.Forms.Label guiBattleTagCode;
    }
}

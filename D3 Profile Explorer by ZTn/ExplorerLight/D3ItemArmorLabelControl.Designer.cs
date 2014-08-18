namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    partial class D3ItemArmorLabelControl
    {
        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.guiArmorLabel = new System.Windows.Forms.Label();
            this.guiArmorValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guiArmorLabel
            // 
            this.guiArmorLabel.AutoSize = true;
            this.guiArmorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.guiArmorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(144)))), ((int)(((byte)(144)))));
            this.guiArmorLabel.Location = new System.Drawing.Point(50, 11);
            this.guiArmorLabel.Margin = new System.Windows.Forms.Padding(0);
            this.guiArmorLabel.Name = "guiArmorLabel";
            this.guiArmorLabel.Size = new System.Drawing.Size(34, 13);
            this.guiArmorLabel.TabIndex = 1;
            this.guiArmorLabel.Text = "Armor";
            // 
            // guiArmorValue
            // 
            this.guiArmorValue.AutoSize = true;
            this.guiArmorValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.guiArmorValue.ForeColor = System.Drawing.Color.White;
            this.guiArmorValue.Location = new System.Drawing.Point(0, 3);
            this.guiArmorValue.Margin = new System.Windows.Forms.Padding(0);
            this.guiArmorValue.Name = "guiArmorValue";
            this.guiArmorValue.Size = new System.Drawing.Size(50, 24);
            this.guiArmorValue.TabIndex = 0;
            this.guiArmorValue.Text = "0000";
            // 
            // D3ItemArmorLabelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.guiArmorValue);
            this.Controls.Add(this.guiArmorLabel);
            this.Name = "D3ItemArmorLabelControl";
            this.Size = new System.Drawing.Size(1386, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label guiArmorValue;
        private System.Windows.Forms.Label guiArmorLabel;
    }
}

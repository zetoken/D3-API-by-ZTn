namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    partial class D3ItemSecondaryLabelControl
    {
        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.guiSecondaryLabel = new System.Windows.Forms.Label();
            this.guiSecondaryValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guiSecondaryLabel
            // 
            this.guiSecondaryLabel.AutoSize = true;
            this.guiSecondaryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.guiSecondaryLabel.ForeColor = System.Drawing.Color.White;
            this.guiSecondaryLabel.Location = new System.Drawing.Point(0, 3);
            this.guiSecondaryLabel.Margin = new System.Windows.Forms.Padding(0);
            this.guiSecondaryLabel.Name = "guiSecondaryLabel";
            this.guiSecondaryLabel.Size = new System.Drawing.Size(58, 13);
            this.guiSecondaryLabel.TabIndex = 1;
            this.guiSecondaryLabel.Text = "Secondary";
            // 
            // guiSecondaryValue
            // 
            this.guiSecondaryValue.AutoSize = true;
            this.guiSecondaryValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.guiSecondaryValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(255)))));
            this.guiSecondaryValue.Location = new System.Drawing.Point(0, 16);
            this.guiSecondaryValue.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.guiSecondaryValue.Name = "guiSecondaryValue";
            this.guiSecondaryValue.Size = new System.Drawing.Size(112, 13);
            this.guiSecondaryValue.TabIndex = 0;
            this.guiSecondaryValue.Text = "Secondary description";
            // 
            // D3ItemSecondaryLabelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.guiSecondaryLabel);
            this.Controls.Add(this.guiSecondaryValue);
            this.Name = "D3ItemSecondaryLabelControl";
            this.Size = new System.Drawing.Size(1386, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label guiSecondaryValue;
        private System.Windows.Forms.Label guiSecondaryLabel;
    }
}

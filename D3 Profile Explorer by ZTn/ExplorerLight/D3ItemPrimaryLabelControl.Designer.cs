namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    sealed partial class D3ItemPrimaryLabelControl
    {
        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.guiPrimaryLabel = new System.Windows.Forms.Label();
            this.guiPrimaryValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guiPrimaryLabel
            // 
            this.guiPrimaryLabel.AutoSize = true;
            this.guiPrimaryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.guiPrimaryLabel.ForeColor = System.Drawing.Color.White;
            this.guiPrimaryLabel.Location = new System.Drawing.Point(0, 3);
            this.guiPrimaryLabel.Margin = new System.Windows.Forms.Padding(0);
            this.guiPrimaryLabel.Name = "guiPrimaryLabel";
            this.guiPrimaryLabel.Size = new System.Drawing.Size(41, 13);
            this.guiPrimaryLabel.TabIndex = 1;
            this.guiPrimaryLabel.Text = "Primary";
            // 
            // guiPrimaryValue
            // 
            this.guiPrimaryValue.AutoSize = true;
            this.guiPrimaryValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.guiPrimaryValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(255)))));
            this.guiPrimaryValue.Location = new System.Drawing.Point(0, 16);
            this.guiPrimaryValue.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.guiPrimaryValue.Name = "guiPrimaryValue";
            this.guiPrimaryValue.Size = new System.Drawing.Size(95, 13);
            this.guiPrimaryValue.TabIndex = 0;
            this.guiPrimaryValue.Text = "Primary description";
            // 
            // D3ItemPrimaryLabelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.guiPrimaryLabel);
            this.Controls.Add(this.guiPrimaryValue);
            this.Name = "D3ItemPrimaryLabelControl";
            this.Size = new System.Drawing.Size(1386, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label guiPrimaryValue;
        private System.Windows.Forms.Label guiPrimaryLabel;
    }
}

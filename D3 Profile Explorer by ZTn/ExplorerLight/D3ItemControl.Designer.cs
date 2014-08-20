namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    partial class D3ItemControl
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
            this.guiItemName = new System.Windows.Forms.Label();
            this.guiItemPicture = new System.Windows.Forms.PictureBox();
            this.guiDescriptionPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.guiItemPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // guiItemName
            // 
            this.guiItemName.AutoSize = true;
            this.guiItemName.BackColor = System.Drawing.Color.Transparent;
            this.guiItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.guiItemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(100)))), ((int)(((byte)(47)))));
            this.guiItemName.Location = new System.Drawing.Point(73, 3);
            this.guiItemName.Name = "guiItemName";
            this.guiItemName.Size = new System.Drawing.Size(51, 20);
            this.guiItemName.TabIndex = 1;
            this.guiItemName.Text = "Name";
            // 
            // guiItemPicture
            // 
            this.guiItemPicture.BackColor = System.Drawing.Color.Transparent;
            this.guiItemPicture.Location = new System.Drawing.Point(3, 6);
            this.guiItemPicture.Name = "guiItemPicture";
            this.guiItemPicture.Size = new System.Drawing.Size(64, 128);
            this.guiItemPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guiItemPicture.TabIndex = 2;
            this.guiItemPicture.TabStop = false;
            // 
            // guiDescriptionPanel
            // 
            this.guiDescriptionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guiDescriptionPanel.AutoSize = true;
            this.guiDescriptionPanel.BackColor = System.Drawing.Color.Transparent;
            this.guiDescriptionPanel.Location = new System.Drawing.Point(74, 26);
            this.guiDescriptionPanel.Name = "guiDescriptionPanel";
            this.guiDescriptionPanel.Size = new System.Drawing.Size(323, 108);
            this.guiDescriptionPanel.TabIndex = 3;
            // 
            // D3ItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.guiItemPicture);
            this.Controls.Add(this.guiItemName);
            this.Controls.Add(this.guiDescriptionPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "D3ItemControl";
            this.Size = new System.Drawing.Size(400, 140);
            ((System.ComponentModel.ISupportInitialize)(this.guiItemPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label guiItemName;
        private System.Windows.Forms.PictureBox guiItemPicture;
        private System.Windows.Forms.FlowLayoutPanel guiDescriptionPanel;
    }
}

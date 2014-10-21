namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    sealed partial class D3HeroControl
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
            this.guiHeroClass = new System.Windows.Forms.Label();
            this.guiHeroName = new System.Windows.Forms.Label();
            this.guiHeroParangonLevel = new System.Windows.Forms.Label();
            this.guiHeroLevel = new System.Windows.Forms.Label();
            this.guiHeroHardcore = new System.Windows.Forms.Label();
            this.guiHeroPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.guiHeroPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // guiHeroClass
            // 
            this.guiHeroClass.AutoSize = true;
            this.guiHeroClass.BackColor = System.Drawing.Color.Transparent;
            this.guiHeroClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(180)))), ((int)(((byte)(115)))));
            this.guiHeroClass.Location = new System.Drawing.Point(51, 27);
            this.guiHeroClass.Name = "guiHeroClass";
            this.guiHeroClass.Size = new System.Drawing.Size(32, 13);
            this.guiHeroClass.TabIndex = 0;
            this.guiHeroClass.Text = "Class";
            // 
            // guiHeroName
            // 
            this.guiHeroName.AutoSize = true;
            this.guiHeroName.BackColor = System.Drawing.Color.Transparent;
            this.guiHeroName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.guiHeroName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(100)))), ((int)(((byte)(47)))));
            this.guiHeroName.Location = new System.Drawing.Point(51, 3);
            this.guiHeroName.Name = "guiHeroName";
            this.guiHeroName.Size = new System.Drawing.Size(61, 24);
            this.guiHeroName.TabIndex = 1;
            this.guiHeroName.Text = "Name";
            // 
            // guiHeroParangonLevel
            // 
            this.guiHeroParangonLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guiHeroParangonLevel.AutoSize = true;
            this.guiHeroParangonLevel.BackColor = System.Drawing.Color.Transparent;
            this.guiHeroParangonLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(145)))), ((int)(((byte)(194)))));
            this.guiHeroParangonLevel.Location = new System.Drawing.Point(216, 3);
            this.guiHeroParangonLevel.Name = "guiHeroParangonLevel";
            this.guiHeroParangonLevel.Size = new System.Drawing.Size(31, 13);
            this.guiHeroParangonLevel.TabIndex = 3;
            this.guiHeroParangonLevel.Text = "+000";
            this.guiHeroParangonLevel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // guiHeroLevel
            // 
            this.guiHeroLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guiHeroLevel.AutoSize = true;
            this.guiHeroLevel.BackColor = System.Drawing.Color.Transparent;
            this.guiHeroLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(145)))), ((int)(((byte)(194)))));
            this.guiHeroLevel.Location = new System.Drawing.Point(185, 3);
            this.guiHeroLevel.Name = "guiHeroLevel";
            this.guiHeroLevel.Size = new System.Drawing.Size(25, 13);
            this.guiHeroLevel.TabIndex = 4;
            this.guiHeroLevel.Text = "000";
            this.guiHeroLevel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // guiHeroHardcore
            // 
            this.guiHeroHardcore.AutoSize = true;
            this.guiHeroHardcore.BackColor = System.Drawing.Color.Transparent;
            this.guiHeroHardcore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guiHeroHardcore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.guiHeroHardcore.Location = new System.Drawing.Point(198, 35);
            this.guiHeroHardcore.Name = "guiHeroHardcore";
            this.guiHeroHardcore.Size = new System.Drawing.Size(49, 13);
            this.guiHeroHardcore.TabIndex = 5;
            this.guiHeroHardcore.Text = "hardcore";
            this.guiHeroHardcore.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // guiHeroPicture
            // 
            this.guiHeroPicture.BackColor = System.Drawing.Color.Transparent;
            this.guiHeroPicture.Location = new System.Drawing.Point(3, 6);
            this.guiHeroPicture.Name = "guiHeroPicture";
            this.guiHeroPicture.Size = new System.Drawing.Size(42, 42);
            this.guiHeroPicture.TabIndex = 6;
            this.guiHeroPicture.TabStop = false;
            // 
            // D3HeroControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.guiHeroPicture);
            this.Controls.Add(this.guiHeroHardcore);
            this.Controls.Add(this.guiHeroLevel);
            this.Controls.Add(this.guiHeroParangonLevel);
            this.Controls.Add(this.guiHeroName);
            this.Controls.Add(this.guiHeroClass);
            this.Name = "D3HeroControl";
            this.Size = new System.Drawing.Size(250, 54);
            ((System.ComponentModel.ISupportInitialize)(this.guiHeroPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label guiHeroClass;
        private System.Windows.Forms.Label guiHeroName;
        private System.Windows.Forms.Label guiHeroParangonLevel;
        private System.Windows.Forms.Label guiHeroLevel;
        private System.Windows.Forms.Label guiHeroHardcore;
        private System.Windows.Forms.PictureBox guiHeroPicture;
    }
}

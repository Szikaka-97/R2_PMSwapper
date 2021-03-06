namespace PlayerModelSwapper {
    partial class PlayerModelSwapper {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerModelSwapper));
            this.textureDialog = new System.Windows.Forms.OpenFileDialog();
            this.directoryDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.textureButton = new System.Windows.Forms.Button();
            this.updateLabel = new System.Windows.Forms.Label();
            this.directoryButton = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.workButton = new System.Windows.Forms.Button();
            this.TextureIndicator = new System.Windows.Forms.PictureBox();
            this.directoryIndicator = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.infoLabel = new System.Windows.Forms.Label();
            this.finishedIndicator = new System.Windows.Forms.PictureBox();
            this.indicatorsPanel = new System.Windows.Forms.Panel();
            this.fileDragPanel = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.texturesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreFromBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.TextureIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.directoryIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finishedIndicator)).BeginInit();
            this.indicatorsPanel.SuspendLayout();
            this.fileDragPanel.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // textureDialog
            // 
            this.textureDialog.FileName = "openFileDialog1";
            // 
            // textureButton
            // 
            this.textureButton.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textureButton.Location = new System.Drawing.Point(12, 329);
            this.textureButton.Name = "textureButton";
            this.textureButton.Size = new System.Drawing.Size(150, 40);
            this.textureButton.TabIndex = 0;
            this.textureButton.Text = "Select Texture File";
            this.textureButton.UseVisualStyleBackColor = true;
            this.textureButton.Click += new System.EventHandler(this.textureButton_Click);
            // 
            // updateLabel
            // 
            this.updateLabel.AllowDrop = true;
            this.updateLabel.AutoSize = true;
            this.updateLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.updateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.updateLabel.Location = new System.Drawing.Point(260, 33);
            this.updateLabel.MinimumSize = new System.Drawing.Size(120, 220);
            this.updateLabel.Name = "updateLabel";
            this.updateLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.updateLabel.Size = new System.Drawing.Size(120, 220);
            this.updateLabel.TabIndex = 2;
            this.updateLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // directoryButton
            // 
            this.directoryButton.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.directoryButton.Location = new System.Drawing.Point(200, 329);
            this.directoryButton.Name = "directoryButton";
            this.directoryButton.Size = new System.Drawing.Size(180, 40);
            this.directoryButton.TabIndex = 5;
            this.directoryButton.Text = "Locate Game Directory";
            this.directoryButton.UseVisualStyleBackColor = true;
            this.directoryButton.Click += new System.EventHandler(this.directoryButton_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "disabled.png");
            this.imageList.Images.SetKeyName(1, "enabled.png");
            // 
            // workButton
            // 
            this.workButton.Enabled = false;
            this.workButton.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.workButton.Location = new System.Drawing.Point(420, 329);
            this.workButton.Name = "workButton";
            this.workButton.Size = new System.Drawing.Size(150, 40);
            this.workButton.TabIndex = 6;
            this.workButton.Text = "Mod";
            this.workButton.UseVisualStyleBackColor = true;
            this.workButton.Click += new System.EventHandler(this.workButton_Click);
            // 
            // TextureIndicator
            // 
            this.TextureIndicator.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextureIndicator.BackgroundImage = global::PlayerModelSwapper.Properties.Resources.disabled;
            this.TextureIndicator.Location = new System.Drawing.Point(0, 0);
            this.TextureIndicator.Name = "TextureIndicator";
            this.TextureIndicator.Size = new System.Drawing.Size(50, 50);
            this.TextureIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TextureIndicator.TabIndex = 7;
            this.TextureIndicator.TabStop = false;
            // 
            // directoryIndicator
            // 
            this.directoryIndicator.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.directoryIndicator.BackgroundImage = global::PlayerModelSwapper.Properties.Resources.disabled;
            this.directoryIndicator.Location = new System.Drawing.Point(65, 0);
            this.directoryIndicator.Name = "directoryIndicator";
            this.directoryIndicator.Size = new System.Drawing.Size(50, 50);
            this.directoryIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.directoryIndicator.TabIndex = 4;
            this.directoryIndicator.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(145, 290);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 290);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(471, 33);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.infoLabel.Size = new System.Drawing.Size(102, 78);
            this.infoLabel.TabIndex = 8;
            this.infoLabel.Text = "Modding Tool \r\nby Szikaka\r\nver. 1.1.0\r\n\r\nFor support, contact\r\nSzikakA#3853";
            // 
            // finishedIndicator
            // 
            this.finishedIndicator.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.finishedIndicator.BackgroundImage = global::PlayerModelSwapper.Properties.Resources.disabled;
            this.finishedIndicator.Location = new System.Drawing.Point(130, 0);
            this.finishedIndicator.Name = "finishedIndicator";
            this.finishedIndicator.Size = new System.Drawing.Size(50, 50);
            this.finishedIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.finishedIndicator.TabIndex = 9;
            this.finishedIndicator.TabStop = false;
            // 
            // indicatorsPanel
            // 
            this.indicatorsPanel.BackColor = System.Drawing.Color.Silver;
            this.indicatorsPanel.Controls.Add(this.TextureIndicator);
            this.indicatorsPanel.Controls.Add(this.finishedIndicator);
            this.indicatorsPanel.Controls.Add(this.directoryIndicator);
            this.indicatorsPanel.Location = new System.Drawing.Point(200, 273);
            this.indicatorsPanel.Name = "indicatorsPanel";
            this.indicatorsPanel.Size = new System.Drawing.Size(180, 50);
            this.indicatorsPanel.TabIndex = 10;
            // 
            // fileDragPanel
            // 
            this.fileDragPanel.AllowDrop = true;
            this.fileDragPanel.Controls.Add(this.pictureBox1);
            this.fileDragPanel.Location = new System.Drawing.Point(14, 33);
            this.fileDragPanel.Name = "fileDragPanel";
            this.fileDragPanel.Size = new System.Drawing.Size(145, 290);
            this.fileDragPanel.TabIndex = 12;
            this.fileDragPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.box2_dragDrop);
            this.fileDragPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.box2_dragEnter);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.texturesMenu,
            this.restoreMenu});
            this.menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(584, 24);
            this.menu.TabIndex = 13;
            this.menu.Text = "menuStrip1";
            // 
            // texturesMenu
            // 
            this.texturesMenu.Name = "texturesMenu";
            this.texturesMenu.Size = new System.Drawing.Size(62, 20);
            this.texturesMenu.Text = "Textures";
            // 
            // restoreMenu
            // 
            this.restoreMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreFromBackupToolStripMenuItem});
            this.restoreMenu.Name = "restoreMenu";
            this.restoreMenu.Size = new System.Drawing.Size(58, 20);
            this.restoreMenu.Text = "Restore";
            // 
            // restoreFromBackupToolStripMenuItem
            // 
            this.restoreFromBackupToolStripMenuItem.Name = "restoreFromBackupToolStripMenuItem";
            this.restoreFromBackupToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.restoreFromBackupToolStripMenuItem.Text = "Restore from backup";
            this.restoreFromBackupToolStripMenuItem.Click += new System.EventHandler(this.restoreFromBackupToolStripMenuItem_Click);
            // 
            // PlayerModelSwapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(584, 381);
            this.Controls.Add(this.fileDragPanel);
            this.Controls.Add(this.indicatorsPanel);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.workButton);
            this.Controls.Add(this.directoryButton);
            this.Controls.Add(this.updateLabel);
            this.Controls.Add(this.textureButton);
            this.Controls.Add(this.menu);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menu;
            this.MaximumSize = new System.Drawing.Size(600, 420);
            this.MinimumSize = new System.Drawing.Size(600, 420);
            this.Name = "PlayerModelSwapper";
            this.Text = "PlayerModelSwapper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerModelSwapper_FormClosing);
            this.Load += new System.EventHandler(this.PlayerModelSwapper_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TextureIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.directoryIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finishedIndicator)).EndInit();
            this.indicatorsPanel.ResumeLayout(false);
            this.fileDragPanel.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog textureDialog;
        private System.Windows.Forms.FolderBrowserDialog directoryDialog;
        private System.Windows.Forms.Button textureButton;
        private System.Windows.Forms.Label updateLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox directoryIndicator;
        private System.Windows.Forms.Button directoryButton;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button workButton;
        private System.Windows.Forms.PictureBox TextureIndicator;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.PictureBox finishedIndicator;
        private System.Windows.Forms.Panel indicatorsPanel;
        private System.Windows.Forms.Panel fileDragPanel;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem texturesMenu;
        private System.Windows.Forms.ToolStripMenuItem restoreMenu;
        private System.Windows.Forms.ToolStripMenuItem restoreFromBackupToolStripMenuItem;
    }
}


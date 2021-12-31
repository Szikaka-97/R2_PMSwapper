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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.workButton = new System.Windows.Forms.Button();
            this.TextureIndicator = new System.Windows.Forms.PictureBox();
            this.directoryIndicator = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.finishedIndicator = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.TextureIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.directoryIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finishedIndicator)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textureDialog
            // 
            this.textureDialog.FileName = "openFileDialog1";
            // 
            // textureButton
            // 
            this.textureButton.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textureButton.Location = new System.Drawing.Point(12, 319);
            this.textureButton.Name = "textureButton";
            this.textureButton.Size = new System.Drawing.Size(150, 40);
            this.textureButton.TabIndex = 0;
            this.textureButton.Text = "Select Texture File";
            this.textureButton.UseVisualStyleBackColor = true;
            this.textureButton.Click += new System.EventHandler(this.textureButton_Click);
            // 
            // updateLabel
            // 
            this.updateLabel.AutoSize = true;
            this.updateLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.updateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.updateLabel.Location = new System.Drawing.Point(263, 13);
            this.updateLabel.MinimumSize = new System.Drawing.Size(120, 230);
            this.updateLabel.Name = "updateLabel";
            this.updateLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.updateLabel.Size = new System.Drawing.Size(120, 230);
            this.updateLabel.TabIndex = 2;
            this.updateLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // directoryButton
            // 
            this.directoryButton.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.directoryButton.Location = new System.Drawing.Point(200, 319);
            this.directoryButton.Name = "directoryButton";
            this.directoryButton.Size = new System.Drawing.Size(180, 40);
            this.directoryButton.TabIndex = 5;
            this.directoryButton.Text = "Select Game Directory";
            this.directoryButton.UseVisualStyleBackColor = true;
            this.directoryButton.Click += new System.EventHandler(this.directoryButton_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "disabled.png");
            this.imageList1.Images.SetKeyName(1, "enabled.png");
            // 
            // workButton
            // 
            this.workButton.Enabled = false;
            this.workButton.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.workButton.Location = new System.Drawing.Point(420, 319);
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
            this.TextureIndicator.Image = global::PlayerModelSwapper.Properties.Resources.disabled;
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
            this.directoryIndicator.Image = global::PlayerModelSwapper.Properties.Resources.disabled;
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
            this.pictureBox1.Location = new System.Drawing.Point(12, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(471, 13);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(102, 78);
            this.label1.TabIndex = 8;
            this.label1.Text = "Modding Tool \r\nby Szikaka\r\nver. 1.0.0\r\n\r\nFor support, contact\r\nSzikakA#3853";
            // 
            // finishedIndicator
            // 
            this.finishedIndicator.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.finishedIndicator.Image = global::PlayerModelSwapper.Properties.Resources.disabled;
            this.finishedIndicator.Location = new System.Drawing.Point(130, 0);
            this.finishedIndicator.Name = "finishedIndicator";
            this.finishedIndicator.Size = new System.Drawing.Size(50, 50);
            this.finishedIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.finishedIndicator.TabIndex = 9;
            this.finishedIndicator.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.TextureIndicator);
            this.panel1.Controls.Add(this.finishedIndicator);
            this.panel1.Controls.Add(this.directoryIndicator);
            this.panel1.Location = new System.Drawing.Point(200, 263);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 50);
            this.panel1.TabIndex = 10;
            // 
            // PlayerModelSwapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(584, 381);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.workButton);
            this.Controls.Add(this.directoryButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.updateLabel);
            this.Controls.Add(this.textureButton);
            this.DoubleBuffered = true;
            this.Name = "PlayerModelSwapper";
            this.Text = "PlayerModelSwapper";
            ((System.ComponentModel.ISupportInitialize)(this.TextureIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.directoryIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finishedIndicator)).EndInit();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button workButton;
        private System.Windows.Forms.PictureBox TextureIndicator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox finishedIndicator;
        private System.Windows.Forms.Panel panel1;
    }
}


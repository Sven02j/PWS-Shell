
namespace PWS_Shell
{
    partial class BrightnessVolumeDisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.soundIcon = new System.Windows.Forms.PictureBox();
            this.brightnessIcon = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.soundLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.brightnessLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.soundIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // soundIcon
            // 
            this.soundIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.soundIcon.Image = global::PWS_Shell.Properties.Resources.sound;
            this.soundIcon.Location = new System.Drawing.Point(3, 0);
            this.soundIcon.Name = "soundIcon";
            this.soundIcon.Size = new System.Drawing.Size(24, 24);
            this.soundIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.soundIcon.TabIndex = 1;
            this.soundIcon.TabStop = false;
            this.soundIcon.Click += new System.EventHandler(this.soundIcon_Click);
            // 
            // brightnessIcon
            // 
            this.brightnessIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.brightnessIcon.Image = global::PWS_Shell.Properties.Resources.brightness;
            this.brightnessIcon.Location = new System.Drawing.Point(3, 3);
            this.brightnessIcon.Name = "brightnessIcon";
            this.brightnessIcon.Size = new System.Drawing.Size(24, 24);
            this.brightnessIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.brightnessIcon.TabIndex = 0;
            this.brightnessIcon.TabStop = false;
            this.brightnessIcon.Click += new System.EventHandler(this.brightnessIcon_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.soundLabel);
            this.panel1.Controls.Add(this.soundIcon);
            this.panel1.Location = new System.Drawing.Point(3, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(112, 24);
            this.panel1.TabIndex = 2;
            // 
            // soundLabel
            // 
            this.soundLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.soundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soundLabel.Location = new System.Drawing.Point(33, 0);
            this.soundLabel.Name = "soundLabel";
            this.soundLabel.Size = new System.Drawing.Size(76, 24);
            this.soundLabel.TabIndex = 2;
            this.soundLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.brightnessLabel);
            this.panel2.Controls.Add(this.brightnessIcon);
            this.panel2.Location = new System.Drawing.Point(3, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(112, 29);
            this.panel2.TabIndex = 3;
            // 
            // brightnessLabel
            // 
            this.brightnessLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.brightnessLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brightnessLabel.Location = new System.Drawing.Point(33, 3);
            this.brightnessLabel.Name = "brightnessLabel";
            this.brightnessLabel.Size = new System.Drawing.Size(76, 24);
            this.brightnessLabel.TabIndex = 2;
            this.brightnessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BrightnessVolumeDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "BrightnessVolumeDisplay";
            this.Size = new System.Drawing.Size(119, 71);
            ((System.ComponentModel.ISupportInitialize)(this.soundIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox brightnessIcon;
        private System.Windows.Forms.PictureBox soundIcon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label soundLabel;
        private System.Windows.Forms.Label brightnessLabel;
    }
}

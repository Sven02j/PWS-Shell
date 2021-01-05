
namespace PWS_Shell
{
    partial class BatteryDisplay
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
            this.batteryIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.batteryIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // batteryIcon
            // 
            this.batteryIcon.BackColor = System.Drawing.Color.Transparent;
            this.batteryIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.batteryIcon.Location = new System.Drawing.Point(0, 0);
            this.batteryIcon.Name = "batteryIcon";
            this.batteryIcon.Size = new System.Drawing.Size(150, 150);
            this.batteryIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.batteryIcon.TabIndex = 0;
            this.batteryIcon.TabStop = false;
            // 
            // BatteryDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.batteryIcon);
            this.Name = "BatteryDisplay";
            ((System.ComponentModel.ISupportInitialize)(this.batteryIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox batteryIcon;
    }
}

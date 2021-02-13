
namespace PWS_Shell
{
    partial class NetworkDisplay
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
            this.networkIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.networkIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // networkIcon
            // 
            this.networkIcon.BackColor = System.Drawing.Color.Transparent;
            this.networkIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.networkIcon.Location = new System.Drawing.Point(0, 0);
            this.networkIcon.Name = "networkIcon";
            this.networkIcon.Size = new System.Drawing.Size(150, 150);
            this.networkIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.networkIcon.TabIndex = 1;
            this.networkIcon.TabStop = false;
            this.networkIcon.Click += new System.EventHandler(this.networkIcon_Click);
            // 
            // NetworkDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.networkIcon);
            this.Name = "NetworkDisplay";
            this.Load += new System.EventHandler(this.NetworkDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.networkIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox networkIcon;
    }
}

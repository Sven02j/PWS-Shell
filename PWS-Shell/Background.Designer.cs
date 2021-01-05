namespace PWS_Shell
{
    partial class Background
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
            this.achtergrond = new System.Windows.Forms.PictureBox();
            this.DesktopControl = new PWS_Shell.DesktopControl();
            ((System.ComponentModel.ISupportInitialize)(this.achtergrond)).BeginInit();
            this.SuspendLayout();
            // 
            // achtergrond
            // 
            this.achtergrond.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.achtergrond.Location = new System.Drawing.Point(0, 0);
            this.achtergrond.Name = "achtergrond";
            this.achtergrond.Size = new System.Drawing.Size(977, 546);
            this.achtergrond.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.achtergrond.TabIndex = 0;
            this.achtergrond.TabStop = false;
            // 
            // DesktopControl
            // 
            this.DesktopControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DesktopControl.BackColor = System.Drawing.Color.Transparent;
            this.DesktopControl.Location = new System.Drawing.Point(0, 0);
            this.DesktopControl.Name = "DesktopControl";
            this.DesktopControl.Size = new System.Drawing.Size(977, 546);
            this.DesktopControl.TabIndex = 1;
            // 
            // Background
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.DesktopControl);
            this.Controls.Add(this.achtergrond);
            this.Name = "Background";
            this.Size = new System.Drawing.Size(977, 546);
            ((System.ComponentModel.ISupportInitialize)(this.achtergrond)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox achtergrond;
        internal DesktopControl DesktopControl;
    }
}

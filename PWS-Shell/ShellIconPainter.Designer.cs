namespace PWS_Shell
{
    partial class ShellIconPainter
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xIcon = new System.Windows.Forms.PictureBox();
            this.waiter = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.xIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // xIcon
            // 
            this.xIcon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.xIcon.BackColor = System.Drawing.Color.Transparent;
            this.xIcon.Location = new System.Drawing.Point(38, 43);
            this.xIcon.Name = "xIcon";
            this.xIcon.Size = new System.Drawing.Size(171, 162);
            this.xIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.xIcon.TabIndex = 0;
            this.xIcon.TabStop = false;
            // 
            // waiter
            // 
            this.waiter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.waiter_DoWork);
            this.waiter.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.waiter_RunWorkerCompleted);
            // 
            // ShellIconPainter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(256, 256);
            this.Controls.Add(this.xIcon);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShellIconPainter";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ShellIconPainter";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Gray;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShellIconPainter_FormClosing);
            this.Load += new System.EventHandler(this.ShellIconPainter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox xIcon;
        private System.ComponentModel.BackgroundWorker waiter;
    }
}
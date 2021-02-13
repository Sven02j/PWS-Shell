namespace PWS_Shell
{
    partial class DesktopControl
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
            this.components = new System.ComponentModel.Container();
            this.transInfoPanel = new System.Windows.Forms.Panel();
            this.infoLabel = new System.Windows.Forms.Label();
            this.allAppsButton = new System.Windows.Forms.Button();
            this.UpPanel = new PWS_Shell.UpperShellPanel();
            this.noAppStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.vernieuwenStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.linkToevoegenStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.mapAanmakenStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.transInfoPanel.SuspendLayout();
            this.noAppStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // transInfoPanel
            // 
            this.transInfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.transInfoPanel.Controls.Add(this.infoLabel);
            this.transInfoPanel.Location = new System.Drawing.Point(3, 118);
            this.transInfoPanel.Name = "transInfoPanel";
            this.transInfoPanel.Size = new System.Drawing.Size(243, 310);
            this.transInfoPanel.TabIndex = 1;
            this.transInfoPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.transInfoPanel_Paint);
            // 
            // infoLabel
            // 
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel.ForeColor = System.Drawing.Color.White;
            this.infoLabel.Location = new System.Drawing.Point(6, 0);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(234, 310);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.naamLabel_Paint);
            // 
            // allAppsButton
            // 
            this.allAppsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.allAppsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.allAppsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allAppsButton.ForeColor = System.Drawing.Color.White;
            this.allAppsButton.Location = new System.Drawing.Point(3, 73);
            this.allAppsButton.Name = "allAppsButton";
            this.allAppsButton.Size = new System.Drawing.Size(243, 39);
            this.allAppsButton.TabIndex = 2;
            this.allAppsButton.Text = "Alle apps weergeven";
            this.allAppsButton.UseVisualStyleBackColor = true;
            this.allAppsButton.Click += new System.EventHandler(this.allAppsButton_Click);
            // 
            // UpPanel
            // 
            this.UpPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.UpPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UpPanel.Location = new System.Drawing.Point(0, 0);
            this.UpPanel.Name = "UpPanel";
            this.UpPanel.Size = new System.Drawing.Size(772, 70);
            this.UpPanel.TabIndex = 3;
            this.UpPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.UpPanel_Paint);
            // 
            // noAppStrip
            // 
            this.noAppStrip.BackColor = System.Drawing.Color.Black;
            this.noAppStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vernieuwenStrip,
            this.linkToevoegenStrip,
            this.mapAanmakenStrip});
            this.noAppStrip.Name = "appStrip";
            this.noAppStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.noAppStrip.Size = new System.Drawing.Size(157, 70);
            // 
            // vernieuwenStrip
            // 
            this.vernieuwenStrip.Name = "vernieuwenStrip";
            this.vernieuwenStrip.Size = new System.Drawing.Size(156, 22);
            this.vernieuwenStrip.Text = "Vernieuwen";
            this.vernieuwenStrip.Click += new System.EventHandler(this.vernieuwenStrip_Click);
            // 
            // linkToevoegenStrip
            // 
            this.linkToevoegenStrip.Name = "linkToevoegenStrip";
            this.linkToevoegenStrip.Size = new System.Drawing.Size(156, 22);
            this.linkToevoegenStrip.Text = "Link toevoegen";
            this.linkToevoegenStrip.Click += new System.EventHandler(this.linkToevoegenStrip_Click);
            // 
            // mapAanmakenStrip
            // 
            this.mapAanmakenStrip.Name = "mapAanmakenStrip";
            this.mapAanmakenStrip.Size = new System.Drawing.Size(156, 22);
            this.mapAanmakenStrip.Text = "Map aanmaken";
            this.mapAanmakenStrip.Click += new System.EventHandler(this.mapAanmakenStrip_Click);
            // 
            // DesktopControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.UpPanel);
            this.Controls.Add(this.allAppsButton);
            this.Controls.Add(this.transInfoPanel);
            this.Name = "DesktopControl";
            this.Size = new System.Drawing.Size(772, 428);
            this.transInfoPanel.ResumeLayout(false);
            this.noAppStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel transInfoPanel;
        private System.Windows.Forms.Button allAppsButton;
        private System.Windows.Forms.Label infoLabel;
        internal UpperShellPanel UpPanel;
        private System.Windows.Forms.ContextMenuStrip noAppStrip;
        private System.Windows.Forms.ToolStripMenuItem vernieuwenStrip;
        private System.Windows.Forms.ToolStripMenuItem linkToevoegenStrip;
        private System.Windows.Forms.ToolStripMenuItem mapAanmakenStrip;
    }
}

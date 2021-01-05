namespace PWS_Shell
{
    partial class UpperShellPanel
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
            this.energyControlButton = new System.Windows.Forms.PictureBox();
            this.settingsLinker = new System.Windows.Forms.PictureBox();
            this.searchIcon = new System.Windows.Forms.PictureBox();
            this.energyDropDown = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.afsluitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opnieuwOpstartenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.sluimerstandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slaapstandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.uitloggenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vergrendelenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoUpdater = new System.Windows.Forms.Timer(this.components);
            this.batteryDisplay = new PWS_Shell.BatteryDisplay();
            this.TimeDateDisplay = new PWS_Shell.DateTimeControl();
            ((System.ComponentModel.ISupportInitialize)(this.energyControlButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsLinker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchIcon)).BeginInit();
            this.energyDropDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // energyControlButton
            // 
            this.energyControlButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.energyControlButton.BackColor = System.Drawing.Color.Transparent;
            this.energyControlButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.energyControlButton.Image = global::PWS_Shell.Properties.Resources.shutdown;
            this.energyControlButton.Location = new System.Drawing.Point(140, 3);
            this.energyControlButton.Margin = new System.Windows.Forms.Padding(2);
            this.energyControlButton.Name = "energyControlButton";
            this.energyControlButton.Size = new System.Drawing.Size(64, 64);
            this.energyControlButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.energyControlButton.TabIndex = 6;
            this.energyControlButton.TabStop = false;
            this.energyControlButton.Click += new System.EventHandler(this.energyControlButton_Click);
            // 
            // settingsLinker
            // 
            this.settingsLinker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.settingsLinker.BackColor = System.Drawing.Color.Transparent;
            this.settingsLinker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsLinker.Image = global::PWS_Shell.Properties.Resources.cog;
            this.settingsLinker.Location = new System.Drawing.Point(72, 3);
            this.settingsLinker.Margin = new System.Windows.Forms.Padding(2);
            this.settingsLinker.Name = "settingsLinker";
            this.settingsLinker.Size = new System.Drawing.Size(64, 64);
            this.settingsLinker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.settingsLinker.TabIndex = 6;
            this.settingsLinker.TabStop = false;
            this.settingsLinker.Click += new System.EventHandler(this.settingsLinker_Click);
            // 
            // searchIcon
            // 
            this.searchIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.searchIcon.BackColor = System.Drawing.Color.Transparent;
            this.searchIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchIcon.Image = global::PWS_Shell.Properties.Resources.search;
            this.searchIcon.Location = new System.Drawing.Point(3, 3);
            this.searchIcon.Name = "searchIcon";
            this.searchIcon.Size = new System.Drawing.Size(64, 64);
            this.searchIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.searchIcon.TabIndex = 4;
            this.searchIcon.TabStop = false;
            this.searchIcon.Click += new System.EventHandler(this.searchIcon_Click);
            this.searchIcon.MouseEnter += new System.EventHandler(this.searchIcon_MouseEnter);
            this.searchIcon.MouseLeave += new System.EventHandler(this.searchIcon_MouseLeave);
            // 
            // energyDropDown
            // 
            this.energyDropDown.BackColor = System.Drawing.Color.Black;
            this.energyDropDown.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.energyDropDown.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afsluitenToolStripMenuItem,
            this.opnieuwOpstartenToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sluimerstandToolStripMenuItem,
            this.slaapstandToolStripMenuItem,
            this.toolStripMenuItem2,
            this.uitloggenToolStripMenuItem,
            this.vergrendelenToolStripMenuItem});
            this.energyDropDown.Name = "energyDropDown";
            this.energyDropDown.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.energyDropDown.Size = new System.Drawing.Size(176, 148);
            // 
            // afsluitenToolStripMenuItem
            // 
            this.afsluitenToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.afsluitenToolStripMenuItem.Name = "afsluitenToolStripMenuItem";
            this.afsluitenToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.afsluitenToolStripMenuItem.Text = "Afsluiten";
            this.afsluitenToolStripMenuItem.Click += new System.EventHandler(this.afsluitenToolStripMenuItem_Click);
            // 
            // opnieuwOpstartenToolStripMenuItem
            // 
            this.opnieuwOpstartenToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.opnieuwOpstartenToolStripMenuItem.Name = "opnieuwOpstartenToolStripMenuItem";
            this.opnieuwOpstartenToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.opnieuwOpstartenToolStripMenuItem.Text = "Opnieuw opstarten";
            this.opnieuwOpstartenToolStripMenuItem.Click += new System.EventHandler(this.opnieuwOpstartenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 6);
            // 
            // sluimerstandToolStripMenuItem
            // 
            this.sluimerstandToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.sluimerstandToolStripMenuItem.Name = "sluimerstandToolStripMenuItem";
            this.sluimerstandToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.sluimerstandToolStripMenuItem.Text = "Sluimerstand";
            this.sluimerstandToolStripMenuItem.Click += new System.EventHandler(this.sluimerstandToolStripMenuItem_Click);
            // 
            // slaapstandToolStripMenuItem
            // 
            this.slaapstandToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.slaapstandToolStripMenuItem.Name = "slaapstandToolStripMenuItem";
            this.slaapstandToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.slaapstandToolStripMenuItem.Text = "Slaapstand";
            this.slaapstandToolStripMenuItem.Click += new System.EventHandler(this.slaapstandToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 6);
            // 
            // uitloggenToolStripMenuItem
            // 
            this.uitloggenToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.uitloggenToolStripMenuItem.Name = "uitloggenToolStripMenuItem";
            this.uitloggenToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.uitloggenToolStripMenuItem.Text = "Uitloggen";
            this.uitloggenToolStripMenuItem.Click += new System.EventHandler(this.uitloggenToolStripMenuItem_Click);
            // 
            // vergrendelenToolStripMenuItem
            // 
            this.vergrendelenToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.vergrendelenToolStripMenuItem.Name = "vergrendelenToolStripMenuItem";
            this.vergrendelenToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.vergrendelenToolStripMenuItem.Text = "Vergrendelen";
            this.vergrendelenToolStripMenuItem.Click += new System.EventHandler(this.vergrendelenToolStripMenuItem_Click);
            // 
            // InfoUpdater
            // 
            this.InfoUpdater.Interval = 20;
            this.InfoUpdater.Tick += new System.EventHandler(this.InfoUpdater_Tick);
            // 
            // batteryDisplay
            // 
            this.batteryDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.batteryDisplay.BackColor = System.Drawing.Color.Transparent;
            this.batteryDisplay.Location = new System.Drawing.Point(505, 3);
            this.batteryDisplay.Name = "batteryDisplay";
            this.batteryDisplay.Size = new System.Drawing.Size(62, 64);
            this.batteryDisplay.TabIndex = 7;
            // 
            // TimeDateDisplay
            // 
            this.TimeDateDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TimeDateDisplay.BackColor = System.Drawing.Color.Transparent;
            this.TimeDateDisplay.Location = new System.Drawing.Point(574, 0);
            this.TimeDateDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.TimeDateDisplay.Name = "TimeDateDisplay";
            this.TimeDateDisplay.Size = new System.Drawing.Size(197, 70);
            this.TimeDateDisplay.TabIndex = 5;
            // 
            // UpperShellPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.batteryDisplay);
            this.Controls.Add(this.energyControlButton);
            this.Controls.Add(this.settingsLinker);
            this.Controls.Add(this.TimeDateDisplay);
            this.Controls.Add(this.searchIcon);
            this.Name = "UpperShellPanel";
            this.Size = new System.Drawing.Size(771, 70);
            ((System.ComponentModel.ISupportInitialize)(this.energyControlButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsLinker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchIcon)).EndInit();
            this.energyDropDown.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox searchIcon;
        private DateTimeControl TimeDateDisplay;
        private System.Windows.Forms.PictureBox settingsLinker;
        private System.Windows.Forms.PictureBox energyControlButton;
        private System.Windows.Forms.ContextMenuStrip energyDropDown;
        private System.Windows.Forms.ToolStripMenuItem afsluitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opnieuwOpstartenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sluimerstandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slaapstandToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem uitloggenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vergrendelenToolStripMenuItem;
        private System.Windows.Forms.Timer InfoUpdater;
        private BatteryDisplay batteryDisplay;
    }
}

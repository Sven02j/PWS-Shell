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
            this.energyControlButton = new System.Windows.Forms.PictureBox();
            this.settingsLinker = new System.Windows.Forms.PictureBox();
            this.searchIcon = new System.Windows.Forms.PictureBox();
            this.optionsStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.systeemInstellingenStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.shellInstellingenStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.shellTerugzettenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsButton = new System.Windows.Forms.PictureBox();
            this.brightnessVolumeDisplay = new PWS_Shell.BrightnessVolumeDisplay();
            this.networkDisplay = new PWS_Shell.NetworkDisplay();
            this.batteryDisplay = new PWS_Shell.BatteryDisplay();
            this.TimeDateDisplay = new PWS_Shell.DateTimeControl();
            this.toolsStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.taakbeheerStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.commandPromptStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.powerShellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.apparaatbeheerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schijfbeheerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.verkennerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkTimer = new System.Windows.Forms.Timer(this.components);
            this.registereditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.energyDropDown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.energyControlButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsLinker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchIcon)).BeginInit();
            this.optionsStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolsButton)).BeginInit();
            this.toolsStrip.SuspendLayout();
            this.SuspendLayout();
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
            // energyControlButton
            // 
            this.energyControlButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.energyControlButton.BackColor = System.Drawing.Color.Transparent;
            this.energyControlButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.energyControlButton.Image = global::PWS_Shell.Properties.Resources.shutdown;
            this.energyControlButton.Location = new System.Drawing.Point(208, 3);
            this.energyControlButton.Margin = new System.Windows.Forms.Padding(2);
            this.energyControlButton.Name = "energyControlButton";
            this.energyControlButton.Size = new System.Drawing.Size(64, 64);
            this.energyControlButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.energyControlButton.TabIndex = 6;
            this.energyControlButton.TabStop = false;
            this.energyControlButton.Click += new System.EventHandler(this.energyControlButton_Click);
            this.energyControlButton.MouseEnter += new System.EventHandler(this.energyControlButton_MouseEnter);
            this.energyControlButton.MouseLeave += new System.EventHandler(this.energyControlButton_MouseLeave);
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
            this.settingsLinker.MouseEnter += new System.EventHandler(this.settingsLinker_MouseEnter);
            this.settingsLinker.MouseLeave += new System.EventHandler(this.settingsLinker_MouseLeave);
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
            // optionsStrip
            // 
            this.optionsStrip.BackColor = System.Drawing.Color.Black;
            this.optionsStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.optionsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.systeemInstellingenStrip,
            this.shellInstellingenStrip,
            this.toolStripMenuItem5,
            this.shellTerugzettenToolStripMenuItem});
            this.optionsStrip.Name = "energyDropDown";
            this.optionsStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.optionsStrip.Size = new System.Drawing.Size(185, 82);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // systeemInstellingenStrip
            // 
            this.systeemInstellingenStrip.BackColor = System.Drawing.Color.Black;
            this.systeemInstellingenStrip.ForeColor = System.Drawing.Color.White;
            this.systeemInstellingenStrip.Name = "systeemInstellingenStrip";
            this.systeemInstellingenStrip.Size = new System.Drawing.Size(184, 22);
            this.systeemInstellingenStrip.Text = "Systeem-instellingen";
            this.systeemInstellingenStrip.Click += new System.EventHandler(this.systeemInstellingen_Click);
            // 
            // shellInstellingenStrip
            // 
            this.shellInstellingenStrip.ForeColor = System.Drawing.Color.White;
            this.shellInstellingenStrip.Name = "shellInstellingenStrip";
            this.shellInstellingenStrip.Size = new System.Drawing.Size(184, 22);
            this.shellInstellingenStrip.Text = "Shell-instellingen";
            this.shellInstellingenStrip.Click += new System.EventHandler(this.shellInstellingen_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(181, 6);
            // 
            // shellTerugzettenToolStripMenuItem
            // 
            this.shellTerugzettenToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.shellTerugzettenToolStripMenuItem.Name = "shellTerugzettenToolStripMenuItem";
            this.shellTerugzettenToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.shellTerugzettenToolStripMenuItem.Text = "Shell terugzetten";
            this.shellTerugzettenToolStripMenuItem.Click += new System.EventHandler(this.shellTerugzetten_Click);
            // 
            // toolsButton
            // 
            this.toolsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.toolsButton.BackColor = System.Drawing.Color.Transparent;
            this.toolsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toolsButton.Image = global::PWS_Shell.Properties.Resources.tools;
            this.toolsButton.Location = new System.Drawing.Point(140, 3);
            this.toolsButton.Margin = new System.Windows.Forms.Padding(2);
            this.toolsButton.Name = "toolsButton";
            this.toolsButton.Size = new System.Drawing.Size(64, 64);
            this.toolsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.toolsButton.TabIndex = 6;
            this.toolsButton.TabStop = false;
            this.toolsButton.Click += new System.EventHandler(this.toolsButton_Click);
            this.toolsButton.MouseEnter += new System.EventHandler(this.toolsButton_MouseEnter);
            this.toolsButton.MouseLeave += new System.EventHandler(this.toolsButton_MouseLeave);
            // 
            // brightnessVolumeDisplay
            // 
            this.brightnessVolumeDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.brightnessVolumeDisplay.BackColor = System.Drawing.Color.Transparent;
            this.brightnessVolumeDisplay.Location = new System.Drawing.Point(477, 3);
            this.brightnessVolumeDisplay.Name = "brightnessVolumeDisplay";
            this.brightnessVolumeDisplay.Size = new System.Drawing.Size(90, 64);
            this.brightnessVolumeDisplay.TabIndex = 9;
            // 
            // networkDisplay
            // 
            this.networkDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.networkDisplay.BackColor = System.Drawing.Color.Transparent;
            this.networkDisplay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.networkDisplay.Location = new System.Drawing.Point(407, 3);
            this.networkDisplay.Name = "networkDisplay";
            this.networkDisplay.Size = new System.Drawing.Size(64, 64);
            this.networkDisplay.TabIndex = 8;
            // 
            // batteryDisplay
            // 
            this.batteryDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.batteryDisplay.BackColor = System.Drawing.Color.Transparent;
            this.batteryDisplay.Location = new System.Drawing.Point(337, 3);
            this.batteryDisplay.Name = "batteryDisplay";
            this.batteryDisplay.Size = new System.Drawing.Size(64, 64);
            this.batteryDisplay.TabIndex = 7;
            // 
            // TimeDateDisplay
            // 
            this.TimeDateDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TimeDateDisplay.BackColor = System.Drawing.Color.Transparent;
            this.TimeDateDisplay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TimeDateDisplay.Location = new System.Drawing.Point(574, 0);
            this.TimeDateDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.TimeDateDisplay.Name = "TimeDateDisplay";
            this.TimeDateDisplay.Size = new System.Drawing.Size(197, 70);
            this.TimeDateDisplay.TabIndex = 5;
            // 
            // toolsStrip
            // 
            this.toolsStrip.BackColor = System.Drawing.Color.Black;
            this.toolsStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.taakbeheerStrip,
            this.commandPromptStrip,
            this.powerShellToolStripMenuItem,
            this.registereditorToolStripMenuItem,
            this.toolStripMenuItem3,
            this.apparaatbeheerToolStripMenuItem,
            this.schijfbeheerToolStripMenuItem,
            this.toolStripMenuItem4,
            this.verkennerToolStripMenuItem});
            this.toolsStrip.Name = "energyDropDown";
            this.toolsStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolsStrip.Size = new System.Drawing.Size(181, 198);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // taakbeheerStrip
            // 
            this.taakbeheerStrip.ForeColor = System.Drawing.Color.White;
            this.taakbeheerStrip.Name = "taakbeheerStrip";
            this.taakbeheerStrip.Size = new System.Drawing.Size(180, 22);
            this.taakbeheerStrip.Text = "Taakbeheer";
            this.taakbeheerStrip.Click += new System.EventHandler(this.taakbeheerStrip_Click);
            // 
            // commandPromptStrip
            // 
            this.commandPromptStrip.ForeColor = System.Drawing.Color.White;
            this.commandPromptStrip.Name = "commandPromptStrip";
            this.commandPromptStrip.Size = new System.Drawing.Size(180, 22);
            this.commandPromptStrip.Text = "Opdrachtprompt";
            this.commandPromptStrip.Click += new System.EventHandler(this.commandPromptStrip_Click);
            // 
            // powerShellToolStripMenuItem
            // 
            this.powerShellToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.powerShellToolStripMenuItem.Name = "powerShellToolStripMenuItem";
            this.powerShellToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.powerShellToolStripMenuItem.Text = "PowerShell";
            this.powerShellToolStripMenuItem.Click += new System.EventHandler(this.powerShellToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // apparaatbeheerToolStripMenuItem
            // 
            this.apparaatbeheerToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.apparaatbeheerToolStripMenuItem.Name = "apparaatbeheerToolStripMenuItem";
            this.apparaatbeheerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.apparaatbeheerToolStripMenuItem.Text = "Apparaatbeheer";
            this.apparaatbeheerToolStripMenuItem.Click += new System.EventHandler(this.apparaatbeheerToolStripMenuItem_Click);
            // 
            // schijfbeheerToolStripMenuItem
            // 
            this.schijfbeheerToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.schijfbeheerToolStripMenuItem.Name = "schijfbeheerToolStripMenuItem";
            this.schijfbeheerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.schijfbeheerToolStripMenuItem.Text = "Schijfbeheer";
            this.schijfbeheerToolStripMenuItem.Click += new System.EventHandler(this.schijfbeheerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(177, 6);
            // 
            // verkennerToolStripMenuItem
            // 
            this.verkennerToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.verkennerToolStripMenuItem.Name = "verkennerToolStripMenuItem";
            this.verkennerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.verkennerToolStripMenuItem.Text = "Verkenner";
            this.verkennerToolStripMenuItem.Click += new System.EventHandler(this.bestandsSysteem_Click);
            // 
            // networkTimer
            // 
            this.networkTimer.Interval = 4000;
            this.networkTimer.Tick += new System.EventHandler(this.networkTimer_Tick);
            // 
            // registereditorToolStripMenuItem
            // 
            this.registereditorToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.registereditorToolStripMenuItem.Name = "registereditorToolStripMenuItem";
            this.registereditorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.registereditorToolStripMenuItem.Text = "Register-editor";
            this.registereditorToolStripMenuItem.Click += new System.EventHandler(this.registereditorToolStripMenuItem_Click);
            // 
            // UpperShellPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.brightnessVolumeDisplay);
            this.Controls.Add(this.networkDisplay);
            this.Controls.Add(this.batteryDisplay);
            this.Controls.Add(this.toolsButton);
            this.Controls.Add(this.energyControlButton);
            this.Controls.Add(this.settingsLinker);
            this.Controls.Add(this.TimeDateDisplay);
            this.Controls.Add(this.searchIcon);
            this.Name = "UpperShellPanel";
            this.Size = new System.Drawing.Size(771, 70);
            this.energyDropDown.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.energyControlButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsLinker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchIcon)).EndInit();
            this.optionsStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toolsButton)).EndInit();
            this.toolsStrip.ResumeLayout(false);
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
        private NetworkDisplay networkDisplay;
        internal BrightnessVolumeDisplay brightnessVolumeDisplay;
        private System.Windows.Forms.ContextMenuStrip optionsStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.PictureBox toolsButton;
        private System.Windows.Forms.ToolStripMenuItem systeemInstellingenStrip;
        private System.Windows.Forms.ToolStripMenuItem shellInstellingenStrip;
        private System.Windows.Forms.ContextMenuStrip toolsStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem taakbeheerStrip;
        private System.Windows.Forms.ToolStripMenuItem commandPromptStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem shellTerugzettenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem apparaatbeheerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem verkennerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schijfbeheerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem powerShellToolStripMenuItem;
        private System.Windows.Forms.Timer networkTimer;
        private System.Windows.Forms.ToolStripMenuItem registereditorToolStripMenuItem;
    }
}

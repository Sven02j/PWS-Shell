namespace PWS_Shell
{
    partial class Knop
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
            this.pictogram = new System.Windows.Forms.PictureBox();
            this.wrap = new System.Windows.Forms.Panel();
            this.bestandsNaam = new System.Windows.Forms.Label();
            this.appStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alternatiefStartenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.locatieOpzoekenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkVerwijderenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.naamWijzigenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.verwijderenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictogram)).BeginInit();
            this.wrap.SuspendLayout();
            this.appStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictogram
            // 
            this.pictogram.Location = new System.Drawing.Point(8, 8);
            this.pictogram.Name = "pictogram";
            this.pictogram.Size = new System.Drawing.Size(64, 64);
            this.pictogram.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictogram.TabIndex = 0;
            this.pictogram.TabStop = false;
            // 
            // wrap
            // 
            this.wrap.Controls.Add(this.bestandsNaam);
            this.wrap.Location = new System.Drawing.Point(3, 78);
            this.wrap.Name = "wrap";
            this.wrap.Size = new System.Drawing.Size(74, 41);
            this.wrap.TabIndex = 0;
            // 
            // bestandsNaam
            // 
            this.bestandsNaam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bestandsNaam.ForeColor = System.Drawing.Color.White;
            this.bestandsNaam.Location = new System.Drawing.Point(3, 0);
            this.bestandsNaam.Name = "bestandsNaam";
            this.bestandsNaam.Size = new System.Drawing.Size(74, 41);
            this.bestandsNaam.TabIndex = 0;
            this.bestandsNaam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // appStrip
            // 
            this.appStrip.BackColor = System.Drawing.Color.Black;
            this.appStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startenToolStripMenuItem,
            this.alternatiefStartenToolStripMenuItem,
            this.toolStripMenuItem1,
            this.locatieOpzoekenToolStripMenuItem,
            this.linkVerwijderenToolStripMenuItem,
            this.naamWijzigenToolStripMenuItem,
            this.toolStripMenuItem2,
            this.verwijderenToolStripMenuItem});
            this.appStrip.Name = "appStrip";
            this.appStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.appStrip.Size = new System.Drawing.Size(181, 170);
            // 
            // startenToolStripMenuItem
            // 
            this.startenToolStripMenuItem.Name = "startenToolStripMenuItem";
            this.startenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startenToolStripMenuItem.Text = "Starten";
            // 
            // alternatiefStartenToolStripMenuItem
            // 
            this.alternatiefStartenToolStripMenuItem.Name = "alternatiefStartenToolStripMenuItem";
            this.alternatiefStartenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.alternatiefStartenToolStripMenuItem.Text = "Alternatief starten";
            this.alternatiefStartenToolStripMenuItem.Click += new System.EventHandler(this.alternatiefStartenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // locatieOpzoekenToolStripMenuItem
            // 
            this.locatieOpzoekenToolStripMenuItem.Name = "locatieOpzoekenToolStripMenuItem";
            this.locatieOpzoekenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.locatieOpzoekenToolStripMenuItem.Text = "Locatie opzoeken";
            this.locatieOpzoekenToolStripMenuItem.Click += new System.EventHandler(this.locatieOpzoekenToolStripMenuItem_Click);
            // 
            // linkVerwijderenToolStripMenuItem
            // 
            this.linkVerwijderenToolStripMenuItem.Name = "linkVerwijderenToolStripMenuItem";
            this.linkVerwijderenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.linkVerwijderenToolStripMenuItem.Text = "Link verwijderen";
            // 
            // naamWijzigenToolStripMenuItem
            // 
            this.naamWijzigenToolStripMenuItem.Name = "naamWijzigenToolStripMenuItem";
            this.naamWijzigenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.naamWijzigenToolStripMenuItem.Text = "Naam wijzigen";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // verwijderenToolStripMenuItem
            // 
            this.verwijderenToolStripMenuItem.Name = "verwijderenToolStripMenuItem";
            this.verwijderenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.verwijderenToolStripMenuItem.Text = "Verwijderen";
            // 
            // Knop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.wrap);
            this.Controls.Add(this.pictogram);
            this.Name = "Knop";
            this.Size = new System.Drawing.Size(80, 123);
            this.MouseEnter += new System.EventHandler(this.Knop_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pictogram)).EndInit();
            this.wrap.ResumeLayout(false);
            this.appStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictogram;
        private System.Windows.Forms.Panel wrap;
        private System.Windows.Forms.Label bestandsNaam;
        private System.Windows.Forms.ContextMenuStrip appStrip;
        private System.Windows.Forms.ToolStripMenuItem startenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alternatiefStartenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem locatieOpzoekenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linkVerwijderenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem naamWijzigenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem verwijderenToolStripMenuItem;
    }
}

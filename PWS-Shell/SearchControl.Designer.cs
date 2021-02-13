namespace PWS_Shell
{
    partial class SearchControl
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
            this.components = new System.ComponentModel.Container();
            this.searchFunction = new System.ComponentModel.BackgroundWorker();
            this.help = new System.Windows.Forms.Label();
            this.items = new System.Windows.Forms.ListView();
            this.naamKop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.padKop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.resultStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bestandslocatieOpenenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.alternatiefStartenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitButton = new System.Windows.Forms.Button();
            this.searchBox = new PWS_Shell.SearchBox();
            this.resultStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchFunction
            // 
            this.searchFunction.WorkerSupportsCancellation = true;
            this.searchFunction.DoWork += new System.ComponentModel.DoWorkEventHandler(this.searchFunction_DoWork);
            this.searchFunction.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.searchFunction_RunWorkerCompleted);
            // 
            // help
            // 
            this.help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.help.AutoSize = true;
            this.help.ForeColor = System.Drawing.Color.White;
            this.help.Location = new System.Drawing.Point(92, 576);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(0, 13);
            this.help.TabIndex = 2;
            // 
            // items
            // 
            this.items.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.items.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(75)))));
            this.items.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.items.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.naamKop,
            this.padKop});
            this.items.ContextMenuStrip = this.resultStrip;
            this.items.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.items.ForeColor = System.Drawing.Color.White;
            this.items.FullRowSelect = true;
            this.items.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.items.HideSelection = false;
            this.items.Location = new System.Drawing.Point(92, 186);
            this.items.Name = "items";
            this.items.Size = new System.Drawing.Size(889, 428);
            this.items.TabIndex = 3;
            this.items.UseCompatibleStateImageBehavior = false;
            this.items.View = System.Windows.Forms.View.Details;
            this.items.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.items_MouseDoubleClick);
            // 
            // naamKop
            // 
            this.naamKop.Text = "Naam";
            this.naamKop.Width = 250;
            // 
            // padKop
            // 
            this.padKop.Text = "Pad";
            // 
            // resultStrip
            // 
            this.resultStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openenToolStripMenuItem,
            this.bestandslocatieOpenenToolStripMenuItem,
            this.toolStripMenuItem1,
            this.alternatiefStartenToolStripMenuItem});
            this.resultStrip.Name = "resultStrip";
            this.resultStrip.Size = new System.Drawing.Size(200, 98);
            this.resultStrip.Opening += new System.ComponentModel.CancelEventHandler(this.resultStrip_Opening);
            // 
            // openenToolStripMenuItem
            // 
            this.openenToolStripMenuItem.Name = "openenToolStripMenuItem";
            this.openenToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.openenToolStripMenuItem.Text = "Openen";
            this.openenToolStripMenuItem.Click += new System.EventHandler(this.openenToolStripMenuItem_Click);
            // 
            // bestandslocatieOpenenToolStripMenuItem
            // 
            this.bestandslocatieOpenenToolStripMenuItem.Name = "bestandslocatieOpenenToolStripMenuItem";
            this.bestandslocatieOpenenToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.bestandslocatieOpenenToolStripMenuItem.Text = "Bestandslocatie openen";
            this.bestandslocatieOpenenToolStripMenuItem.Click += new System.EventHandler(this.bestandslocatieOpenenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(196, 6);
            // 
            // alternatiefStartenToolStripMenuItem
            // 
            this.alternatiefStartenToolStripMenuItem.Name = "alternatiefStartenToolStripMenuItem";
            this.alternatiefStartenToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.alternatiefStartenToolStripMenuItem.Text = "Alternatief starten";
            this.alternatiefStartenToolStripMenuItem.Click += new System.EventHandler(this.alternatiefStartenToolStripMenuItem_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(75)))));
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.exitButton.Location = new System.Drawing.Point(1009, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(82, 82);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "X";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.exitButton_MouseDown);
            this.exitButton.MouseEnter += new System.EventHandler(this.exitButton_MouseEnter);
            this.exitButton.MouseLeave += new System.EventHandler(this.exitButton_MouseLeave);
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(75)))));
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.searchBox.Location = new System.Drawing.Point(92, 109);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(889, 70);
            this.searchBox.TabIndex = 0;
            // 
            // SearchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Magenta;
            this.ClientSize = new System.Drawing.Size(1091, 670);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.items);
            this.Controls.Add(this.help);
            this.Controls.Add(this.searchBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchControl";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.Leave += new System.EventHandler(this.SearchControl_Leave);
            this.resultStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SearchBox searchBox;
        private System.ComponentModel.BackgroundWorker searchFunction;
        private System.Windows.Forms.Label help;
        private System.Windows.Forms.ListView items;
        private System.Windows.Forms.ColumnHeader naamKop;
        private System.Windows.Forms.ColumnHeader padKop;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.ContextMenuStrip resultStrip;
        private System.Windows.Forms.ToolStripMenuItem openenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bestandslocatieOpenenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem alternatiefStartenToolStripMenuItem;
    }
}
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
            this.searchFunction = new System.ComponentModel.BackgroundWorker();
            this.help = new System.Windows.Forms.Label();
            this.items = new System.Windows.Forms.ListView();
            this.naamKop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.padKop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.searchBox = new PWS_Shell.SearchBox();
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
            this.Controls.Add(this.items);
            this.Controls.Add(this.help);
            this.Controls.Add(this.searchBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchControl";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Leave += new System.EventHandler(this.SearchControl_Leave);
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
    }
}
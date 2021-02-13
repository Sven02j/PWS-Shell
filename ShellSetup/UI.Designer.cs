
namespace ShellSetup
{
    partial class UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI));
            this.title = new System.Windows.Forms.Label();
            this.bereikBox = new System.Windows.Forms.GroupBox();
            this.huidigeGebruiker = new System.Windows.Forms.RadioButton();
            this.heleSysteem = new System.Windows.Forms.RadioButton();
            this.toepassenKnop = new System.Windows.Forms.Button();
            this.annulerenKnop = new System.Windows.Forms.Button();
            this.bereikBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(112, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(554, 31);
            this.title.TabIndex = 0;
            this.title.Text = "PWS-Shell Configureren als systeemshell";
            // 
            // bereikBox
            // 
            this.bereikBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bereikBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bereikBox.Controls.Add(this.heleSysteem);
            this.bereikBox.Controls.Add(this.huidigeGebruiker);
            this.bereikBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bereikBox.Location = new System.Drawing.Point(18, 53);
            this.bereikBox.Name = "bereikBox";
            this.bereikBox.Size = new System.Drawing.Size(748, 427);
            this.bereikBox.TabIndex = 1;
            this.bereikBox.TabStop = false;
            this.bereikBox.Text = "Bereik kiezen";
            // 
            // huidigeGebruiker
            // 
            this.huidigeGebruiker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.huidigeGebruiker.AutoSize = true;
            this.huidigeGebruiker.Checked = true;
            this.huidigeGebruiker.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huidigeGebruiker.Location = new System.Drawing.Point(261, 100);
            this.huidigeGebruiker.Name = "huidigeGebruiker";
            this.huidigeGebruiker.Size = new System.Drawing.Size(241, 33);
            this.huidigeGebruiker.TabIndex = 0;
            this.huidigeGebruiker.TabStop = true;
            this.huidigeGebruiker.Text = "Huidige gebruiker";
            this.huidigeGebruiker.UseVisualStyleBackColor = true;
            // 
            // heleSysteem
            // 
            this.heleSysteem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.heleSysteem.AutoSize = true;
            this.heleSysteem.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heleSysteem.Location = new System.Drawing.Point(280, 232);
            this.heleSysteem.Name = "heleSysteem";
            this.heleSysteem.Size = new System.Drawing.Size(189, 33);
            this.heleSysteem.TabIndex = 0;
            this.heleSysteem.Text = "Hele systeem";
            this.heleSysteem.UseVisualStyleBackColor = true;
            // 
            // toepassenKnop
            // 
            this.toepassenKnop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toepassenKnop.Location = new System.Drawing.Point(610, 486);
            this.toepassenKnop.Name = "toepassenKnop";
            this.toepassenKnop.Size = new System.Drawing.Size(75, 23);
            this.toepassenKnop.TabIndex = 2;
            this.toepassenKnop.Text = "Toepassen";
            this.toepassenKnop.UseVisualStyleBackColor = true;
            this.toepassenKnop.Click += new System.EventHandler(this.toepassenKnop_Click);
            // 
            // annulerenKnop
            // 
            this.annulerenKnop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.annulerenKnop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.annulerenKnop.Location = new System.Drawing.Point(691, 486);
            this.annulerenKnop.Name = "annulerenKnop";
            this.annulerenKnop.Size = new System.Drawing.Size(75, 23);
            this.annulerenKnop.TabIndex = 2;
            this.annulerenKnop.Text = "Annuleren";
            this.annulerenKnop.UseVisualStyleBackColor = true;
            this.annulerenKnop.Click += new System.EventHandler(this.annulerenKnop_Click);
            // 
            // UI
            // 
            this.AcceptButton = this.toepassenKnop;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.annulerenKnop;
            this.ClientSize = new System.Drawing.Size(784, 521);
            this.Controls.Add(this.annulerenKnop);
            this.Controls.Add(this.toepassenKnop);
            this.Controls.Add(this.bereikBox);
            this.Controls.Add(this.title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "UI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PWS-Shell setup";
            this.bereikBox.ResumeLayout(false);
            this.bereikBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.GroupBox bereikBox;
        private System.Windows.Forms.RadioButton heleSysteem;
        private System.Windows.Forms.RadioButton huidigeGebruiker;
        private System.Windows.Forms.Button toepassenKnop;
        private System.Windows.Forms.Button annulerenKnop;
    }
}


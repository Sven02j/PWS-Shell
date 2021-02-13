
namespace PWS_Shell
{
    partial class AdvancedAppStarter
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
            this.fileLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.executeButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.adminBox = new System.Windows.Forms.CheckBox();
            this.windowStyleBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.argumentsBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.workingDirBox = new System.Windows.Forms.TextBox();
            this.changeWorkingDirButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileLocation
            // 
            this.fileLocation.Location = new System.Drawing.Point(47, 6);
            this.fileLocation.Name = "fileLocation";
            this.fileLocation.ReadOnly = true;
            this.fileLocation.Size = new System.Drawing.Size(493, 20);
            this.fileLocation.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pad:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.adminBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.argumentsBox);
            this.groupBox1.Location = new System.Drawing.Point(15, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 77);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "App-opties";
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(384, 178);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(75, 23);
            this.executeButton.TabIndex = 3;
            this.executeButton.Text = "Uitvoeren";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(465, 178);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Annuleren";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // adminBox
            // 
            this.adminBox.AutoSize = true;
            this.adminBox.Location = new System.Drawing.Point(6, 19);
            this.adminBox.Name = "adminBox";
            this.adminBox.Size = new System.Drawing.Size(149, 17);
            this.adminBox.TabIndex = 0;
            this.adminBox.Text = "Als administrator uitvoeren";
            this.adminBox.UseVisualStyleBackColor = true;
            // 
            // windowStyleBox
            // 
            this.windowStyleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.windowStyleBox.FormattingEnabled = true;
            this.windowStyleBox.Items.AddRange(new object[] {
            "Normaal",
            "Gemaximaliseerd",
            "Geminimaliseerd",
            "Verborgen"});
            this.windowStyleBox.Location = new System.Drawing.Point(81, 123);
            this.windowStyleBox.Name = "windowStyleBox";
            this.windowStyleBox.Size = new System.Drawing.Size(121, 21);
            this.windowStyleBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Optionele argumenten:";
            // 
            // argumentsBox
            // 
            this.argumentsBox.Location = new System.Drawing.Point(126, 39);
            this.argumentsBox.Name = "argumentsBox";
            this.argumentsBox.Size = new System.Drawing.Size(393, 20);
            this.argumentsBox.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Venster-stijl:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Werkmap:";
            // 
            // workingDirBox
            // 
            this.workingDirBox.Location = new System.Drawing.Point(81, 150);
            this.workingDirBox.Name = "workingDirBox";
            this.workingDirBox.ReadOnly = true;
            this.workingDirBox.Size = new System.Drawing.Size(425, 20);
            this.workingDirBox.TabIndex = 0;
            // 
            // changeWorkingDirButton
            // 
            this.changeWorkingDirButton.Location = new System.Drawing.Point(512, 149);
            this.changeWorkingDirButton.Name = "changeWorkingDirButton";
            this.changeWorkingDirButton.Size = new System.Drawing.Size(28, 23);
            this.changeWorkingDirButton.TabIndex = 5;
            this.changeWorkingDirButton.Text = "...";
            this.changeWorkingDirButton.UseVisualStyleBackColor = true;
            this.changeWorkingDirButton.Click += new System.EventHandler(this.changeWorkingDirButton_Click);
            // 
            // AdvancedAppStarter
            // 
            this.AcceptButton = this.executeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(552, 212);
            this.Controls.Add(this.changeWorkingDirButton);
            this.Controls.Add(this.windowStyleBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.executeButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.workingDirBox);
            this.Controls.Add(this.fileLocation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdvancedAppStarter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Geavanceerd starten";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fileLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox adminBox;
        private System.Windows.Forms.ComboBox windowStyleBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox argumentsBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox workingDirBox;
        private System.Windows.Forms.Button changeWorkingDirButton;
    }
}
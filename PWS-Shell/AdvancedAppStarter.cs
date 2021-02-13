using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PWS_Shell
{
    public partial class AdvancedAppStarter : Form
    {
        private string fileName;
        private bool usingReducedMode;

        public AdvancedAppStarter()
        {
            InitializeComponent();
        }

        public AdvancedAppStarter(string program)
        {
            if (File.Exists(program))
            {
                string ext = Path.GetExtension(program).ToLower();

                if (ext == ".lnk")
                {
                    string loc = ShortcutLocationHandler.GetTargetLocation(program)[0];

                    if (!loc.StartsWith("ERR:"))
                    {
                        program = loc.Substring(4);
                    }

                    ext = Path.GetExtension(program).ToLower();
                }

                Text = $"Geavanceerd starten: ..{Path.GetFileName(program)} in {Path.GetDirectoryName(program)}";
                fileName = program;

                InitializeComponent();

                fileLocation.Text = program;

                if (ext == ".exe" || ext == ".scr" || ext == ".com")
                {
                    usingReducedMode = false;
                }
                else
                {
                    usingReducedMode = true;
                    groupBox1.Enabled = false;
                }

                windowStyleBox.SelectedIndex = 0;
            }
            else
            {
                Close();
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            ProcessWindowStyle style;

            switch (windowStyleBox.Items[windowStyleBox.SelectedIndex].ToString())
            {
                case "Normaal":
                    style = ProcessWindowStyle.Normal;
                    break;
                case "Gemaximaliseerd":
                    style = ProcessWindowStyle.Maximized;
                    break;
                case "Geminimaliseerd":
                    style = ProcessWindowStyle.Minimized;
                    break;
                case "Verborgen":
                    style = ProcessWindowStyle.Hidden;
                    break;
                default:
                    throw new Exception();
            }

            ProcessStartInfo psi;

            if (usingReducedMode)
            {
                psi = new ProcessStartInfo()
                {
                    FileName = fileName,
                    WindowStyle = style
                };

                if (Directory.Exists(workingDirBox.Text))
                    psi.WorkingDirectory = workingDirBox.Text;
            }
            else
            {
                psi = new ProcessStartInfo()
                {
                    FileName = fileName,
                    WindowStyle = style,
                    Arguments = argumentsBox.Text
                };

                if (Directory.Exists(workingDirBox.Text))
                    psi.WorkingDirectory = workingDirBox.Text;

                if (adminBox.Checked)
                {
                    psi.Verb = "runas";
                    psi.UseShellExecute = true;
                }
            }

            try
            {
                Process.Start(psi);
                Close();
            }
            catch
            {

            }
        }

        private void changeWorkingDirButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog()
            {
                Description = "Selecteer de werkmap voor dit proces",
                RootFolder = Environment.SpecialFolder.MyComputer,
                ShowNewFolderButton = true
            };

            if (fb.ShowDialog() == DialogResult.OK)
            {
                workingDirBox.Text = fb.SelectedPath;
            }
        }
    }
}
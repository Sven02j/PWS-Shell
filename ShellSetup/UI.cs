using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using setshell;

namespace ShellSetup
{
    public partial class UI : Form
    {
        private string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public UI()
        {
            InitializeComponent();

            if (!Directory.Exists($"{dir}\\shell"))
            {
                MessageBox.Show("De shell kan niet ingesteld worden. De shell-bestanden zijn niet gevonden. Controleer of de shell zich in het mapje \'shell\' bevindt, en dat die map in dezelfde map staat als dit setup-programma.", "Kan de shell niet instellen.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            else if (!File.Exists($"{dir}\\shell\\PWS-Shell.exe"))
            {
                MessageBox.Show("De shell kan niet ingesteld worden. De shell-bestanden zijn niet gevonden. Controleer of de shell zich in het mapje \'shell\' bevindt, en dat die map in dezelfde map staat als dit setup-programma.", "Kan de shell niet instellen.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void toepassenKnop_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Weet je zeker dat je de shell wilt toepassen? Je kunt altijd terugkeren naar de standaard windows-shell. Je wordt direct afgemeld, niet opgeslagen gegevens gaan verloren.", "Weet je zeker dat je de shell wilt toepassen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (huidigeGebruiker.Checked)
                {
                    SetShell.ShellChange(SetShell.ShellSection.User, $"{dir}\\shell\\PWS-Shell.exe");
                    SetShell.Logoff();
                }
                else if (heleSysteem.Checked)
                {
                    if (SetShell.IsAdministrator())
                    {
                        SetShell.ShellChange(SetShell.ShellSection.Global, $"{dir}\\shell\\PWS-Shell.exe");
                        SetShell.Logoff();
                    }
                    else
                    {
                        ProcessStartInfo p = new ProcessStartInfo()
                        {
                            FileName = Assembly.GetExecutingAssembly().Location,
                            Arguments = "--setGlobalShell",
                            UseShellExecute = true,
                            Verb = "runas"
                        };

                        try
                        {
                            Process.Start(p);
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }

        private void annulerenKnop_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
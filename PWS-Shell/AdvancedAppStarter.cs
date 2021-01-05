using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PWS_Shell
{
    public partial class AdvancedAppStarter : Form
    {
        public AdvancedAppStarter()
        {
            InitializeComponent();
        }

        public AdvancedAppStarter(string program)
        {
            if (!File.Exists(program) && Path.GetExtension(program) == ".exe")
            {
                ProcessStartInfo PWSI = new ProcessStartInfo();
                Process p = new Process();
            }

            InitializeComponent();
            Text = $"Geavanceerd starten: {program}";
        }
    }
}
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PWS_Shell
{
    internal static class ProcessStarter
    {
        internal static void Start(AppLink linker)
        {
            string data = linker.linkData;
            switch (linker.linkType)
            {
                case LinkType.Normal:
                    if (Directory.Exists(data))
                    {
                        // starten met toekomstige bestandsverkenner!

                        ProcessStartInfo PSI = new ProcessStartInfo()
                        {
                            FileName = $"{Environment.GetFolderPath(Environment.SpecialFolder.Windows)}\\explorer.exe",
                            Arguments = $"\"{data}\""
                        };

                        Process.Start(PSI);
                    }
                    else if (File.Exists(data))
                    {
                        Process.Start(data);
                    }
                    else
                    {
                        MessageBox.Show("De locatie waar deze snelkoppeling naar verwijst kan niet worden gevonden.", "Kan snelkoppeling niet openen.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case LinkType.Advertised:
                    break;
                case LinkType.UWP:
                    break;
            }
        }
    }
}
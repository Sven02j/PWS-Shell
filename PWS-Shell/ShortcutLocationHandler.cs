using System;
using System.IO;
using System.Diagnostics;
using IWshRuntimeLibrary;
using File = System.IO.File;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace PWS_Shell
{
    internal static class ShortcutLocationHandler
    {
        internal static string[] GetShortcutLocation(string lnkFile)
        {
            return GetTargetLocation(lnkFile);
        }

        internal static void OpenShortcutLocation(string lnkFile)
        {
            string loc = GetTargetLocation(lnkFile)[0];

            if (!loc.StartsWith("ERR:"))
            {
                SelectFile(loc.Substring(4));
            }
            else
            {
                //MessageBox.Show($"Kan bestandslocatie niet ophalen.\r\n\r\nDarwinDataBlock ID:\r\n{loc.Substring(4)}", "Niet ondersteund", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SelectFile(lnkFile);
            }
        }

        private static string[] GetTargetLocation(string lnkFile)
        {
            string tar = GetShortcutTargetFile(lnkFile);
            string darwindatablock = "NONE";

            if (tar.Contains(@"\Installer\{") && tar.Contains("}"))
            {
                // Jaa, dit is dan waarschijnlijk een advertised shortcut.
                darwindatablock = GetDarwinDataBlockFromShortcutFile(lnkFile);

                string path = null;
                bool found = false;

                RegistryKey assemblyHive = (Registry.ClassesRoot).OpenSubKey(@"Installer\Assemblies");
                foreach (string key in assemblyHive.GetSubKeyNames())
                {
                    RegistryKey subHive = assemblyHive.OpenSubKey(key);
                    foreach (string valueName in subHive.GetValueNames())
                    {
                        string DPreg = ((string[])subHive.GetValue(valueName))[0];

                        if (darwindatablock == DPreg)
                        {
                            path = key.Replace("|", "\\");
                            found = true;
                            break;
                        }
                    }

                    subHive.Close();

                    if (found)
                    {
                        break;
                    }
                }

                assemblyHive.Close();

                if (!found || string.IsNullOrWhiteSpace(path))
                {
                    return new string[] { "ERR:" + darwindatablock, darwindatablock};
                }
                else
                {
                    return new string[] { "ADV:" + path, darwindatablock };
                }
            }
            else
            {
                return new string[] { "NOR:" + tar, "NORMAL" };
            }

            // nog checken voor de volgende 4 shortcut types:
            // Application References, dus in de zin van een Win32-snelkoppeling uit shell:appsFolder. De link naar het doelbestand lijkt gewoon in het bestand te staan, maar Windows zelf opent de snelkoppeling uit het startmenu waar het naar verwijst. Hier nog naar kijken
            // UWP Application References, de friendly name staat in de snelkoppeling. Je moet deze in een UWP-map vinden, en de entrypoint selecten door middel van AppxManifest.xml te doorzoeken.
            // Explorer shortcuts, het doel is meestal gewoon de working directory + de arguments. (Win32-apps)
            // Explorer shortcuts UWP. Dit is dat windows verkenner voor de naam van een uwp friendly name staat. De argument moet op dezelfde manier behandeld worden als bij UWP application references, alleen is de friendly name makkelijker te verkrijgen.
        }

        internal static void SelectFile(string file)
        {
            ProcessStartInfo PSI = new ProcessStartInfo()
            {
                Arguments = $"/select,\"{file}\"",
                FileName = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\explorer.exe",
                WindowStyle = ProcessWindowStyle.Maximized
            };

            Process host = new Process
            {
                StartInfo = PSI
            };
            host.Start();
            host.WaitForInputIdle();
        }

        internal static string GetShortcutTargetFile(string shortcutFilename)
        {
            WshShell shell = new WshShell();
            IWshShortcut link = (IWshShortcut)shell.CreateShortcut(shortcutFilename);
            return link.TargetPath;
        }

        internal static string GetDarwinDataBlockFromShortcutFile(string LnkFile)
        {
            WshShell shell = new WshShell();
            IWshShortcut link = (IWshShortcut)shell.CreateShortcut(LnkFile);

            // shortcut target location, the darwin descriptor is the next set of chars in the file, 8 chars further.
            string target = link.TargetPath;

            // Read the file with ANSI (Western European) Encoding.
            string read = File.ReadAllText(LnkFile, Encoding.GetEncoding(1250));

            // Retrieve the location of the target location in the shortcut file.
            int TargetPathPositionInFile = chklocation(read, target);

            // If the target path is not found, return null.
            if (TargetPathPositionInFile == -1)
            {
                return null;
            }

            // Cut of the first part of the string to start with the data block.
            string DarwinDataBlockRaw = read.Substring(TargetPathPositionInFile + (target.Length * 2) + 8);

            // Represents an empty character, which somehow is not an space.
            char empty = (char)0;

            // Split the raw data block on the empty char and take the first part of it, to completely receive the darwin data block.
            string result = DarwinDataBlockRaw.Split(empty)[0];

            // Method used once.
            // Used to get the location of the target path inside the shortcut.
            int chklocation(string buffer, string nospace)
            {
                int j = 0;
                // Check for every character in the file (buffer), if it starts with the same character as the target file (nospace). It then builds an string, by constantly skipping one character (cause that is empty), until it reaches the length of the target path multiplied by two. If it is equal, it returns the location. If not, it keeps scanning.
                foreach (char c in buffer)
                {
                    if (c == nospace[0])
                    {
                        int chklngth = nospace.Length;
                        string builder = "";

                        for (int u = 0; u < chklngth * 2; u++)
                        {
                            builder += buffer[j + u];
                            u++;
                        }

                        if (builder.Contains(nospace))
                        {
                            return j;
                        }
                    }
                    j++;
                }
                // The target path has not been found inside the shortcut file, and so it returns -1 (null equivalent in int)
                return -1;
            }

            return result;
        }
    }
}
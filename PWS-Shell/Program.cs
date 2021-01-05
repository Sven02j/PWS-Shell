using System;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace PWS_Shell
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0].StartsWith("-AltStart:"))
                {
                    string program = args[0].Substring(10);

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new AdvancedAppStarter(program));

                    Environment.Exit(0);
                }
            }

            string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            bool debugMode = false;

            if (File.Exists(path + "\\ShellDebugMode"))
                debugMode = true;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Desktop(debugMode));
        }
    }
}
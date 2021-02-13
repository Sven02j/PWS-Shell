using System;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using setshell;

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

                if (args[0] == "--revertShell")
                {
                    if (SetShell.IsAdministrator())
                        SetShell.RevertShell();
                    Environment.Exit(0);
                }

                if (args[0] == "-ChangeName")
                {
                    if (SetShell.IsAdministrator())
                    {
                        if (args.Length > 2)
                        {
                            try
                            {
                                if (File.Exists(args[1]) && !File.Exists(args[2]) && !Directory.Exists(args[2]))
                                {
                                    File.Move(args[1], args[2]);
                                }
                                else if (Directory.Exists(args[1]) && !Directory.Exists(args[2]) && !File.Exists(args[2]))
                                {
                                    Directory.Move(args[1], args[2]);
                                }
                            }
                            catch
                            {

                            }
                        }
                    }

                    Environment.Exit(0);
                }

                if (args[0] == "-Delete")
                {
                    if (SetShell.IsAdministrator())
                    {
                        if (args.Length > 1)
                        {
                            try
                            {
                                if (File.Exists(args[1]))
                                {
                                    File.Delete(args[1]);
                                }
                                else if (Directory.Exists(args[1]))
                                {
                                    Directory.Delete(args[1], true);
                                }
                            }
                            catch
                            {

                            }
                        }
                    }

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
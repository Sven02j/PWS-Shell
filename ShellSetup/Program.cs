using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using setshell;

namespace ShellSetup
{
    static class Program
    {
        private static string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0] == "--setGlobalShell")
                {
                    if (SetShell.IsAdministrator() && File.Exists($"{dir}\\shell\\PWS-Shell.exe"))
                    {
                        SetShell.ShellChange(SetShell.ShellSection.Global, $"{dir}\\shell\\PWS-Shell.exe");
                        SetShell.Logoff();
                    }
                    Environment.Exit(0);
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UI());
        }
    }
}
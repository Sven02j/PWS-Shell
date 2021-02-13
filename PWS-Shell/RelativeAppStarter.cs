using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PWS_Shell
{
    internal static class RelativeAppStarter
    {
        internal static void StartRelativeApp(string appName)
        {
            string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\" + appName;

            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
            else
            {
                new Task(() => { StartApp(path); }).Start();
            }
        }

        private static void StartApp(string path)
        {
            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = path
                }
            };

            process.Start();
        }

        internal static bool StartRelativeApp(string appName, string arguments, bool admin)
        {
            string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\" + appName;

            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
            else
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = path,
                    Arguments = arguments
                };

                if (admin)
                {
                    psi.Verb = "runas";
                    psi.UseShellExecute = true;
                }

                try
                {
                    Process.Start(psi);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
using System;
using System.Reflection;
using System.IO;
using System.Diagnostics;

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
                Process.Start(path);
            }
        }

        internal static void StartRelativeApp(string appName, string arguments)
        {
            string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\" + appName;

            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
            else
            {
                Process.Start(path, arguments);
            }
        }
    }
}
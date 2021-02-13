using Microsoft.Win32;
using System;
using System.IO;
using System.Security.Principal;

namespace setshell
{
    internal static class SetShell
    {
        internal static void RevertShell()
        {
            ShellChange(ShellSection.Global, "explorer.exe");
            ShellChange(ShellSection.User, "<SMDefault>");
            PWS_Shell.ShutdownComponent.Logoff();
        }

        internal static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        internal static bool ExistsOnPath(string fileName)
        {
            return GetFullPath(fileName) != null;
        }

        internal static string GetFullPath(string fileName)
        {
            if (fileName == "<SMDefault>")
                return fileName;
            if (fileName == "explorer.exe")
                return fileName;
            if (File.Exists(fileName))
                return Path.GetFullPath(fileName);

            var values = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in values.Split(Path.PathSeparator))
            {
                var fullPath = Path.Combine(path, fileName);
                if (File.Exists(fullPath))
                    return fullPath;
            }
            return null;
        }

        internal static void ShellChange(ShellSection section, string path)
        {
            if (!ExistsOnPath(path))
            {
                throw new FileNotFoundException();
            }

            path = GetFullPath(path);

            RegistryKey regKey;

            switch (section)
            {
                case ShellSection.Global:
                    if (!IsAdministrator())
                    {
                        throw new UnauthorizedAccessException();
                    }
                    regKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true);
                    break;
                case ShellSection.User:
                    regKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true);
                    if (path == "<SMDefault>")
                    {
                        regKey.DeleteValue("Shell", false);
                        return;
                    }
                    break;
                default:
                    throw new Exception("Impossible.");
            }

            regKey.SetValue("Shell", path);
            regKey.Close();
        }

        internal static string ShellReturn(ShellSection section)
        {
            RegistryKey regKey;

            switch (section)
            {
                case ShellSection.Global:
                    regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", false);
                    break;
                case ShellSection.User:
                    regKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", false);
                    break;
                default:
                    throw new Exception("Impossible.");
            }

            if (regKey != null)
            {
                string value = (string)regKey.GetValue("Shell");
                if (string.IsNullOrWhiteSpace(value))
                {
                    return null;
                }
                else
                {
                    return value;
                }
            }
            else
            {
                return null;
            }
        }

        internal enum ShellSection
        {
            Global,
            User
        }
    }
}
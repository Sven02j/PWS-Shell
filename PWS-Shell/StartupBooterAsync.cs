using System;
using Microsoft.Win32;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;
using System.Security.Principal;
using System.Web;
using System.Linq;
using System.Security.AccessControl;
using System.Security;
using System.Diagnostics.CodeAnalysis;

namespace PWS_Shell
{
    internal static class StartupBooterAsync
    {
        internal static void StartProcesses()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;

            worker.RunWorkerAsync();
        }

        private static void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            RegistryKey disabled = (Registry.Users).OpenSubKey($@"{SID}\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\StartupApproved\Run");

            Console.WriteLine(SID);

            // Dit lijkt niet voor alle apps te werken... maar, dit kan fout gemeten zijn.
            string[] unallowed = disabled.GetValueNames();

            disabled.Close();

            // kijken naar RunOnceEx??? Ook eventueel 32-bit gebruikeropstartprocessen, ook al bestaan ze niet. Ze zouden ergens anders wel kunnen bestaan.

            // global startup
            RegistryKey globalStartup = (Registry.LocalMachine).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            // user startup
            RegistryKey userStartup = (Registry.CurrentUser).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            // global startup ONCE
            RegistryKey globalStartupONCE = (Registry.LocalMachine).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\RunOnce");
            // user startup ONCE
            RegistryKey userStartupONCE = (Registry.CurrentUser).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\RunOnce");
            // global startup 32-bit
            RegistryKey globalStartup32 = (Registry.LocalMachine).OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Run");
            // global startup 32-bit ONCE
            RegistryKey globalStartupONCE32 = (Registry.LocalMachine).OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\RunOnce");

            Console.WriteLine();

            if (globalStartup != null)
                ProcessRegistryKey(ref globalStartup, false, unallowed);
            if (globalStartup32 != null)
                ProcessRegistryKey(ref globalStartup32, false, unallowed);
            if (userStartup != null)
                ProcessRegistryKey(ref userStartup, false, unallowed);
            if (globalStartupONCE != null)
                ProcessRegistryKey(ref globalStartupONCE, true, unallowed);
            if (globalStartupONCE32 != null)
                ProcessRegistryKey(ref globalStartupONCE32, true, unallowed);
            if (userStartupONCE != null)
                ProcessRegistryKey(ref userStartupONCE, true, unallowed);
        }

        private static void ProcessRegistryKey(ref RegistryKey key, bool RunONCE, string[] unallowed)
        {
            foreach (string valueName in key.GetValueNames())
            {
                if (!unallowed.Contains(valueName) && !RunONCE || (HasAccess(key) && RunONCE))
                {
                    string value = Environment.ExpandEnvironmentVariables(key.GetValue(valueName).ToString());

                    Console.WriteLine(value);

                    string fileName;
                    string arguments;

                    if (value.Contains("\""))
                    {
                        // Between the "" is the file name, everything behind it are the arguments.
                        if (value.StartsWith("\""))
                        {
                            fileName = value.Substring(value.IndexOf('\"') + 1).Split('\"')[0];


                            arguments = value.Substring(value.IndexOf('\"') + 1);
                            arguments = arguments.Substring(fileName.Length + 1);

                            if (arguments.StartsWith(" "))
                                arguments = arguments.Substring(1);

                            Console.WriteLine("STARTUP PROGRAM: POSSIBLE ARGUMENTS. CHECK.");
                            Console.WriteLine($"File Name: {fileName}");
                            Console.WriteLine($"Arguments: {arguments}");
                            Console.WriteLine();
                        }
                        else
                        {
                            // not supported.
                            continue;
                        }
                    }
                    else
                    {
                        // Value has no arguments
                        fileName = value;
                        arguments = "";

                        Console.WriteLine("STARTUP PROGRAM: NO ARGUMENTS. STILL CHECK.");
                        Console.WriteLine($"File Name: {fileName}");
                        Console.WriteLine($"Arguments: {arguments}");
                        Console.WriteLine();
                    }

                    ProcessStartInfo startupInfo = new ProcessStartInfo()
                    {
                        FileName = fileName,
                        Arguments = arguments,
                        WorkingDirectory = Path.GetDirectoryName(fileName)
                    };

                    Process startup = new Process()
                    {
                        StartInfo = startupInfo
                    };

                    startup.Start();
                    startup.WaitForInputIdle(2500);

                    if (RunONCE)
                    {
                        key.DeleteValue(valueName);
                    }
                } // else: Disabled, or run-once and we cannot delete the value.
            }

            key.Close();
        }

        [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "<Pending>")]
        public static SecurityIdentifier SID
        {
            get
            {
                WindowsIdentity identity = null;

                if (HttpContext.Current == null)
                {
                    identity = WindowsIdentity.GetCurrent();
                }
                else
                {
                    identity = HttpContext.Current.User.Identity as WindowsIdentity;
                }

                return identity.User;
            }
        }

        /// <summary>
        /// Checks if we have permission to delete a registry key
        /// </summary>
        /// <param name="key">Registry key</param>
        /// <returns>True if we can delete it</returns>
        public static bool HasAccess(RegistryKey key)
        {
            try
            {
                if (key.SubKeyCount > 0)
                {
                    bool ret = false;

                    foreach (string subKey in key.GetSubKeyNames())
                    {
                        ret = HasAccess(key.OpenSubKey(subKey));

                        if (!ret)
                            break;
                    }

                    return ret;
                }
                else
                {
                    RegistrySecurity regSecurity = key.GetAccessControl();

                    foreach (AuthorizationRule rule in regSecurity.GetAccessRules(true, false, typeof(NTAccount)))
                    {
                        if ((RegistryRights.Delete & ((RegistryAccessRule)(rule)).RegistryRights) != RegistryRights.Delete)
                        {
                            return false;
                        }
                    }

                    return true;
                }

            }
            catch (SecurityException)
            {
                return false;
            }
        }
    }
}
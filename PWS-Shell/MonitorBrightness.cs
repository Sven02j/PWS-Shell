using System;
using System.Management;

namespace PWS_Shell
{
    public static class WindowsSettingsBrightnessController
    {
        public static int Get()
        {
            using var mclass = new ManagementClass("WmiMonitorBrightness")
            {
                Scope = new ManagementScope(@"\\.\root\wmi")
            };
            using var instances = mclass.GetInstances();
            foreach (ManagementObject instance in instances)
            {
                return (byte)instance.GetPropertyValue("CurrentBrightness");
            }
            return 0;
        }

        public static void Set(int brightness)
        {
            using var mclass = new ManagementClass("WmiMonitorBrightnessMethods")
            {
                Scope = new ManagementScope(@"\\.\root\wmi")
            };
            using var instances = mclass.GetInstances();
            var args = new object[] { 1, brightness };
            foreach (ManagementObject instance in instances)
            {
                instance.InvokeMethod("WmiSetBrightness", args);
            }
        }
    }

    public class MonitorBrightnessWatcher
    {
        private readonly ManagementEventWatcher Watcher;
        private readonly ManagementScope Scope;

        internal delegate void BrightnessChangeHandler(int brightness, string instanceName);
        internal event BrightnessChangeHandler BrightnessChanged;

        private void WmiEventHandler(object sender, EventArrivedEventArgs e)
        {
            int brightness = Convert.ToInt32(e.NewEvent.Properties["Brightness"].Value);
            string instanceName = e.NewEvent.Properties["InstanceName"].Value.ToString();

            BrightnessChangeHandler handler = BrightnessChanged;
            handler.Invoke(brightness, instanceName);
        }

        public MonitorBrightnessWatcher()
        {
            try
            {
                string ComputerName = "localhost";
                string WmiQuery;

                if (!ComputerName.Equals("localhost", StringComparison.OrdinalIgnoreCase))
                {
                    ConnectionOptions Conn = new ConnectionOptions();
                    Conn.Username = "";
                    Conn.Password = "";
                    Conn.Authority = "ntlmdomain:DOMAIN";
                    Scope = new ManagementScope(String.Format("\\\\{0}\\root\\WMI", ComputerName), Conn);
                }
                else
                    Scope = new ManagementScope(String.Format("\\\\{0}\\root\\WMI", ComputerName), null);
                Scope.Connect();

                WmiQuery = "Select * From WmiMonitorBrightnessEvent";

                Watcher = new ManagementEventWatcher(Scope, new EventQuery(WmiQuery));
                Watcher.EventArrived += new EventArrivedEventHandler(this.WmiEventHandler);
                Watcher.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception {0} Trace {1}", e.Message, e.StackTrace);
            }
        }

        public void StopWatching()
        {
            Watcher.Stop();
        }
    }
}
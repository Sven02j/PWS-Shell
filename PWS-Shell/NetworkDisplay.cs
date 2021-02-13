using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using PWS_Shell.Properties;
using static PWS_Shell.NetworkMethods;

namespace PWS_Shell
{
    public partial class NetworkDisplay : UserControl
    {
        private bool IsChecking = false;

        public NetworkDisplay()
        {
            InitializeComponent();
        }

        private void NetworkDisplay_Load(object sender, EventArgs e)
        {
            UpdateVisualComponent(NetworkConnectionType.None, NetworkConnectionStrength.Problem);

            CheckNetworkDetails();

            NetworkChange.NetworkAddressChanged += NetworkChange_NetworkAddressChanged;
        }

        internal void CheckNetworkDetails()
        {
            if (!IsChecking)
            {
                IsChecking = true;

                foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (netInterface.OperationalStatus == OperationalStatus.Up)
                    {
                        string inter = netInterface.NetworkInterfaceType.ToString();
                        long speed = netInterface.Speed / 1048576;

                        Console.WriteLine(inter);

                        if (inter.StartsWith("Ethernet"))
                        {
                            if (speed < 1)
                            {
                                UpdateVisualComponent(NetworkConnectionType.Wired, NetworkConnectionStrength.Problem);
                            }
                            else
                            {
                                UpdateVisualComponent(NetworkConnectionType.Wired, NetworkConnectionStrength.Good);
                            }
                            break;
                        }
                        else if (inter.StartsWith("Wireless"))
                        {
                            if (speed < 1)
                            {
                                UpdateVisualComponent(NetworkConnectionType.Wireless, NetworkConnectionStrength.Problem);
                            }
                            else if (speed < 3)
                            {
                                UpdateVisualComponent(NetworkConnectionType.Wireless, NetworkConnectionStrength.Poor);
                            }
                            else if (speed < 7)
                            {
                                UpdateVisualComponent(NetworkConnectionType.Wireless, NetworkConnectionStrength.Weak);
                            }
                            else if (speed < 12)
                            {
                                UpdateVisualComponent(NetworkConnectionType.Wireless, NetworkConnectionStrength.Good);
                            }
                            else
                            {
                                UpdateVisualComponent(NetworkConnectionType.Wireless, NetworkConnectionStrength.Strong);
                            }
                        }
                        else if (inter.StartsWith("Loopback"))
                        {
                            if (!IsNetworkAvailable())
                            {
                                UpdateVisualComponent(NetworkConnectionType.None, NetworkConnectionStrength.Problem);
                            }
                        }
                    }
                }

                IsChecking = false;
            }
        }

        private void NetworkChange_NetworkAddressChanged(object sender, EventArgs e)
        {
            CheckNetworkDetails();
        }

        private void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (netInterface.OperationalStatus == OperationalStatus.Up)
                {
                    string inter = netInterface.NetworkInterfaceType.ToString();
                    Console.WriteLine(inter);

                    if (inter.StartsWith("Ethernet"))
                    {
                        UpdateVisualComponent(NetworkConnectionType.Wired, NetworkConnectionStrength.Good);
                    }
                    else if (inter.StartsWith("Wireless"))
                    {
                        UpdateVisualComponent(NetworkConnectionType.Wireless, NetworkConnectionStrength.Good);
                    }
                    else
                    {
                        UpdateVisualComponent(NetworkConnectionType.None, NetworkConnectionStrength.Problem);
                    }
                }
            }
        }

        internal void UpdateVisualComponent(NetworkConnectionType connectionType, NetworkConnectionStrength connectionStrength)
        {
            switch ((int)connectionType)
            {
                case 0:
                    SetImage(Resources.no_network);
                    break;
                case 1:
                    switch ((int)connectionStrength)
                    {
                        case 0:
                            SetImage(Resources.network_error);
                            break;
                        case 1:
                            SetImage(Resources.wifi_weak);
                            break;
                        case 2:
                            SetImage(Resources.wifi_poor);
                            break;
                        case 3:
                            SetImage(Resources.wifi_good);
                            break;
                        case 4:
                            SetImage(Resources.wifi_strong);
                            break;
                    }
                    break;
                case 2:
                    if ((int)connectionStrength == 0)
                    {
                        SetImage(Resources.network_error);
                    }
                    else
                    {
                        SetImage(Resources.ethernet);
                    }
                    break;
            }

            void SetImage(Image img)
            {
                networkIcon.Image = img;
            }
        }

        internal enum NetworkConnectionType
        {
            None = 0,
            Wireless = 1,
            Wired = 2
        }

        internal enum NetworkConnectionStrength
        {
            Problem = 0,
            Weak = 1,
            Poor = 2,
            Good = 3,
            Strong = 4
        }

        private void networkIcon_Click(object sender, EventArgs e)
        {
            RelativeAppStarter.StartRelativeApp("Instellingen.exe");
        }
    }
}
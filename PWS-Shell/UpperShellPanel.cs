using System;
using System.Windows.Forms;
using PWS_Shell.Properties;
using AudioSwitcher.AudioApi.CoreAudio;
using System.Drawing;
using System.Diagnostics;
using setshell;
using System.IO;
using System.Reflection;

namespace PWS_Shell
{
    public partial class UpperShellPanel : UserControl
    {
        internal VolumeController Volume;
        private bool hasBattery;

        private int ScreenNumber 
        { 
            get
            {
                return ((Desktop)Parent.Parent.Parent.Parent).ScreenNumber;
            }
        }

        public UpperShellPanel()
        {
            InitializeComponent();

            hasBattery = (SystemInformation.PowerStatus.BatteryChargeStatus != BatteryChargeStatus.NoSystemBattery);

            Volume = new VolumeController();
            brightnessVolumeDisplay.ForceUpdateSound(Convert.ToInt32(Math.Round(Volume.SystemVolume)), Volume.IsMuted);

            InfoUpdater.Start();
            networkTimer.Start();

            foreach (ToolStripItem item in energyDropDown.Items)
            {
                item.Font = new Font(item.Font.FontFamily, 15);
            }

            foreach (ToolStripItem item in optionsStrip.Items)
            {
                item.Font = new Font(item.Font.FontFamily, 15);
            }

            foreach (ToolStripItem item in toolsStrip.Items)
            {
                item.Font = new Font(item.Font.FontFamily, 15);
            }
        }

        private void searchIcon_MouseEnter(object sender, EventArgs e)
        {
            searchIcon.Image = Resources.searchhover;
        }

        private void searchIcon_MouseLeave(object sender, EventArgs e)
        {
            searchIcon.Image = Resources.search;
        }

        private void searchIcon_Click(object sender, EventArgs e)
        {
            OpacityOverlayStandalone OOS = new OpacityOverlayStandalone(ScreenNumber);
            OOS.FormProjection(new SearchControl(ScreenNumber));
        }

        internal class VolumeController
        {
            private CoreAudioDevice control;

            internal double SystemVolume
            {
                get
                {
                    return control.Volume;
                }
            }

            internal bool IsMuted
            {
                get
                {
                    return control.IsMuted;
                }
            }

            internal VolumeController()
            {
                control = new CoreAudioController().DefaultPlaybackDevice;
            }

            internal void IncreaseVolume()
            {
                if (control.IsMuted)
                    control.Mute(false);

                if (!(control.Volume + 2 >= 100))
                    control.Volume += 2;
            }

            internal void DecreaseVolume()
            {
                if (control.Volume - 2 <= 0)
                {
                    control.Volume = 0;
                    control.Mute(true);
                }
                else
                {
                    if (control.IsMuted)
                        control.Mute(false);

                    control.Volume -= 2;
                }
            }

            internal void Mute()
            {
                bool mute = control.IsMuted;
                control.Mute(Convert.ToBoolean(1 - Convert.ToInt32(mute)));
            }
        }

        private void settingsLinker_Click(object sender, EventArgs e)
        {
            Point loc = MonitorMethods.PointCumulate(MonitorMethods.GetLeftCornerOfScreenNumber(ScreenNumber), new Point(0, Height));
            optionsStrip.Show(loc);
        }

        private void energyControlButton_Click(object sender, EventArgs e)
        {
            Point loc = MonitorMethods.PointCumulate(MonitorMethods.GetLeftCornerOfScreenNumber(ScreenNumber), new Point(0, Height));
            energyDropDown.Show(loc);
        }

        #region Energieopties
        private void afsluitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Desktop.allowExit = true;
            ShutdownComponent.Shutdown();
        }

        private void opnieuwOpstartenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Desktop.allowExit = true;
            ShutdownComponent.Reboot();
        }

        private void sluimerstandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShutdownComponent.Suspend();
        }

        private void slaapstandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShutdownComponent.Sleep();
        }

        private void uitloggenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Desktop.allowExit = true;
            ShutdownComponent.Logoff();
        }

        private void vergrendelenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShutdownComponent.Lock();
        }
        #endregion

        private void InfoUpdater_Tick(object sender, EventArgs e)
        {
            TimeDateDisplay.TimeDateUpdate();

            if (hasBattery)
                batteryDisplay.UpdateBatteryIcon();

            brightnessVolumeDisplay.UpdateVolume(Convert.ToInt32(Math.Round(Volume.SystemVolume)), Volume.IsMuted);
        }

        private void settingsLinker_MouseEnter(object sender, EventArgs e)
        {
            settingsLinker.Image = Resources.coghover;
        }

        private void settingsLinker_MouseLeave(object sender, EventArgs e)
        {
            settingsLinker.Image = Resources.cog;
        }

        private void energyControlButton_MouseEnter(object sender, EventArgs e)
        {
            energyControlButton.Image = Resources.shutdownhover;
        }

        private void energyControlButton_MouseLeave(object sender, EventArgs e)
        {
            energyControlButton.Image = Resources.shutdown;
        }

        private void shellInstellingen_Click(object sender, EventArgs e)
        {
            RelativeAppStarter.StartRelativeApp("Instellingen.exe");
        }

        private void systeemInstellingen_Click(object sender, EventArgs e)
        {
            ProcessStart("control.exe");
        }

        private void shellTerugzetten_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Weet je zeker dat je de shell terug wilt zetten naar de standaard Windows-Shell? Je wordt direct afgemeld, niet opgeslagen gegevens gaan verloren.", "Shell terugzetten", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (SetShell.ShellReturn(SetShell.ShellSection.Global) != "explorer.exe")
                {
                    ProcessStartInfo p = new ProcessStartInfo()
                    {
                        FileName = Assembly.GetExecutingAssembly().Location,
                        Arguments = "--revertShell",
                        Verb = "runas",
                        UseShellExecute = true
                    };

                    try
                    {
                        Process.Start(p);
                    }
                    catch
                    {

                    }
                }
                else
                {
                    SetShell.ShellChange(SetShell.ShellSection.User, "<SMDefault>");
                    ShutdownComponent.Logoff();
                }
            }
        }

        private void bestandsSysteem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", ",");
        }

        private void toolsButton_MouseEnter(object sender, EventArgs e)
        {
            toolsButton.Image = Resources.tools_hover;
        }

        private void toolsButton_MouseLeave(object sender, EventArgs e)
        {
            toolsButton.Image = Resources.tools;
        }

        private void toolsButton_Click(object sender, EventArgs e)
        {
            Point loc = MonitorMethods.PointCumulate(MonitorMethods.GetLeftCornerOfScreenNumber(ScreenNumber), new Point(0, Height));
            toolsStrip.Show(loc);
        }

        private void taakbeheerStrip_Click(object sender, EventArgs e)
        {
            ProcessStart("taskmgr.exe");
        }

        private void commandPromptStrip_Click(object sender, EventArgs e)
        {
            ProcessStart("cmd.exe");
        }

        private void apparaatbeheerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStart("devmgmt.msc");
        }

        private void schijfbeheerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStart("diskmgmt.msc");
        }

        private void powerShellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStart("powershell.exe");
        }

        private void networkTimer_Tick(object sender, EventArgs e)
        {
            networkDisplay.CheckNetworkDetails();
        }

        private void ProcessStart(string proc)
        {
            try
            {
                Process.Start(proc);
            }
            catch
            {

            }
        }

        private void registereditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStart("regedit.exe");

        }
    }
}
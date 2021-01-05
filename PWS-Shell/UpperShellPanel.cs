using System;
using System.Windows.Forms;
using PWS_Shell.Properties;
using AudioSwitcher.AudioApi.CoreAudio;
using System.Drawing;

namespace PWS_Shell
{
    public partial class UpperShellPanel : UserControl
    {
        internal VolumeController Volume;
        private bool hasBattery;

        public UpperShellPanel()
        {
            InitializeComponent();

            hasBattery = (SystemInformation.PowerStatus.BatteryChargeStatus != BatteryChargeStatus.NoSystemBattery);
            InfoUpdater.Start();

            Volume = new VolumeController();
            
            foreach (ToolStripItem item in energyDropDown.Items)
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
            OpacityOverlayStandalone OOS = new OpacityOverlayStandalone();
            OOS.FormProjection(new SearchControl());
        }

        internal class VolumeController
        {
            private CoreAudioDevice control;

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
            RelativeAppStarter.StartRelativeApp("Instellingen.exe");
        }

        private void energyControlButton_Click(object sender, EventArgs e)
        {
            Point pnt = new Point();
            pnt.X = 0;
            pnt.Y = this.Height;
            energyDropDown.Show(pnt);
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
        }
    }
}
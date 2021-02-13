using System;
using System.Windows.Forms;
using PWS_Shell.Properties;

namespace PWS_Shell
{
    public partial class BrightnessVolumeDisplay : UserControl
    {
        private bool prevMuted;

        public BrightnessVolumeDisplay()
        {
            InitializeComponent();

            panel1.Parent = this;
            panel2.Parent = this;
        }

        internal void UpdateVolume(int volume, bool muted)
        {
            soundLabel.Text = volume.ToString();

            if (muted)
            {
                if (!prevMuted)
                {
                    soundIcon.Image = Resources.sound_mute;
                }

                prevMuted = true;
            }
            else
            {
                if (prevMuted)
                {
                    soundIcon.Image = Resources.sound;
                }

                prevMuted = false;
            }
        }

        internal void UpdateBrightness(int brightness)
        {
            if (brightness == -1)
            {
                panel2.Visible = false;
            }
            brightnessLabel.Text = brightness.ToString();
        }

        internal void ForceUpdateSound(int volume, bool muted)
        {
            soundLabel.Text = volume.ToString();

            if (muted)
            {
                soundIcon.Image = Resources.sound_mute;
                prevMuted = true;
            }
            else
            {
                soundIcon.Image = Resources.sound;
                prevMuted = false;
            }
        }

        private void soundIcon_Click(object sender, EventArgs e)
        {
            RelativeAppStarter.StartRelativeApp("Instellingen.exe");
        }

        private void brightnessIcon_Click(object sender, EventArgs e)
        {
            RelativeAppStarter.StartRelativeApp("Instellingen.exe");
        }
    }
}
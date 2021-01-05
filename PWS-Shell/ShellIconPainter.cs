using System;
using System.Windows.Forms;
using PWS_Shell.Properties;
using System.Threading;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Drawing;

namespace PWS_Shell
{
    public partial class ShellIconPainter : Form, ISynchronizeInvoke
    {
        private bool isAllowed = false;

        /// <summary>
        /// Verbergen voor het ALT + TAB Menu
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // turn on WS_EX_TOOLWINDOW style bit
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        public ShellIconPainter()
        {
            InitializeComponent();
        }

        internal ShellIconPainter(IconType iconType, int value)
        {
            InitializeComponent();
            SetImage(iconType);

            xIcon.Parent = this;

            int xSize = Convert.ToInt32(Math.Round(Convert.ToDouble(value + 50) / 1.5d));
            this.Size = new Size(xSize, xSize);
        }

        internal enum IconType
        {
            Sound,
            Brightness
        }

        private void Fancyness()
        {
            FadeIn(this, 10);
        }

        private void SetImage(IconType type)
        {
            switch (type)
            {
                case IconType.Brightness:
                    xIcon.Image = Resources.brightness;
                    break;
                case IconType.Sound:
                    xIcon.Image = Resources.sound;
                    break;
            }
        }

        private void ShellIconPainter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isAllowed)
                e.Cancel = true;
        }

        private void ShellIconPainter_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            Fancyness();
            waiter.RunWorkerAsync();
        }

        private async void FadeIn(Form o, int interval = 80)
        {
            //Object is not fully invisible. Fade it in
            while (o.Opacity < 1.0)
            {
                await Task.Delay(interval);
                o.Opacity += 0.05;
            }
            o.Opacity = 1; //make fully visible       
        }

        private async void FadeOut(Form o, int interval = 80)
        {
            //Object is fully visible. Fade it out
            while (o.Opacity > 0.0)
            {
                await Task.Delay(interval);
                o.Opacity -= 0.05;
            }
            o.Opacity = 0; //make fully invisible       
        }

        private void waiter_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(200);
        }

        private void waiter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Hide();
            Close();
        }
    }
}
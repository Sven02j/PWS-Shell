using System;
using System.Windows.Forms;
using PWS_Shell.Properties;
using System.Threading;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Drawing;
using static PWS_Shell.ShellIconTreadHost;

namespace PWS_Shell
{
    public partial class ShellIconPainter : Form, ISynchronizeInvoke
    {
        private bool isAllowed = false;

        private IconFlag flag;

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

        internal ShellIconPainter(IconType iconType, int value, IconFlag flag)
        {
            Rectangle bnd = Screen.GetWorkingArea(this);
            Location = new Point(Convert.ToInt32(Math.Round(Convert.ToDouble(bnd.Width) / 15d)), Convert.ToInt32(Math.Round(Convert.ToDouble(bnd.Height) / 15d)));

            InitializeComponent();
            SetImage(iconType, (flag) == IconFlag.Muted);

            xIcon.Parent = this;
            this.flag = flag;

            // Form grooter maken, en vervolgens image resizen om te zorgen dat het vanuit het midden gebeurt!
            int xSize = Convert.ToInt32(Math.Round((Convert.ToDouble(value) / 4) + 90));
            xIcon.Size = new Size(xSize, xSize);
            xIcon.Location = new Point(Convert.ToInt32(Math.Round(Convert.ToDouble(Width - xSize) / 2)), Convert.ToInt32(Math.Round(Convert.ToDouble(Height - xSize) / 2)));
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

        private void SetImage(IconType type, bool isMute)
        {
            switch (type)
            {
                case IconType.Brightness:
                    xIcon.Image = Resources.brightness;
                    break;
                case IconType.Sound:
                    if (isMute)
                    {
                        xIcon.Image = Resources.sound_mute;
                    }
                    else
                    {
                        xIcon.Image = Resources.sound;
                    }
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

            switch (flag)
            {
                case IconFlag.Increased:
                    waiter.RunWorkerAsync("enlarge");
                    break;
                case IconFlag.Decreased:
                    waiter.RunWorkerAsync("shrink");
                    break;
                case IconFlag.Muted:
                case IconFlag.Unmuted:
                    waiter.RunWorkerAsync("");
                    break;
            }
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
            string arg = e.Argument.ToString();

            switch (arg)
            {
                case "":
                    for (int i = 0; i < 10; i++)
                    {
                        Thread.Sleep(20);
                        this.InvokeEx(o => o.Opacity -= 0.04);
                    }
                    break;
                case "shrink":
                    for (int i = 0; i < 10; i++)
                    {
                        Thread.Sleep(20);

                        this.InvokeEx(g => g.ChangeImageSize(0.99d));
                        this.InvokeEx(o => o.Opacity -= 0.04);
                    }
                    break;
                case "enlarge":
                    for (int i = 0; i < 10; i++)
                    {
                        Thread.Sleep(20);

                        this.InvokeEx(g => g.ChangeImageSize(1.01d));
                        this.InvokeEx(o => o.Opacity -= 0.04);
                    }
                    break;
            }
        }

        private void waiter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FadeOut(this, 10);
            this.Hide();
            Close();
        }

        private void ChangeImageSize(double relative)
        {
            xIcon.Size = new Size(end(Convert.ToDouble(xIcon.Width) * relative), end(Convert.ToDouble(xIcon.Height) * relative));
            xIcon.Location = new Point(Convert.ToInt32(Math.Round(Convert.ToDouble(Width - xIcon.Width) / 2)), Convert.ToInt32(Math.Round(Convert.ToDouble(Height - xIcon.Width) / 2)));

            int end(double conv)
            {
                return Convert.ToInt32(Math.Round(conv));
            }
        }
    }
}
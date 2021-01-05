using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PWS_Shell
{
    public partial class Knop : UserControl
    {
        internal delegate void AppAboutToStartHandler(AppLink appLink);
        internal event AppAboutToStartHandler AppAboutToStart;

        internal delegate void AppStartEventHandler(AppLink appLink);
        internal event AppStartEventHandler AppStart;

        internal AppLink appLink { get; private set; }

        public Knop()
        {
            InitializeComponent();

            bestandsNaam.Parent = this;
            pictogram.Parent = this;

            this.Cursor = Cursors.Hand;
            this.MouseDown += Knop_MouseDown;
            bestandsNaam.MouseDown += Knop_MouseDown;
            pictogram.MouseDown += Knop_MouseDown;

            bestandsNaam.Parent = wrap;
            wrap.Parent = this;

            foreach (ToolStripItem item in appStrip.Items)
            {
                item.BackColor = Color.Black;
                item.ForeColor = Color.White;
            }
        }

        private void Knop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                AppStartEventHandler handler = AppStart;
                handler.Invoke(appLink);
            }
            else if (e.Button == MouseButtons.Right)
            {
                appStrip.Show(Cursor.Position);
            }
        }

        private void Knop_Click(object sender, EventArgs e)
        {
            AppStartEventHandler handler = AppStart;
            handler.Invoke(appLink);
        }

        internal void KnopMaken(AppLink appLink)
        {
            this.appLink = appLink;

            switch (appLink.linkType)
            {
                case LinkType.Advertised:
                    break;
                case LinkType.UWP:
                    break;
                case LinkType.Normal:
                    bestandsNaam.Text = Path.GetFileNameWithoutExtension(appLink.linkData);
                    if (File.Exists(appLink.linkData))
                    {
                        pictogram.Image = ExtractImages.ExtractFromFile(appLink.linkData);
                    }
                    else if (Directory.Exists(appLink.linkData))
                    {
                        pictogram.Image = ExtractImages.ExtractFromFolder(appLink.linkData);
                    }
                    break;
            }
        }

        private void Knop_MouseEnter(object sender, EventArgs e)
        {
            AppAboutToStartHandler handler = AppAboutToStart;
            handler.Invoke(appLink);
        }

        private void locatieOpzoekenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Path.GetExtension(appLink.linkData) == ".lnk")
            {
                ShortcutLocationHandler.OpenShortcutLocation(appLink.linkData);
            }
            else
            {
                ShortcutLocationHandler.SelectFile(appLink.linkData);
            }
        }

        private void alternatiefStartenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelativeAppStarter.StartRelativeApp("PWS-Shell.exe", $"\"-AltStart:{appLink.linkData}\"");
        }
    }
}
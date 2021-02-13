using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace PWS_Shell
{
    public partial class Knop : UserControl
    {
        internal delegate void AppAboutToStartHandler(AppLink appLink);
        internal event AppAboutToStartHandler AppAboutToStart;

        internal delegate void AppStartEventHandler(AppLink appLink);
        internal event AppStartEventHandler AppStart;

        private string publicApps = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu) + "\\Programs";
        private string publicDesktop = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);

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
                if (Directory.Exists(appLink.linkData))
                {
                    alternatiefStartenToolStripMenuItem.Visible = false;
                }
                else
                {
                    alternatiefStartenToolStripMenuItem.Visible = true;
                }

                string ext = Path.GetExtension(appLink.linkData);
                if (ch(ext, ".lnk") || ch(ext, ".appref-ms") || ch(ext, ".url"))
                {
                    linkVerwijderenToolStripMenuItem.Visible = true;
                }
                else
                {
                    linkVerwijderenToolStripMenuItem.Visible = false;
                }

                bool ch(string f, string c)
                {
                    return f == c;
                }

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
            RelativeAppStarter.StartRelativeApp("PWS-Shell.exe", $"\"-AltStart:{appLink.linkData}\"", false);
        }

        private void startenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppStartEventHandler handler = AppStart;
            handler.Invoke(appLink);
        }

        private void verwijderenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(appLink.linkData);

            if (ch(ext, ".lnk") || ch(ext, ".appref-ms") || ch(ext, ".url"))
            {
                ProcessStartInfo psi = new ProcessStartInfo()
                {
                    FileName = "control.exe",
                    Arguments = "appwiz.cpl"
                };

                Process.Start(psi);
            }
            else
            {
                if (MessageBox.Show($"Weet je ZEKER dat je \"{Path.GetFileName(appLink.linkData)}\" wilt verwijderen? Het wordt NIET eerst naar de prullenbak verplaatst.", "Zeker weten?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (Directory.Exists(appLink.linkData))
                    {
                        if (appLink.linkData.StartsWith(publicDesktop) || appLink.linkData.StartsWith(publicApps))
                        {
                            if (RelativeAppStarter.StartRelativeApp("PWS-Shell.exe", $"\"-Delete\" \"{appLink.linkData}\"", true))
                            {
                                Parent.Controls.Remove(this);
                            }
                        }
                        else
                        {
                            try
                            {
                                Directory.Delete(appLink.linkData, true);
                                Parent.Controls.Remove(this);
                            }
                            catch
                            {
                                MessageBox.Show("Kan de map niet verwijderen: Waarschijnlijk is de map in gebruik.", "Kan map niet verwijderen.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else if (File.Exists(appLink.linkData))
                    {
                        if (appLink.linkData.StartsWith(publicDesktop) || appLink.linkData.StartsWith(publicApps))
                        {
                            if (RelativeAppStarter.StartRelativeApp("PWS-Shell.exe", $"\"-Delete\" \"{appLink.linkData}\"", true))
                            {
                                Parent.Controls.Remove(this);
                            }
                        }
                        else
                        {
                            try
                            {
                                File.Delete(appLink.linkData);
                                Parent.Controls.Remove(this);
                            }
                            catch
                            {
                                MessageBox.Show("Kan het bestand niet verwijderen: Waarschijnlijk is het in gebruik.", "Kan bestand niet verwijderen.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        Parent.Controls.Remove(this);
                    }
                }
            }

            bool ch(string f, string c)
            {
                return f == c;
            }
        }

        private void naamWijzigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox($"Voer de nieuwe naam in voor \"{Path.GetFileName(appLink.linkData)}\"", "Voer de nieuwe naam in.", Path.GetFileName(appLink.linkData));

            if (!string.IsNullOrWhiteSpace(input) && input != Path.GetFileName(appLink.linkData))
            {
                if (!Directory.Exists(Path.GetDirectoryName(appLink.linkData) + "\\" + input) && !File.Exists(Path.GetDirectoryName(appLink.linkData) + "\\" + input))
                {
                    if (Directory.Exists(appLink.linkData))
                    {
                        if (appLink.linkData.StartsWith(publicDesktop) || appLink.linkData.StartsWith(publicApps))
                        {
                            if (RelativeAppStarter.StartRelativeApp("PWS-Shell.exe", $"\"-ChangeName\" \"{appLink.linkData}\" \"{Path.GetDirectoryName(appLink.linkData) + "\\" + input}\"", true))
                            {
                                appLink.SetLinkData(Path.GetDirectoryName(appLink.linkData) + "\\" + input);
                                bestandsNaam.Text = Path.GetFileNameWithoutExtension(appLink.linkData);
                            }
                        }
                        else
                        {
                            try
                            {
                                Directory.Move(appLink.linkData, Path.GetDirectoryName(appLink.linkData) + "\\" + input);

                                appLink.SetLinkData(Path.GetDirectoryName(appLink.linkData) + "\\" + input);
                                bestandsNaam.Text = Path.GetFileNameWithoutExtension(appLink.linkData);
                            }
                            catch
                            {
                                MessageBox.Show("Kan de naam niet aanpassen: De naam bevat ongeldige karakters, of de map is in gebruik.", "Kan de naam niet aanpassen.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else if (File.Exists(appLink.linkData))
                    {
                        if (appLink.linkData.StartsWith(publicDesktop) || appLink.linkData.StartsWith(publicApps))
                        {
                            if (RelativeAppStarter.StartRelativeApp("PWS-Shell.exe", $"\"-ChangeName\" \"{appLink.linkData}\" \"{Path.GetDirectoryName(appLink.linkData) + "\\" + input}\"", true))
                            {
                                appLink.SetLinkData(Path.GetDirectoryName(appLink.linkData) + "\\" + input);
                                bestandsNaam.Text = Path.GetFileNameWithoutExtension(appLink.linkData);
                            }
                        }
                        else
                        {
                            try
                            {
                                File.Move(appLink.linkData, Path.GetDirectoryName(appLink.linkData) + "\\" + input);

                                appLink.SetLinkData(Path.GetDirectoryName(appLink.linkData) + "\\" + input);
                                bestandsNaam.Text = Path.GetFileNameWithoutExtension(appLink.linkData);
                            }
                            catch
                            {
                                MessageBox.Show("Kan de naam niet aanpassen: De naam bevat ongeldige karakters, of het bestand is in gebruik.", "Kan de naam niet aanpassen.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kan de naam niet aanpassen: het bestand (of map) is niet gevonden.", "Kan de naam niet aanpassen.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Kan de naam niet aanpassen: Er bestaat al een bestand of map met dezelfde naam.", "Kan de naam niet aanpassen.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void linkVerwijderenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(appLink.linkData))
            {
                if (MessageBox.Show($"Weet je zeker dat je koppeling naar \"{Path.GetFileNameWithoutExtension(appLink.linkData)}\" wilt verwijderen? Het wordt permanent verwijderd, maar de app waar het naar verwijst niet.", "Zeker weten?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (appLink.linkData.StartsWith(publicDesktop) || appLink.linkData.StartsWith(publicApps))
                    {
                        if (RelativeAppStarter.StartRelativeApp("PWS-Shell.exe", $"\"-Delete\" \"{appLink.linkData}\"", true))
                        {
                            Parent.Controls.Remove(this);
                        }
                    }
                    else
                    {
                        try
                        {
                            File.Delete(appLink.linkData);
                            Parent.Controls.Remove(this);
                        }
                        catch
                        {
                            MessageBox.Show("Kan de koppeling niet verwijderen: Mogelijk is het in gebruik.", "Kan koppeling niet verwijderen.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                Parent.Controls.Remove(this);
            }
        }
    }
}
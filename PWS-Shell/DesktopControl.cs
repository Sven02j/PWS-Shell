using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace PWS_Shell
{
    public partial class DesktopControl : UserControl
    {
        internal delegate void ModeSwitchEventHandler(FolderCollection collection);
        internal event ModeSwitchEventHandler ModeSwitch;
        private CustomFLP Icons = new CustomFLP();
        private ShellBrowserLocation shellBrowserLocation = ShellBrowserLocation.Desktop;
        private bool isStartMenuRoot = false;
        private bool tempStorage;

        private InfoPanelHelper infoPanelHelper;
        
        public DesktopControl()
        {
            InitializeComponent();

            Icons.BackColor = Color.Transparent;
            Icons.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Icons.Location = new Point(252, 70);
            Icons.Size = new Size(520, 358);
            Icons.AutoScroll = true;
            Icons.BringToFront();
            Icons.FlowDirection = FlowDirection.TopDown;
            Icons.Parent = this;
            transInfoPanel.Parent = this;
            infoLabel.Parent = transInfoPanel;
            transInfoPanel.BackColor = Color.FromArgb(130, Color.Black);
            infoLabel.BackColor = Color.FromArgb(0, Color.Black);

            UpPanel.Parent = this;
            UpPanel.BackColor = Color.FromArgb(150, Color.Black);

            infoPanelHelper = new InfoPanelHelper();
        }

        internal List<Knop> GetButtons(FolderCollection collection)
        {
            tempStorage = collection.isStartMenuRoot;
            List<string> linkPaths = new List<string>();

            foreach (string directoryToEnumerate in collection.directories)
            {
                foreach (string file in Directory.GetFiles(directoryToEnumerate))
                {
                    if (!File.GetAttributes(file).HasFlag(FileAttributes.Hidden))
                        linkPaths.Add(file);
                }

                foreach (string folder in Directory.GetDirectories(directoryToEnumerate))
                {
                    if (!File.GetAttributes(folder).HasFlag(FileAttributes.Hidden))
                        linkPaths.Add(folder);
                }
            }

            List<Knop> knoppen = new List<Knop>();

            foreach (string path in linkPaths)
            {
                Knop knop = new Knop();
                knop.KnopMaken(AppLink.GetLinkObject(path));
                knoppen.Add(knop);
            }

            return knoppen;
        }

        internal void RecvMsg(string msg)
        {
            switch (msg)
            {
                case "volup":
                    UpPanel.Volume.IncreaseVolume();
                    break;
                case "voldown":
                    UpPanel.Volume.DecreaseVolume();
                    break;
                case "volmute":
                    UpPanel.Volume.Mute();
                    break;
            }
        }

        internal void Maak(List<Knop> knoppen)
        {
            Icons.SuspendLayout();
            Icons.Controls.Clear();
            
            foreach (Knop knop in knoppen)
            {
                knop.Margin = new Padding(20);
                knop.AppAboutToStart += Knop_AppAboutToStart;
                knop.AppStart += Knop_AppStart;
                Icons.Controls.Add(knop);
            }

            Icons.ResumeLayout();
            isStartMenuRoot = tempStorage;
        }

        private void Knop_AppStart(AppLink appLink)
        {
            // kijken of dit een submap van het startmenu is. Zo ja, deze openen. Zo nee, deze starten met een EXTERNE methode!
            if (isStartMenuRoot && appLink.linkType == LinkType.Normal && Directory.Exists(appLink.linkData))
            {
                allAppsButton.Appmenu();
                Invoker(FolderCollection.StartMenuSubMap(appLink.linkData));
                shellBrowserLocation = ShellBrowserLocation.StartMenuSubFolder;
            }
            else
            {
                ProcessStarter.Start(appLink);
            }
        }

        private void Knop_AppAboutToStart(AppLink appLink)
        {
            string ext = Path.GetExtension(appLink.linkData);
            string endLocation = "";
            string darwinDataBlock = "";

            if (ext != ".lnk")
            {
                endLocation = appLink.linkData;
            }
            else
            {
                int index = 0;
                foreach (string tmData in ShortcutLocationHandler.GetShortcutLocation(appLink.linkData))
                {
                    if (index == 0)
                    {
                        if (tmData.StartsWith("ERR:"))
                        {
                            endLocation = appLink.linkData;
                        }
                        else if (tmData.StartsWith("NOR:") || tmData.StartsWith("ADV:"))
                        {
                            endLocation = tmData.Substring(4);
                        }
                    }
                    else
                    {
                        darwinDataBlock = tmData;
                    }

                    index++;
                }
            }

            string link;
            string type;

            if (ext == ".lnk")
            {
                link = Path.GetFileNameWithoutExtension(appLink.linkData);
                type = FileDescriptions.GetFileTypeDescription(endLocation);
            }
            else if (Directory.Exists(endLocation))
            {
                link = Path.GetFileName(appLink.linkData);
                type = "Bestandsmap";
            }
            else
            {
                link = Path.GetFileName(appLink.linkData);
                type = FileDescriptions.GetFileTypeDescription(endLocation);
            }

            infoPanelHelper.Clear();
            infoPanelHelper.AddInformation("Naam", link);
            infoPanelHelper.AddInformation("Type", type);

            if (type != "Bestandsmap")
            {
                string AssemblyTitle = FileVersionInfo.GetVersionInfo(endLocation).FileDescription;

                if (!string.IsNullOrWhiteSpace(AssemblyTitle))
                {
                    infoPanelHelper.AddInformation("Titel", AssemblyTitle);
                }
            }

            infoLabel.Text = infoPanelHelper.Get();
        }

        private void BestandKnop_Click(object sender, EventArgs e)
        {
            MessageBox.Show(((Button)sender).Text + " wordt geopend...");
        }

        private void transInfoPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Transparent, 0, 0, 100, 100);
        }

        private void naamLabel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Transparent, 0, 0, 100, 100);
        }

        private void allAppsButton_Click(object sender, EventArgs e)
        {
            switch (shellBrowserLocation)
            {
                // shellBrowserLocation is de locatie die nog veranderd wordt! Dus als deze nu nog 'Desktop' is, wordt die straks 'StartMenu'.
                case ShellBrowserLocation.Desktop:
                    shellBrowserLocation = ShellBrowserLocation.StartMenu;
                    allAppsButton.Startscherm();
                    Invoker(FolderCollection.StartMenuView());
                    break;
                case ShellBrowserLocation.StartMenu:
                    shellBrowserLocation = ShellBrowserLocation.Desktop;
                    allAppsButton.Appmenu();
                    Invoker(FolderCollection.DesktopView());
                    break;
                case ShellBrowserLocation.StartMenuSubFolder:
                    shellBrowserLocation = ShellBrowserLocation.StartMenu;
                    allAppsButton.Startscherm();
                    Invoker(FolderCollection.StartMenuView());
                    break;
            }
        }

        private void Invoker(FolderCollection folcollection)
        {
            ModeSwitchEventHandler handler = ModeSwitch;
            handler.Invoke(folcollection);
        }

        private enum ShellBrowserLocation
        {
            Desktop,
            StartMenu,
            StartMenuSubFolder
        }

        private void UpPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Transparent, 0, 0, 100, 100);
        }
    }

    internal static class TextExtensions
    {
        internal static void Startscherm(this Button bron)
        {
            bron.Text = "Startscherm weergeven";
        }

        internal static void Appmenu(this Button bron)
        {
            bron.Text = "Alle apps weergeven";
        }
    }

    internal class InfoPanelHelper
    {
        private string infoString = "";

        internal void AddInformation(string category, string data)
        {
            infoString += $"{category}: {data}\r\n";
        }

        internal void Clear()
        {
            infoString = "";
        }

        internal string Get()
        {
            return infoString;
        }
    }
}
using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using static PWS_Shell.ExtractImages;
using System.Linq;

namespace PWS_Shell
{
    public partial class SearchControl : Form, ISynchronizeInvoke
    {
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

        private string userProfile = Environment.GetEnvironmentVariable("userprofile");

        private bool isRequest = false;
        private string requestString;

        private ImageList imgList = new ImageList();

        public SearchControl()
        {
            InitializeComponent();
        }

        public SearchControl(int MonitorNumber)
        {
            InitializeComponent();

            MonitorMethods.DisplayFullAtMonitor(MonitorNumber, this);

            searchBox.inputBox.TextChanged += InputBox_TextChanged;

            items.Columns[1].Width = items.Width - items.Columns[0].Width - 40;

            imgList.ImageSize = new Size(64, 64);
            imgList.ColorDepth = ColorDepth.Depth32Bit;
            items.SmallImageList = imgList;
        }

        private void InputBox_TextChanged(object sender, EventArgs e)
        {
            string text = searchBox.inputBox.Text;

            if (!string.IsNullOrWhiteSpace(text))
            {
                UpdateSearchFunction(text);
            }
            else
            {
                searchFunction.CancelAsync();
                imgList.Images.Clear();
                items.Items.Clear();
            }
        }

        private void resultPanel_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Transparent, 0, 0, 100, 100);
        }

        private void UpdateSearchFunction(string newText)
        {
            if (searchFunction.IsBusy)
            {
                PullRequest(newText);
                searchFunction.CancelAsync();
            }
            else
            {
                items.Items.Clear();
                imgList.Images.Clear();
                searchFunction.RunWorkerAsync(newText);
            }
        }

        private void PullRequest(string newText)
        {
            isRequest = true;
            requestString = newText;
        }

        private void searchFunction_DoWork(object sender, DoWorkEventArgs e)
        {
            string searchWord = e.Argument.ToString();

            List<string[]> found = new List<string[]>();

            List<string> directories = Directory.GetDirectories(userProfile).ToList();
            directories.Add(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu));
            directories.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu));
            directories.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory));

            foreach (string dir in directories)
            {
                if (dir.EndsWith("AppData"))
                    continue;

                if (!Path.GetFileName(dir).StartsWith("."))
                {
                    DirectoryInfo di = new DirectoryInfo(dir);

                    if (!di.Attributes.HasFlag(FileAttributes.Hidden))
                    {
                        if (!ProcessFolder(dir))
                            break;
                        if (!DirReport())
                            break;
                    }
                }
            }

            bool DirReport()
            {
                if (searchFunction.CancellationPending)
                    return false;

                this.InvokeEx(g => g.listUpdate(found));
                found.Clear();

                return true;
            }

            bool ProcessFolder(string folder)
            {
                foreach (string fil in GetFiles(folder, "*"))
                {
                    if (searchFunction.CancellationPending)
                        return false;

                    if (!File.GetAttributes(fil).HasFlag(FileAttributes.Hidden))
                    {
                        if (Path.GetFileName(fil).ToLower().Contains(searchWord.ToLower()))
                            found.Add(new string[] { fil, "File" });
                    }
                }

                foreach (string dir in GetFolders(folder, "*"))
                {
                    if (Path.GetFileName(dir).ToLower().Contains(searchWord.ToLower()))
                        found.Add(new string[] { dir, "Directory" });
                }

                return true;
            }
        }

        private void listUpdate(List<string[]> _out)
        {
            items.BeginUpdate();

            int index;
            foreach (string[] result in _out)
            {
                ListViewItem temp = new ListViewItem()
                {
                    Text = Path.GetFileName(result[0])
                };

                temp.SubItems.Add(result[0]);
                temp.Tag = result[1];

                index = items.Items.Count;

                if (result[1] == "File")
                {
                    imgList.Images.Add(ExtractFromFile(result[0]));
                }
                else
                {
                    imgList.Images.Add(ExtractFromFolder(result[0]));
                }

                temp.ImageIndex = index;

                items.Items.Add(temp);
            }

            items.EndUpdate();
        }

        private void searchFunction_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (isRequest)
            {
                items.Items.Clear();
                imgList.Images.Clear();
                searchFunction.RunWorkerAsync(requestString);
                isRequest = false;
            }
        }

        public static IEnumerable<string> GetFiles(string root, string searchPattern)
        {
            Stack<string> pending = new Stack<string>();
            pending.Push(root);
            while (pending.Count != 0)
            {
                var path = pending.Pop();
                string[] next = null;
                try
                {
                    next = Directory.GetFiles(path, searchPattern);
                }
                catch { }
                if (next != null && next.Length != 0)
                    foreach (var file in next) yield return file;
                try
                {
                    next = Directory.GetDirectories(path);
                    foreach (var subdir in next) pending.Push(subdir);
                }
                catch { }
            }
        }

        public static IEnumerable<string> GetFolders(string root, string searchPattern)
        {
            Stack<string> pending = new Stack<string>();
            pending.Push(root);
            while (pending.Count != 0)
            {
                var path = pending.Pop();
                string[] next = null;
                try
                {
                    next = Directory.GetDirectories(path, searchPattern);
                }
                catch { }
                if (next != null && next.Length != 0)
                    foreach (var file in next) yield return file;
                try
                {
                    next = Directory.GetDirectories(path);
                    foreach (var subdir in next) pending.Push(subdir);
                }
                catch { }
            }
        }

        private void SearchControl_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SearchControl_Leave(object sender, EventArgs e)
        {
            Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exitButton_MouseEnter(object sender, EventArgs e)
        {
            exitButton.ForeColor = Color.White;
        }

        private void exitButton_MouseLeave(object sender, EventArgs e)
        {
            exitButton.ForeColor = Color.WhiteSmoke;
        }

        private void exitButton_MouseDown(object sender, MouseEventArgs e)
        {
            exitButton.ForeColor = Color.OrangeRed;
        }

        private void SearchControl_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void items_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = GetItemFromPoint(Cursor.Position);

            if (item != null)
            {
                ProcessStarter.Start(new AppLink(LinkType.Normal, item.SubItems[1].Text));
            }
        }

        private ListViewItem GetItemFromPoint(Point mousePosition)
        {
            // translate the mouse position from screen coordinates to 
            // client coordinates within the given ListView
            Point localPoint = items.PointToClient(mousePosition);
            return items.GetItemAt(localPoint.X, localPoint.Y);
        }

        private void openenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (items.SelectedItems.Count > 0)
            {
                ProcessStarter.Start(new AppLink(LinkType.Normal, items.SelectedItems[0].SubItems[1].Text));
            }
        }

        private void bestandslocatieOpenenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (items.SelectedItems.Count > 0)
            {
                ShortcutLocationHandler.SelectFile(items.SelectedItems[0].SubItems[1].Text);
            }
        }

        private void alternatiefStartenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (items.SelectedItems.Count > 0)
            {
                switch (items.SelectedItems[0].Tag.ToString())
                {
                    case "File":
                        RelativeAppStarter.StartRelativeApp("PWS-Shell.exe", $"\"-AltStart:{items.SelectedItems[0].SubItems[1].Text}\"", false);
                        break;
                }
            }
        }

        private void resultStrip_Opening(object sender, CancelEventArgs e)
        {
            if (items.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }
            else
            {
                if (items.SelectedItems[0].Tag.ToString() == "Directory")
                {
                    alternatiefStartenToolStripMenuItem.Visible = false;
                    toolStripMenuItem1.Visible = false;
                }
                else
                {
                    alternatiefStartenToolStripMenuItem.Visible = true;
                    toolStripMenuItem1.Visible = true;
                }
            }
        }
    }

    public static class ISynchronizeInvokeExtensions
    {
        public static void InvokeEx<T>(this T @this, Action<T> action) where T : ISynchronizeInvoke
        {
            if (@this.InvokeRequired)
            {
                try
                {
                    @this.Invoke(action, new object[] { @this });
                }
                catch
                {

                }
            }
            else
            {
                try
                {
                    action(@this);
                }
                catch
                {

                }
            }
        }
    }
}
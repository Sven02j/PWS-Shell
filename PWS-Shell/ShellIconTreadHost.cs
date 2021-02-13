using System.ComponentModel;
using static PWS_Shell.ShellIconPainter;

namespace PWS_Shell
{
    internal class ShellIconTreadHost
    {
        private readonly BackgroundWorker bw;
        ShellIconPainter painter;

        private readonly IconType iconType;
        private readonly int value;
        private readonly IconFlag flag;

        internal ShellIconTreadHost(IconType iconType, int value, IconFlag flag)
        {
            bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;

            this.value = value;
            this.iconType = iconType;
            this.flag = flag;

            bw.RunWorkerAsync();
        }

        internal static ShellIconTreadHost Run(IconType iconType, int value, IconFlag flag)
        {
            return new ShellIconTreadHost(iconType, value, flag);
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bw.Dispose();
            painter.Dispose();
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            painter = new ShellIconPainter(iconType, value, flag);
            painter.ShowDialog();
        }

        internal enum IconFlag
        {
            Increased = 0,
            Decreased = 1,
            Muted = 2,
            Unmuted = 3
        }
    }
}
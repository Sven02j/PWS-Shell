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

        internal ShellIconTreadHost(IconType iconType, int value)
        {
            bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;

            this.value = value;
            this.iconType = iconType;

            bw.RunWorkerAsync();
        }

        internal static ShellIconTreadHost Run(IconType iconType, int value)
        {
            return new ShellIconTreadHost(iconType, value);
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bw.Dispose();
            painter.Dispose();
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            painter = new ShellIconPainter(iconType, value);
            painter.ShowDialog();
        }
    }
}
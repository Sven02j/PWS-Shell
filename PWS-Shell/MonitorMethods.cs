using System.Drawing;
using System.Windows.Forms;

namespace PWS_Shell
{
    internal static class MonitorMethods
    {
        internal static void DisplayFullAtMonitor(int index, Form form)
        {
            form.Location = new Point(Screen.AllScreens[index].Bounds.Left, Screen.AllScreens[index].Bounds.Top);
            form.Size = Screen.AllScreens[index].Bounds.Size;

            form.WindowState = FormWindowState.Maximized;
        }

        internal static Point GetLeftCornerOfScreenNumber(int screenNumber)
        {
            return new Point
            {
                X = Screen.AllScreens[screenNumber].Bounds.Left,
                Y = Screen.AllScreens[screenNumber].Bounds.Top
            };
        }

        internal static Point PointCumulate(Point a, Point b)
        {
            return new Point
            {
                X = a.X + b.X,
                Y = a.Y + b.Y
            };
        }

    }
}
using System.Windows.Forms;

namespace PWS_Shell
{
    internal class CustomFLP : FlowLayoutPanel
    {
        internal CustomFLP() : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.DoubleBuffered = true;
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            this.Invalidate();
            base.OnScroll(se);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            this.Invalidate();
            base.OnMouseWheel(e);
        }
    }
}
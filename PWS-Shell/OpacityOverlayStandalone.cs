using System;
using System.Drawing;
using System.Windows.Forms;

namespace PWS_Shell
{
    public partial class OpacityOverlayStandalone : Form
    {
        private bool isProjectionSet = false;
        private Form redir;

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

        public OpacityOverlayStandalone()
        {
            InitializeComponent();
        }

        internal void FormProjection(Form Project)
        {
            SetProjection(Project);
        }

        internal void FormProjection(Form Project, int Opacity)
        {
            this.Opacity = Convert.ToDouble(Opacity);
            SetProjection(Project);
        }

        internal void FormProjection(Form Project, int Opacity, Color BackColor)
        {
            this.Opacity = Convert.ToDouble(Opacity);
            this.BackColor = BackColor;
            SetProjection(Project);
        }

        internal void FormProjection(Form Project, Color BackColor)
        {
            this.BackColor = BackColor;
            SetProjection(Project);
        }

        private void OpacityOverlayStandalone_Load(object sender, EventArgs e)
        {
            if (isProjectionSet)
            {
                redir.ShowDialog();
                Close();
            }
        }

        internal void SetProjection(Form redir)
        {
            isProjectionSet = true;
            this.redir = redir;
            this.ShowDialog();
        }
    }
}
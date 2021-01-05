using PWS_Shell.Properties;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace PWS_Shell
{
    public partial class Background : UserControl
    {
        private List<Knop> knoppen = new List<Knop>();

        public Background()
        {
            InitializeComponent();

            achtergrond.Parent = this;
            DesktopControl.Parent = achtergrond;
        }

        internal void SetBackground()
        {
            achtergrond.Image = ResizeImage.resizeImage(Size.Width, Size.Height, Resources.background);
        }

        internal void GetButtons(FolderCollection collection)
        {
            knoppen = DesktopControl.GetButtons(collection);
        }

        internal void KnoppenMaken()
        {
            DesktopControl.Maak(knoppen);
        }
    }
}
using PWS_Shell.Properties;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using SettingsReaderWriter;
using System.IO;

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
            string path = null;

            RegistryInstellingen ri = new RegistryInstellingen(true);
            if (ri.BekijkOfInstellingBestaat("achtergrondAfbeelding"))
                path = ri.InstellingOphalen("achtergrondAfbeelding");

            bool useFile = false;

            if (File.Exists(path))
            {
                if (CheckImageFile.IsValidImageFile(path))
                {
                    useFile = true;
                }
            }

            if (useFile)
            {
                try
                {
                    FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);

                    achtergrond.Image = ResizeImage.resizeImage(Size.Width, Size.Height, Image.FromStream(stream));

                    stream.Close();
                    stream.Dispose();
                }
                catch
                {
                    achtergrond.Image = ResizeImage.resizeImage(Size.Width, Size.Height, Resources.background);
                }
            }
            else
            {
                achtergrond.Image = ResizeImage.resizeImage(Size.Width, Size.Height, Resources.background);
            }
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
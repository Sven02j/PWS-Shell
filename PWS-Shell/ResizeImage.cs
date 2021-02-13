using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace PWS_Shell
{
    internal static class ResizeImage
    {
        internal static Image resizeImage(int newWidth, int newHeight, Image imgSrc)
        {
            Image imgPhoto = imgSrc;

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;

            //Consider vertical pics
            if (sourceWidth < sourceHeight)
            {
                int buff = newWidth;

                newWidth = newHeight;
                newHeight = buff;
            }

            int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
            float nPercent = 0, nPercentW = 0, nPercentH = 0;

            nPercentW = ((float)newWidth / (float)sourceWidth);
            nPercentH = ((float)newHeight / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((newWidth -
                          (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((newHeight -
                          (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);


            Bitmap bmPhoto = new Bitmap(newWidth, newHeight,
                          PixelFormat.Format24bppRgb);

            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                         imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Black);
            grPhoto.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            imgPhoto.Dispose();
            return bmPhoto;
        }

        internal static Image CreateThumbnail(Image i, int dMaxSize)
        {
            int dWidth = i.Width;
            int dHeight = i.Height;

            if (dWidth > dMaxSize)
            {
                dHeight = (dHeight * dMaxSize) / dWidth;
                dWidth = dMaxSize;
            }
            if (dHeight > dMaxSize)
            {
                dWidth = (dWidth * dMaxSize) / dHeight;
                dHeight = dMaxSize;
            }
            return i.GetThumbnailImage(dWidth, dHeight, delegate () { return false; }, IntPtr.Zero);
        }
    }
}
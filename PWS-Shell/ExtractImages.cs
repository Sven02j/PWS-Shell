using System.Drawing;
using System;
using System.IO;
using System.Runtime.InteropServices;
using PWS_Shell.Properties;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Security.Cryptography;

namespace PWS_Shell
{
    internal static class ExtractImages
    {
        // methodes toevoegen voor het krijgen van thumbnails voor Video's, Foto's en Nintendo DS ROMS.
        internal static Image ExtractFromFile(string filePath)
        {
            string ext = Path.GetExtension(filePath);

            string[] photos = { ".jpg", ".jpeg", ".jfif", ".png", ".gif", ".bmp", ".tiff" };
            string[] videos = { ".mp4", ".webm", ".avi", ".flv" };

            if (photos.Contains(ext))
            {
                try
                {
                    return new Bitmap(filePath);
                }
                catch
                {
                    return Icon.ExtractAssociatedIcon(filePath).ToBitmap();
                }
            }
            else if (videos.Contains(ext))
            {
                try
                {
                    string tempPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\temp\\PWS-ShellThumbnails";
                    string hash = BitConverter.ToString(getFileHash(filePath)).Replace("-", "").ToLower();

                    if (!Directory.Exists(tempPath))
                        Directory.CreateDirectory(tempPath);

                    if (!File.Exists($"{tempPath}\\{hash}.bmp"))
                        ProduceThumbnail(filePath, $"{tempPath}\\{hash}.bmp");

                    return new Bitmap($"{tempPath}\\{hash}.bmp");
                }
                catch
                {
                    return Icon.ExtractAssociatedIcon(filePath).ToBitmap();
                }
            }
            else
            {
                return Icon.ExtractAssociatedIcon(filePath).ToBitmap();
            }
        }

        internal static void ClearCacheInstant()
        {
            string tempPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\temp\\PWS-ShellThumbnails";

            if (Directory.Exists(tempPath))
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = $"/C title CLEARING PWS-SHELL CACHE & rd /S /Q \"{tempPath}\"";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                process.Start();
            }
        }

        internal static Image ExtractFromFolder(string folderPath)
        {
            List<string> files = Directory.GetFiles(folderPath).ToList();

            string[] forbidden = new string[] { "desktop.ini", "thumbs.db" };

            for (int i = 0; i < forbidden.Length; i++)
            {
                string p = forbidden[i];

                int index = files.FindIndex(x => x.Equals($"{folderPath}\\{p}", StringComparison.OrdinalIgnoreCase));

                if (index != -1)
                {
                    files.RemoveAt(index);
                }
                else
                {
                    i++;
                }
            }
            
            Image dirImg = DefaultDirImage(folderPath);

            if (files.Count > 0)
            {
                Image overlayImg = Icon.ExtractAssociatedIcon(files[0]).ToBitmap();
                overlayImg = ResizeImage.CreateThumbnail(overlayImg, Convert.ToInt32(Math.Round(Convert.ToDouble(dirImg.Width) / 1.5d)));

                Graphics g = Graphics.FromImage(dirImg);
                g.DrawImage(overlayImg, new Point(dirImg.Width / 4, dirImg.Height / 4));

                return dirImg;
            }
            else
            {
                return dirImg;
            }

            Image DefaultDirImage(string path)
            {
                Icon icon = DefaultIcons.ExtractFromPath(path);
                if (icon == null)
                    return Resources._102;
                return icon.ToBitmap();
            }
        }

        internal static void ProduceThumbnail(string video, string thumbnail)
        {
            var cmd = $"ffmpeg  -itsoffset -1  -i \"{video}\" -vcodec mjpeg -vframes 1 -an -f rawvideo -s 128x128 \"{thumbnail}\"";

            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = "/C " + cmd
            };

            var process = new Process
            {
                StartInfo = startInfo
            };

            process.Start();
            process.WaitForExit(5000);
        }

        internal static byte[] getFileHash(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return md5.ComputeHash(stream);
                }
            }
        }


        private class DefaultIcons
        {
            private static readonly Lazy<Icon> _lazyFolderIcon = new Lazy<Icon>(FetchIcon, true);

            public static Icon FolderLarge
            {
                get { return _lazyFolderIcon.Value; }
            }

            private static Icon FetchIcon()
            {
                var tmpDir = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString())).FullName;
                var icon = ExtractFromPath(tmpDir);
                Directory.Delete(tmpDir);
                return icon;
            }

            public static Icon ExtractFromPath(string path)
            {
                SHFILEINFO shinfo = new SHFILEINFO();
                SHGetFileInfo(
                    path,
                    0, ref shinfo, (uint)Marshal.SizeOf(shinfo),
                    SHGFI_ICON | SHGFI_LARGEICON);
                try
                {
                    return Icon.FromHandle(shinfo.hIcon);
                }
                catch
                {
                    return null;
                }
            }

            //Struct used by SHGetFileInfo function
            [StructLayout(LayoutKind.Sequential)]
            private struct SHFILEINFO
            {
                public IntPtr hIcon;
                public int iIcon;
                public uint dwAttributes;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
                public string szDisplayName;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
                public string szTypeName;
            };

            [DllImport("shell32.dll")]
            private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

            private const uint SHGFI_ICON = 0x100;
            private const uint SHGFI_LARGEICON = 0x0;
            private const uint SHGFI_SMALLICON = 0x000000001;
        }
    }
}
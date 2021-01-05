using System.Drawing;
using System;
using System.IO;
using System.Runtime.InteropServices;
using PWS_Shell.Properties;

namespace PWS_Shell
{
    internal static class ExtractImages
    {
        // methodes toevoegen voor het krijgen van thumbnails voor Video's, Foto's en Nintendo DS ROMS.
        internal static Image ExtractFromFile(string filePath)
        {
            return Icon.ExtractAssociatedIcon(filePath).ToBitmap();
        }

        internal static Image ExtractFromFolder(string folderPath)
        {
            Icon icon = DefaultIcons.ExtractFromPath(folderPath);
            if (icon == null)
                return Resources._102;
            return icon.ToBitmap();
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
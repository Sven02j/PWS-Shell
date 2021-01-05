using System;

namespace PWS_Shell
{
    internal class FolderCollection
    {
        internal string[] directories { get; private set; }
        internal bool isStartMenuRoot { get; private set; }

        private static string publicDesktop = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
        private static string userDesktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        private static string publicApps = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu) + "\\Programs";
        private static string userApps = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\Programs";

        internal FolderCollection(string[] directories, bool isStartMenuRoot)
        {
            this.directories = directories;
            this.isStartMenuRoot = isStartMenuRoot;
        }
        /// <summary>
        /// Omvat de mappen op het Bureaublad.
        /// </summary>
        /// <returns>Een mappencollectie met de bureaubladmappen.</returns>
        internal static FolderCollection DesktopView()
        {
            return new FolderCollection(new string[] { publicDesktop, userDesktop }, false);
        }
        /// <summary>
        /// Omvat de mappen in het Start-Menu.
        /// </summary>
        /// <returns>Een mappencollectie met de startmenumappen.</returns>
        internal static FolderCollection StartMenuView()
        {
            return new FolderCollection(new string[] { publicApps, userApps }, true);
        }

        internal static FolderCollection StartMenuSubMap(string subMap)
        {
            return new FolderCollection(new string[] { subMap }, true);
        }
    }
}
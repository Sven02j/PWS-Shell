namespace PWS_Shell
{
    internal class AppLink
    {
        internal LinkType linkType { get; private set; }

        internal string linkData { get; private set; }

        internal AppLink(LinkType linkType, string linkData)
        {
            this.linkType = linkType;
            this.linkData = linkData;
        }

        internal static AppLink GetLinkObject(string srcFile)
        {
            return new AppLink(LinkType.Normal, srcFile);
        }
    }

    enum LinkType
    {
        // Normale koppeling naar Win32-apps of een link naar elk overig bestand.
        Normal = 0,
        // Een link naar een UWP-app.
        UWP = 1,
        // Een advertised (Windows Installer) snelkoppeling naar een Win32-app.
        Advertised = 2
    }
}
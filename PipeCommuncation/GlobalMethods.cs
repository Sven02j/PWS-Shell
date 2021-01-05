using System;
using System.IO;

namespace PipeCommunication
{
    internal static class GlobalMethods
    {
        internal static string RewriteCommsId(string communicationId)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                communicationId = communicationId.Replace(c, '_');
            }

            return communicationId;
        }

        internal static string GetWriteDirectory(bool allUsers)
        {
            if (allUsers)
            {
                return "C:\\Users\\Public\\AppData\\Local\\Temp";
            }
            else
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp";
            }
        }

        internal static string GetFileName(string writeDirectory, string communicationId, bool error)
        {
            if (error)
            {
                return string.Format("{0}\\{1}.alt", writeDirectory, communicationId);
            }
            else
            {
                return string.Format("{0}\\{1}.tmp", writeDirectory, communicationId);
            }
        }
    }
}
using System;
using System.IO;

namespace PipeCommunication
{
    /// <summary>
    /// Maak een object gebonden aan de huidige gebruiker of het hele systeem, die voor een bepaald Id berichten schrijft naar het betandssysteem. Gebruik de receiver-klasse om deze te lezen.
    /// </summary>
    public class Sender
    {
        private readonly string communicationId;
        private readonly string writeDirectory;

        /// <summary>
        /// Instantieer een Sender-klasse met eigenschappen, om een Receiver-klasse data te kunnen laten lezen.
        /// </summary>
        /// <param name="allUsers">Geeft aan of de Pipe Communication beschikbaar moet zijn voor alle gebruikers of alleen voor de huidige gebruiker.</param>
        /// <param name="communicationId">De string die de Pipe Communcation identificeert, en voor de Sender en de Receiver gelijk moet zijn.</param>
        public Sender(bool allUsers, string communicationId)
        {
            this.communicationId = GlobalMethods.RewriteCommsId(communicationId);
            writeDirectory = GlobalMethods.GetWriteDirectory(allUsers);
        }

        /// <summary>
        /// Geef een bericht door aan eventuele Receivers voor dit Id.
        /// </summary>
        /// <param name="message">Het door te geven bericht.</param>
        public void WriteMessage(string message)
        {
            if (!Directory.Exists(writeDirectory))
                Directory.CreateDirectory(writeDirectory);

            try
            {
                string IOname = GlobalMethods.GetFileName(writeDirectory, communicationId, false);
                File.WriteAllText(IOname, message);
            }
            catch (Exception)
            {
                try
                {
                    string IOname = GlobalMethods.GetFileName(writeDirectory, communicationId, true);
                    File.WriteAllText(IOname, message);
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
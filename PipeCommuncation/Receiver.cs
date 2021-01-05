using System;
using System.ComponentModel;
using System.IO;
using System.Threading;

namespace PipeCommunication
{
    /// <summary>
    /// Maak een object gebonden aan de huidige gebruiker of het hele systeem, die voor een bepaald Id berichten leest van het betandssysteem. Gebruik de sender-klasse om deze te sturen.
    /// </summary>
    public class Receiver
    {
        private readonly BackgroundWorker checkIOtimer;

        private readonly string FileName;
        private readonly string AltFileName;

        private readonly MessageReceivedEventHandler eventHandler;
        /// <summary>
        /// Sjabloon voor het Message Received evenement.
        /// </summary>
        /// <param name="messageData">De data die gestuurd is.</param>
        public delegate void MessageReceivedEventHandler(MessageData messageData);

        private readonly MessageReadingErrorHandler errorHandler;
        /// <summary>
        /// Evenement die getriggerd wordt wanneer er een bericht ontvangen is op het bekeken Id.
        /// </summary>
        public event MessageReceivedEventHandler MessageReceived;

        /// <summary>
        /// Sjabloon voor het Error Reading evenement.
        /// </summary>
        public delegate void MessageReadingErrorHandler();
        /// <summary>
        /// Evenement die getriggerd wordt wanneer er een fout opgetreden is bij het bekijken van een Id.
        /// </summary>
        public event MessageReadingErrorHandler MessageReadingError;

        /// <summary>
        /// Instantieer een Receiver-klasse met eigenschappen, om een Sender-klasse data te kunnen laten sturen.
        /// </summary>
        /// <param name="allUsers">Geeft aan of de Pipe Communication beschikbaar moet zijn voor alle gebruikers of alleen voor de huidige gebruiker.</param>
        /// <param name="communicationId">De string die de Pipe Communcation identificeert, en voor de Sender en de Receiver gelijk moet zijn.</param>
        public Receiver(bool allUsers, string communicationId)
        {
            communicationId = GlobalMethods.RewriteCommsId(communicationId);
            string writeDirectory = GlobalMethods.GetWriteDirectory(allUsers);

            FileName = GlobalMethods.GetFileName(writeDirectory, communicationId, false);
            AltFileName = GlobalMethods.GetFileName(writeDirectory, communicationId, true);

            eventHandler = MessageReceived;
            errorHandler = MessageReadingError;

            checkIOtimer = new BackgroundWorker()
            {
                WorkerSupportsCancellation = true,
                WorkerReportsProgress = true
            };

            checkIOtimer.DoWork += CheckIOtimer_DoWork;
            checkIOtimer.ProgressChanged += CheckIOtimer_ProgressChanged;
        }

        private void CheckIOtimer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MessageReceivedEventHandler handler = MessageReceived;
            handler.Invoke((MessageData)e.UserState);
        }

        private void CheckIOtimer_DoWork(object sender, DoWorkEventArgs e)
        {
            int interval = Convert.ToInt32(e.Argument);

            while (!checkIOtimer.CancellationPending)
            {
                int rep = Report();

                if (rep != 0)
                {
                    try
                    {
                        MessageData mData;

                        switch (rep)
                        {
                            case 1:
                                // Message found for normal data stream.
                                mData = new MessageData(File.ReadAllText(FileName), false);
                                File.Delete(FileName);
                                break;
                            case 2:
                                // Message found for alternate (error) data stream.
                                mData = new MessageData(File.ReadAllText(AltFileName), true);
                                File.Delete(AltFileName);
                                break;
                            default:
                                throw new Exception();
                        }

                        checkIOtimer.ReportProgress(0, mData);
                    }
                    catch (Exception)
                    {
                        MessageReadingErrorHandler handler = MessageReadingError;
                        handler.Invoke();
                    }
                }

                Thread.Sleep(interval);
            }

            int Report()
            {
                if (File.Exists(AltFileName))
                {
                    return 2;
                }
                else if (File.Exists(FileName))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Verwijderd pipe-bestanden van dit Id om een foutieve lezing te voorkomen. Doe dit voor of na het Lezen.
        /// </summary>
        public void CleanListeningCache()
        {
            if (!checkIOtimer.IsBusy)
            {
                TryDel(FileName);
                TryDel(AltFileName);
            }

            void TryDel(string fileName)
            {
                try
                {
                    if (File.Exists(fileName))
                        File.Delete(fileName);
                }
                catch (Exception)
                {

                }
            }
        }

        /// <summary>
        /// Start met het luisteren naar bestanden op dit Id, met een interval als wachttijd in milliseconden.
        /// </summary>
        /// <param name="interval">Wachttijd in ms.</param>
        public void StartListening(int interval)
        {
            if (!checkIOtimer.IsBusy)
                checkIOtimer.RunWorkerAsync(interval);
        }

        /// <summary>
        /// Stop met het luisteren naar bestanden op dit Id.
        /// </summary>
        public void StopListening()
        {
            if (checkIOtimer.IsBusy && !checkIOtimer.CancellationPending)
            {
                checkIOtimer.CancelAsync();
            }
        }
    }

    /// <summary>
    /// De gelezen data van een bericht, inclusief een waarde die aangeeft of er een error-pipe gebruikt is.
    /// </summary>
    public class MessageData
    {
        /// <summary>
        /// Het gelezen bericht.
        /// </summary>
        public readonly string Message;
        /// <summary>
        /// Geeft aan of de waarde door de error-pipe komt. Dit kan betekenen dat er te vaak wordt geschreven naar dit Id of dat het interval te hoog is.
        /// </summary>
        public readonly bool UsedErrorStream;

        internal MessageData(string Message, bool UsedErrorStream)
        {
            this.Message = Message;
            this.UsedErrorStream = UsedErrorStream;
        }
    }
}
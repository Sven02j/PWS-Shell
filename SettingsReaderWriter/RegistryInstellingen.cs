using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SettingsReaderWriter
{
    /// <summary>
    /// Een Registry Instellingen-methoden object.
    /// </summary>
    public partial class RegistryInstellingen
    {
        private RegistryKey rKey;
        private bool instantiated = false;

        /// <summary>
        /// Instantieer een nieuw Registry Instellingen-methoden object.
        /// </summary>
        /// <param name="gelijkOpenen">Geeft aan of de methode RegistryOpenen() gelijk uitgevoerd moet worden.</param>
        public RegistryInstellingen(bool gelijkOpenen)
        {
            // FileNotFoundException on Micrsoft.Win32.Registy DLL!
            if (gelijkOpenen)
                Instantiate();
        }

        private void Instantiate()
        {
            if (!instantiated)
            {
                rKey = (Registry.CurrentUser).CreateSubKey($@"SOFTWARE\{ApplicationName}\settings");
                instantiated = true;
            }
        }

        private void Clear()
        {
            if (instantiated)
            {
                rKey.Flush();
                rKey.Close();
                rKey.Dispose();
                rKey = null;
                instantiated = false;
            }
        }

        private void DoAccessCheck()
        {
            if (!instantiated)
            {
                throw new RegistryClosedException("Het Registry Instellingen-methoden object kan niet in de registry werken als het niet geopend is. Zorg dat dit geopend is voordat je deze actie uitvoert, of laat het automatisch openen in de constructor.");
            }
        }

        /// <summary>
        /// Haalt een lijst met instellingen op, die de naam van de instelling en de waarde ervan bevatten.
        /// </summary>
        /// <returns>Een lijst met instellingen, waaronder de naam en de bijbehorende waarden.</returns>
        public List<Instelling> InstellingenOphalen()
        {
            DoAccessCheck();

            List<Instelling> instellingen = new List<Instelling>();

            foreach (string InstellingNaam in rKey.GetValueNames())
            {
                instellingen.Add(new Instelling(InstellingNaam, rKey.GetValue(InstellingNaam).ToString()));
            }

            return instellingen;
        }

        /// <summary>
        /// Haalt een lijst met namen van instellingen op.
        /// </summary>
        /// <returns>Een lijst met namen van instellingen.</returns>
        public string[] InstellingenNamenOphalen()
        {
            DoAccessCheck();

            return rKey.GetValueNames();
        }

        /// <summary>
        /// Haalt de waarde van een instelling op via een gegeven naam.
        /// </summary>
        /// <param name="InstellingNaam"></param>
        /// <returns>De waarde van de betreffende instelling. 'null' als de instelling niet bestaat.</returns>
        public string InstellingOphalen(string InstellingNaam)
        {
            DoAccessCheck();

            return rKey.GetValue(InstellingNaam).ToString();
        }

        /// <summary>
        /// Zoekt de instellingen door of er een waarde gegeven is voor de opgegeven instelling naam.
        /// </summary>
        /// <param name="InstellingNaam">Geeft aan of de instellingen de instelling met deze naam bevat.</param>
        /// <returns></returns>
        public bool BekijkOfInstellingBestaat(string InstellingNaam)
        {
            DoAccessCheck();

            return rKey.GetValue(InstellingNaam) != null;
        }

        /// <summary>
        /// Schrijft een waarde naar een instelling met een naam.
        /// </summary>
        /// <param name="InstellingNaam">De naam van de instelling om naar te schrijven.</param>
        /// <param name="InstellingWaarde">De waarde van de instelling om hierin te zetten.</param>
        public void NaarInstellingSchrijven(string InstellingNaam, string InstellingWaarde)
        {
            DoAccessCheck();

            if (int.TryParse(InstellingWaarde, out int _))
            {
                rKey.SetValue(InstellingNaam, InstellingWaarde, RegistryValueKind.DWord);
            }
            else
            {
                rKey.SetValue(InstellingNaam, InstellingWaarde, RegistryValueKind.String);
            }
        }

        /// <summary>
        /// Opent de registry als dit nog niet gedaan is. Dit is vereist om te kunnen schrijven en lezen naar de registry.
        /// </summary>
        public void RegistryOpenen() { Instantiate(); }

        /// <summary>
        /// Sluit de registry als dit nog niet gedaan is. Dit zorgt voor minder gegevensgebruik en laat andere applicaties bij deze registervermeldingen.
        /// </summary>
        public void RegistrySluiten() { Clear(); }
    }

    public class Instelling
    {
        public string InstellingNaam { get; private set; }

        public string InstellingWaarde { get; private set; }

        internal Instelling(string InstellingNaam, string InstellingWaarde)
        {
            this.InstellingNaam = InstellingNaam;
            this.InstellingWaarde = InstellingWaarde;
        }
    }

    /// <summary>
    /// Uitzondering die gegeven wordt wanneer er geprobeerd wordt naar de instellingen te schrijven of te lezen terwijl het gesloten is.
    /// </summary>
    public class RegistryClosedException : NotImplementedException
    {
        internal RegistryClosedException(string message) : base(message) { }

        protected RegistryClosedException(SerializationInfo info, StreamingContext ctxt) : base (info, ctxt) { }
    }
}
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PWS_Shell
{
    public partial class DateTimeControl : UserControl
    {
        public DateTimeControl()
        {
            InitializeComponent();

            BackColor = Color.Transparent;
        }

        internal void TimeDateUpdate()
        {
            SetTime();
            SetDate();
        }

        private void SetTime()
        {
            // optioneel maken om secondes te tonen. Analoge klok gebruiken als extra optie (kant en klaar op internet??)
            string hour = DateTime.Now.Hour.ToString();
            string minute = DateTime.Now.Minute.ToString();
            string second = DateTime.Now.Second.ToString();

            // Tijdzone updaten
            TimeZoneInfo.ClearCachedData();

            if (hour.Length == 1)
                hour = "0" + hour;
            if (minute.Length == 1)
                minute = "0" + minute;
            if (second.Length == 1)
                second = "0" + second;

            timeLabel.Text = $"{hour}:{minute}:{second}";
        }

        private void SetDate()
        {
            // Optioneel maken om datum te tonen.
            dateLabel.Text = $"{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}";
        }
    }
}
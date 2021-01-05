using System;
using System.Drawing;
using System.Windows.Forms;
using static PWS_Shell.Properties.Resources;

namespace PWS_Shell
{
    public partial class BatteryDisplay : UserControl
    {
        public BatteryDisplay()
        {
            InitializeComponent();
        }

        internal void UpdateBatteryIcon()
        {
            float capacity = SystemInformation.PowerStatus.BatteryLifePercent;
            int percentage = Convert.ToInt32(Math.Round((capacity / 1) * 100));
            bool attached = (SystemInformation.PowerStatus.PowerLineStatus != PowerLineStatus.Offline);
            BatteryState state;

            if (attached)
            {
                state = BatteryState.Charging;
            }
            else
            {
                if (percentage < 20)
                {
                    state = BatteryState.Low;
                }
                else if (percentage < 40)
                {
                    state = BatteryState.Poor;
                }
                else if (percentage < 60)
                {
                    state = BatteryState.Average;
                }
                else if (percentage < 80)
                {
                    state = BatteryState.Good;
                }
                else
                {
                    state = BatteryState.Excellent;
                }
            }

            batteryIcon.Image = GetBatteryImage(state);
        }

        private Image GetBatteryImage(BatteryState state)
        {
            switch ((int)state)
            {
                case 0:
                    return chargingBattery;
                case 1:
                    return lowBattery;
                case 2:
                    return poorBattery;
                case 3:
                    return averageBattery;
                case 4:
                    return goodBattery;
                case 5:
                    return excellentBattery;
                default:
                    throw new Exception();
            }
        }

        private enum BatteryState
        {
            Charging = 0,
            Low = 1,
            Poor = 2,
            Average = 3,
            Good = 4,
            Excellent = 5
        }
    }
}
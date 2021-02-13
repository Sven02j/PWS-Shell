using System;
using System.Windows.Forms;
using System.ComponentModel;
using Gma.System.MouseKeyHook;
using System.Runtime.InteropServices;
using PipeCommunication;
using System.Collections.Generic;
using Microsoft.Win32;
using static PWS_Shell.ShellIconTreadHost;

namespace PWS_Shell
{
    public partial class Desktop : Form
    {
        /// <summary>
        /// Verbergen voor het ALT + TAB Menu
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // turn on WS_EX_TOOLWINDOW style bit
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        private readonly IKeyboardMouseEvents globalHook;
        private readonly MonitorBrightnessWatcher brightnessWatcher;

        private bool debugMode;
        internal static bool allowExit = false;

        private Receiver receiver;

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const uint SWP_NOSIZE = 0x0001;
        const uint SWP_NOMOVE = 0x0002;
        const uint SWP_NOACTIVATE = 0x0010;

        private bool isMainMonitor = true;

        internal int ScreenNumber = 0;

        private List<Desktop> monitorScreens;

        private Desktop mainForm = null;

        private int lastBrightnessLevel;

        public Desktop()
        {
            InitializeComponent();
        }

        // This always gets called under execution circumstances.
        public Desktop(bool debugMode)
        {
            this.debugMode = debugMode;

            ExtractImages.ClearCacheInstant();

            InitializeComponent();

            background.DesktopControl.BindNoAppContext();
            lastBrightnessLevel = GetBrightness();
            background.DesktopControl.UpPanel.brightnessVolumeDisplay.UpdateBrightness(lastBrightnessLevel);

            monitorScreens = new List<Desktop>();

            MonitorMethods.DisplayFullAtMonitor(0, this);

            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                if (i != 0)
                {
                    monitorScreens.Add(new Desktop(i, debugMode, this));
                }
            }

            foreach (Desktop dk in monitorScreens)
            {
                dk.Show();
                dk.ReceiveUpdateDataBrightness(lastBrightnessLevel);
            }

            background.DesktopControl.ModeSwitch += DesktopControl_ModeSwitch;

            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;

            globalHook = Hook.GlobalEvents();
            globalHook.KeyDown += GlobalHook_KeyDown;

            brightnessWatcher = new MonitorBrightnessWatcher();
            brightnessWatcher.BrightnessChanged += BrightnessWatcher_BrightnessChanged;

            receiver = new Receiver(false, "PWSSHELL_86390333-5097-4798-8bde-2ef59f78c9d8");
            receiver.MessageReceived += Receiver_MessageReceived;
            receiver.CleanListeningCache();
            receiver.StartListening(100);
        }

        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            foreach (Desktop dg in monitorScreens)
            {
                dg.ForceQuit();
                dg.Dispose();
            }

            monitorScreens.Clear();

            MonitorMethods.DisplayFullAtMonitor(0, this);

            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                if (i != 0)
                {
                    monitorScreens.Add(new Desktop(i, debugMode, this));
                }
            }

            foreach (Desktop dk in monitorScreens)
            {
                dk.Show();
                dk.ReceiveUpdateDataBrightness(lastBrightnessLevel);
            }
        }

        public Desktop(int screen, bool debugMode, Form callingForm)
        {
            this.debugMode = debugMode;
            isMainMonitor = false;
            ScreenNumber = screen;

            mainForm = callingForm as Desktop;

            Screen[] screens = Screen.AllScreens;

            if (screen >= 0 && screen < screens.Length)
            {
                MonitorMethods.DisplayFullAtMonitor(screen, this);
            }
            else
            {
                Close();
            }

            InitializeComponent();

            background.DesktopControl.HideMainComponents();
        }
        
        private void Receiver_MessageReceived(MessageData messageData)
        {
            switch (messageData.Message)
            {
                case "achtergrondAfbeelding":
                    background.SetBackground();

                    foreach (Desktop dg  in monitorScreens)
                    {
                        dg.RequestBackgroundUpdate();
                    }
                    break;
            }
        }
        
        private void BrightnessWatcher_BrightnessChanged(int brightness, string instanceName)
        {
            if (isMainMonitor)
            {
                IconFlag flag = IconFlag.Decreased;

                if (brightness > lastBrightnessLevel)
                {
                    flag = IconFlag.Increased;
                }
                lastBrightnessLevel = brightness;

                ShellIconTreadHost.Run(ShellIconPainter.IconType.Brightness, brightness, flag);

                background.DesktopControl.UpPanel.brightnessVolumeDisplay.InvokeEx(g => g.UpdateBrightness(brightness));

                foreach (Desktop dg in monitorScreens)
                {
                    dg.InvokeEx(g => g.ReceiveUpdateDataBrightness(brightness));
                }
            }
        }

        internal void ReceiveUpdateDataBrightness(int brightness)
        {
            background.DesktopControl.UpPanel.brightnessVolumeDisplay.UpdateBrightness(brightness);
        }

        private void GlobalHook_KeyDown(object sender, KeyEventArgs e)
        {
            Keys keyData = e.KeyData;

            if (keyData == Keys.VolumeUp)
            {
                background.DesktopControl.RecvMsg("volup");
                ShellIconTreadHost.Run(ShellIconPainter.IconType.Sound, GetVolume(), IconFlag.Increased);
            }
            else if (keyData == Keys.VolumeDown)
            {
                background.DesktopControl.RecvMsg("voldown");
                if (background.DesktopControl.UpPanel.Volume.IsMuted)
                {
                    ShellIconTreadHost.Run(ShellIconPainter.IconType.Sound, GetVolume(), IconFlag.Muted);
                }
                else
                {
                    ShellIconTreadHost.Run(ShellIconPainter.IconType.Sound, GetVolume(), IconFlag.Decreased);
                }
            }
            else if (keyData == Keys.VolumeMute)
            {
                background.DesktopControl.RecvMsg("volmute");

                if (background.DesktopControl.UpPanel.Volume.IsMuted)
                {
                    ShellIconTreadHost.Run(ShellIconPainter.IconType.Sound, GetVolume(), IconFlag.Muted);
                }
                else
                {
                    ShellIconTreadHost.Run(ShellIconPainter.IconType.Sound, GetVolume(), IconFlag.Unmuted);
                }
            }
        }

        private void DesktopControl_ModeSwitch(FolderCollection collection)
        {
            Init.RunWorkerAsync(collection);
        }

        private void Desktop_Load(object sender, EventArgs e)
        {
            if (isMainMonitor)
            {
                Init.RunWorkerAsync(FolderCollection.DesktopView());
                if (!debugMode)
                    StartupBooterAsync.StartProcesses();
            }
            else
            {
                Init.RunWorkerAsync();
            }
        }

        private void Init_DoWork(object sender, DoWorkEventArgs e)
        {
            background.SetBackground();

            if (isMainMonitor)
                background.GetButtons((FolderCollection)e.Argument);
        }

        private void Init_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (isMainMonitor)
                background.KnoppenMaken();
        }

        private void Desktop_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!debugMode && !allowExit)
            {
                // deze optie moet gekozen worden wanneer de shell in NIET-DEBUG mode draait, en de gebruiker bijv. via Alt-F4 de shell probeert te sluiten (dat moet natuurlijk niet)
                e.Cancel = true;
            }
            else if (!isMainMonitor && !allowExit)
            {
                // deze optie moet alleen gekozen worden wanneer een niet-main shell-window wordt gesloten door de gebruiker, en de main shell-window instructies geeft om alle childs te sluiten en daarna zichzelf.
                mainForm.ForceQuit();
            }
            else if (isMainMonitor)
            {
                receiver.StopListening();
                Shutdown();
            }
        }

        internal void ForceQuit()
        {
            allowExit = true;
            Close();
        }

        private void Shutdown()
        {
            if (isMainMonitor)
            {
                foreach (Desktop dg in monitorScreens)
                {
                    dg.ForceQuit();
                }
            }

            allowExit = true;
            this.Hide();
            globalHook.KeyDown -= GlobalHook_KeyDown;
            globalHook.Dispose();
        }

        internal void BringInstancesDown()
        {
            // These are just the NON main-monitors.
            foreach (Desktop dg in monitorScreens)
            {
                dg.BringDown();
            }

            //This is the main-monitor.
            BringDown();
        }

        internal void BringDown()
        {
            SetWindowPos(Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE);
        }

        private void Desktop_Activated(object sender, EventArgs e)
        {
            if (isMainMonitor)
            {
                BringInstancesDown();
            }
            else
            {
                mainForm.BringInstancesDown();
            }
        }

        internal void RequestBackgroundUpdate()
        {
            background.SetBackground();
        }

        private int GetVolume()
        {
            return Convert.ToInt32(Math.Round(background.DesktopControl.UpPanel.Volume.SystemVolume));
        }

        private int GetBrightness()
        {
            return MonitorBrightnessWatcher.GetCurrentMonitorBrightness();
        }
    }
}
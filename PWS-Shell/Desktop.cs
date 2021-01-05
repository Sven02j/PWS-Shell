using System;
using System.Windows.Forms;
using System.ComponentModel;
using Gma.System.MouseKeyHook;
using System.Runtime.InteropServices;
using PipeCommunication;

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

        public Desktop()
        {
            InitializeComponent();
        }

        public Desktop(bool debugMode)
        {
            this.debugMode = debugMode;

            InitializeComponent();

            background.DesktopControl.ModeSwitch += DesktopControl_ModeSwitch;

            globalHook = Hook.GlobalEvents();
            globalHook.KeyDown += GlobalHook_KeyDown;

            brightnessWatcher = new MonitorBrightnessWatcher();
            brightnessWatcher.BrightnessChanged += BrightnessWatcher_BrightnessChanged;

            receiver = new Receiver(false, "PWSSHELL_86390333-5097-4798-8bde-2ef59f78c9d8");
            receiver.MessageReceived += Receiver_MessageReceived;
            receiver.CleanListeningCache();
            receiver.StartListening(100);
        }
        
        private void Receiver_MessageReceived(MessageData messageData)
        {
            MessageBox.Show($"Data: {messageData.Message}\r\n\r\nError:{messageData.UsedErrorStream}");
        }
        
        private void BrightnessWatcher_BrightnessChanged(int brightness, string instanceName)
        {
            ShellIconTreadHost.Run(ShellIconPainter.IconType.Brightness, brightness);
        }

        private void GlobalHook_KeyDown(object sender, KeyEventArgs e)
        {
            Keys keyData = e.KeyData;

            if (keyData == Keys.VolumeUp)
            {
                background.DesktopControl.RecvMsg("volup");
            }
            else if (keyData == Keys.VolumeDown)
            {
                background.DesktopControl.RecvMsg("voldown");
            }
            else if (keyData == Keys.VolumeMute)
            {
                background.DesktopControl.RecvMsg("volmute");
            }
        }

        private void DesktopControl_ModeSwitch(FolderCollection collection)
        {
            Init.RunWorkerAsync(collection);
        }

        private void Desktop_Load(object sender, EventArgs e)
        {
            Init.RunWorkerAsync(FolderCollection.DesktopView());
            if (!debugMode)
                StartupBooterAsync.StartProcesses();
        }

        private void Init_DoWork(object sender, DoWorkEventArgs e)
        {
            background.SetBackground();
            background.GetButtons((FolderCollection)e.Argument);
        }

        private void Init_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            background.KnoppenMaken();
        }

        private void Desktop_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!debugMode && !allowExit)
            {
                e.Cancel = true;
            }
            else
            {
                receiver.StopListening();
                Shutdown();
            }
        }

        private void Shutdown()
        {
            allowExit = true;
            this.Hide();
            globalHook.KeyDown -= GlobalHook_KeyDown;
            globalHook.Dispose();
        }

        private void Desktop_Activated(object sender, EventArgs e)
        {
            SetWindowPos(Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE);
            //this.SendToBack();
            //this.Focus();
        }
    }
}
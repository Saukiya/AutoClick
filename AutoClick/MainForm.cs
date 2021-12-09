using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AutoClick {
    public partial class MainForm : Form {
        public static MainForm inst;

        public Keys key_click = Keys.None;

        public Keys key_pickup = Keys.None;

        public Keys key_move = Keys.None;

        public bool boo_click;

        public bool boo_pickup;

        public bool boo_move;

        [DllImport("user32")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [DllImport("user32")]
        private static extern int keybd_event(byte bVK, byte bScan, int dwFlags, int dwExtraInfo);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        //模拟键盘按下 
        const int KEY_DOWN = 0x0000;

        //模拟键盘拾起 
        const int KEY_UP = 0x0002;

        //模拟鼠标左键按下 
        const int MOUSE_L_DOWN = 0x0002;

        //模拟鼠标左键抬起 
        const int MOUSE_L_UP = 0x0004;

        public MainForm() {
            inst = this;
            InitializeComponent();
            btn_click.KeyUp += (sender, args) => {
                key_click = args.KeyCode;
                btn_click.Text = "连点-" + key_click.ToString();
                boo_click = false;
                ActiveControl = Logger;
            };

            btn_click.Click += (sender, args) => {
                key_click = Keys.None;
                btn_click.Text = "设置热键";
                boo_click = false;
            };

            btn_pickup.KeyUp += (sender, args) => {
                key_pickup = args.KeyCode;
                btn_pickup.Text = "拾取-" + key_pickup.ToString();
                boo_pickup = false;
                ActiveControl = Logger;
            };

            btn_pickup.Click += (sender, args) => {
                key_pickup = Keys.None;
                btn_pickup.Text = "设置热键";
                boo_pickup = false;
            };

            btn_move.KeyUp += (sender, args) => {
                key_move = args.KeyCode;
                btn_move.Text = "奔跑-" + key_move.ToString();
                boo_move = false;
                ActiveControl = Logger;
            };

            btn_move.Click += (sender, args) => {
                key_move = Keys.None;
                btn_move.Text = "设置热键";
                boo_move = false;
            };

            ActiveControl = Logger;

            FormClosed += (sender, args) => { Environment.Exit(0); };

            new Thread(() => {
                while (true) {
                    if (boo_click) {
                        if (isGameWindow()) {
                            mouse_event(MOUSE_L_DOWN, 0, 0, 0, 0);
                            mouse_event(MOUSE_L_UP, 0, 0, 0, 0);
                        } else {
                            boo_click = false;
                            Log("鼠标连点已关闭");
                        }
                    }
                    if (boo_pickup) {
                        if (isGameWindow()) {
                            keybd_event((byte) Keys.F, 0, KEY_DOWN, 0);
                            keybd_event((byte) Keys.F, 0, KEY_UP, 0);
                        } else {
                            boo_pickup = false;
                            Log("自动拾取已关闭");
                        }
                    }
                    Thread.Sleep(100);
                }
            }).Start();

            KeyboardHook keyboardHook = new KeyboardHook();
            keyboardHook.KeyDownEvent += (sender, args) => {
                if (args.KeyCode == key_click && isGameWindow()) {
                    boo_click = !boo_click;
                    boo_move = !boo_click;
                    Log("鼠标连点已" + (boo_click ? "开启" : "关闭"));
                } else if (args.KeyCode == key_move && isGameWindow()) {
                    if (!boo_move) {
                        keybd_event((byte) Keys.W, 0, KEY_DOWN, 0);
                        keybd_event(0x10, 0, KEY_DOWN, 0);
                        Log("自动奔跑已开启");
                        boo_move = !boo_move;
                        boo_click = !boo_move;
                    } else {
                        keybd_event((byte) Keys.W, 0, KEY_UP, 0);
                        keybd_event(0x10, 0, KEY_UP, 0);
                        Log("自动奔跑已关闭");
                        boo_move = !boo_move;
                    }
                } else if (boo_move && args.KeyCode == Keys.W) {
                    keybd_event(0x10, 0, KEY_UP, 0);
                    Log("自动奔跑已关闭");
                    boo_move = !boo_move;
                }
                if (args.KeyCode == key_pickup && isGameWindow()) {
                    boo_pickup = !boo_pickup;
                    Log("自动拾取已" + (boo_pickup ? "开启" : "关闭"));
                } 
            };
            keyboardHook.Start();
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            if (!windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator)) {
                MessageBox.Show("如果原神为管理员身份启动时，该程序也要以管理员身份启动！");
            }
        }

        public static void Log(string log) {
            inst.Logger.Text = log;
        }

        public static bool isGameWindow() {
            IntPtr intPtr = GetForegroundWindow();
            int length = GetWindowTextLength(intPtr) * 2;
            StringBuilder sb = new StringBuilder(length);
            GetWindowText(intPtr, sb, length);
            return sb.ToString().Equals("原神");
        }
    }
}
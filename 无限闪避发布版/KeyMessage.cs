using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace 无限闪避
{
    class KeyMessage
    {
        #region Function Imports

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        #endregion

        #region Constants


        // Messages
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const int WM_CHAR = 0x105;
        const int WM_SYSKEYDOWN = 0x104;
        const int WM_SYSKEYUP = 0x105;

        #endregion

       static IntPtr GetWindowByName(string name)
        {
            Process[] processes = Process.GetProcessesByName(name);

            foreach (Process p in processes)
            {
                IntPtr windowHandle = p.MainWindowHandle;
                return windowHandle;
                // do something with windowHandle
            }
            return IntPtr.Zero;
        }

        public static void SendKey(string wName, Keys key)
        {

            IntPtr hWnd = GetWindowByName( wName);

            SendMessage(hWnd, WM_KEYDOWN, Convert.ToInt32(key), 0);
            SendMessage(hWnd, WM_KEYUP, Convert.ToInt32(key), 0);
        }

        public static void SendSysKey(string wName, Keys key)
        {
            IntPtr hWnd = GetWindowByName(wName);

            SendMessage(hWnd, WM_SYSKEYDOWN, Convert.ToInt32(key), 0);
            SendMessage(hWnd, WM_SYSKEYUP, Convert.ToInt32(key), 0);
        }

        public static void SendChar(string wName, char c)
        {
            IntPtr hWnd = GetWindowByName(wName);

            SendMessage(hWnd, WM_CHAR, (int)c, 0);
        }
    }
}

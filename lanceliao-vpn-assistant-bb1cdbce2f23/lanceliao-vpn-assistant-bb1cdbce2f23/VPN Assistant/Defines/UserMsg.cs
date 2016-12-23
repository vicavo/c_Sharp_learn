using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

namespace Com.Shuyz.VPN_Assistant
{
    public class UserMsg
    {
        public enum Messages
        {
            WM_USER = 0x0400,
            WM_PING_RESULT = WM_USER + 111,
            WM__LOCATE_RESULT = WM_USER + 112
        }

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint wMsg, int wParam, string lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint wMsg, string wParam, string lParam);
    }
      
}

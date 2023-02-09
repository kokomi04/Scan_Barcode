using System;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Scan_Barcode_Dual
{
    static class Program
    {
        /*---------------*/
        [DllImport("user32")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32")]
        private static extern IntPtr FindWindowEx(IntPtr hWndParent, IntPtr childAfter, string lpClassName, string lpWindowName);

        [DllImport("user32")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32", CharSet = CharSet.Unicode)]
        private static extern int SendMessage(IntPtr hWnd, int uMsg, IntPtr wParam, IntPtr lParam);
        /*---------------*/

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*---------------*/
            IntPtr hWndVNC = FindWindow(null, "Scan_Barcode_Dual");
            if (hWndVNC != IntPtr.Zero)
            {
                SetForegroundWindow(hWndVNC);
                IntPtr hWndStart = FindWindowEx(hWndVNC, IntPtr.Zero, null, "START_SCAN");
                if (hWndStart != IntPtr.Zero) SendMessage(hWndStart, 245, IntPtr.Zero, IntPtr.Zero);
                return;
            }
            /*---------------*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Main());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementBackend
{
   public class user128
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        public static void sendMessage(System.IntPtr ex)
        {
      
            try {
                ReleaseCapture();
                SendMessage(ex, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            } catch {
            }

        }


    

    }
}

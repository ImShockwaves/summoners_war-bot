using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Runtime.InteropServices;
using sw_bot.constructors;

namespace sw_bot.srcs
{
    public class ScreenCapture
    {
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

        public static Bitmap PrintWindow(IntPtr hwnd)    
        {       
            RECT rc;        
            GetWindowRect(hwnd, out rc);

            Bitmap bmp = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppArgb);        
            Graphics g = Graphics.FromImage(bmp);        
            IntPtr hdcBitmap = g.GetHdc();        

            PrintWindow(hwnd, hdcBitmap, 0);  

            g.ReleaseHdc(hdcBitmap);               
            g.Dispose(); 

            return bmp; 
        }

        public static Bitmap getWindowScreen() {
            Process[] procs;
            try
            {
                procs = Process.GetProcessesByName("BlueStacks");
                return PrintWindow(procs[0].MainWindowHandle);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"Could not retrieve bluestack process: {e.Message}");
                return null;
            } 
        }
    }
}
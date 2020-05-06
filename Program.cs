using System.Drawing;
using sw_bot.srcs;
using sw_bot.srcs.pyProcessHandler;
using System.Threading;

namespace sw_bot
{
    class Program
    {
        static void Main(string[] args)
        {  
            while (true) {
                Bitmap baseImg = ScreenCapture.getWindowScreen();
                string based64 = ScriptCaller.ImageToByte(baseImg);
                ScriptCaller.run_cmd("detection.py", based64);
                Thread.Sleep(10000);
            }   
        }
    }
}

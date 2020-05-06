using System;
using System.Diagnostics;
using System.IO;
using System.Drawing;

namespace sw_bot.srcs.pyProcessHandler
{
    public class ScriptCaller
    {
        public static void run_cmd(string args, string based64)
        {
            string cmd = PyFinder.GetPythonPath();
            if (String.IsNullOrEmpty(cmd)) {
                return;
            }
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = cmd;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.CreateNoWindow = true;
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;
            start.RedirectStandardInput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamWriter writer = process.StandardInput)
                {
                    writer.WriteLine(based64);
                }
                using (StreamReader reader = process.StandardOutput)
                {
                    string stderr = process.StandardError.ReadToEnd();
                    string result = reader.ReadToEnd();
                    Console.WriteLine(stderr);
                    Console.WriteLine(result);
                }
            }
        }

        public static string ImageToByte(Bitmap img)
        {
            var ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return Convert.ToBase64String(ms.GetBuffer());
        }

    }
}
using System;
using Microsoft.Win32;

namespace sw_bot.srcs.pyProcessHandler
{
    public class PyFinder
    {
        public static string GetPythonPath() {

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Python\PythonCore\");
            string[] temp = key.GetSubKeyNames();
            if (Array.IndexOf(temp, "3.6") >= 0) {
                key = Registry.CurrentUser.OpenSubKey(@"Software\Python\PythonCore\3.6\");
                temp = key.GetSubKeyNames();
                if (Array.IndexOf(temp, "InstallPath") >= 0) {
                    key = Registry.CurrentUser.OpenSubKey(@"Software\Python\PythonCore\3.6\InstallPath\");
                    temp = key.GetValueNames();
                    if (Array.IndexOf(temp, "ExecutablePath") >= 0) {
                        return (string)key.GetValue("ExecutablePath");
                    } else {
                        Console.WriteLine("Python seems to not be well installed. Check how to install Python 3.6.x");
                    }
                } else {
                    Console.WriteLine("Python seems to not be well installed or has been removed. Check how to install Python 3.6.x");
                }
            } else {
                Console.WriteLine("You don't have Python installed or it version is not compatible. Check how to install Python 3.6.x");    
            }
            return null;
        }
    }      
}
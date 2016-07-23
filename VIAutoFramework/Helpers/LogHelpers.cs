using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIAutoFramework.Helpers
{
   public class LogHelpers
    {
        // Global Declaration of filename
        private static string _logFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        private static StreamWriter _streamW = null;

        //create a file which can store the log information

        public static void CreateLogFile()
        {
            string dir = @"C:\ViditureAutomationLogs\";
            if (Directory.Exists(dir))
            {
                _streamW = File.AppendText(dir + _logFileName + ".log");
            }
            else
            {
                Directory.CreateDirectory(dir);
                
                _streamW = File.AppendText(dir + _logFileName + ".log");
            }
        }
        //create a method which can write txt in the log file.
        public static void Write(string logMessage)
        {
            _streamW.Write("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _streamW.WriteLine("     {0}", logMessage);
            _streamW.Flush();
        }
    }
}

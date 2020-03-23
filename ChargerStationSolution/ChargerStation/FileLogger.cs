using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChargerStation
{
    public class FileLogger : ILogger
    {
        public StreamWriter writer (string path, bool append);
        
        public FileLogger
        {
            writer = new StreamWriter ("ChargerstationLog.txt", true);
        }
        
        public void LogThis(string logText)
        {
            string time = DateTime.Now.ToString("h:mm:ss");
            writer.Write("Logger at " +time+ " : "+logText);
        }
    }
}
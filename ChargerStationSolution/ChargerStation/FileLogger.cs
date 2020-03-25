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
        public StreamWriter writer;
        
        public FileLogger()
        {
            //writer = new StreamWriter ("ChargerstationLog.txt", true);
        }
        
        public void LogThis(string logText)
        {
            writer = new StreamWriter("ChargerstationLog.txt", true);
            string time = DateTime.Now.ToString("h:mm:ss");
            writer.WriteLine("Logger at " +time+ " : "+logText);
            writer.Close();
        }
    }
}
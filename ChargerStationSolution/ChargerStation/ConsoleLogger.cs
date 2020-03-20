using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation
{
    public class ConsoleLogger : ILogger
    {
        public void LogThis(string logText)
        {
            string time = DateTime.Now.ToString("h:mm:ss");
            Console.WriteLine("Logger at " +time+ " : "+logText);
        }
    }
}

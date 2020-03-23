using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChargerStation
{
    public class Program
    {
        static void Main(string[] args)
        {
            DoorSensor doorSensor = new DoorSensor();
            ConsoleOutput consoleOutput = new ConsoleOutput();
            FileLogger fileLogger = new FileLogger();
            ConsoleLogger consoleLogger = new ConsoleLogger();
            VerificationUnit verificationUnit = new VerificationUnit();
            RfidReader rfidReader = new RfidReader();
            ChargeControl chargeControl = new ChargeControl();

            StationControl stationControl = new StationControl(doorSensor,consoleOutput,rfidReader,chargeControl,fileLogger,verificationUnit);

            Console.WriteLine("Write open to open");
            Console.WriteLine("Write connect to connect phone.");
            Console.WriteLine("write close to close.");
            Console.WriteLine("Write scan,<integer RFID tag between 1000 and 9999> to scan RFID.");
            Console.WriteLine("Write disconnect to disconnect phone.");

            Regex scanRegex = new Regex(@"^\bscan\b,\b[1-9][0-9]{3}\b$");

            while (true)
            {
                string userInput = Console.ReadLine();

                if (userInput == "open")
                {
                    doorSensor.OnDoorOpened();
                }
                else if (userInput == "connect" )
                {
                    chargeControl.OnPhoneConnected();
                }
                else if (userInput == "close")
                {
                    doorSensor.OnDoorClosed();
                }
                else if (scanRegex.IsMatch(userInput))
                {
                    string[] splitInput = userInput.Split(',');
                    int RFIDtag = int.Parse(splitInput[1]);
                    rfidReader.OnRfidDetected(RFIDtag);
                }
                else if (userInput == "disconnect")
                {
                    chargeControl.OnPhoneDisconnected();
                }
            }
        }
    }
}

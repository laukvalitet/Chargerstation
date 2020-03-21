using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation
{
    public class ConsoleOutput : IUserOutput
    {
        public void Notify_OpenDoorConnectPhone()
        {
            Console.WriteLine("Please open the door and connect your phone.");
        }

        public void Notify_ConnectPhone()
        {
            Console.WriteLine("Please connect your phone.");
        }

        public void Notify_PhoneConnectedCloseDoor()
        {
            Console.WriteLine("Phone connected, please close door.");
        }

        public void Notify_ScanRFID_ToLock()
        {
            Console.WriteLine("Scan RFID to lock.");
        }

        public void Notify_CheckingRFID()
        {
            Console.WriteLine("Checking RFID.");
        }

        public void Notify_DoorLocked_ScanRfidToUnlock()
        {
            Console.WriteLine("Door is locked, scan RFID to unlock.");
        }

        public void Notify_WrongRfidUnlockingFailed()
        {
            Console.WriteLine("RFID incorrect, scan the correct RFID to unlock.");
        }

        public void Notify_YouMayOpenDoorAndDisconnect()
        {
            Console.WriteLine("Door unlocked, you may open door and disconnect");
        }
        
        public void Notify_ChargerNoConnection()
        {
            Console.WriteLine("No Connection to phone");
        }

        public void Notify_ChargerPhoneFullyCharged()
        {
            Console.WriteLine("Phone is fully charged");
        }

        public void Notify_ChargerCharging()
        {
            Console.WriteLine("Charging phone");
        }

        void Notify_ChargerError()
        {
            Console.WriteLine("Attempt to charging phone failed, disconnect your phone.");
        }
    }
}

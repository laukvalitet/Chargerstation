using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation.States
{
    class OccupiedDoorClosedCheckingRFID : IState
    {
        public StationControl StationControlRef { get; set; }

        public OccupiedDoorClosedCheckingRFID(StationControl stationControlRef)
        {
            StationControlRef = stationControlRef;
        }

        public void OnEntry()
        {
            StationControlRef.UserOutput.Notify_CheckingRFID();
            StationControlRef.Logger.LogThis("Checking RFID");
        }

        public void OnExit()
        {
        }

        public void OnDoorClosed()
        {
        }

        public void OnDoorOpened()
        {
        }

        public void OnRfidDetected()
        {
        }

        public void OnPhoneConnected()
        {
        }

        public void OnPhoneDisconnected()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation.States
{
    class OccupiedDoorClosedAwaitingRFID : IState
    {
        public StationControl StationControlRef { get; set; }

        public OccupiedDoorClosedAwaitingRFID(StationControl stationControlRef)
        {
            StationControlRef = stationControlRef;
        }

        public void OnEntry()
        {
            StationControlRef.UserOutput.Notify_DoorLocked_ScanRfidToUnlock();
            StationControlRef.Logger.LogThis("Door has been locked");
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
            StationControlRef.SetState(StationControlRef.OCCUPIED_DOOR_CLOSED_CHECKING_RFID);
        }

        public void OnPhoneConnected()
        {
        }

        public void OnPhoneDisconnected()
        {
        }
    }
}

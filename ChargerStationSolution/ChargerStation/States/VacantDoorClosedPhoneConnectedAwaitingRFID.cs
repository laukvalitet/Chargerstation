using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation.States
{
    class VacantDoorClosedPhoneConnectedAwaitingRFID : IState
    {
        public StationControl StationControlRef { get; set; }

        public VacantDoorClosedPhoneConnectedAwaitingRFID(StationControl stationControlRef)
        {
            StationControlRef = stationControlRef;
        }

        public void OnEntry()
        {
            StationControlRef.UserOutput.Notify_ScanRFID_ToLock();
            StationControlRef.Logger.LogThis("Door closed, awaiting RFID tag");

        }

        public void OnExit()
        {
        }

        public void OnDoorClosed()
        {
        }

        public void OnDoorOpened()
        {
            StationControlRef.SetState(StationControlRef.VACANT_DOOR_OPEN_PHONE_CONNECTED);
        }

        public void OnRfidDetected(int RFIDtag)
        {
            StationControlRef.LockDoorWithReceivedID(RFIDtag);
            StationControlRef.SetState(StationControlRef.OCCUPIED_DOOR_CLOSED_AWAITING_RFID);
        }

        public void OnPhoneConnected()
        {
        }

        public void OnPhoneDisconnected()
        {
        }
    }
}

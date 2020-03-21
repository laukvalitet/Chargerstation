using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation.States
{
    class VacantDoorClosedPhoneConnectedAwaitingRFID : IState
    {
        public IStationControl StationControlRef { get; set; }

        public VacantDoorClosedPhoneConnectedAwaitingRFID(IStationControl stationControlRef)
        {
            StationControlRef = stationControlRef;
        }

        public void OnEntry()
        {
            StationControlRef.Logger.LogThis("Door closed, awaiting RFID tag");
            StationControlRef.UserOutput.Notify_ScanRFID_ToLock();
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
            StationControlRef.VerificationUnit.LockDoorWithReceivedID(RFIDtag);
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

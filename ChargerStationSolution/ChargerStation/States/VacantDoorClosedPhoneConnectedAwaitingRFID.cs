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
            
        }

    

        public void OnDoorClosed()
        {
        }

        public void OnDoorOpened()
        {
            StationControlRef.Logger.LogThis("Door opened");
            StationControlRef.UserOutput.Notify_DoorOpened();
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

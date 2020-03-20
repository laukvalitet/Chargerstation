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

        public void OnRfidDetected(int RFIDtag)
        {
            if (StationControlRef.TryUnlockDoorWithReceivedID(RFIDtag) == true)
            {
                StationControlRef.SetState(StationControlRef.VACANT_DOOR_CLOSED_PHONE_CONNECTED_AWAITING_RFID);
                StationControlRef.Logger.LogThis("Door has been unlocked");
            }
            else
            {
                StationControlRef.SetState(StationControlRef.OCCUPIED_DOOR_CLOSED_AWAITING_RFID);
                StationControlRef.Logger.LogThis("Wrong RFID, door remains locked");
            }
        }

        public void OnPhoneConnected()
        {
        }

        public void OnPhoneDisconnected()
        {
        }
    }
}

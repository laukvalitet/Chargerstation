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
            StationControlRef.Logger.LogThis("Door has been locked",DateTime.Now);
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
                StationControlRef.Logger.LogThis("Door has been unlocked",DateTime.Now);
                StationControlRef.SetState(StationControlRef.VACANT_DOOR_CLOSED_PHONE_CONNECTED_AWAITING_RFID);
                StationControlRef.UserOutput.Notify_YouMayOpenDoorAndDisconnect();
            }
            else if (StationControlRef.TryUnlockDoorWithReceivedID(RFIDtag) == false)
            {
                StationControlRef.Logger.LogThis("Wrong RFID, door remains locked",DateTime.Now);
                StationControlRef.SetState(StationControlRef.OCCUPIED_DOOR_CLOSED_AWAITING_RFID);
                StationControlRef.UserOutput.Notify_WrongRfidUnlockingFailed();
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

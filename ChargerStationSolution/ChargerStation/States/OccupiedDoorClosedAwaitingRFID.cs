using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation.States
{
    class OccupiedDoorClosedAwaitingRFID : IState
    {
        public IStationControl StationControlRef { get; set; }

        public OccupiedDoorClosedAwaitingRFID(IStationControl stationControlRef)
        {
            StationControlRef = stationControlRef;
        }

        public void OnEntry()
        {
            StationControlRef.Logger.LogThis("Door has been locked");
            StationControlRef.UserOutput.Notify_DoorLocked_ScanRfidToUnlock();
        }

        public void OnDoorClosed()
        {
        }

        public void OnDoorOpened()
        {
        }

        public void OnRfidDetected(int RFIDtag)
        {

            if (StationControlRef.VerificationUnit.TryUnlockDoorWithReceivedID(RFIDtag) == true)
            {
                StationControlRef.Logger.LogThis("Door has been unlocked");
                StationControlRef.SetState(StationControlRef.VACANT_DOOR_CLOSED_PHONE_CONNECTED_AWAITING_RFID);
                StationControlRef.UserOutput.Notify_YouMayOpenDoorAndDisconnect();
            }
            else 
            {
                StationControlRef.Logger.LogThis("Wrong RFID, door remains locked");
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation.States
{
    class VacantDoorClosedNoPhoneConnected : IState
    {
        public StationControl StationControlRef { get; set; }

        public VacantDoorClosedNoPhoneConnected(StationControl stationControlRef)
        {
            StationControlRef = stationControlRef;
        }

        public void OnEntry()
        {
            StationControlRef.Logger.LogThis("Door is closed");
            StationControlRef.UserOutput.Notify_OpenDoorConnectPhone();
        }

        public void OnExit()
        {
        }

        public void OnDoorClosed()
        {
        }

        public void OnDoorOpened()
        {
            StationControlRef.SetState(StationControlRef.VACANT_DOOR_OPEN_NO_PHONE_CONNECTED);
        }

        public void OnRfidDetected(int RFIDtag)
        {
            StationControlRef.LockDoorWithReceivedID(RFIDtag);
        }

        public void OnPhoneConnected()
        {
        }

        public void OnPhoneDisconnected()
        {
        }
    }
}


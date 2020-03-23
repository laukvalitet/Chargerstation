using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation.States
{
    class VacantDoorOpenPhoneConnected : IState
    {
        public IStationControl StationControlRef { get; set; }

        public VacantDoorOpenPhoneConnected(IStationControl stationControlRef)
        {
            StationControlRef = stationControlRef;
        }

        public void OnEntry()
        {
            
        }

        public void OnExit()
        {
        }

        public void OnDoorClosed()
        {
            StationControlRef.Logger.LogThis("Door closed, awaiting RFID tag");
            StationControlRef.UserOutput.Notify_ScanRFID_ToLock();
            StationControlRef.SetState(StationControlRef.VACANT_DOOR_CLOSED_PHONE_CONNECTED_AWAITING_RFID);
        }

        public void OnDoorOpened()
        {
        }

        public void OnRfidDetected(int RFIDtag)
        { }

        public void OnPhoneConnected()
        {
        }

        public void OnPhoneDisconnected()
        {
            StationControlRef.ChargeControl.TerminateCharging();
            StationControlRef.Logger.LogThis("Phone has been disconnected");
            StationControlRef.SetState(StationControlRef.VACANT_DOOR_OPEN_NO_PHONE_CONNECTED);
        }
    }
}

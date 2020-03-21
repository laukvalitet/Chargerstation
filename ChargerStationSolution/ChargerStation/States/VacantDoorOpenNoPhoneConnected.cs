using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation.States
{
    class VacantDoorOpenNoPhoneConnected : IState
    {
        public IStationControl StationControlRef { get; set; }

        public VacantDoorOpenNoPhoneConnected(IStationControl stationControlRef)
        {
            StationControlRef = stationControlRef;
        }

        public void OnEntry()
        {
            StationControlRef.Logger.LogThis("Door opened");
            StationControlRef.UserOutput.Notify_ConnectPhone();
        }

        public void OnExit()
        {
            
        }

        public void OnDoorClosed()
        {
            StationControlRef.SetState(StationControlRef.VACANT_DOOR_CLOSED_NO_PHONE_CONNECTED);
        }

        public void OnDoorOpened()
        {
        }

        public void OnRfidDetected(int RFIDtag)
        {
            
        }

        public void OnPhoneConnected()
        {
            StationControlRef.SetState(StationControlRef.VACANT_DOOR_OPEN_PHONE_CONNECTED);
        }

        public void OnPhoneDisconnected()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation.States
{
    class VacantDoorClosedNoPhoneConnected : IState
    {
        public IStationControl StationControlRef { get; set; }

        public VacantDoorClosedNoPhoneConnected(IStationControl stationControlRef)
        {
            StationControlRef = stationControlRef;
        }

        public void OnEntry()
        {
            StationControlRef.Logger.LogThis("Door is closed");
            StationControlRef.UserOutput.Notify_OpenDoorConnectPhone();
        }



        public void OnDoorClosed()
        {
        }

        public void OnDoorOpened()
        {
            StationControlRef.Logger.LogThis("Door opened");
            StationControlRef.UserOutput.Notify_ConnectPhone();
            StationControlRef.SetState(StationControlRef.VACANT_DOOR_OPEN_NO_PHONE_CONNECTED);
        }

        public void OnRfidDetected(int RFIDtag)
        {
        }

        public void OnPhoneConnected()
        {

        }

        public void OnPhoneDisconnected()
        {
        }
    }
}


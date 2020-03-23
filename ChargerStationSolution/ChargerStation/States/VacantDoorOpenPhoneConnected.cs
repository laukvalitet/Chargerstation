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
            StationControlRef.Logger.LogThis("Phone connected");
            StationControlRef.UserOutput.Notify_PhoneConnectedCloseDoor();
            //StationControlRef.ChargeControl.TimerOnElapsed(fatter ej hvad den skal tage);
        }

        public void OnExit()
        {
        }

        public void OnDoorClosed()
        {
            StationControlRef.SetState(StationControlRef.VACANT_DOOR_CLOSED_PHONE_CONNECTED_AWAITING_RFID);

        }

        public void OnDoorOpened()
        {
        }

        public void OnRfidDetected(int RFIDtag)
        { }

        public void OnPhoneConnected()
        {
            StationControlRef.ChargeControl.OnPhoneDisconnected();
        }

        public void OnPhoneDisconnected()
        {
            StationControlRef.SetState(StationControlRef.VACANT_DOOR_OPEN_NO_PHONE_CONNECTED);
        }
    }
}

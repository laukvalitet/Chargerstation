﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation.States
{
    class VacantDoorOpenNoPhoneConnected : IState
    {
        public StationControl StationControlRef { get; set; }

        public VacantDoorOpenNoPhoneConnected(StationControl stationControlRef)
        {
            StationControlRef = stationControlRef;
        }

        public void OnEntry()
        {
            
        }

  

        public void OnDoorClosed()
        {
            StationControlRef.UserOutput.Notify_DoorClosed();
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
            StationControlRef.Logger.LogThis("Phone connected");
            StationControlRef.UserOutput.Notify_PhoneConnectedCloseDoor();
            StationControlRef.ChargeControl.InitiateCharging();
            StationControlRef.SetState(StationControlRef.VACANT_DOOR_OPEN_PHONE_CONNECTED);
        }

        public void OnPhoneDisconnected()
        {
        }
    }
}

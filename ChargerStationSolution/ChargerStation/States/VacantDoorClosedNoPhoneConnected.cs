﻿using System;
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
            StationControlRef.Logger.LogThis("Door is closed",DateTime.Now);
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
        }

        public void OnPhoneConnected()
        {
        }

        public void OnPhoneDisconnected()
        {
        }
    }
}


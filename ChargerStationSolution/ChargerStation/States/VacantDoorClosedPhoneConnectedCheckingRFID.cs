using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation.States
{
    class VacantDoorClosedPhoneConnectedCheckingRFID : IState
    {
        public StationControl StationControlRef { get; set; }

        public VacantDoorClosedPhoneConnectedCheckingRFID(StationControl stationControlRef)
        {
            StationControlRef = stationControlRef;
        }
        public void OnDoorClosed()
        {
            throw new NotImplementedException();
        }

        public void OnDoorOpened()
        {
            throw new NotImplementedException();
        }

        public void OnRfidDetected()
        {
            throw new NotImplementedException();
        }

        public void OnPhoneConnected()
        {
            throw new NotImplementedException();
        }

        public void OnPhoneDisconnected()
        {
            throw new NotImplementedException();
        }
    }
}

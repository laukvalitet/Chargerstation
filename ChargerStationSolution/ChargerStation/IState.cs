using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation
{
    public interface IState
    {
        IStationControl StationControlRef { get; set; }
        void OnEntry();
        void OnDoorClosed();
        void OnDoorOpened();
        void OnRfidDetected(int RFIDtag);
        void OnPhoneConnected();
        void OnPhoneDisconnected();
    }
}

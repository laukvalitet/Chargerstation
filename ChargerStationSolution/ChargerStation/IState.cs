using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation
{
    public interface IState
    {
        StationControl StationControlRef { get; set; }
        void OnEntry();
        void OnExit();
        void OnDoorClosed();
        void OnDoorOpened();
        void OnRfidDetected();
        void OnPhoneConnected();
        void OnPhoneDisconnected();
    }
}

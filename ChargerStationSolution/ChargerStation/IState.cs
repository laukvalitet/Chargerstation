using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    interface IState
    {
        StationControl StationControlRef { get; set; }
        void OnDoorClosed();
        void OnDoorOpened();
        void OnRfidDetected();
        void OnPhoneConnected();
        void OnPhoneDisconnected();
    }
}

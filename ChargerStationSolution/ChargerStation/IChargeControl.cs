using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation
{
    public interface IChargeControl
    {
        event EventHandler<EventArgs> PhoneConnected;
        event EventHandler<EventArgs> PhoneDisconnected;

        void OnPhoneConnected();
        void OnPhoneDisconnected();

        void InitiateCharging();
        void TerminateCharging();

    }
}

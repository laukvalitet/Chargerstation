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
        void OnPhoneConnected(object sender, EventArgs e);
        void OnPhoneDisconnected(object sender, EventArgs e);

        void NewCurrentValueHandler(object sender, CurrentEventArgs e);

        void InitiateCharging();
        void TerminateCharging();
    }
}

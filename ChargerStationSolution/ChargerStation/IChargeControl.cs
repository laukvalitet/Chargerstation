using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation
{
    public class CurrentEventArgs : EventArgs
    {
        // Value in mA (milliAmpere)
        public double Current { set; get; }
    }

    public interface IChargeControl
    {
        event EventHandler<EventArgs> PhoneConnected;
        event EventHandler<EventArgs> PhoneDisconnected;
        event EventHandler<CurrentEventArgs> NewCurrentValueEvent;


        void OnPhoneConnected();
        void OnPhoneDisconnected();

        void InitiateCharging();
        void TerminateCharging();

    }
}

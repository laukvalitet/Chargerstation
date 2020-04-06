using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ChargerStation
{
    public class CurrentEventArgs : EventArgs
    {
        // Value in mA (milliAmpere)
        public double Current { set; get; }
    }

    public interface IUSBCharger
    {
        event EventHandler<EventArgs> PhoneConnected;
        event EventHandler<EventArgs> PhoneDisconnected;
        event EventHandler<CurrentEventArgs> NewCurrentValueEvent;


        void OnPhoneConnected();
        void OnPhoneDisconnected();

        void InitiateCharging();
        void TerminateCharging();

        void TimerOnElapsed(object sender, ElapsedEventArgs e);
        void OnNewCurrent();
        Timer _timer { get; set; }
        double CurrentValue { get; }
    }
}

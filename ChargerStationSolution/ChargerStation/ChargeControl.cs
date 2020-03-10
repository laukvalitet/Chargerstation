using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation
{
    class ChargeControl : IChargeControl
    {
        public event EventHandler<EventArgs> PhoneConnected;
        public event EventHandler<EventArgs> PhoneDisconnected;
        public void OnPhoneConnected()
        {
            PhoneConnected?.Invoke(this, EventArgs.Empty);
        }

        public void OnPhoneDisconnected()
        {
            PhoneDisconnected?.Invoke(this, EventArgs.Empty);
        }

        public void InitiateCharging()
        {
            throw new NotImplementedException(); //implement timer or something
        }

        public void TerminateCharging()
        {
            throw new NotImplementedException(); //implement timer or something
        }
    }
}

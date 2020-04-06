using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace ChargerStation 
{
    public class ChargeControl : IChargeControl
    {
        
        public event EventHandler<EventArgs> PhoneConnected;
        public event EventHandler<EventArgs> PhoneDisconnected;

        public IUSBCharger UsbCharger { get; set; }
        public ILogger Logger { get; set; }

        public ChargeControl(IUSBCharger usbCharger, ILogger logger)
        {
            UsbCharger = usbCharger;
            Logger = logger;
            UsbCharger.PhoneConnected += OnPhoneConnected;
            UsbCharger.PhoneDisconnected += OnPhoneDisconnected;
            UsbCharger.NewCurrentValueEvent += NewCurrentValueHandler;
        }

        public void OnPhoneConnected(object sender, EventArgs e)
        {
            this.PhoneConnected?.Invoke(this, EventArgs.Empty);
        }

        public void OnPhoneDisconnected(object sender, EventArgs e)
        {
            this.PhoneDisconnected?.Invoke(this, EventArgs.Empty);
        }

        public void NewCurrentValueHandler(object sender, CurrentEventArgs e)
        {
            Logger.LogThis("Current current value: " + e.Current + " mA");
        }

        public void InitiateCharging()
        {
            UsbCharger.InitiateCharging();
        }

        public void TerminateCharging()
        {
            UsbCharger.TerminateCharging();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace ChargerStation
{
    public class USBCharger : IUSBCharger
    {
        public event EventHandler<EventArgs> PhoneConnected;
        public event EventHandler<EventArgs> PhoneDisconnected;
        public event EventHandler<CurrentEventArgs> NewCurrentValueEvent;

        private const double MaxCurrent = 500.0; // mA
        private const double FullyChargedCurrent = 2.5; // mA
        private const double OverloadCurrent = 750; // mA
        private const int ChargeTimeMinutes = 20; // minutes
        private const int CurrentTickInterval = 250; // ms


        public double CurrentValue { get; private set; }

        public bool Connected { get; private set; }

        private bool _overload;
        private bool _charging;
        public Timer _timer { get; set; }
        private int _ticksSinceStart;

        public USBCharger()
        {
            CurrentValue = 0.0;
            Connected = true;
            _overload = false;
            _timer = new Timer();
            _timer.Enabled = false;
            _timer.Interval = CurrentTickInterval;
            _timer.Elapsed += TimerOnElapsed;

        }

        public void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            // Only execute if charging
            if (_charging)
            {
                _ticksSinceStart++;
                if (Connected && !_overload)
                {
                    double newValue = MaxCurrent -
                                      _ticksSinceStart * (MaxCurrent - FullyChargedCurrent) / (ChargeTimeMinutes * 60 * 1000 / CurrentTickInterval);
                    CurrentValue = Math.Max(newValue, FullyChargedCurrent);
                }
                else if (Connected && _overload)
                {
                    CurrentValue = OverloadCurrent;
                }
                else if (!Connected)
                {
                    CurrentValue = 0.0;
                }

                OnNewCurrent();
            }
        }

        public void OnPhoneConnected()
        {
            Connected = true;
            PhoneConnected?.Invoke(this, EventArgs.Empty);
        }

        public void OnPhoneDisconnected()
        {
            Connected = false;
            PhoneDisconnected?.Invoke(this, EventArgs.Empty);
        }

        public void SimulateConnected(bool connected)
        {
            Connected = connected;
        }

        public void SimulateOverload(bool overload)
        {
            _overload = overload;
        }
        public void InitiateCharging()
        {
            // Ignore if already charging
            if (!_charging)
            {
                if (Connected && !_overload)
                {
                    CurrentValue = 500;
                }
                else if (Connected && _overload)
                {
                    CurrentValue = OverloadCurrent;
                }
                else if (!Connected)
                {
                    CurrentValue = 0.0;
                }

                OnNewCurrent();
                _ticksSinceStart = 0;

                _charging = true;

                _timer.Start();
            }
        }

        public void TerminateCharging()
        {
            _timer.Stop();

            CurrentValue = 0.0;
            OnNewCurrent();

            _charging = false;
        }

        public void OnNewCurrent()
        {
            NewCurrentValueEvent?.Invoke(this, new CurrentEventArgs() { Current = this.CurrentValue });
        }
    }
}

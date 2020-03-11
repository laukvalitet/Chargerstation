using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation
{
    public class DoorSensor : IDoorSensor
    {
        public event EventHandler<EventArgs> DoorOpened;
        public event EventHandler<EventArgs> DoorClosed;
        public void OnDoorOpened()
        {
            DoorOpened?.Invoke(this, EventArgs.Empty);
        }

        public void OnDoorClosed()
        {
            DoorClosed?.Invoke(this, EventArgs.Empty);
        }
    }
}


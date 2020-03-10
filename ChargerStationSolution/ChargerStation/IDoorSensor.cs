using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    interface IDoorSensor
    {
        event EventHandler<EventArgs> DoorOpened;
        event EventHandler<EventArgs> DoorClosed;
        
        void OnDoorOpened();
        void OnDoorClosed();

    }
}

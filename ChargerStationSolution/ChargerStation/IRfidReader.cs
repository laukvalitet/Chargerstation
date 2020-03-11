using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation
{
    public interface IRfidReader
    {
        event EventHandler<RfidDetectedEventArgs> RfidDetected;
        void OnRfidDetected(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    class RfidReader : IRfidReader
    {
        public event EventHandler<RfidDetectedEventArgs> RfidDetected;
        public void OnRfidDetected(int id)
        {
            RfidDetected?.Invoke(this, new RfidDetectedEventArgs(id));
        }
    }
}

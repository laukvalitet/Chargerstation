using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation
{
    public class RfidDetectedEventArgs : EventArgs
    {
        public int ID { get; set; }
        public RfidDetectedEventArgs(int id)
        {
            ID = id;
        }
    }
}

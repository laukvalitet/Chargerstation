using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation
{
    interface IVerificationUnit
    {
        int RFIDtagNeededToUnlock { get; set; }
        void LockDoorWithReceivedID(int ID);
        bool TryUnlockDoorWithReceivedID(int ID);
    }
}

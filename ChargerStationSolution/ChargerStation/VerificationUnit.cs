using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation
{
    class VerificationUnit : IVerificationUnit
    {
        public int RFIDtagNeededToUnlock { get; set; }
        public void LockDoorWithReceivedID(int ID)
        {
            RFIDtagNeededToUnlock = ID;
        }

        public bool TryUnlockDoorWithReceivedID(int ID)
        {
            if (ID == RFIDtagNeededToUnlock)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

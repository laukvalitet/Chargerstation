using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargerStation
{
    public interface IUserOutput
    {
        void Notify_OpenDoorConnectPhone();
        void Notify_ConnectPhone();
        void Notify_PhoneConnectedCloseDoor();
        void Notify_ScanRFID_ToLock();
        void Notify_CheckingRFID();
        void Notify_DoorLocked_ScanRfidToUnlock();
        void Notify_WrongRfidUnlockingFailed();
        void Notify_YouMayOpenDoorAndDisconnect();
        void Notify_ChargerNoConnection();
        void Notify_ChargerPhoneFullyCharged();
        void Notify_ChargerCharging();
        void Notify_ChargerError();
    }
}

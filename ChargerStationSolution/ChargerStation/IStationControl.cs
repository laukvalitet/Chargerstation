using System;

namespace ChargerStation
{
    public interface IStationControl
    {
        IState VACANT_DOOR_CLOSED_NO_PHONE_CONNECTED { get; set; }
        IState VACANT_DOOR_OPEN_NO_PHONE_CONNECTED { get; set; }
        IState VACANT_DOOR_OPEN_PHONE_CONNECTED { get; set; }
        IState VACANT_DOOR_CLOSED_PHONE_CONNECTED_AWAITING_RFID { get; set; }
        IState OCCUPIED_DOOR_CLOSED_AWAITING_RFID { get; set; }
        IState CurrentState { get; set; }
        IDoorSensor DoorSensor { get; set; }
        IUserOutput UserOutput { get; set; }
        IRfidReader RfidReader { get; set; }
        IChargeControl ChargeControl { get; set; }
        ILogger Logger { get; set; }
        IVerificationUnit VerificationUnit { get; set; }
        void SetState(IState newState);
        void DoorOpenedHandler(object sender, EventArgs e);
        void DoorClosedHandler(object sender, EventArgs e);
        void PhoneConnectedHandler(object sender, EventArgs e);
        void PhoneDisconnectedHandler(object sender, EventArgs e);
        void RfidDetectedHandler(object sender, RfidDetectedEventArgs e);

    }
}
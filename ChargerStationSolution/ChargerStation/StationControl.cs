﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargerStation.States;

namespace ChargerStation
{
    public class StationControl : IStationControl
    {
        public IState VACANT_DOOR_CLOSED_NO_PHONE_CONNECTED { get; set; }
        public IState VACANT_DOOR_OPEN_NO_PHONE_CONNECTED { get; set; }
        public IState VACANT_DOOR_OPEN_PHONE_CONNECTED { get; set; }
        public IState VACANT_DOOR_CLOSED_PHONE_CONNECTED_AWAITING_RFID { get; set; }
        public IState OCCUPIED_DOOR_CLOSED_AWAITING_RFID { get; set; }

        public IState CurrentState { get; set; }
        public IDoorSensor DoorSensor { get; set; }
        public IUserOutput UserOutput { get; set; }
        public IRfidReader RfidReader { get; set; }
        public IChargeControl ChargeControl { get; set; }
        public ILogger Logger { get; set; }


     

        public StationControl(IDoorSensor doorSensor, IUserOutput userOutput, IRfidReader rfidReader, IChargeControl chargeControl, ILogger logger)
        {
            //init states
            VACANT_DOOR_CLOSED_NO_PHONE_CONNECTED=new States.VacantDoorClosedNoPhoneConnected(this);
            VACANT_DOOR_OPEN_NO_PHONE_CONNECTED=new States.VacantDoorOpenNoPhoneConnected(this);
            VACANT_DOOR_OPEN_PHONE_CONNECTED = new States.VacantDoorOpenPhoneConnected(this);
            VACANT_DOOR_CLOSED_PHONE_CONNECTED_AWAITING_RFID = new States.VacantDoorClosedPhoneConnectedAwaitingRFID(this);
            OCCUPIED_DOOR_CLOSED_AWAITING_RFID = new States.OccupiedDoorClosedAwaitingRFID(this);

            //Initial state
            CurrentState = VACANT_DOOR_CLOSED_NO_PHONE_CONNECTED;

            //init properties
            DoorSensor = doorSensor;
            UserOutput = userOutput;
            RfidReader = rfidReader;
            ChargeControl = chargeControl;
            Logger = logger;

            //Attaching events
            DoorSensor.DoorOpened += DoorOpenedHandler;
            DoorSensor.DoorClosed += DoorClosedHandler;
            RfidReader.RfidDetected += RfidDetectedHandler;
            ChargeControl.PhoneConnected += PhoneConnectedHandler;
            ChargeControl.PhoneDisconnected += PhoneDisconnectedHandler;
        }

        public void SetState(IState newState)
        {   
            CurrentState.OnExit();
            CurrentState = newState;
            CurrentState.OnEntry();
        }
        
        public void DoorOpenedHandler(object sender, EventArgs e)
        {
            CurrentState.OnDoorOpened();
        }

        public void DoorClosedHandler(object sender, EventArgs e)
        {
            CurrentState.OnDoorClosed();
        }

        public void PhoneConnectedHandler(object sender, EventArgs e)
        {
            CurrentState.OnPhoneConnected();
        }

        public void PhoneDisconnectedHandler(object sender, EventArgs e)
        {
            CurrentState.OnPhoneDisconnected();
        }

        public void RfidDetectedHandler(object sender, RfidDetectedEventArgs e)
        {
            CurrentState.OnRfidDetected(e.ID);
        }
    }
}

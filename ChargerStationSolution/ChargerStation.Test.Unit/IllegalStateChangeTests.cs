using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargerStation;
using NSubstitute;
using NUnit.Framework;

namespace ChargerStation.Test.Unit
{
    [TestFixture]
    public class IllegalStateChangeTests
    {
        private IDoorSensor _doorSensor;
        private IUSBCharger _chargeControl;
        private ILogger _logger;
        private IRfidReader _rfidReader;
        private IUserOutput _userOutput;
        private IVerificationUnit _verificationUnit;
        private StationControl _uut;

        [SetUp]
        public void Setup()
        {
            _doorSensor = Substitute.For<IDoorSensor>();
            _userOutput = Substitute.For<IUserOutput>();
            _rfidReader = Substitute.For<IRfidReader>();
            _chargeControl = Substitute.For<IUSBCharger>();
            _logger = Substitute.For<ILogger>();
            _verificationUnit = Substitute.For<IVerificationUnit>();

            _uut = new StationControl(_doorSensor, _userOutput, _rfidReader, _chargeControl, _logger,_verificationUnit);
        }
        
        [Test]
        public void VACANT_DOOR_CLOSED_NO_PHONE_CONNECTED_testing_illegal_state_changes()
        {
            //act
            _doorSensor.DoorClosed += Raise.EventWith(EventArgs.Empty);
            _rfidReader.RfidDetected += Raise.EventWith(new RfidDetectedEventArgs(5));
            _chargeControl.PhoneConnected += Raise.EventWith(EventArgs.Empty);
            _chargeControl.PhoneDisconnected += Raise.EventWith(EventArgs.Empty);

            //assert
            //correct behavior
            _logger.Received(1).LogThis("Door is closed");
            _userOutput.Received(1).Notify_OpenDoorConnectPhone();

            //incorrect behaviour
            _logger.Received(0).LogThis("Door opened");
            _logger.Received(0).LogThis("Door has been locked");
            _logger.Received(0).LogThis("Door has been unlocked");
            _logger.Received(0).LogThis("Wrong RFID, door remains locked");
            _logger.Received(0).LogThis("Phone connected");
            _logger.Received(0).LogThis("Phone has been disconnected");
            _logger.Received(0).LogThis("Door closed, awaiting RFID tag");
            _logger.Received(0).LogThis("Phone has been disconnected");


            _userOutput.Received(0).Notify_DoorOpened();
            _userOutput.Received(0).Notify_ConnectPhone();
            _userOutput.Received(0).Notify_PhoneConnectedCloseDoor();
            _userOutput.Received(0).Notify_ScanRFID_ToLock();
            _userOutput.Received(0).Notify_CheckingRFID();
            _userOutput.Received(0).Notify_DoorLocked_ScanRfidToUnlock();
            _userOutput.Received(0).Notify_YouMayOpenDoorAndDisconnect();
        }






        [Test]
        public void VACANT_DOOR_OPEN_NO_PHONE_CONNECTED_testing_illegal_state_changes()
        {
            //arrange
            _doorSensor.DoorOpened += Raise.EventWith(EventArgs.Empty);

            //act

            //assert

            
        }

        [Test]
        public void VACANT_DOOR_OPEN_PHONE_CONNECTED_testing_illegal_state_changes()
        {
            //arrange
            _doorSensor.DoorOpened += Raise.EventWith(EventArgs.Empty);
            _chargeControl.PhoneConnected += Raise.EventWith(EventArgs.Empty);


            //act
  

            //assert

        }

        [Test]
        public void VACANT_DOOR_CLOSED_PHONE_CONNECTED_AWAITING_RFID_testing_illegal_state_changes()
        {
            //arrange
            _doorSensor.DoorOpened += Raise.EventWith(EventArgs.Empty);
            _chargeControl.PhoneConnected += Raise.EventWith(EventArgs.Empty);
            _doorSensor.DoorClosed += Raise.EventWith(EventArgs.Empty);


            //act

            //assert

        }

        [Test]
        public void from_OCCUPIED_DOOR_CLOSED_AWAITING_RFID_testing_illegal_state_changes()
        {
            //arrange
            _doorSensor.DoorOpened += Raise.EventWith(EventArgs.Empty);
            _chargeControl.PhoneConnected += Raise.EventWith(EventArgs.Empty);
            _doorSensor.DoorClosed += Raise.EventWith(EventArgs.Empty);
            _rfidReader.RfidDetected += Raise.EventWith(new RfidDetectedEventArgs(1234));


            //act

            //assert


        }
    }
}
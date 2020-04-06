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
        public void from_VACANT_DOOR_CLOSED_NO_PHONE_CONNECTED_to_VACANT_DOOR_OPEN_NO_PHONE_CONNECTED()
        {
            //act
            _doorSensor.DoorOpened += Raise.EventWith(EventArgs.Empty);

            //assert
            _logger.Received(1).LogThis("Door opened");
            _userOutput.Received().Notify_ConnectPhone();
        }

        [Test]
        public void from_VACANT_DOOR_OPEN_NO_PHONE_CONNECTED_to_VACANT_DOOR_OPEN_PHONE_CONNECTED()
        {
            //arrange
            _doorSensor.DoorOpened += Raise.EventWith(EventArgs.Empty);

            //act
            _chargeControl.PhoneConnected += Raise.EventWith(EventArgs.Empty);

            //assert
            _chargeControl.Received(1).InitiateCharging();
            _logger.Received(1).LogThis("Phone connected");
            _userOutput.Received(1).Notify_PhoneConnectedCloseDoor();
            
        }

        [Test]
        public void from_VACANT_DOOR_OPEN_PHONE_CONNECTED_to_VACANT_DOOR_CLOSED_PHONE_CONNECTED_AWAITING_RFID()
        {
            //arrange
            _doorSensor.DoorOpened += Raise.EventWith(EventArgs.Empty);
            _chargeControl.PhoneConnected += Raise.EventWith(EventArgs.Empty);


            //act
            _doorSensor.DoorClosed += Raise.EventWith(EventArgs.Empty);

            //assert
            _userOutput.Received().Notify_ScanRFID_ToLock();
            _logger.Received(1).LogThis("Door closed, awaiting RFID tag");
        }

        [Test]
        public void from_VACANT_DOOR_CLOSED_PHONE_CONNECTED_AWAITING_RFID_to_OCCUPIED_DOOR_CLOSED_AWAITING_RFID()
        {
            //arrange
            _doorSensor.DoorOpened += Raise.EventWith(EventArgs.Empty);
            _chargeControl.PhoneConnected += Raise.EventWith(EventArgs.Empty);
            _doorSensor.DoorClosed += Raise.EventWith(EventArgs.Empty);


            //act
            _rfidReader.RfidDetected += Raise.EventWith(new RfidDetectedEventArgs(1234));

            //assert
            _verificationUnit.Received(1).LockDoorWithReceivedID(1234);
            _logger.Received(1).LogThis("Door has been locked");
            _userOutput.Received().Notify_DoorLocked_ScanRfidToUnlock();
        }

        [Test]
        public void from_OCCUPIED_DOOR_CLOSED_AWAITING_RFID____checking_RFID()
        {
            //arrange
            _doorSensor.DoorOpened += Raise.EventWith(EventArgs.Empty);
            _chargeControl.PhoneConnected += Raise.EventWith(EventArgs.Empty);
            _doorSensor.DoorClosed += Raise.EventWith(EventArgs.Empty);
            _rfidReader.RfidDetected += Raise.EventWith(new RfidDetectedEventArgs(1234));
            _verificationUnit.TryUnlockDoorWithReceivedID(1234).Returns(true);

            //act
            _rfidReader.RfidDetected += Raise.EventWith(new RfidDetectedEventArgs(1234));
            //assert

            _verificationUnit.Received(1).TryUnlockDoorWithReceivedID(1234);
            _logger.Received(1).LogThis("Door has been unlocked");
            _userOutput.Received().Notify_YouMayOpenDoorAndDisconnect();
        }

        [Test]
        public void from_OCCUPIED_DOOR_CLOSED_AWAITING_RFID_____wrong_RFID_detected()
        {
            //arrange
            _doorSensor.DoorOpened += Raise.EventWith(EventArgs.Empty);
            _chargeControl.PhoneConnected += Raise.EventWith(EventArgs.Empty);
            _doorSensor.DoorClosed += Raise.EventWith(EventArgs.Empty);
            _rfidReader.RfidDetected += Raise.EventWith(new RfidDetectedEventArgs(1234));
            _verificationUnit.TryUnlockDoorWithReceivedID(4321).Returns(false);


            //act
            _rfidReader.RfidDetected += Raise.EventWith(new RfidDetectedEventArgs(4321));


            //assert
            _uut.VerificationUnit.Received(1).TryUnlockDoorWithReceivedID(4321);
            _logger.Received(1).LogThis("Wrong RFID, door remains locked");
            _userOutput.Received().Notify_WrongRfidUnlockingFailed();
        }


        [Test]
        public void from_VACANT_DOOR_OPEN_PHONE_CONNECTED_to_VACANT_DOOR_OPEN_NO_PHONE_CONNECTED()
        {
            //arrange
            _doorSensor.DoorOpened += Raise.EventWith(EventArgs.Empty);
            _chargeControl.PhoneConnected += Raise.EventWith(EventArgs.Empty);


            //act
            _chargeControl.PhoneDisconnected += Raise.EventWith(EventArgs.Empty);

            //assert
            _chargeControl.Received(1).TerminateCharging();
            _logger.Received(1).LogThis("Phone has been disconnected");
        }

        [Test]
        public void from_VACANT_DOOR_CLOSED_PHONE_CONNECTED_AWAITING_RFID_to_VACANT_DOOR_OPEN_PHONE_CONNECTED()
        {
            //arrange
            _doorSensor.DoorOpened += Raise.EventWith(EventArgs.Empty);
            _chargeControl.PhoneConnected += Raise.EventWith(EventArgs.Empty); 
            _doorSensor.DoorClosed += Raise.EventWith(EventArgs.Empty); 
            _rfidReader.RfidDetected += Raise.EventWith(new RfidDetectedEventArgs(1234));
            _verificationUnit.TryUnlockDoorWithReceivedID(1234).Returns(true);
            _rfidReader.RfidDetected += Raise.EventWith(new RfidDetectedEventArgs(1234));
            

            //act
            _doorSensor.DoorOpened += Raise.EventWith(EventArgs.Empty);

            //assert

            _logger.Received(2).LogThis("Door opened");
            _userOutput.Received().Notify_DoorOpened();
        }

        [Test]
        public void from_VACANT_DOOR_OPEN_NO_PHONE_CONNECTED_to_VACANT_DOOR_CLOSED_NO_PHONE_CONNECTED()
        {
            //arrange
            _doorSensor.DoorOpened += Raise.EventWith(EventArgs.Empty);
            _chargeControl.PhoneConnected += Raise.EventWith(EventArgs.Empty); 
            _doorSensor.DoorClosed += Raise.EventWith(EventArgs.Empty); 
            _rfidReader.RfidDetected += Raise.EventWith(new RfidDetectedEventArgs(1234));
            _verificationUnit.TryUnlockDoorWithReceivedID(1234).Returns(true);
            _rfidReader.RfidDetected += Raise.EventWith(new RfidDetectedEventArgs(1234));
            _doorSensor.DoorOpened += Raise.EventWith(EventArgs.Empty);
            _chargeControl.PhoneDisconnected += Raise.EventWith(EventArgs.Empty);

            //act
            _doorSensor.DoorClosed += Raise.EventWith(EventArgs.Empty);

            //assert
            _logger.Received(2).LogThis("Door is closed");
            _userOutput.Received().Notify_OpenDoorConnectPhone();
        }

    }
}

//testing for illegal state changes
_userOutput.Received(0).Notify_CheckingRFID();
_userOutput.Received(0).Notify_ChargerCharging();
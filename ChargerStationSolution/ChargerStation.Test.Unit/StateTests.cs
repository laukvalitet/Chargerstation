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
    public class StateTests
    {
        private IDoorSensor _doorSensor;
        private IChargeControl _chargeControl;
        private ILogger _logger;
        private IRfidReader _rfidReader;
        private IUserOutput _userOutput;
        private StationControl _uut;

        [SetUp]
        public void Setup()
        {
            _doorSensor = Substitute.For<IDoorSensor>();
            _userOutput = Substitute.For<IUserOutput>();
            _rfidReader = Substitute.For<IRfidReader>();
            _chargeControl = Substitute.For<IChargeControl>();
            _logger = Substitute.For<ILogger>();
            _uut = new StationControl(_doorSensor, _userOutput, _rfidReader, _chargeControl, _logger);
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
            _logger.Received(1).LogThis("Phone connected");
            _userOutput.Received().Notify_PhoneConnectedCloseDoor();
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
            _logger.Received(1).LogThis("Door closed, awaiting RFID");
            _userOutput.Received().Notify_ScanRFID_ToLock();
        }



    }
}
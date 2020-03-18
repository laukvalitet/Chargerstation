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
            _uut = new StationControl(_doorSensor, _userOutput, _rfidReader, _chargeControl, _logger);
        }
        
        [Test]
        public void from_VACANT_DOOR_CLOSED_NO_PHONE_CONNECTED_to_VACANT_DOOR_OPEN_NO_PHONE_CONNECTED()
        {
            //arrange
            //_userValidation.ValidateEntryRequest(1111).Returns(true);

            //act
            _doorSensor.DoorOpened += Raise.EventWith(EventArgs.Empty);

            //assert
            //_door.Received(1).Close();
            _userOutput.Received().Notify_ConnectPhone();
            //Assert.That(_uut.CurrentState.GetType() == typeof(_uut.) );
        }
    }
}
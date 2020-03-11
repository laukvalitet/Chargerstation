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
            _uut = new StationControl(_doorSensor, _userOutput, _rfidReader, _chargeControl);
        }
        
        [Test]
        public void FromThisToThat()
        {
            //arrange
            //_userValidation.ValidateEntryRequest(1111).Returns(true);

            //act
            //_uut.RequestEntry(1111);
            //_uut.DoorOpen();

            //assert
            //_door.Received(1).Close();
        }
    }
}
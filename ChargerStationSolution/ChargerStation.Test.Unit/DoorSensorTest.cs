using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using ChargerStation;
using NSubstitute.ReceivedExtensions;

namespace ChargerStation.Test.Unit
{
    [TestFixture]
    public class DoorSensorTest
    {
        private DoorSensor _uut;

        [SetUp]
        public void Setup()
        {
            _uut=new DoorSensor();
        }

        [Test]
        public void DoorSensor_fire_event_DoorOpened()
        {
            //arrange
            var wasCalled = false;
            //act
            _uut.DoorOpened +=
                (o, args) => wasCalled = true;

            _uut.OnDoorOpened();
            //assert
            Assert.True(wasCalled);

        }

        [Test]
        public void DoorSensor_fire_event_DoorClosed()
        {
            //arrange
            var wasCalled = false;
            //act
            _uut.DoorClosed +=
                (o, args) => wasCalled = true;

            _uut.OnDoorClosed();
            //assert
            Assert.True(wasCalled);

        }

    }
}

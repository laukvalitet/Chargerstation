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
    public class DoorEventTests
    {
        private  DoorSensor _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new DoorSensor();
        }

        [Test]
        public void Raise_door_opened()
        {
            _uut.Should().Raise("DoorOpened");
        }

        [Test]
        public void Raise_door_closed()
        {
            _uut.Should().Raise("DoorClosed");
        }
    }
}
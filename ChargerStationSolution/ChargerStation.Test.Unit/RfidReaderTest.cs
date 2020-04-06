using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using ChargerStation;
using NSubstitute.ReceivedExtensions;

namespace ChargerStation.Test.Unit
{
    [TestFixture]
    class RfidReaderTest
    {
        private RfidReader _uut;
        private RfidDetectedEventArgs _recievedEventArgs;

        [SetUp]
        public void Setup()
        {
            _recievedEventArgs = null;
            _uut=new RfidReader();
            _uut.OnRfidDetected(1);

            _uut.RfidDetected +=
                (o, args) => { _recievedEventArgs = args; };
        }

        [Test]
        public void On_RfidDetected_event_fired()
        {
            //arrange
            //act
            _uut.OnRfidDetected(1);
            //assert
            Assert.That(_recievedEventArgs.ID, Is.EqualTo(1));
        }


    }
}

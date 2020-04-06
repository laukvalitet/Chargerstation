using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using ChargerStation;

namespace ChargerStation.Test.Unit
{
    [TestFixture]
    class RfidReaderTest
    {
        private RfidReader _uut;

        [SetUp]
        public void Setup()
        {
            _uut=new RfidReader();
        }

        [Test]
        public void On_RfidDetected_invoke_event_Send_ID()
        {
            //arrange

            //act

            //assert

            
        }

    }
}

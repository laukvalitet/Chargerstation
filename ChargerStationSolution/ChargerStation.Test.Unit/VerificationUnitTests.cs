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
    public class VerificationUnitTests
    {
        private VerificationUnit _uut;
        private IStationControl _stationControl;

        [SetUp]
        public void Setup()
        {
            _uut = new VerificationUnit();
            _stationControl = Substitute.For<IStationControl>();
        }
        
        [Test]
        public void LockDoorWithReceivedIDTes()
        {
            void LockDoorWithReceivedID(int ID);
            bool TryUnlockDoorWithReceivedID(int ID);
        }
    }
}
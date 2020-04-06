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

        [SetUp]
        public void Setup()
        {
            _uut = new VerificationUnit();
        }
        
        [Test]
        public void TryUnlockDoorWithReceivedID_ReturnsFalseOnWrongID()
        {
            //arrange
            _uut.LockDoorWithReceivedID(1);
            //act
            //assert
            Assert.AreEqual(_uut.TryUnlockDoorWithReceivedID(2),false);
        }
        [Test]
        public void TryUnlockDoorWithReceivedID_ReturnsTrueOnWrongID()
        {
            //arrange
            _uut.LockDoorWithReceivedID(1);
            //act
            //assert
            Assert.AreEqual(_uut.TryUnlockDoorWithReceivedID(1),true);
        }
    }
}
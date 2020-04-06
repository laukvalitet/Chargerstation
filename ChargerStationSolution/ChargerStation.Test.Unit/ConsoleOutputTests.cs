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
    public class ConsoleOutputTests
    {
        private ConsoleOutput _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new ConsoleOutput();
        }
        
        [Test]
        public void test1()
        {
            //arrange
            _uut.Notify_ChargerError();
            //act
            //assert
            Assert.
            Assert.AreEqual(_uut.TryUnlockDoorWithReceivedID(2),false);
        }
        
    }
}
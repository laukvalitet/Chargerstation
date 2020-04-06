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
    public class ChargeControlTests
    {
        private ChargeControl _uut;
        private IUSBCharger _usbCharger;
        private ILogger _logger;
        
        [SetUp]
            public void Setup()
            {
                _usbCharger = Substitute.For<IUSBCharger>();
                _logger = Substitute.For<ILogger>();
                _uut=new ChargeControl(_usbCharger, _logger);
            }
  
            [Test]
            public void ChargeControlFiresEvent_PhoneConnected()
            {
                //arrange
                var wasCalled = false;
                //act
                _uut.PhoneConnected +=
                    (o, args) => wasCalled = true;

                _uut.OnPhoneConnected(_uut,EventArgs.Empty);
                //assert
                Assert.True(wasCalled);
            }

            [Test]
            public void ChargeControlFiresEvent_PhoneDisconnected()
            {
                //arrange
                var wasCalled = false;
                //act
                _uut.PhoneDisconnected +=
                    (o, args) => wasCalled = true;

                _uut.OnPhoneDisconnected(_uut,EventArgs.Empty);
                //assert
                Assert.True(wasCalled);
            }
            
            [Test]
            public void NewCurrentValueHandler_Invokes_Logger()
            {
                //arrange
                CurrentEventArgs currentEvent = new CurrentEventArgs();
                currentEvent.Current = 3;

                //act
                _uut.NewCurrentValueHandler(_uut,currentEvent);

                //assert
                _logger.Received(1).LogThis("Current current value: 3 mA");
            }
            
            [Test]
            public void InitiateCharging_Invokes_USBCharger()
            {
                //arrange
                
                //act
                _uut.InitiateCharging();
                
                //assert
                _usbCharger.Received(1).InitiateCharging();
            } 
            
            [Test]
            public void TerminateCharging_Invokes_USBCharger()
            {
                //arrange
                
                //act
                _uut.TerminateCharging();
                
                //assert
                _usbCharger.Received(1).TerminateCharging();
            }
            }
    }
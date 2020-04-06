﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ChargerStation.Test.Unit
{
    [TestFixture]
    public class TestUsbChargerSimulator
    {
        private USBCharger _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new USBCharger();
        }

        [Test]
        public void ctor_IsConnected()
        {
            Assert.That(_uut.Connected, Is.True);
        }

        [Test]
        public void ctor_CurrentValueIsZero()
        {
            Assert.That(_uut.CurrentValue, Is.Zero);
        }

        [Test]
        public void SimulateDisconnected_ReturnsDisconnected()
        {
            _uut.OnPhoneConnected();
            Assert.That(_uut.Connected, Is.True);
        }

        [Test]
        public void Started_WaitSomeTime_ReceivedSeveralValues()
        {
            int numValues = 0;
            _uut.NewCurrentValueEvent += (o, args) => numValues++;

            _uut.InitiateCharging();

            System.Threading.Thread.Sleep(1100);

            Assert.That(numValues, Is.GreaterThan(4));
        }

        [Test]
        public void Started_WaitSomeTime_ReceivedChangedValue()
        {
            double lastValue = 1000;
            _uut.NewCurrentValueEvent += (o, args) => lastValue = args.Current;

            _uut.InitiateCharging();

            System.Threading.Thread.Sleep(300);

            Assert.That(lastValue, Is.LessThan(500.0));
        }

        [Test]
        public void StartedNoEventReceiver_WaitSomeTime_PropertyChangedValue()
        {
            _uut.InitiateCharging();

            System.Threading.Thread.Sleep(300);

            Assert.That(_uut.CurrentValue, Is.LessThan(500.0));
        }

        [Test]
        public void Started_WaitSomeTime_PropertyMatchesReceivedValue()
        {
            double lastValue = 1000;
            _uut.NewCurrentValueEvent += (o, args) => lastValue = args.Current;

            _uut.InitiateCharging();

            System.Threading.Thread.Sleep(1100);

            Assert.That(lastValue, Is.EqualTo(_uut.CurrentValue));
        }


        [Test]
        public void Started_SimulateOverload_ReceivesHighValue()
        {
            ManualResetEvent pause = new ManualResetEvent(false);
            double lastValue = 0;

            _uut.NewCurrentValueEvent += (o, args) =>
            {
                lastValue = args.Current;
                pause.Set();
            };

            // Start
            _uut.InitiateCharging();

            // Next value should be high
            _uut.SimulateOverload(true);

            // Reset event
            pause.Reset();

            // Wait for next tick, should send overloaded value
            pause.WaitOne(300);

            Assert.That(lastValue, Is.GreaterThan(500.0));
        }

        [Test]
        public void Started_SimulateDisconnected_ReceivesZero()
        {
            ManualResetEvent pause = new ManualResetEvent(false);
            double lastValue = 1000;

            _uut.NewCurrentValueEvent += (o, args) =>
            {
                lastValue = args.Current;
                pause.Set();
            };


            // Start
            _uut.InitiateCharging();

            // Next value should be zero
            _uut.SimulateConnected(false);

            // Reset event
            pause.Reset();

            // Wait for next tick, should send disconnected value
            pause.WaitOne(300);

            Assert.That(lastValue, Is.Zero);
        }

        [Test]
        public void SimulateOverload_Start_ReceivesHighValueImmediately()
        {
            double lastValue = 0;

            _uut.NewCurrentValueEvent += (o, args) =>
            {
                lastValue = args.Current;
            };

            // First value should be high
            _uut.SimulateOverload(true);

            // Start
            _uut.InitiateCharging();

            // Should not wait for first tick, should send overload immediately

            Assert.That(lastValue, Is.GreaterThan(500.0));
        }

        [Test]
        public void SimulateDisconnected_Start_ReceivesZeroValueImmediately()
        {
            double lastValue = 1000;

            _uut.NewCurrentValueEvent += (o, args) =>
            {
                lastValue = args.Current;
            };

            // First value should be high
            _uut.SimulateConnected(false);

            // Start
            _uut.InitiateCharging();

            // Should not wait for first tick, should send zero immediately

            Assert.That(lastValue, Is.Zero);
        }

        [Test]
        public void StopCharge_IsCharging_ReceivesZeroValue()
        {
            double lastValue = 1000;
            _uut.NewCurrentValueEvent += (o, args) => lastValue = args.Current;

            _uut.InitiateCharging();

            System.Threading.Thread.Sleep(300);

            _uut.TerminateCharging();

            Assert.That(lastValue, Is.EqualTo(0.0));
        }

        [Test]
        public void StopCharge_IsCharging_PropertyIsZero()
        {
            _uut.InitiateCharging();

            System.Threading.Thread.Sleep(300);

            _uut.TerminateCharging();

            Assert.That(_uut.CurrentValue, Is.EqualTo(0.0));
        }

        [Test]
        public void StopCharge_IsCharging_ReceivesNoMoreValues()
        {
            double lastValue = 1000;
            _uut.NewCurrentValueEvent += (o, args) => lastValue = args.Current;

            _uut.TerminateCharging();

            System.Threading.Thread.Sleep(300);

            _uut.TerminateCharging();
            lastValue = 1000;

            // Wait for a tick
            System.Threading.Thread.Sleep(300);

            // No new value received
            Assert.That(lastValue, Is.EqualTo(1000.0));
        }



    }
}

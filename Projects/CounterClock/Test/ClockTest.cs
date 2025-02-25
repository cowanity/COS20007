using ClockClass;
using NUnit.Framework;

namespace ClockTest
{
    [TestFixture]
    public class Tests
    {
        private Clock _clock;

        [SetUp]
        public void Setup()
        {
            _clock = new Clock();
        }

        [Test]
        public void IncrementSeconds()
        {
            _clock.Tick();
            Assert.That(_clock.CurrentTime(), Is.EqualTo("00:00:01"));
        }

        [Test]
        public void IncrementMinutes()
        {
            for (int i = 0; i < 60; i++)
            {
                _clock.Tick();
            }
            Assert.That(_clock.CurrentTime(), Is.EqualTo("00:01:00"));
        }

        [Test]
        public void IncrementHours()
        {
            for (int i = 0; i < 3600; i++)
            {
                _clock.Tick();
            }
            Assert.That(_clock.CurrentTime(), Is.EqualTo("01:00:00"));
        }

        [Test]
        public void ClockResetsToZero()
        {
            for (int i = 0; i < 86400; i++)
            {
                _clock.Tick();
            }
            Assert.That(_clock.CurrentTime(), Is.EqualTo("00:00:00"));
        }

        [Test]
        public void SetTime()
        {
            _clock.SetTime("12:34:56");
            Assert.That(_clock.CurrentTime(), Is.EqualTo("12:34:56"));
        }

        [Test]
        public void ResetClock()
        {
            _clock.SetTime("12:34:56");
            _clock.Reset();
            Assert.That(_clock.CurrentTime(), Is.EqualTo("00:00:00"));
        }
    }
}
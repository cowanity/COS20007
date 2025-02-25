using ClockClass;
using NUnit.Framework;

namespace CounterTest
{
    [TestFixture]
    public class Tests
    {
        private Counter _counter;

        [SetUp]
        public void Setup()
        {
            _counter = new Counter("Test Counter");
        }

        [Test]
        public void InitializeCounter()
        {
            Assert.That(_counter.Tick, Is.EqualTo(0));
        }

        [Test]
        public void IncrementCounterByOne()
        {
            _counter.Increment();
            Assert.That(_counter.Tick, Is.EqualTo(1));
        }

        [Test]
        public void IncrementContinuously()
        {
            _counter.Increment();
            _counter.Increment();
            _counter.Increment();
            Assert.That(_counter.Tick, Is.EqualTo(3));
        }

        [Test]
        public void ResetCounter()
        {
            _counter.Increment();
            _counter.Reset();
            Assert.That(_counter.Tick, Is.EqualTo(0));
        }

        [Test]
        public void SetCounterName()
        {
            _counter.Name = "New Counter Name";
            Assert.That(_counter.Name, Is.EqualTo("New Counter Name"));
        }
    }
}

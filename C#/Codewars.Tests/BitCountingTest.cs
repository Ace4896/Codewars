namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class BitCountingTest
    {
        [Test]
        public void CountBits()
        {
            Assert.That(Kata.CountBits(0), Is.EqualTo(0));
            Assert.That(Kata.CountBits(4), Is.EqualTo(1));
            Assert.That(Kata.CountBits(7), Is.EqualTo(3));
            Assert.That(Kata.CountBits(9), Is.EqualTo(2));
            Assert.That(Kata.CountBits(10), Is.EqualTo(2));
        }
    }
}

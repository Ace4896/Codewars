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
            ClassicAssert.AreEqual(0, Kata.CountBits(0));
            ClassicAssert.AreEqual(1, Kata.CountBits(4));
            ClassicAssert.AreEqual(3, Kata.CountBits(7));
            ClassicAssert.AreEqual(2, Kata.CountBits(9));
            ClassicAssert.AreEqual(2, Kata.CountBits(10));
        }
    }
}

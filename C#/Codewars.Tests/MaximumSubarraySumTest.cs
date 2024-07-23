namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class MaximumSubarraySumTest
    {
        [Test]
        public void Test0()
        {
            Assert.That(Kata.MaxSequence([]), Is.EqualTo(0));
        }

        [Test]
        public void Test1()
        {
            Assert.That(Kata.MaxSequence([-2, 1, -3, 4, -1, 2, 1, -5, 4]), Is.EqualTo(6));
        }
    }
}

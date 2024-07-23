namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class MaximumSubarraySumTest
    {
        [Test]
        public void Test0()
        {
            Assert.That(Kata.MaxSequence(new int[0]), Is.EqualTo(0));
        }

        [Test]
        public void Test1()
        {
            Assert.That(Kata.MaxSequence(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }), Is.EqualTo(6));
        }
    }
}

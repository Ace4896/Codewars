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
            ClassicAssert.AreEqual(0, Kata.MaxSequence(new int[0]));
        }

        [Test]
        public void Test1()
        {
            ClassicAssert.AreEqual(6, Kata.MaxSequence(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));
        }
    }
}

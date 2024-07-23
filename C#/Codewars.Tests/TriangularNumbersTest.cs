namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class TriangularNumbersTest
    {
        Triangular triangular = new Triangular();

        [Test]
        public void TriangularTests()
        {
            ClassicAssert.AreEqual(true, triangular.isTriangular(6));
        }

        [Test]
        public void BigTriangularTests()
        {
            ClassicAssert.AreEqual(false, triangular.isTriangular(2147483646), "T = 2147483646"); // upper bound
            ClassicAssert.AreEqual(true, triangular.isTriangular(2147450880), "T = 2147450880"); // max triangular
            ClassicAssert.AreEqual(false, triangular.isTriangular(2147450879), "T = 2147450879"); // next to max triangular
            ClassicAssert.AreEqual(false, triangular.isTriangular(2147450881), "T = 2147450881"); // next to max triangular
            ClassicAssert.AreEqual(false, triangular.isTriangular(536870912), "T = 536870912"); // 8 * t + 1 truncated to 32 bits is a square
            ClassicAssert.AreEqual(false, triangular.isTriangular(536871065), "T = 536871065"); // 8 * t + 1 truncated to 32 bits is a square
            ClassicAssert.AreEqual(false, triangular.isTriangular(333333333), "T = 333333333"); // 8 * t + 1 truncated to 32 bits is negative
        }
    }
}

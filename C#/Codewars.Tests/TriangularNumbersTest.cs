namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class TriangularNumbersTest
    {
        Triangular triangular = new Triangular();

        [Test]
        public void TriangularTests()
        {
            Assert.That(triangular.isTriangular(6), Is.EqualTo(true));
        }

        [Test]
        public void BigTriangularTests()
        {
            Assert.That(triangular.isTriangular(2147483646), Is.EqualTo(false), "T = 2147483646"); // upper bound
            Assert.That(triangular.isTriangular(2147450880), Is.EqualTo(true), "T = 2147450880"); // max triangular
            Assert.That(triangular.isTriangular(2147450879), Is.EqualTo(false), "T = 2147450879"); // next to max triangular
            Assert.That(triangular.isTriangular(2147450881), Is.EqualTo(false), "T = 2147450881"); // next to max triangular
            Assert.That(triangular.isTriangular(536870912), Is.EqualTo(false), "T = 536870912"); // 8 * t + 1 truncated to 32 bits is a square
            Assert.That(triangular.isTriangular(536871065), Is.EqualTo(false), "T = 536871065"); // 8 * t + 1 truncated to 32 bits is a square
            Assert.That(triangular.isTriangular(333333333), Is.EqualTo(false), "T = 333333333"); // 8 * t + 1 truncated to 32 bits is negative
        }
    }
}

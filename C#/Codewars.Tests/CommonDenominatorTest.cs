namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class CommonDenominatorTest
    {
        [Test]
        public void ConvertFrac_NonReducibleFractions()
        {
            long[,] lst = new long[,] { { 1, 2 }, { 1, 3 }, { 1, 4 } };
            Assert.That(Fracts.convertFrac(lst), Is.EqualTo("(6,12)(4,12)(3,12)"));
        }

        [Test]
        public void ConvertFrac_ReducibleFractions()
        {
            long[,] lst = new long[,] { { 2, 4 }, { 2, 6 }, { 2, 8 } };
            Assert.That(Fracts.convertFrac(lst), Is.EqualTo("(6,12)(4,12)(3,12)"));
        }

        [Test]
        public void ComputeGCD_Works()
        {
            Assert.That(Fracts.ComputeGCD(18, 48), Is.EqualTo(6));
            Assert.That(Fracts.ComputeGCD(5, 5), Is.EqualTo(5));
            Assert.That(Fracts.ComputeGCD(13, 17), Is.EqualTo(1));
        }

        [Test]
        public void ComputeLCM_WithTwoNumbers_Works()
        {
            Assert.That(Fracts.ComputeLCM(4, 6), Is.EqualTo(12));
            Assert.That(Fracts.ComputeLCM(5, 7), Is.EqualTo(35));
            Assert.That(Fracts.ComputeLCM(10, 10), Is.EqualTo(10));
        }

        [Test]
        public void ComputeLCM_WithMultipleNumbers_Works()
        {
            Assert.That(Fracts.ComputeLCM(new long[] { 4, 6, 12 }), Is.EqualTo(12));
            Assert.That(Fracts.ComputeLCM(new long[] { 2, 10, 25 }), Is.EqualTo(50));
            Assert.That(Fracts.ComputeLCM(new long[] { 3, 5, 7 }), Is.EqualTo(105));
        }
    }
}

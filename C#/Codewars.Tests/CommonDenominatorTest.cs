namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CommonDenominatorTest
    {
        [Test]
        public void ConvertFrac_NonReducibleFractions()
        {
            long[,] lst = new long[,] { { 1, 2 }, { 1, 3 }, { 1, 4 } };
            Assert.AreEqual("(6,12)(4,12)(3,12)", Fracts.convertFrac(lst));
        }

        [Test]
        public void ConvertFrac_ReducibleFractions()
        {
            long[,] lst = new long[,] { { 2, 4 }, { 2, 6 }, { 2, 8 } };
            Assert.AreEqual("(6,12)(4,12)(3,12)", Fracts.convertFrac(lst));
        }

        [Test]
        public void ComputeGCD_Works()
        {
            Assert.AreEqual(6, Fracts.ComputeGCD(18, 48));
            Assert.AreEqual(5, Fracts.ComputeGCD(5, 5));
            Assert.AreEqual(1, Fracts.ComputeGCD(13, 17));
        }

        [Test]
        public void ComputeLCM_WithTwoNumbers_Works()
        {
            Assert.AreEqual(12, Fracts.ComputeLCM(4, 6));
            Assert.AreEqual(35, Fracts.ComputeLCM(5, 7));
            Assert.AreEqual(10, Fracts.ComputeLCM(10, 10));
        }

        [Test]
        public void ComputeLCM_WithMultipleNumbers_Works()
        {
            Assert.AreEqual(12, Fracts.ComputeLCM(new long[] { 4, 6, 12 }));
            Assert.AreEqual(50, Fracts.ComputeLCM(new long[] { 2, 10, 25 }));
            Assert.AreEqual(105, Fracts.ComputeLCM(new long[] { 3, 5, 7 }));
        }
    }
}

namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class RangeExtractionTest
    {
        [Test(Description = "Simple tests")]
        public void SimpleTests()
        {
            Assert.That(RangeExtraction.Extract([1, 2]), Is.EqualTo("1,2"));
            Assert.That(RangeExtraction.Extract([1, 2, 3]), Is.EqualTo("1-3"));

            Assert.That(
                RangeExtraction.Extract([-6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20])
, Is.EqualTo("-6,-3-1,3-5,7-11,14,15,17-20"));

            Assert.That(
                RangeExtraction.Extract([-3, -2, -1, 2, 10, 15, 16, 18, 19, 20])
, Is.EqualTo("-3--1,2,10,15,16,18-20"));
        }
    }
}

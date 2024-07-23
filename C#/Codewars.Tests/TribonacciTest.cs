namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class XbonacciTest
    {
        private Xbonacci? variabonacci;

        [SetUp]
        public void SetUp()
        {
            variabonacci = new Xbonacci();
        }

        [TearDown]
        public void TearDown()
        {
            variabonacci = null;
        }

        [Test]
        public void Tests()
        {
            Assert.That(variabonacci?.Tribonacci(new double[] { 1, 1, 1 }, 10), Is.EqualTo(new double[] { 1, 1, 1, 3, 5, 9, 17, 31, 57, 105 }));
            Assert.That(variabonacci?.Tribonacci(new double[] { 0, 0, 1 }, 10), Is.EqualTo(new double[] { 0, 0, 1, 1, 2, 4, 7, 13, 24, 44 }));
            Assert.That(variabonacci?.Tribonacci(new double[] { 0, 1, 1 }, 10), Is.EqualTo(new double[] { 0, 1, 1, 2, 4, 7, 13, 24, 44, 81 }));
        }
    }
}

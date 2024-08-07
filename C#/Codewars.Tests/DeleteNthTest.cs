namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DeleteNthTest
    {
        [Test]
        public void TestSimple()
        {
            var expected = new int[] { 20, 37, 21 };

            var actual = Kata.DeleteNth([20, 37, 20, 21], 1);

            Assert.That(actual, Is.EqualTo(expected).AsCollection);
        }

        [Test]
        public void TestSimple2()
        {
            var expected = new int[] { 1, 1, 3, 3, 7, 2, 2, 2 };

            var actual = Kata.DeleteNth([1, 1, 3, 3, 7, 2, 2, 2, 2], 3);

            Assert.That(actual, Is.EqualTo(expected).AsCollection);
        }
    }
}

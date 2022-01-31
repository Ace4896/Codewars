namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class MakeNegativeTest
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(-42, Kata.MakeNegative(42));
            Assert.AreEqual(-727, Kata.MakeNegative(-727));
        }
    }
}

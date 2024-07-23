namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class MakeNegativeTest
    {
        [Test]
        public void Test1()
        {
            Assert.That(Kata.MakeNegative(42), Is.EqualTo(-42));
            Assert.That(Kata.MakeNegative(-727), Is.EqualTo(-727));
        }
    }
}

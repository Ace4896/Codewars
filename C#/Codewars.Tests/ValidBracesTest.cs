namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ValidBraceTests
    {
        [Test]
        public void Test1()
        {
            Assert.That(Brace.validBraces("()"), Is.EqualTo(true));
        }

        [Test]
        public void Test2()
        {

            Assert.That(Brace.validBraces("[(])"), Is.EqualTo(false));
        }
    }
}

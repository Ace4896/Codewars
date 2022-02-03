namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ValidBraceTests
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(true, Brace.validBraces("()"));
        }

        [Test]
        public void Test2()
        {

            Assert.AreEqual(false, Brace.validBraces("[(])"));
        }
    }
}

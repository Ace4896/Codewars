namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class ValidBraceTests
    {
        [Test]
        public void Test1()
        {
            ClassicAssert.AreEqual(true, Brace.validBraces("()"));
        }

        [Test]
        public void Test2()
        {

            ClassicAssert.AreEqual(false, Brace.validBraces("[(])"));
        }
    }
}

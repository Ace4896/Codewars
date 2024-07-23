namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class MakeNegativeTest
    {
        [Test]
        public void Test1()
        {
            ClassicAssert.AreEqual(-42, Kata.MakeNegative(42));
            ClassicAssert.AreEqual(-727, Kata.MakeNegative(-727));
        }
    }
}

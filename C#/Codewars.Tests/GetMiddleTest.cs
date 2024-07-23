namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class GetMiddleTest
    {
        [Test]
        public void GenericTests()
        {
            ClassicAssert.AreEqual("es", Kata.GetMiddle("test"));
            ClassicAssert.AreEqual("t", Kata.GetMiddle("testing"));
            ClassicAssert.AreEqual("dd", Kata.GetMiddle("middle"));
            ClassicAssert.AreEqual("A", Kata.GetMiddle("A"));
        }
    }
}

namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class YouOnlyNeedOneTest
    {
        [Test]
        public void BasicTests()
        {
            ClassicAssert.AreEqual(true, Kata.Check(new object[] { 66, 101 }, 66));
            ClassicAssert.AreEqual(true, Kata.Check(new object[] { 80, 117, 115, 104, 45, 85, 112, 115 }, 45));

            ClassicAssert.AreEqual(true, Kata.Check(new object[] { 't', 'e', 's', 't' }, 'e'));
            ClassicAssert.AreEqual(false, Kata.Check(new object[] { "what", "a", "great", "kata" }, "kat"));
        }
    }
}

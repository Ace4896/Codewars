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
            Assert.That(Kata.Check(new object[] { 66, 101 }, 66), Is.EqualTo(true));
            Assert.That(Kata.Check(new object[] { 80, 117, 115, 104, 45, 85, 112, 115 }, 45), Is.EqualTo(true));

            Assert.That(Kata.Check(new object[] { 't', 'e', 's', 't' }, 'e'), Is.EqualTo(true));
            Assert.That(Kata.Check(new object[] { "what", "a", "great", "kata" }, "kat"), Is.EqualTo(false));
        }
    }
}

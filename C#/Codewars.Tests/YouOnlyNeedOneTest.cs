namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class YouOnlyNeedOneTest
    {
        [Test]
        public void BasicTests()
        {
            Assert.That(Kata.Check([66, 101], 66), Is.EqualTo(true));
            Assert.That(Kata.Check([80, 117, 115, 104, 45, 85, 112, 115], 45), Is.EqualTo(true));

            Assert.That(Kata.Check(['t', 'e', 's', 't'], 'e'), Is.EqualTo(true));
            Assert.That(Kata.Check(["what", "a", "great", "kata"], "kat"), Is.EqualTo(false));
        }
    }
}

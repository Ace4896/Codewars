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
            Assert.That(Kata.GetMiddle("test"), Is.EqualTo("es"));
            Assert.That(Kata.GetMiddle("testing"), Is.EqualTo("t"));
            Assert.That(Kata.GetMiddle("middle"), Is.EqualTo("dd"));
            Assert.That(Kata.GetMiddle("A"), Is.EqualTo("A"));
        }
    }
}

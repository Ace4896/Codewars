namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class AssembleStringTest
    {
        [Test]
        public void SampleTests()
        {
            Assert.That(Kata.Assemble(new string[] { "a*cde", "*bcde", "abc*e" }), Is.EqualTo("abcde"));
            Assert.That(Kata.Assemble(new string[] { "a*c**", "**cd*", "a*cd*" }), Is.EqualTo("a#cd#"));
            Assert.That(Kata.Assemble(new string[] { "*ashtag ** *", "h*sht*g *> *", "has*tag -* *" }), Is.EqualTo("hashtag -> #"));
        }

        [Test]
        public void SpecialTests()
        {
            Assert.That(Kata.Assemble(new string[] { "abcde", "abcde", "abcbe" }), Is.EqualTo("abcde"));
            Assert.That(Kata.Assemble(new string[] { "*****", "*****", "*****" }), Is.EqualTo("#####"));
            Assert.That(Kata.Assemble(new string[0]), Is.EqualTo(""));
            Assert.That(Kata.Assemble(new string[] { "", "", "" }), Is.EqualTo(""));
        }
    }
}

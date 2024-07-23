namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class AssembleStringTest
    {
        [Test]
        public void SampleTests()
        {
            Assert.That(Kata.Assemble(["a*cde", "*bcde", "abc*e"]), Is.EqualTo("abcde"));
            Assert.That(Kata.Assemble(["a*c**", "**cd*", "a*cd*"]), Is.EqualTo("a#cd#"));
            Assert.That(Kata.Assemble(["*ashtag ** *", "h*sht*g *> *", "has*tag -* *"]), Is.EqualTo("hashtag -> #"));
        }

        [Test]
        public void SpecialTests()
        {
            Assert.That(Kata.Assemble(["abcde", "abcde", "abcbe"]), Is.EqualTo("abcde"));
            Assert.That(Kata.Assemble(["*****", "*****", "*****"]), Is.EqualTo("#####"));
            Assert.That(Kata.Assemble([]), Is.EqualTo(""));
            Assert.That(Kata.Assemble(["", "", ""]), Is.EqualTo(""));
        }
    }
}

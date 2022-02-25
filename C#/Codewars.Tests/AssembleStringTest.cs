namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class AssembleStringTest
    {
        [Test]
        public void SampleTests()
        {
            Assert.AreEqual("abcde", Kata.Assemble(new string[] { "a*cde", "*bcde", "abc*e" }));
            Assert.AreEqual("a#cd#", Kata.Assemble(new string[] { "a*c**", "**cd*", "a*cd*" }));
            Assert.AreEqual("hashtag -> #", Kata.Assemble(new string[] { "*ashtag ** *", "h*sht*g *> *", "has*tag -* *" }));
        }

        [Test]
        public void SpecialTests()
        {
            Assert.AreEqual("abcde", Kata.Assemble(new string[] { "abcde", "abcde", "abcbe" }));
            Assert.AreEqual("#####", Kata.Assemble(new string[] { "*****", "*****", "*****" }));
            Assert.AreEqual("", Kata.Assemble(new string[0]));
            Assert.AreEqual("", Kata.Assemble(new string[] { "", "", "" }));
        }
    }
}

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
            ClassicAssert.AreEqual("abcde", Kata.Assemble(new string[] { "a*cde", "*bcde", "abc*e" }));
            ClassicAssert.AreEqual("a#cd#", Kata.Assemble(new string[] { "a*c**", "**cd*", "a*cd*" }));
            ClassicAssert.AreEqual("hashtag -> #", Kata.Assemble(new string[] { "*ashtag ** *", "h*sht*g *> *", "has*tag -* *" }));
        }

        [Test]
        public void SpecialTests()
        {
            ClassicAssert.AreEqual("abcde", Kata.Assemble(new string[] { "abcde", "abcde", "abcbe" }));
            ClassicAssert.AreEqual("#####", Kata.Assemble(new string[] { "*****", "*****", "*****" }));
            ClassicAssert.AreEqual("", Kata.Assemble(new string[0]));
            ClassicAssert.AreEqual("", Kata.Assemble(new string[] { "", "", "" }));
        }
    }
}

namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class TextJustifyTest
    {
        [Test]
        public void OneWordLines()
        {
            Assert.AreEqual("aaaaa\nbbbbb", Kata.Justify("aaaaa bbbbb", 10));
        }

        [Test]
        public void TwoWordLines()
        {
            Assert.AreEqual("123  45\n6", Kata.Justify("123 45 6", 7));
        }

        [Test]
        public void MultipleWordsPerLine()
        {
            Assert.AreEqual("aaa   bbb  c\ndddd", Kata.Justify("aaa bbb c dddd", 12));
            Assert.AreEqual(
                "Lorem     ipsum\ndolor sit amet,\nconsectetur\nadipiscing\nelit.",
                Kata.Justify("Lorem ipsum dolor sit amet, consectetur adipiscing elit.", 15));
        }

        [Test]
        public void EdgeCases()
        {
            Assert.AreEqual(string.Empty, Kata.Justify(string.Empty, 2));
            Assert.AreEqual(string.Empty, Kata.Justify(string.Empty, 123));
        }
    }
}

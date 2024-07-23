namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class TextJustifyTest
    {
        [Test]
        public void OneWordLines()
        {
            Assert.That(Kata.Justify("aaaaa bbbbb", 10), Is.EqualTo("aaaaa\nbbbbb"));
        }

        [Test]
        public void TwoWordLines()
        {
            Assert.That(Kata.Justify("123 45 6", 7), Is.EqualTo("123  45\n6"));
        }

        [Test]
        public void MultipleWordsPerLine()
        {
            Assert.That(Kata.Justify("aaa bbb c dddd", 12), Is.EqualTo("aaa   bbb  c\ndddd"));
            Assert.That(
                Kata.Justify("Lorem ipsum dolor sit amet, consectetur adipiscing elit.", 15), Is.EqualTo("Lorem     ipsum\ndolor sit amet,\nconsectetur\nadipiscing\nelit."));
        }

        [Test]
        public void EdgeCases()
        {
            Assert.That(Kata.Justify(string.Empty, 2), Is.EqualTo(string.Empty));
            Assert.That(Kata.Justify(string.Empty, 123), Is.EqualTo(string.Empty));
        }
    }
}

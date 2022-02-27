namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class SortInnerContentTest
    {
        [Test]
        public void ExampleTests()
        {
            Assert.AreEqual("srot the inner ctonnet in dsnnieedcg oredr", Kata.SortTheInnerContent("sort the inner content in descending order"));
            Assert.AreEqual("wiat for me", Kata.SortTheInnerContent("wait for me"));
            Assert.AreEqual("tihs ktaa is esay", Kata.SortTheInnerContent("this kata is easy"));
        }
    }
}

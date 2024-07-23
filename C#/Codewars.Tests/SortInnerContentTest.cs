namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class SortInnerContentTest
    {
        [Test]
        public void ExampleTests()
        {
            Assert.That(Kata.SortTheInnerContent("sort the inner content in descending order"), Is.EqualTo("srot the inner ctonnet in dsnnieedcg oredr"));
            Assert.That(Kata.SortTheInnerContent("wait for me"), Is.EqualTo("wiat for me"));
            Assert.That(Kata.SortTheInnerContent("this kata is easy"), Is.EqualTo("tihs ktaa is esay"));
        }
    }
}

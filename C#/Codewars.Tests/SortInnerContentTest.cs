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
            ClassicAssert.AreEqual("srot the inner ctonnet in dsnnieedcg oredr", Kata.SortTheInnerContent("sort the inner content in descending order"));
            ClassicAssert.AreEqual("wiat for me", Kata.SortTheInnerContent("wait for me"));
            ClassicAssert.AreEqual("tihs ktaa is esay", Kata.SortTheInnerContent("this kata is easy"));
        }
    }
}

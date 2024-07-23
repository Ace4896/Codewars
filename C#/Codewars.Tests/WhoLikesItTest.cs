namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class WhoLikesItTest
    {
        [Test, Description("It should return correct text")]
        public void SampleTest()
        {
            Assert.That(Kata.Likes(new string[0]), Is.EqualTo("no one likes this"));
            Assert.That(Kata.Likes(new string[] { "Peter" }), Is.EqualTo("Peter likes this"));
            Assert.That(Kata.Likes(new string[] { "Jacob", "Alex" }), Is.EqualTo("Jacob and Alex like this"));
            Assert.That(Kata.Likes(new string[] { "Max", "John", "Mark" }), Is.EqualTo("Max, John and Mark like this"));
            Assert.That(Kata.Likes(new string[] { "Alex", "Jacob", "Mark", "Max" }), Is.EqualTo("Alex, Jacob and 2 others like this"));
        }
    }
}

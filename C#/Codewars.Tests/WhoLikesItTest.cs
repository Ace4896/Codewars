namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WhoLikesItTest
    {
        [Test, Description("It should return correct text")]
        public void SampleTest()
        {
            Assert.That(Kata.Likes([]), Is.EqualTo("no one likes this"));
            Assert.That(Kata.Likes(["Peter"]), Is.EqualTo("Peter likes this"));
            Assert.That(Kata.Likes(["Jacob", "Alex"]), Is.EqualTo("Jacob and Alex like this"));
            Assert.That(Kata.Likes(["Max", "John", "Mark"]), Is.EqualTo("Max, John and Mark like this"));
            Assert.That(Kata.Likes(["Alex", "Jacob", "Mark", "Max"]), Is.EqualTo("Alex, Jacob and 2 others like this"));
        }
    }
}

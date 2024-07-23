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
            ClassicAssert.AreEqual("no one likes this", Kata.Likes(new string[0]));
            ClassicAssert.AreEqual("Peter likes this", Kata.Likes(new string[] { "Peter" }));
            ClassicAssert.AreEqual("Jacob and Alex like this", Kata.Likes(new string[] { "Jacob", "Alex" }));
            ClassicAssert.AreEqual("Max, John and Mark like this", Kata.Likes(new string[] { "Max", "John", "Mark" }));
            ClassicAssert.AreEqual("Alex, Jacob and 2 others like this", Kata.Likes(new string[] { "Alex", "Jacob", "Mark", "Max" }));
        }
    }
}

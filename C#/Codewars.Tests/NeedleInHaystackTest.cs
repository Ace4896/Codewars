namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class NeedleInHaystackTest
    {
        [Test]
        public void GenericTests()
        {
            var haystack_1 = new object[] { '3', "123124234", null!, "needle", "world", "hay", 2, '3', true, false };
            var haystack_2 = new object[] { "283497238987234", "a dog", "a cat", "some random junk", "a piece of hay", "needle", "something somebody lost a while ago" };
            var haystack_3 = new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 8, 7, 5, 4, 3, 4, 5, 6, 67, 5, 5, 3, 3, 4, 2, 34, 234, 23, 4, 234, 324, 324, "needle", 1, 2, 3, 4, 5, 5, 6, 5, 4, 32, 3, 45, 54 };

            Assert.That(Kata.FindNeedle(haystack_1), Is.EqualTo("found the needle at position 3"));
            Assert.That(Kata.FindNeedle(haystack_2), Is.EqualTo("found the needle at position 5"));
            Assert.That(Kata.FindNeedle(haystack_3), Is.EqualTo("found the needle at position 30"));
        }
    }
}

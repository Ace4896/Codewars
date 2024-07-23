namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class SumGroupsTest
    {
        [Test]
        public void BasicTests()
        {
            Assert.That(Kata.SumGroups([2, 1, 2, 2, 6, 5, 0, 2, 0, 5, 5, 7, 7, 4, 3, 3, 9]), Is.EqualTo(6));
            Assert.That(Kata.SumGroups([2, 1, 2, 2, 6, 5, 0, 2, 0, 3, 3, 3, 9, 2]), Is.EqualTo(5));
            Assert.That(Kata.SumGroups([1]), Is.EqualTo(1));
            Assert.That(Kata.SumGroups([2]), Is.EqualTo(1));
            Assert.That(Kata.SumGroups([1, 2]), Is.EqualTo(2));
            Assert.That(Kata.SumGroups([1, 1, 2, 2]), Is.EqualTo(1));
        }
    }
}

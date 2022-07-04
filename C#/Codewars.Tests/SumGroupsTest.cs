namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class SumGroupsTest
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(6, Kata.SumGroups(new int[] { 2, 1, 2, 2, 6, 5, 0, 2, 0, 5, 5, 7, 7, 4, 3, 3, 9 }));
            Assert.AreEqual(5, Kata.SumGroups(new int[] { 2, 1, 2, 2, 6, 5, 0, 2, 0, 3, 3, 3, 9, 2 }));
            Assert.AreEqual(1, Kata.SumGroups(new int[] { 1 }));
            Assert.AreEqual(1, Kata.SumGroups(new int[] { 2 }));
            Assert.AreEqual(2, Kata.SumGroups(new int[] { 1, 2 }));
            Assert.AreEqual(1, Kata.SumGroups(new int[] { 1, 1, 2, 2 }));
        }
    }
}

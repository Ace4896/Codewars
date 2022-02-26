namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class SortOneThreeTwoTest
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(new[] { 8, 8, 9, 9, 10, 10, 0 }, Dinglemouse.Sort(new[] { 0, 8, 8, 9, 9, 10, 10 }));
            Assert.AreEqual(new[] { 4, 1, 3, 2 }, Dinglemouse.Sort(new[] { 1, 2, 3, 4 }));
            Assert.AreEqual(new[] { 9, 999, 99 }, Dinglemouse.Sort(new[] { 9, 99, 999 }));
        }
    }
}

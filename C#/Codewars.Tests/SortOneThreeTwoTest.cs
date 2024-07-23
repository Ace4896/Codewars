namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class SortOneThreeTwoTest
    {
        [Test]
        public void Test()
        {
            ClassicAssert.AreEqual(new[] { 8, 8, 9, 9, 10, 10, 0 }, Dinglemouse.Sort(new[] { 0, 8, 8, 9, 9, 10, 10 }));
            ClassicAssert.AreEqual(new[] { 4, 1, 3, 2 }, Dinglemouse.Sort(new[] { 1, 2, 3, 4 }));
            ClassicAssert.AreEqual(new[] { 9, 999, 99 }, Dinglemouse.Sort(new[] { 9, 99, 999 }));
        }
    }
}

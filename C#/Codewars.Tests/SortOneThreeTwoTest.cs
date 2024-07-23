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
            Assert.That(Dinglemouse.Sort(new[] { 0, 8, 8, 9, 9, 10, 10 }), Is.EqualTo(new[] { 8, 8, 9, 9, 10, 10, 0 }));
            Assert.That(Dinglemouse.Sort(new[] { 1, 2, 3, 4 }), Is.EqualTo(new[] { 4, 1, 3, 2 }));
            Assert.That(Dinglemouse.Sort(new[] { 9, 99, 999 }), Is.EqualTo(new[] { 9, 999, 99 }));
        }
    }
}

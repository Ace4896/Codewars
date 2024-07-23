namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class SumGroupsTest
    {
        [Test]
        public void BasicTests()
        {
            ClassicAssert.AreEqual(6, Kata.SumGroups(new int[] { 2, 1, 2, 2, 6, 5, 0, 2, 0, 5, 5, 7, 7, 4, 3, 3, 9 }));
            ClassicAssert.AreEqual(5, Kata.SumGroups(new int[] { 2, 1, 2, 2, 6, 5, 0, 2, 0, 3, 3, 3, 9, 2 }));
            ClassicAssert.AreEqual(1, Kata.SumGroups(new int[] { 1 }));
            ClassicAssert.AreEqual(1, Kata.SumGroups(new int[] { 2 }));
            ClassicAssert.AreEqual(2, Kata.SumGroups(new int[] { 1, 2 }));
            ClassicAssert.AreEqual(1, Kata.SumGroups(new int[] { 1, 1, 2, 2 }));
        }
    }
}

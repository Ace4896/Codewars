namespace Codewars.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class SortByLevelsTest
    {
        [Test]
        public void NullTest()
        {
            ClassicAssert.AreEqual(new List<int>(), Kata.TreeByLevels(null));
        }

        [Test]
        public void BasicTest()
        {
            ClassicAssert.AreEqual(
                new List<int>() { 1, 2, 3, 4, 5, 6 },
                Kata.TreeByLevels(new Node(new Node(null, new Node(null, null, 4), 2), new Node(new Node(null, null, 5), new Node(null, null, 6), 3), 1))
            );
        }
    }
}

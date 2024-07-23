namespace Codewars.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class SortByLevelsTest
    {
        [Test]
        public void NullTest()
        {
            Assert.That(Kata.TreeByLevels(null), Is.EqualTo(new List<int>()));
        }

        [Test]
        public void BasicTest()
        {
            Assert.That(
                Kata.TreeByLevels(new Node(new Node(null, new Node(null, null, 4), 2), new Node(new Node(null, null, 5), new Node(null, null, 6), 3), 1))
, Is.EqualTo(new List<int>() { 1, 2, 3, 4, 5, 6 }));
        }
    }
}

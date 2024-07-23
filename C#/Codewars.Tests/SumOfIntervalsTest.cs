namespace Codewars.Tests
{
    using NUnit.Framework;
    using System;

    using Interval = System.ValueTuple<int, int>;

    public class IntervalTest
    {
        [Test]
        public void ShouldHandleEmptyIntervals()
        {
            Assert.That(Intervals.SumIntervals(Array.Empty<(int, int)>()), Is.EqualTo(0));
            Assert.That(Intervals.SumIntervals([(4, 4), (6, 6), (8, 8)]), Is.EqualTo(0));
        }

        [Test]
        public void ShouldAddDisjoinedIntervals()
        {
            Assert.That(Intervals.SumIntervals([(1, 2), (6, 10), (11, 15)]), Is.EqualTo(9));
            Assert.That(Intervals.SumIntervals([(4, 8), (9, 10), (15, 21)]), Is.EqualTo(11));
            Assert.That(Intervals.SumIntervals([(-1, 4), (-5, -3)]), Is.EqualTo(7));
            Assert.That(Intervals.SumIntervals([(-245, -218), (-194, -179), (-155, -119)]), Is.EqualTo(78));
        }

        [Test]
        public void ShouldAddAdjacentIntervals()
        {
            Assert.That(Intervals.SumIntervals([(1, 2), (2, 6), (6, 55)]), Is.EqualTo(54));
            Assert.That(Intervals.SumIntervals([(-2, -1), (-1, 0), (0, 21)]), Is.EqualTo(23));
        }

        [Test]
        public void ShouldAddOverlappingIntervals()
        {
            //ClassicAssert.AreEqual(7, Intervals.SumIntervals(new Interval[] { (1, 4), (7, 10), (3, 5) }));
            //ClassicAssert.AreEqual(6, Intervals.SumIntervals(new Interval[] { (5, 8), (3, 6), (1, 2) }));
            Assert.That(Intervals.SumIntervals([(1, 5), (10, 20), (1, 6), (16, 19), (5, 11)]), Is.EqualTo(19));
        }

        [Test]
        public void ShouldHandleMixedIntervals()
        {
            Assert.That(Intervals.SumIntervals([(2, 5), (-1, 2), (-40, -35), (6, 8)]), Is.EqualTo(13));
            Assert.That(Intervals.SumIntervals([(-7, 8), (-2, 10), (5, 15), (2000, 3150), (-5400, -5338)]), Is.EqualTo(1234));
            Assert.That(Intervals.SumIntervals([(-101, 24), (-35, 27), (27, 53), (-105, 20), (-36, 26)]), Is.EqualTo(158));
        }
    }

}

namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;
    using System;

    using Interval = System.ValueTuple<int, int>;

    public class IntervalTest
    {
        [Test]
        public void ShouldHandleEmptyIntervals()
        {
            ClassicAssert.AreEqual(0, Intervals.SumIntervals(Array.Empty<(int, int)>()));
            ClassicAssert.AreEqual(0, Intervals.SumIntervals(new Interval[] { (4, 4), (6, 6), (8, 8) }));
        }

        [Test]
        public void ShouldAddDisjoinedIntervals()
        {
            ClassicAssert.AreEqual(9, Intervals.SumIntervals(new Interval[] { (1, 2), (6, 10), (11, 15) }));
            ClassicAssert.AreEqual(11, Intervals.SumIntervals(new Interval[] { (4, 8), (9, 10), (15, 21) }));
            ClassicAssert.AreEqual(7, Intervals.SumIntervals(new Interval[] { (-1, 4), (-5, -3) }));
            ClassicAssert.AreEqual(78, Intervals.SumIntervals(new Interval[] { (-245, -218), (-194, -179), (-155, -119) }));
        }

        [Test]
        public void ShouldAddAdjacentIntervals()
        {
            ClassicAssert.AreEqual(54, Intervals.SumIntervals(new Interval[] { (1, 2), (2, 6), (6, 55) }));
            ClassicAssert.AreEqual(23, Intervals.SumIntervals(new Interval[] { (-2, -1), (-1, 0), (0, 21) }));
        }

        [Test]
        public void ShouldAddOverlappingIntervals()
        {
            //ClassicAssert.AreEqual(7, Intervals.SumIntervals(new Interval[] { (1, 4), (7, 10), (3, 5) }));
            //ClassicAssert.AreEqual(6, Intervals.SumIntervals(new Interval[] { (5, 8), (3, 6), (1, 2) }));
            ClassicAssert.AreEqual(19, Intervals.SumIntervals(new Interval[] { (1, 5), (10, 20), (1, 6), (16, 19), (5, 11) }));
        }

        [Test]
        public void ShouldHandleMixedIntervals()
        {
            ClassicAssert.AreEqual(13, Intervals.SumIntervals(new Interval[] { (2, 5), (-1, 2), (-40, -35), (6, 8) }));
            ClassicAssert.AreEqual(1234, Intervals.SumIntervals(new Interval[] { (-7, 8), (-2, 10), (5, 15), (2000, 3150), (-5400, -5338) }));
            ClassicAssert.AreEqual(158, Intervals.SumIntervals(new Interval[] { (-101, 24), (-35, 27), (27, 53), (-105, 20), (-36, 26) }));
        }
    }

}

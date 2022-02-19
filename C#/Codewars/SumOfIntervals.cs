// Goal of this one is to sum all of the interval lengths.
// Overlapping intervals should be merged (so the interval length only counts once).

namespace Codewars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Intervals
    {
        public static int SumIntervals((int, int)[] intervals)
        {
            // Merge as many intervals as possible
            // To make merging easier, sort them in ascending order (by start index, then by end index)
            var sorted = intervals
                .OrderBy(i => i.Item1)
                .ThenBy(i => i.Item2)
                .Distinct()
                .ToArray();

            var output = new List<(int, int)>();
            for (int i = 0; i < sorted.Length; i++)
            {
                // If we have two adjacent intervals that can be merged, see if we can also merge any more
                if (i + 1 < sorted.Length && sorted[i].Item2 >= sorted[i + 1].Item1)
                {
                    var current = sorted[i];
                    var offset = 1;
                    while (i + offset < sorted.Length && current.Item2 >= sorted[i + offset].Item1)
                    {
                        current.Item2 = Math.Max(current.Item2, sorted[i + offset].Item2);
                        offset += 1;
                    }

                    output.Add(current);
                    i += offset - 1;
                }
                else
                {
                    output.Add(sorted[i]);
                }
            }

            return output
                .Select(interval => interval.Item2 - interval.Item1)
                .Sum();
        }
    }
}

// Goal for this one is to delete occurrences of an element if it occurs more than n times in the array.

namespace Codewars
{
    using System.Collections.Generic;

    public static partial class Kata
    {
        public static int[] DeleteNth(int[] arr, int x)
        {
            var count = new Dictionary<int, int>();
            var output = new List<int>();

            foreach (var item in arr)
            {
                if (!count.ContainsKey(item))
                {
                    count[item] = 1;
                    output.Add(item);
                }
                else if (count[item] < x)
                {
                    count[item] += 1;
                    output.Add(item);
                }
            }

            return output.ToArray();
        }
    }
}

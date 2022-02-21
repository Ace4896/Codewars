// Goal of this one is to find the maximum sum of a continguous subsequence in the given array.
// https://www.codewars.com/kata/54521e9ec8e60bc4de000d6c/train/csharp

namespace Codewars
{
    using System;
    using System.Linq;

    public static partial class Kata
    {
        public static int MaxSequence(int[] arr)
        {
            if (arr.Length == 0)
            {
                return 0;
            }

            // Start with maximum value for subsequence of length 1
            var max = arr.Max();
            for (int length = 2; length <= arr.Length; length++)
            {
                for (int i = 0; i <= arr.Length - length; i++)
                {
                    max = Math.Max(max, arr.Skip(i).Take(length).Sum());
                }
            }

            return max;
        }
    }
}

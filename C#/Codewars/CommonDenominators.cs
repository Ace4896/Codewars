// Goal of this one is to convert all fractions so that they have the lowest common denominator.
// https://www.codewars.com/kata/54d7660d2daf68c619000d95/train/csharp

namespace Codewars
{
    using System.Text;

    public class Fracts
    {
        // NOTE: The comma indicates that this is a 2D array
        public static string convertFrac(long[,] lst)
        {
            var n = lst.GetLength(0);
            if (n == 0)
            {
                return string.Empty;
            }
            if (n == 1)
            {
                return $"({lst[0, 0]}, {lst[0, 1]})";
            }

            var denominators = new long[n];

            // Reduce each input fraction, and note down the reduced denominator
            for (int i = 0; i < n; i++)
            {
                var gcd = ComputeGCD(lst[i, 0], lst[i, 1]);
                lst[i, 0] /= gcd;
                lst[i, 1] /= gcd;
                denominators[i] = lst[i, 1];
            }

            // Find the LCM of these denominators so we can convert each fraction
            var lcm = ComputeLCM(denominators);
            var sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var newNumerator = lst[i, 0] * (lcm / lst[i, 1]);
                sb.Append($"({newNumerator},{lcm})");
            }

            return sb.ToString();
        }

        // Euclidean algorithm for finding GCD - needed for reducing input fractions
        public static long ComputeGCD(long x, long y)
        {
            // a = larger value, b = smaller value
            (var a, var b) = x > y ? (x, y) : (y, x);
            long tmp;

            do
            {
                tmp = a % b;
                a = b;
                b = tmp;
            } while (tmp > 0);

            return a;
        }

        // Computes LCM of two numbers using GCD
        public static long ComputeLCM(long x, long y) => x * y / ComputeGCD(x, y);
        public static long ComputeLCM(long[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }

            var lcm = ComputeLCM(nums[0], nums[1]);
            for (int i = 2; i < nums.Length; i++)
            {
                lcm = ComputeLCM(lcm, nums[i]);
            }

            return lcm;
        }
    }
}

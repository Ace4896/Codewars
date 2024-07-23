// Goal of this one is to sort numbers by their english word equivalent.

namespace Codewars
{
    using System.Collections.Generic;
    using System.Linq;

    public class Dinglemouse
    {
        private static readonly string[] belowTwenty = [
            "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
            "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
        ];

        private static readonly string[] tens = [
            "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
        ];

        public static int[] Sort(int[] array)
        {
            return array.Select(n => new { Num = n, Words = ToWords(n) })
                .OrderBy(nw => nw.Words)
                .Select(nw => nw.Num)
                .ToArray();
        }

        private static string ToWords(int n)
        {
            if (n == 0)
            {
                return "zero";
            }

            var output = new List<string>(3);
            if (n >= 100)
            {
                output.Add($"{belowTwenty[n / 100]} hundred");
                n %= 100;
            }

            if (n >= 20)
            {
                output.Add(tens[n / 10]);
                n %= 10;
            }

            if (n > 0)
            {
                output.Add(belowTwenty[n]);
            }

            return string.Join(" ", output);
        }
    }
}

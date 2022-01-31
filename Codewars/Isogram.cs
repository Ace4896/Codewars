// Isograms are words that contain no repeating letters, consecutive or non-consecutive.
// Goal for this one is to determine whether a string is an isogram.
// Other notes:
// - String only contains letters
// - Empty string is an isogram
// - Ignore letter case

namespace Codewars
{
    using System.Collections.Generic;

    public static partial class Kata
    {
        public static bool IsIsogram(string str)
        {
            var usedLetters = new HashSet<char>(26);

            foreach (char c in str)
            {
                var lowerCase = char.ToLowerInvariant(c);
                if (usedLetters.Contains(lowerCase))
                {
                    return false;
                }

                usedLetters.Add(lowerCase);
            }

            return true;
        }
    }
}

// Goal of this one is to remove all vowels in the provided string.

namespace Codewars
{
    using System.Collections.Generic;
    using System.Linq;

    public static partial class Kata
    {
        private static readonly HashSet<char> VOWELS = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
        private static bool IsVowel(char c) => VOWELS.Contains(char.ToLowerInvariant(c));

        public static string Disemvowel(string str) => string.Join("", str.Where(c => !IsVowel(c)));
    }
}

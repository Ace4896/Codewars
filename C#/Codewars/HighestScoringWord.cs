// Goal of this one is to score each word in a string based on their alphabet position (a = 1, b = 2 etc.)
// Then return the word with the highest score

namespace Codewars
{
    using System.Linq;

    public static partial class Kata
    {
        public static string High(string s)
        {
            var max = 0;
            var maxWord = "";

            foreach (var word in s.Split(' '))
            {
                var score = word.Select(c => c - 'a' + 1).Sum();
                if (score > max)
                {
                    max = score;
                    maxWord = word;
                }
            }

            return maxWord;
        }
    }
}

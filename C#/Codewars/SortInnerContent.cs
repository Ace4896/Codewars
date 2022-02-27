namespace Codewars
{
    using System.Linq;

    public static partial class Kata
    {
        public static string SortTheInnerContent(string words)
        {
            return string.Join(" ", words.Split(' ').Select(SortWord));
        }

        private static string SortWord(string word)
        {
            if (word.Length <= 2)
            {
                return word;
            }

            var chars = word.ToCharArray().Skip(1).SkipLast(1);
            var innerContent = string.Concat(chars.OrderByDescending(c => c));

            return word[0] + innerContent + word[word.Length - 1];
        }
    }
}

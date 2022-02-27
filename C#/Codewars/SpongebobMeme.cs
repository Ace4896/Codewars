namespace Codewars
{
    using System.Linq;

    public static partial class Kata
    {
        public static string SpongeMeme(string sentence)
        {
            // NOTE: Select can also take the index into account - no need to create a separate enumerable
            return string.Concat(
                sentence.Select((ch, index) => index % 2 == 0 ? char.ToUpper(ch) : char.ToLower(ch))
            );
        }
    }
}

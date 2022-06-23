namespace Codewars
{
    using System.Linq;

    public static partial class Kata
    {
        // Not sure why this counts as 5 kyu, but oh well...
        public static bool Alphanumeric(string str) => !string.IsNullOrEmpty(str) && str.All(char.IsLetterOrDigit);
    }
}

// Goal of this one is to get the middle character in a string (or middle two characters for even length strings).

namespace Codewars
{
    public static partial class Kata
    {
        public static string GetMiddle(string s)
        {
            var mid = s.Length / 2;
            return s.Length % 2 == 0
                ? s.Substring(mid - 1, 2)
                : s.Substring(mid, 1);
        }
    }
}

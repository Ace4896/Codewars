// Goal of this one is to find the "needle" (a string) in a "haystack" (an array of strings).

namespace Codewars
{
    public static partial class Kata
    {
        public static string FindNeedle(object[] haystack)
        {
            // Alternate Solution
            // Shorter, and in this problem the needle is always present
            // return $"found the needle at position {System.Array.IndexOf(haystack, "needle")}";

            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] is string str && str == "needle")
                {
                    return $"found the needle at position {i}";
                }
            }

            return "";
        }
    }
}

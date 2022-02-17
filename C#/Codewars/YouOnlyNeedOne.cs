// Goal of this one is to check if an array contains the given value.

namespace Codewars
{
    using System.Linq;

    public static partial class Kata
    {
        public static bool Check(object[] a, object x) => a.Contains(x);
    }
}

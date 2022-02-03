// Goal of this one is to convert a name into initials.
// Always takes in a string with two names.

namespace Codewars
{
    using System.Linq;

    public static partial class Kata
    {
        public static string AbbrevName(string name) =>
            string.Join('.', name.Split(' ').Select(n => char.ToUpperInvariant(n.First())));
    }
}

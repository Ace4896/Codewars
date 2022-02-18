// Goal of this one is to use regex (or any other method) to validate a PIN.
// Valid PINs consist of 4 or 6 digits.

namespace Codewars
{
    using System.Text.RegularExpressions;

    public static partial class Kata
    {
        // This regex is super fiddly:
        // - There are edge cases with leading and trailing whitespace/newlines
        // - Leading whitespace is easy - ^ anchor deals with this
        // - Issue is trailing newlines:
        //   - $ matches \n, even in single line mode
        //   - \z doesn't match \n, which is what we need
        private static readonly Regex PIN_REGEX = new Regex(@"^(\d{4}|\d{6})\z", RegexOptions.Singleline | RegexOptions.Compiled);

        public static bool ValidatePin(string pin) => PIN_REGEX.IsMatch(pin);
    }
}

namespace Codewars
{
    using System.Text.RegularExpressions;

    public class BinaryRegex
    {
        /*
         * TODO: Something is missing in my theory - 101111000110000101001110 doesn't match
         * 
         * Explanation:
         * - Need ^ and $ so that it considers the whole line as a binary number, filtering out strings with invalid characters
         * - Breaking down 0*(10101(0101)*|1(00)*1)*0*:
         *   - Leading and trailing 0s are skipped by the 0* at the start and end - WIP: the trailing 0's might be important
         *   - 10101(0101)*: If we see a 1 and it's an alternating pattern of 1/0 like 1010101... there needs to be an odd number of 1's in this pattern for it to be divisible by 3
         *   - 1(00)*1: If we see a 1 with an even number of 0's in-between, then it's also divisible by 3
        */
        public static Regex MultipleOf3() => new("^0*(10101(0101)*|1(00)*1)*0*$");
    }
}

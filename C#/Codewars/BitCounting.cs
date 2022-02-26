// Goal of this one is to count the number of bits that are equal to 1 for the provided integer.

namespace Codewars
{
    public static partial class Kata
    {
        public static int CountBits(int n)
        {
            int total = 0;
            while (n > 0)
            {
                if ((n & 1) == 1)
                {
                    total++;
                }

                n >>= 1;
            }

            return total;
        }
    }
}

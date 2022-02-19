// Goal of this one is to calculate f(n), where n could be negative and can be as large as 200000.
// https://www.codewars.com/kata/53d40c1e2f13e331fc000c26/train/csharp

namespace Codewars
{
    using System.Numerics;

    public class Fibonacci
    {
        // https://en.wikipedia.org/wiki/Fibonacci_number#Matrix_form
        // Calculates (f(n - 1), f(n)) for n >= 1
        // This is done by halving n, then using the two identities for f(2n - 1), f(2n)
        private static (BigInteger, BigInteger) FibMatrix(int n)
        {
            if (n == 1)
            {
                return (BigInteger.Zero, BigInteger.One);
            }

            (var fnMinus1, var fn) = FibMatrix(n / 2);
            var f2nMinus1 = fn * fn + fnMinus1 * fnMinus1;
            var f2n = (2 * fnMinus1 + fn) * fn;

            if (n % 2 == 0)
            {
                return (f2nMinus1, f2n);
            }
            else
            {
                // If n was odd, then we calculated one too little - compensate for this
                return (f2n, f2nMinus1 + f2n);
            }
        }

        public static BigInteger fib(int n)
        {
            // Sample sequence for reference:
            //   n  | -4    -3    -2    -1    0    1    2    3    4  
            // f(n) | -3     2    -1     1    0    1    1    2    3
            //
            // From this, fib(n) is:
            //   f(n)       when n is non-negative
            //   f(-n)      when n is negative and odd
            //   -f(-n)     when n is negative and even
            //
            // Where f(k) is a function that calculates the kth fibonacci number for k > 0
            if (n == 0)
            {
                return BigInteger.Zero;
            }

            if (n < 0)
            {
                return n % 2 == 0
                    ? -FibMatrix(-n).Item2
                    : FibMatrix(-n).Item2;
            }

            return FibMatrix(n).Item2;
        }
    }
}

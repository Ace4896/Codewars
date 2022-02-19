// https://www.codewars.com/kata/54d496788776e49e6b00052f/train/csharp

namespace Codewars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfDivided
    {
        // Finds all of the primes up to (and including) n
        // Uses Sieve of Eratosthenes
        private static IEnumerable<int> FindPrimes(int n)
        {
            var rootN = (int)Math.Sqrt(n);
            var sieve = new bool[n - 1];    // Index 0: Indicates if 2 is prime
                                            // Index 1: Indicates if 3 is prime
                                            // Index n-2: Indicates if n is prime


            Array.Fill(sieve, true);

            for (int i = 2; i <= rootN; i++)
            {
                if (sieve[i - 2])
                {
                    for (int j = i * i; j <= n; j += i)
                    {
                        sieve[j - 2] = false;
                    }
                }
            }

            return Enumerable.Range(0, n - 1)
                .Where(i => sieve[i])
                .Select(i => i + 2);
        }

        public static string sumOfDivided(int[] input)
        {
            // First, find the primes up to the largest absolute value
            // Then, filter out primes that aren't factors of anything in the input
            // Finally, calculate the sum for each prime factor
            var max = input.Select(Math.Abs).Max();
            var primeSums = FindPrimes(max)
                .Where(p => input.Any(i => i % p == 0))
                .Select(p => $"({p} {input.Where(i => i % p == 0).Sum()})");

            return string.Concat(primeSums);
        }
    }
}

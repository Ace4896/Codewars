// https://www.codewars.com/kata/556deca17c58da83c00002db/train/csharp
// Goal of this one is to generate a Tribonacci sequence that starts with the provided signature.

namespace Codewars
{
    using System;
    using System.Linq;

    public class Xbonacci
    {
        public double[] Tribonacci(double[] signature, int n)
        {
            // Base case: avoid invalid values of n
            if (n <= 0)
            {
                return Array.Empty<double>();
            }

            // Base case: If signature is longer than n, take first n
            if (signature.Length > n)
            {
                return signature.Take(n).ToArray();
            }

            var result = new double[n];

            // Fill in starting signature values
            for (int i = 0; i < signature.Length; i++)
            {
                result[i] = signature[i];
            }

            // Start summing remaining values
            for (int i = signature.Length; i < n; i++)
            {
                result[i] = result[i - 1] + result[i - 2] + result[i - 3];
            }

            return result;
        }
    }
}

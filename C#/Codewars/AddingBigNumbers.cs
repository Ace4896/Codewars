// Goal of this one is to add together two very large positive integers.
// The inputs are passed in as a string.

namespace Codewars
{
    using System.Collections.Generic;

    public static partial class Kata
    {
        public static string Add(string a, string b)
        {
            // NOTE: C# has System.Numerics.BigInteger
            // But I just implemented something manually since it's a programming challenge...
            (string longer, string shorter) = a.Length >= b.Length ? (a, b) : (b, a);

            Stack<int> output = new Stack<int>(longer.Length + 1);
            int temp, shorterPos;
            int offset = longer.Length - shorter.Length;
            int carry = 0;

            for (int i = longer.Length - 1; i >= 0; i--)
            {
                temp = longer[i] - '0' + carry;
                shorterPos = i - offset;
                if (shorterPos >= 0)
                {
                    temp += shorter[shorterPos] - '0';
                }

                output.Push(temp % 10);
                carry = temp / 10;
            }

            if (carry > 0)
            {
                output.Push(carry);
            }

            return string.Concat(output);
        }
    }
}

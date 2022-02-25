namespace Codewars
{
    using System;

    public static partial class Kata
    {
        public static string Assemble(string[] copies)
        {
            if (copies.Length == 0 || copies[0].Length == 0)
            {
                return string.Empty;
            }

            var chars = new char[copies[0].Length];
            Array.Fill(chars, '#');

            foreach (var copy in copies)
            {
                for (int i = 0; i < copy.Length; i++)
                {
                    if (chars[i] == '#' && copy[i] != '*')
                    {
                        chars[i] = copy[i];
                    }
                }
            }

            return string.Concat(chars);
        }
    }
}

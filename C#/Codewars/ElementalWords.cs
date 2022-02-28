// https://www.codewars.com/kata/56fa9cd6da8ca623f9001233/train/csharp

namespace Codewars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ElementalWords
    {
        // NOTE: This requires a pre-loaded dictionary - local tests won't work
        // ELEMENTS["H"] == "Hydrogen"
        private static readonly Dictionary<string, string> ELEMENTS = new Dictionary<string, string>();

        public static string[][] ElementalForms(string word)
        {
            var output = new List<string[]>();

            // See if there's any symbols which can be used to start the word
            var startingElements = ELEMENTS.Keys
                .Where(sym => word.StartsWith(sym, StringComparison.InvariantCultureIgnoreCase))
                .ToArray();

            if (startingElements.Length == 0)
            {
                return Array.Empty<string[]>();
            }

            var prevElements = new List<string>();
            foreach (var element in startingElements)
            {
                var shortenedWord = word[element.Length..];
                prevElements.Add(element);

                FindForm(shortenedWord, output, prevElements);

                prevElements.RemoveAt(prevElements.Count - 1);
            }

            return output
                .Select(perm => perm
                    .Select(sym => $"{ELEMENTS[sym]} ({sym})")
                    .ToArray())
                .ToArray();
        }

        private static void FindForm(string word, List<string[]> output, List<string> prevElements)
        {
            // If the shortened word is empty, then we have a valid match
            if (word.Length == 0)
            {
                output.Add(prevElements.ToArray());
                return;
            }

            // Otherwise, look for more matches that work
            var startingElements = ELEMENTS.Keys
                .Where(sym => word.StartsWith(sym, StringComparison.InvariantCultureIgnoreCase));

            foreach (var element in startingElements)
            {
                var shortenedWord = word[element.Length..];
                prevElements.Add(element);

                FindForm(shortenedWord, output, prevElements);

                prevElements.RemoveAt(prevElements.Count - 1);
            }
        }
    }
}

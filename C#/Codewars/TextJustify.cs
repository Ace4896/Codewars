// Goal of this one is to convert a singleline string and apply "justify" formatting with the specified width.
// If there is only one word on a line, then no need to add spaces at the end.

namespace Codewars
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class Kata
    {
        public static string Justify(string str, int len)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return string.Empty;
            }

            var words = str.Split(' ');
            var lines = new List<string>();

            // Start with the first word on the first line
            var lineWords = new List<string>(new string[] { words[0] });
            var lineLen = words[0].Length;

            foreach (var word in words.Skip(1))
            {
                // Two cases for main loop
                // - If this word won't overflow the line, add the length + 1 (minimum length for space)
                // - If this word will overflow the line, finalise the current line and start a new one
                if (lineLen + word.Length + 1 <= len)
                {
                    lineWords.Add(word);
                    lineLen += word.Length + 1;
                }
                else
                {
                    // Find how many spaces are needed to reach the target length
                    var additionalSpaces = len - lineLen;

                    // If line is already at maximum length w/ 1-wide gaps, then just append this line as-is
                    // Otherwise, distribute the additional spaces across each space
                    if (additionalSpaces == 0)
                    {
                        lines.Add(string.Join(' ', lineWords));
                    }
                    else
                    {
                        var totalGaps = lineWords.Count - 1;
                        if (totalGaps == 0)
                        {
                            // No gaps = only one word
                            lines.Add(lineWords[0]);
                        }
                        else
                        {
                            // Determine how many spaces should be present between each word
                            // Example: 4 gaps, additional spaces = 7
                            // - target spaces = gaps + additional spaces = 11
                            // - Start with all gaps being floor(11 / 4) = 2 spaces wide
                            // - There are 11 - (2 * 4) = 3 spaces remaining
                            // - Distribute these remaining 3 spaces across the first three gaps
                            var targetSpaces = additionalSpaces + totalGaps;
                            var minimumSpaces = targetSpaces / totalGaps;
                            var totalLargeGaps = targetSpaces - (minimumSpaces * totalGaps);

                            var lineSb = new StringBuilder();
                            for (int i = 0; i < totalGaps; i++)
                            {
                                lineSb.Append(lineWords[i]);
                                var spaceRepeat = i < totalLargeGaps
                                    ? minimumSpaces + 1
                                    : minimumSpaces;

                                lineSb.Append(' ', spaceRepeat);
                            }

                            // Append last word w/out spaces
                            lineSb.Append(lineWords[totalGaps]);

                            // Finalise this line
                            lines.Add(lineSb.ToString());
                        }
                    }

                    // Then, start a new line
                    lineWords.Clear();
                    lineWords.Add(word);
                    lineLen = word.Length;
                }
            }

            // Append the final line if needed
            if (lineWords.Count > 0)
            {
                lines.Add(string.Join(' ', lineWords));
            }

            return string.Join('\n', lines);
        }
    }
}

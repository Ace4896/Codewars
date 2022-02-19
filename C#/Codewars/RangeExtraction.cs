// https://www.codewars.com/kata/51ba717bb08c1cd60f00002f/train/csharp

namespace Codewars
{
    using System.Collections.Generic;

    public class RangeExtraction
    {
        public static string Extract(int[] args)
        {
            var output = new List<string>(args.Length);
            for (int i = 0; i < args.Length; i++)
            {
                // If we can merge consecutive values into a range, see how many we can merge
                if (i + 2 < args.Length && args[i + 1] - args[i] == 1 && args[i + 2] - args[i + 1] == 1)
                {
                    var offset = 2;
                    while (i + offset + 1 < args.Length && args[i + offset + 1] - args[i + offset] == 1)
                    {
                        offset++;
                    }

                    output.Add($"{args[i]}-{args[i + offset]}");
                    i += offset;
                }
                else
                {
                    output.Add(args[i].ToString());
                }
            }

            return string.Join(",", output);
        }
    }
}

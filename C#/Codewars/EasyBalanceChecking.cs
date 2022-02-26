namespace Codewars
{
    using System;
    using System.Linq;
    using System.Text;

    public class EasyBal
    {
        // NOTE: Tests appear to have used double; using decimal means we're too precise...
        public static string Balance(string book)
        {
            var cleanedLines = book.Split('\n').Select(CleanLine);
            var balance = Convert.ToDouble(cleanedLines.First());
            var total = 0.0;
            var count = 0;

            var sb = new StringBuilder();
            sb.AppendFormat("Original Balance: {0:F2}\n", balance);

            foreach (var check in cleanedLines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(check))
                {
                    continue;
                }

                var checkDetails = check.Split(' ');
                var cost = Convert.ToDouble(checkDetails[2]);

                balance -= cost;
                total += cost;
                count += 1;

                sb.AppendFormat("{0} Balance {1:F2}\n", check, balance);
            }

            var average = total / count;
            sb.AppendFormat("Total expense  {0:F2}\n", total);
            sb.AppendFormat("Average expense  {0:F2}", average);

            return sb.ToString();
        }

        private static string CleanLine(string line)
        {
            var validCharsOnly = string.Concat(line.Where(c => char.IsLetterOrDigit(c) || c == '.' || c == ' '));
            return string.Join(' ', validCharsOnly.Split(' ').Where(c => c.Length > 0));
        }
    }
}

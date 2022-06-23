namespace Codewars
{
    using System;
    using System.Linq;

    public class CountIpAddresses
    {
        // NOTE: Use System.Net instead of this, I only did it this way for practice :P
        public static long IpsBetween(string start, string end)
        {
            byte[] startBytesLE = ParseLittleEndian(start);
            byte[] endBytesLE = ParseLittleEndian(end);

            long startOffset = CalculateOffset(startBytesLE);
            long endOffset = CalculateOffset(endBytesLE);

            return endOffset - startOffset;
        }

        private static byte[] ParseLittleEndian(string ip) =>
            ip.Split('.')
                .Select(s => Convert.ToByte(s))
                .Reverse()
                .ToArray();

        private static long CalculateOffset(byte[] bytesLE) =>
            bytesLE.Zip(Enumerable.Range(0, bytesLE.Length), (byte b, int power) => (long)Math.Pow(256L, power) * b)
                .Sum();
    }
}

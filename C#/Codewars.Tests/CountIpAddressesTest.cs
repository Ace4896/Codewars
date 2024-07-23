namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    public class CountIpAddressesTest
    {
        [Test]
        public void SampleTest()
        {
            ClassicAssert.AreEqual(50, CountIpAddresses.IpsBetween("10.0.0.0", "10.0.0.50"));
            ClassicAssert.AreEqual(246, CountIpAddresses.IpsBetween("20.0.0.10", "20.0.1.0"));
            ClassicAssert.AreEqual((1L << 32) - 1L, CountIpAddresses.IpsBetween("0.0.0.0", "255.255.255.255"));
        }
    }
}

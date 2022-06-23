namespace Codewars.Tests
{
    using NUnit.Framework;

    public class CountIpAddressesTest
    {
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual(50, CountIpAddresses.IpsBetween("10.0.0.0", "10.0.0.50"));
            Assert.AreEqual(246, CountIpAddresses.IpsBetween("20.0.0.10", "20.0.1.0"));
            Assert.AreEqual((1L << 32) - 1L, CountIpAddresses.IpsBetween("0.0.0.0", "255.255.255.255"));
        }
    }
}

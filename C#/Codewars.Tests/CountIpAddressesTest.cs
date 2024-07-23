namespace Codewars.Tests
{
    using NUnit.Framework;

    public class CountIpAddressesTest
    {
        [Test]
        public void SampleTest()
        {
            Assert.That(CountIpAddresses.IpsBetween("10.0.0.0", "10.0.0.50"), Is.EqualTo(50));
            Assert.That(CountIpAddresses.IpsBetween("20.0.0.10", "20.0.1.0"), Is.EqualTo(246));
            Assert.That(CountIpAddresses.IpsBetween("0.0.0.0", "255.255.255.255"), Is.EqualTo((1L << 32) - 1L));
        }
    }
}

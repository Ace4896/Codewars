namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class TcpFsmTest
    {
        [Test]
        public void SampleTests()
        {
            Assert.That(TCP.TraverseStates(["APP_ACTIVE_OPEN", "RCV_SYN_ACK", "RCV_FIN"]), Is.EqualTo("CLOSE_WAIT"));
            Assert.That(TCP.TraverseStates(["APP_PASSIVE_OPEN", "RCV_SYN", "RCV_ACK"]), Is.EqualTo("ESTABLISHED"));
            Assert.That(TCP.TraverseStates(["APP_ACTIVE_OPEN", "RCV_SYN_ACK", "RCV_FIN", "APP_CLOSE"]), Is.EqualTo("LAST_ACK"));
            Assert.That(TCP.TraverseStates(["APP_ACTIVE_OPEN"]), Is.EqualTo("SYN_SENT"));
            Assert.That(TCP.TraverseStates(["APP_PASSIVE_OPEN", "RCV_SYN", "RCV_ACK", "APP_CLOSE", "APP_SEND"]), Is.EqualTo("ERROR"));
        }
    }
}

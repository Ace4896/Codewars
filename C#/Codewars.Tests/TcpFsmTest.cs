namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class TcpFsmTest
    {
        [Test]
        public void SampleTests()
        {
            ClassicAssert.AreEqual("CLOSE_WAIT", TCP.TraverseStates(new[] { "APP_ACTIVE_OPEN", "RCV_SYN_ACK", "RCV_FIN" }));
            ClassicAssert.AreEqual("ESTABLISHED", TCP.TraverseStates(new[] { "APP_PASSIVE_OPEN", "RCV_SYN", "RCV_ACK" }));
            ClassicAssert.AreEqual("LAST_ACK", TCP.TraverseStates(new[] { "APP_ACTIVE_OPEN", "RCV_SYN_ACK", "RCV_FIN", "APP_CLOSE" }));
            ClassicAssert.AreEqual("SYN_SENT", TCP.TraverseStates(new[] { "APP_ACTIVE_OPEN" }));
            ClassicAssert.AreEqual("ERROR", TCP.TraverseStates(new[] { "APP_PASSIVE_OPEN", "RCV_SYN", "RCV_ACK", "APP_CLOSE", "APP_SEND" }));
        }
    }
}

namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class HumanReadableTimeTest
    {
        [Test]
        public void HumanReadableTest()
        {
            ClassicAssert.AreEqual("00:00:00", TimeFormat.GetReadableTime(0));
            ClassicAssert.AreEqual("00:00:05", TimeFormat.GetReadableTime(5));
            ClassicAssert.AreEqual("00:01:00", TimeFormat.GetReadableTime(60));
            ClassicAssert.AreEqual("23:59:59", TimeFormat.GetReadableTime(86399));
            ClassicAssert.AreEqual("99:59:59", TimeFormat.GetReadableTime(359999));
        }
    }
}

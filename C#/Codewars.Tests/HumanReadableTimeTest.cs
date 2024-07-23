namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class HumanReadableTimeTest
    {
        [Test]
        public void HumanReadableTest()
        {
            Assert.That(TimeFormat.GetReadableTime(0), Is.EqualTo("00:00:00"));
            Assert.That(TimeFormat.GetReadableTime(5), Is.EqualTo("00:00:05"));
            Assert.That(TimeFormat.GetReadableTime(60), Is.EqualTo("00:01:00"));
            Assert.That(TimeFormat.GetReadableTime(86399), Is.EqualTo("23:59:59"));
            Assert.That(TimeFormat.GetReadableTime(359999), Is.EqualTo("99:59:59"));
        }
    }
}

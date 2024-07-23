namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class AddingBigNumbersTest
    {
        [Test]
        public void ASimpleKataTest()
        {
            ClassicAssert.AreEqual("110", Kata.Add("91", "19"));
            ClassicAssert.AreEqual("1111111111", Kata.Add("123456789", "987654322"));
            ClassicAssert.AreEqual("1000000000", Kata.Add("999999999", "1"));
        }
    }
}

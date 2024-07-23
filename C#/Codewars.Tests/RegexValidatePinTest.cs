namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class RegexValidatePinTest
    {
        [Test, Description("ValidatePin should return false for pins with length other than 4 or 6")]
        public void LengthTest()
        {
            ClassicAssert.AreEqual(false, Kata.ValidatePin("1"), "Wrong output for \"1\"");
            ClassicAssert.AreEqual(false, Kata.ValidatePin("12"), "Wrong output for \"12\"");
            ClassicAssert.AreEqual(false, Kata.ValidatePin("123"), "Wrong output for \"123\"");
            ClassicAssert.AreEqual(false, Kata.ValidatePin("12345"), "Wrong output for \"12345\"");
            ClassicAssert.AreEqual(false, Kata.ValidatePin("1234567"), "Wrong output for \"1234567\"");
            ClassicAssert.AreEqual(false, Kata.ValidatePin("-1234"), "Wrong output for \"-1234\"");
            ClassicAssert.AreEqual(false, Kata.ValidatePin("1.234"), "Wrong output for \"1.234\"");
            ClassicAssert.AreEqual(false, Kata.ValidatePin("-1.234"), "Wrong output for \"-1.234\"");
            ClassicAssert.AreEqual(false, Kata.ValidatePin("00000000"), "Wrong output for \"00000000\"");
        }

        [Test, Description("ValidatePin should return false for pins which contain characters other than digits")]
        public void NonDigitTest()
        {
            ClassicAssert.AreEqual(false, Kata.ValidatePin("a234"), "Wrong output for \"a234\"");
            ClassicAssert.AreEqual(false, Kata.ValidatePin(".234"), "Wrong output for \".234\"");
        }

        [Test, Description("ValidatePin should return true for valid pins")]
        public void ValidTest()
        {
            ClassicAssert.AreEqual(true, Kata.ValidatePin("1234"), "Wrong output for \"1234\"");
            ClassicAssert.AreEqual(true, Kata.ValidatePin("0000"), "Wrong output for \"0000\"");
            ClassicAssert.AreEqual(true, Kata.ValidatePin("1111"), "Wrong output for \"1111\"");
            ClassicAssert.AreEqual(true, Kata.ValidatePin("123456"), "Wrong output for \"123456\"");
            ClassicAssert.AreEqual(true, Kata.ValidatePin("098765"), "Wrong output for \"098765\"");
            ClassicAssert.AreEqual(true, Kata.ValidatePin("000000"), "Wrong output for \"000000\"");
            ClassicAssert.AreEqual(true, Kata.ValidatePin("090909"), "Wrong output for \"090909\"");
        }

        [Test, Description("ValidatePin should return false in various edge cases")]
        public void EdgeTest()
        {
            ClassicAssert.AreEqual(false, Kata.ValidatePin("1234\n"), "Wrong output for \"1234\\n\"");
        }
    }
}

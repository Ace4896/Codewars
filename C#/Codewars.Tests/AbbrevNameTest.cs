namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class AbbrevNameTest
    {
        [Test]
        public void BasicTests()
        {
            ClassicAssert.AreEqual("S.H", Kata.AbbrevName("Sam Harris"));
            ClassicAssert.AreEqual("P.F", Kata.AbbrevName("Patrick Feenan"));
            ClassicAssert.AreEqual("E.C", Kata.AbbrevName("Evan Cole"));
            ClassicAssert.AreEqual("P.F", Kata.AbbrevName("P Favuzzi"));
            ClassicAssert.AreEqual("D.M", Kata.AbbrevName("David Mendieta"));
        }
    }
}
